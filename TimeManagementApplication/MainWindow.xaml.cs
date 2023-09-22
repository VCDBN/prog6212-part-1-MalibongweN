using System;
using System.Linq;
using System.Windows;
using TimeManagementLibrary;

namespace TimeManagementApplication
{
    public partial class MainWindow : Window
    {
        private TimeManagementHelper timeManagementHelper = new TimeManagementHelper();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get user input and call library methods
                string code = CodeTextBox.Text;
                string name = NameTextBox.Text;
                int credits = int.Parse(CreditsTextBox.Text);
                int classHoursPerWeek = int.Parse(ClassHoursTextBox.Text);

                timeManagementHelper.AddModule(code, name, credits, classHoursPerWeek);

                int numberOfWeeks = int.Parse(WeeksTextBox.Text);
                DateTime startDate = StartDateDatePicker.SelectedDate ?? DateTime.Now;
                timeManagementHelper.SetSemesterInfo(numberOfWeeks, startDate);

                var moduleSummaries = timeManagementHelper.CalculateModuleSummaries();

                // Update UI with the module summaries
                ModuleListView.Items.Clear();

                foreach (var summary in moduleSummaries)
                {
                    ModuleListView.Items.Add(summary);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input. Please enter valid numeric values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SubmitHoursButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedCode = CodeTextBox.Text;
                double hoursWorked = double.Parse(HoursWorkedTextBox.Text);
                DateTime recordDate = RecordDateDatePicker.SelectedDate ?? DateTime.Now;

                var modulesList = timeManagementHelper.GetModules();

                var selectedModule = modulesList.FirstOrDefault(m => m.Code == selectedCode);

                if (selectedModule != null)
                {
                    var recordedHour = new TimeManagementHelper.RecordedHour { Date = recordDate, Hours = hoursWorked };
                    selectedModule.RecordedHours.Add(recordedHour);

                    var moduleSummaries = timeManagementHelper.CalculateModuleSummaries();

                    ModuleListView.Items.Clear();

                    foreach (var summary in moduleSummaries)
                    {
                        ModuleListView.Items.Add(summary);
                    }
                }
                else
                {
                    MessageBox.Show("Module not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input. Please enter valid numeric values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
