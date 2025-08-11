# C# Course Projects

Welcome to my C# course projects repository! This README provides an overview of the five main projects I completed as part of my university Object-Oriented Programming course in .NET framework using C#. Each project demonstrates different aspects of C# programming, from basic console applications to advanced object-oriented design and Windows Forms development.

## Table of Contents
- [Project Overview](#project-overview)
- [Project 1: Basic Programming & Assembly Analysis](#project-1-basic-programming--assembly-analysis)
- [Project 2: Bulls & Cows Console Game](#project-2-bulls--cows-console-game)
- [Project 3: Garage Management System](#project-3-garage-management-system)
- [Project 4: Interfaces, Delegates & Menu System](#project-4-interfaces-delegates--menu-system)
- [Project 5: Bulls & Cows Windows Application](#project-5-bulls--cows-windows-application)
- [Screenshots](#screenshots)
- [Technologies Used](#technologies-used)
- [How to Run](#how-to-run)
- [Course Objectives](#course-objectives)

## Project Overview

This repository contains five progressive projects that showcase the evolution from basic C# programming concepts to complex object-oriented applications:

1. **Assembly Analysis & Basic Programming** - Introduction to .NET assemblies and fundamental C# concepts
2. **Bulls & Cows Console Game** - Object-oriented console game with external DLL usage
3. **Garage Management System** - Complex inheritance hierarchy with polymorphism and collections
4. **Menu System with Interfaces & Delegates** - Advanced OOP concepts and design patterns
5. **Windows Forms Bulls & Cows** - GUI application development

## Project 1: Basic Programming & Assembly Analysis

### Part A: Assembly Detective Work
**Objectives:**
- Understanding .NET Framework fundamentals (PE, Assembly, MSIL, Metadata)
- Working with the `ildasm` tool for assembly analysis
- Learning about managed code advantages and disadvantages

**Tasks:**
- Analyzed a provided .NET executable using `ildasm`
- Identified assembly structure, dependencies, and MSIL code
- Reverse-engineered username/password from assembly metadata

### Part B: Programming Fundamentals
**Objectives:**
- Developing .NET applications using Visual Studio
- Mastering C# syntax and console I/O
- Working with fundamental classes (string, int, float, char, Math, StringBuilder)

**Implemented Programs:**
1. **Binary Series Analyzer** - Converts 4 binary numbers (7 digits each) to decimal with statistics
2. **Number Tree (Beginner)** - Prints a fixed number tree pattern using recursion
3. **Dynamic Number Tree** - User-configurable tree height with input validation
4. **String Parser** - Analyzes 12-character strings for palindromes, divisibility, and alphabetical order
5. **Number Statistics** - Provides comprehensive statistics for 8-digit numbers

**Key Features:**
- Input validation for all user inputs
- Comprehensive error handling
- Statistical analysis algorithms
- Recursive implementation options

*[Screenshots Placeholder - Part 1]*

## Project 2: Bulls & Cows Console Game

**Objectives:**
- Implementing object-oriented programming principles
- Working with arrays and collection classes
- Using external DLL libraries
- Separation of UI and business logic

**Game Description:**
Classic Bulls & Cows guessing game where:
- Computer selects a 4-letter sequence from A-H (unique letters)
- Player guesses the sequence receiving feedback:
  - **Bull (V)**: Correct letter in correct position
  - **Cow (X)**: Correct letter in wrong position
- Configurable number of attempts (4-10)
- Option to quit anytime by pressing 'Q'

**Technical Implementation:**
- **UI Layer**: Console interface for user interaction
- **Business Logic**: Game mechanics and validation
- **External Dependencies**: ConsoleUtils DLL for screen clearing
- **Input Validation**: Comprehensive error checking for all user inputs

**Key Features:**
- Clean separation between UI and game logic
- Robust input validation system
- Reusable business logic for future GUI implementation
- Professional console interface with clear feedback

*[Screenshots Placeholder - Part 2]*

## Project 3: Garage Management System

**Objectives:**
- Advanced object-oriented programming with inheritance and polymorphism
- Working with collections and enums
- Multi-project solution architecture
- Exception handling implementation

**System Overview:**
Comprehensive garage management system supporting five vehicle types:
- **Regular Motorcycle**: Octan98 fuel, 6.2L tank, 2 wheels
- **Electric Motorcycle**: 3.2-hour battery, 2 wheels  
- **Regular Car**: Octan95 fuel, 48L tank, 5 wheels
- **Electric Car**: 4.8-hour battery, 5 wheels
- **Truck**: Soler fuel, 135L tank, 12 wheels

**Architecture:**
- **Ex03.GarageLogic**: Core business logic DLL containing object model
- **Ex03.ConsoleUI**: Console application providing user interface
- **Clean separation**: Business logic independent of UI implementation

**Vehicle Properties:**
- Model name, license number, remaining energy percentage
- Wheel collection with manufacturer, current/max air pressure
- Type-specific properties (license type, color, door count, cargo details)

**Fuel vs Electric Systems:**
- **Fuel Vehicles**: Fuel type, current/max capacity, refueling operations
- **Electric Vehicles**: Battery hours, charging operations

**Management Features:**
1. Load vehicle data from file (Vehicles.db)
2. Add new vehicles to garage
3. Display vehicles with status filtering
4. Update vehicle status (In Repair → Fixed → Paid)
5. Inflate tires to maximum pressure
6. Refuel vehicles with fuel type validation
7. Charge electric vehicles
8. Display comprehensive vehicle information

**Advanced OOP Concepts:**
- Inheritance hierarchy with abstract base classes
- Polymorphism for vehicle operations
- Interface implementation for energy sources
- Custom exception handling (ValueRangeException)
- Factory pattern for vehicle creation
- Enum usage for vehicle properties

*[Screenshots Placeholder - Part 3]*

## Project 4: Interfaces, Delegates & Menu System

**Objectives:**
- Implementing interfaces and delegates
- Advanced polymorphism techniques
- Creating reusable hierarchical menu systems
- Action<T> delegate usage

**System Description:**
Developed a reusable menu component for console applications supporting:
- Hierarchical menu structure with unlimited nesting
- Dynamic menu item addition and navigation
- Action execution for leaf menu items
- Automatic Back/Exit option handling

**Implementation Approaches:**
Created two separate implementations demonstrating different techniques:

### Ex04.Menus.Interfaces
- Interface-based communication between menu system and client code
- Clean contract definition for menu item actions
- Demonstrates interface implementation patterns

### Ex04.Menus.Events  
- Delegate and event-based architecture
- Action<T> delegate usage for menu callbacks
- Modern C# event handling patterns

### Ex04.Menus.Test
Console application demonstrating both menu systems with identical functionality:

**Menu Structure:**
```
Main Menu
├── Version and Letters
│   ├── Show Version (displays: App Version: 25.2.4.4480)
│   └── Count Lowercase Letters (interactive letter counting)
└── Show Current Date/Time
    ├── Show Current Date
    └── Show Current Time
```

**Key Features:**
- Automatic menu numbering and navigation
- Input validation and error handling
- Screen clearing between menu transitions
- Graceful exit handling
- Reusable across different applications

*[Screenshots Placeholder - Part 4]*

## Project 5: Bulls & Cows Windows Application

**Objectives:**
- Windows Forms application development
- Event-driven programming with controls
- GUI design and user experience
- Extending existing console application to Windows

**Application Features:**

### Initial Setup
- Configurable number of guesses (4-10) via counter button
- Clean, intuitive Windows Forms interface

### Game Board
- **Top Row**: 4 black buttons showing computer's hidden sequence (revealed at game end)
- **Guess Rows**: Configurable number of rows for player guesses
- **Color Selection**: 8-color palette window for choosing guess colors
- **Submit Arrows**: Enable only when 4 colors are selected
- **Result Display**: Bulls (black) and Cows (yellow) feedback buttons

### Interactive Gameplay
- Click empty buttons to open color selection dialog
- Choose from 8 available colors (no duplicates allowed)
- Submit guess when all 4 positions filled
- Visual feedback with color-coded results
- Progressive row activation (one row at a time)

### Game States
- **Victory**: Immediate feedback with correct sequence display
- **Defeat**: Hidden sequence revealed after all attempts used
- **New Game**: Option to restart with new configuration

**Technical Implementation:**
- Event-driven Windows Forms architecture
- Dynamic control generation based on user settings
- State management for game progression
- User-friendly color selection interface
- Professional UI design with clear visual feedback

*[Screenshots Placeholder - Part 5]*

## Screenshots

### Project 2: Bulls & Cows Console Game  
<img width="535" height="528" alt="image" src="https://github.com/user-attachments/assets/bfa561fb-f1c6-4009-bade-612854bb40fc" />
<img width="414" height="547" alt="image" src="https://github.com/user-attachments/assets/28b13bce-c0a6-444c-9086-89382530219d" />


### Project 3: Garage Management System
<img width="1671" height="1042" alt="image" src="https://github.com/user-attachments/assets/460150c5-df83-4fe5-b6b4-66e4fa8fa00b" />

### Project 5: Windows Bulls & Cows
<img width="235" height="141" alt="image" src="https://github.com/user-attachments/assets/6022e2c3-aa8a-47b7-a49e-f1385634bf13" />
<img width="380" height="677" alt="image" src="https://github.com/user-attachments/assets/351d6d93-2375-4d56-8f42-ec921b6b7835" />
<img width="381" height="677" alt="image" src="https://github.com/user-attachments/assets/cd416b3f-6c83-4e34-a1bd-2421e18daeb3" />

## Technologies Used

- **Framework**: .NET Framework
- **Language**: C# 
- **IDE**: Microsoft Visual Studio
- **UI Technologies**: 
  - Console Applications
  - Windows Forms
- **Key Concepts**:
  - Object-Oriented Programming (OOP)
  - Inheritance and Polymorphism
  - Interfaces and Abstract Classes
  - Delegates and Events
  - Collections (List<T>, Dictionary<K,V>)
  - Exception Handling
  - File I/O Operations
  - Assembly Analysis

## How to Run

### Prerequisites
- Visual Studio (2019 or later recommended)
- .NET Framework 4.7.2 or higher

### Running the Projects

#### Projects 1-4 (Console Applications):
1. Open the solution file (.sln) in Visual Studio
2. Set the desired project as startup project
3. Build the solution (Ctrl + Shift + B)
4. Run the application (F5 or Ctrl + F5)

#### Project 5 (Windows Application):
1. Open Ex05.BullsAndCows.sln in Visual Studio
2. Ensure Windows Forms dependencies are installed
3. Build and run the application
4. Follow the GUI prompts to configure and play the game

### Project Dependencies
- **Project 2**: Requires Ex02.ConsoleUtils.dll (provided)
- **Project 3**: Multi-project solution with internal references
- **Project 4**: Multi-project solution demonstrating both interface and delegate patterns

## Course Objectives

This course progression demonstrates mastery of:

### Fundamental Concepts
- .NET Framework architecture and assembly structure
- C# syntax, data types, and control structures
- Console I/O and basic user interaction
- Input validation and error handling

### Object-Oriented Programming
- Class design and encapsulation
- Inheritance hierarchies and polymorphism
- Abstract classes and interface implementation
- Access modifiers and property usage

### Advanced Topics
- Collections and generic types
- Exception handling and custom exceptions
- Delegates, events, and functional programming concepts
- Multi-project solutions and DLL creation
- Windows Forms development and event-driven programming

### Software Engineering Practices
- Separation of concerns (UI vs Business Logic)
- Code reusability and modularity
- Clean architecture principles
- Professional documentation and code organization

---

**Course**: Object-Oriented Programming in .NET Framework with C#  
**Institution**: [Your University Name]  
**Semester**: [Semester/Year]

*This repository represents a comprehensive journey through C# and .NET development, showcasing progression from basic programming concepts to advanced object-oriented design and Windows application development.*
