# Time Management Application

## Overview

This is a standalone desktop time management application built using C# and Windows Presentation Foundation (WPF). It allows users to manage their semester modules, track study hours, and calculate the required self-study hours for each module based on the specified parameters.

## Features

### 1. Adding Modules

You can add multiple modules for the semester, each with the following details:
- Code (e.g., PROG6212)
- Name (e.g., Programming 2B)
- Number of credits (e.g., 15)
- Class hours per week (e.g., 5)

### 2. Semester Information

Specify the number of weeks in the semester and the start date for the first week.

### 3. Self-Study Hour Calculation

The application calculates and displays the number of hours of self-study required for each module per week using the formula:

```
self-study hours per week = (number of credits × 10) / (number of weeks − class hours per week)
```

### 4. Recording Study Hours

You can record the number of hours spent working on a specific module on a specific date.

### 5. Remaining Self-Study Hours

The application dynamically calculates and displays the remaining self-study hours for each module for the current week. It considers the number of hours already recorded for each module on specific dates during the current week.

### 6. Data Persistence

Please note that the software does not persist user data between runs. Data is stored in memory only while the software is running.

## Getting Started

1. Clone or download this repository to your local machine.

2. Open the solution in Visual Studio.

3. Build and run the application.

## Usage

1. Add modules by providing their details in the "Module Information" section.

2. Specify the number of weeks and the start date for the semester in the "Semester Information" section.

3. The application will calculate and display the self-study hours required for each module.

4. Record study hours using the "Record Hours" section.

5. View the remaining self-study hours for each module in the list.

## Contributing

Contributions to this project are welcome. You can fork the repository, make improvements, and create a pull request.

## License

This project is licensed under the IIE Varsity College-ST10083947 license.

## Acknowledgments

This application was developed as a project for educational purposes. It was created to demonstrate the implementation of time management features using C# and WPF.

---

© The Independent Institute of Education (Pty) Ltd 2023
