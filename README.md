# 🗓️ Appointment Management Software

This is a **C# Windows Forms (WinForms)** application designed to manage appointments. It provides functionality to schedule, modify, and view appointments, track customer details, and ensure that appointments do not overlap. The application is ideal for businesses that need to keep track of appointments, manage their scheduling, and ensure an organized workflow.

---

## 🧩 Features

- **Schedule Appointments**: Create new appointments with customer and time details.
- **Modify Appointments**: Edit or update existing appointments.
- **View Appointments**: View all scheduled appointments in a table.
- **Appointment Overlap Check**: Ensure appointments do not overlap with existing ones.
- **Filter Appointments**: Filter appointments by day, week, or month.
- **Search Customers by ID**: Easily search for customers by their unique ID.
- **Customer Information**: Store and display customer details associated with appointments.
- **Timezone Support**: Manage appointments in different time zones.
- **Data Persistence**: Appointments data stored in a database for long-term use.
---

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET (WinForms)
- **Database:** MYSQL
- **IDE:** Visual Studio
- **UI:** Windows Forms controls

---

## 🗂️ Project Structure

/AppointmentManagementSoftware
├── AddAppointments.cs             # Form to add new appointments
├── AddCustomer.cs                # Form to add new customers
├── LoginScreen.cs                # Form for user login
├── Main.cs                       # Main form displaying appointments
├── Reports.cs                    # Form for generating reports
├── UpdateAppointments.cs         # Form to update appointments
├── UpdateCustomerRecords.cs      # Form to update customer records

├── Models/                       # Business logic classes
│   ├── Customer.cs               # Customer model
│   └── Directory.cs              # Directory model

├── DataAccess/                   # Database interaction classes
│   └── AppointmentRepository.cs  # Repository for managing appointment data

├── Tests/                        # Unit tests
│   └── IsFormValidTest_Customers.cs # Unit test for customer form validation

├── Program.cs                    # Entry point (`Main()` method)

├── AppointmentManagementSoftware.csproj
├── AppointmentManagementSoftware.sln
├── README.md

---

## 🚀 Getting Started

### Prerequisites

- Windows OS
- Visual Studio 2019 or later
- .NET Framework installed
- SQL Server / SQLite for database storage

### Running the Application

1. Clone the repository:
    ```bash
    git clone https://github.com/Craig-Joiner/AppointmentManagementSoftware.git
    ```

2. Open the `.sln` file in Visual Studio.

3. Build the project:
    - Go to `Build > Build Solution` or press `Ctrl+Shift+B`

4. Run the application:
    - Press `F5` or click the green Run button

---

## 🧠 How It Works

- **Main Form:** Displays a table of all upcoming appointments with options to add, modify, or delete.
- **Add/Modify Appointment:** Allows creation or updating of appointments, with validation to prevent overlap.
- **Search Feature:** Use the search bar to search for customers by their unique ID. The customer details are fetched from the database and displayed in the results.
- **Customer Information:** Customers are associated with appointments to track their details.
- **Appointment Repository:** Interacts with the database to store and retrieve appointments.
- **Filtering:** Appointments can be filtered by day, week, or month for easy viewing.
---

## 👨‍💻 Author

**Craig Joiner**  
[GitHub Profile](https://github.com/Craig-Joiner)
