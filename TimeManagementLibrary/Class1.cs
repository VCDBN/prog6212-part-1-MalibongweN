using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeManagementLibrary
{
    public class TimeManagementHelper
    {
        private List<Module> modules = new List<Module>();
        private int numberOfWeeks;
        private DateTime startDate;

        public List<Module> GetModules()
        {
            return modules;
        }

        public void AddModule(string code, string name, int credits, int classHoursPerWeek)
        {
            // Create a new Module instance and add it to the modules list
            modules.Add(new Module(code, name, credits, classHoursPerWeek));
        }

        public void SetSemesterInfo(int weeks, DateTime startDate)
        {
            // Set the semester information
            numberOfWeeks = weeks;
            this.startDate = startDate;
        }

        public List<ModuleSummary> CalculateModuleSummaries()
        {
            // Calculate the self-study hours per week based on module credits and weeks
            double selfStudyHoursPerWeek = modules.Select(m => (m.Credits * 10.0) / numberOfWeeks - m.ClassHoursPerWeek).FirstOrDefault();

            // Create module summaries for each module
            var moduleSummaries = modules.Select(m => new ModuleSummary
            {
                Code = m.Code,
                Name = m.Name,
                Credits = m.Credits,
                ClassHoursPerWeek = m.ClassHoursPerWeek,
                SelfStudyHoursPerWeek = selfStudyHoursPerWeek,
                RecordedHours = m.RecordedHours.Count(),
                RemainingHours = selfStudyHoursPerWeek - m.RecordedHours.Count()
            }).ToList();

            return moduleSummaries;
        }

        public class Module
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public int Credits { get; set; }
            public int ClassHoursPerWeek { get; set; }
            public List<RecordedHour> RecordedHours { get; set; } = new List<RecordedHour>();

            public Module(string code, string name, int credits, int classHoursPerWeek)
            {
                Code = code;
                Name = name;
                Credits = credits;
                ClassHoursPerWeek = classHoursPerWeek;
            }
        }

        public class RecordedHour
        {
            public DateTime Date { get; set; }
            public double Hours { get; set; }
        }

        public class ModuleSummary
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public int Credits { get; set; }
            public int ClassHoursPerWeek { get; set; }
            public double SelfStudyHoursPerWeek { get; set; }
            public int RecordedHours { get; set; }
            public double RemainingHours { get; set; }
        }
    }
}
