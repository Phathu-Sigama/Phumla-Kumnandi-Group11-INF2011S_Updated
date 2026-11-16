# Phumla Kumnandi Hotel Booking System

A Windows desktop application for managing hotel room bookings, built as a second-year systems development project (INF2011S) by a group of four students (Group 11).

## What it does

The system has two roles, chosen on the start screen.

**Receptionist**
- Make a booking for a guest, with a check on room availability for the chosen dates
- Change, look up or cancel an existing booking
- View a booking confirmation

**Manager**
- Generate occupancy and revenue reports

Room prices depend on the season (low, mid or high), and each booking has a guest account for tracking payments and the outstanding balance.

## How it is built

- **Language and framework:** C# with Windows Forms on .NET Framework 4.8
- **Database:** SQL Server LocalDB, stored in `PhumlaKamnandiHotels.mdf`

The code is split into three layers:

| Folder | Layer | Contents |
| --- | --- | --- |
| `Presentation/` | User interface | The forms: start, home, booking, change, enquiry, cancellation, confirmation and reports |
| `Business/` | Business logic | Entity classes (`Booking`, `Guest`, `Room`, `Account` and others) and the controllers that work with them |
| `Data/` | Data access | Classes that read from and write to the database |

## Running it

The project only runs on Windows, because Windows Forms, .NET Framework 4.8 and LocalDB are not available on macOS or Linux.

1. Install Visual Studio with the **.NET desktop development** workload, which includes SQL Server Express LocalDB.
2. Open `Phumla Kumnandi Group11 INF2011S.sln`.
3. Press **F5** to build and run.

The database file is copied into the build output folder on every build, so data entered while running the app is reset the next time you build.

## About the project

This was coursework for a second-year systems development course, completed by a group of four. It is shared here as a record of that work.
