# C# Course Projects

Welcome to my C# course projects repository! This README provides an overview of the five main projects I completed as part of my university Object-Oriented Programming course in .NET framework using C#. Each project demonstrates different aspects of C# programming, from basic console applications to advanced object-oriented design and Windows Forms development.

## Table of Contents
- [Project Overview](#project-overview)
- [Project 1: Basic Programming & Assembly Analysis](#project-1-basic-programming--assembly-analysis)
- [Project 2: Bulls & Cows Console Game](#project-2-bulls--cows-console-game)
- [Project 3: Garage Management System](#project-3-garage-management-system)
- [Project 4: Interfaces, Delegates & Menu System](#project-4-interfaces-delegates--menu-system)
- [Project 5: Bulls & Cows Windows Application](#project-5-bulls--cows-windows-application)
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
- Understanding .NET Framework fundamentals (PE, Assembly, MSIL, Metadata)
- Working with the `ildasm` tool for assembly analysis
- Reverse-engineered username/password from assembly metadata

### Part B: Programming Fundamentals
**Implemented Programs:**
1. **Binary Series Analyzer** - Converts 4 binary numbers (7 digits each) to decimal with statistics
2. **Number Tree** - Prints number tree patterns with recursion
3. **String Parser** - Analyzes 12-character strings for palindromes, divisibility, and alphabetical order
4. **Number Statistics** - Provides comprehensive statistics for 8-digit numbers

**Key Features:**
- Input validation and comprehensive error handling
- Statistical analysis algorithms
- Working with fundamental classes (string, Math, StringBuilder)

## Project 2: Bulls & Cows Console Game

**Game Description:**
Classic Bulls & Cows guessing game where the computer selects a 4-letter sequence from A-H, and the player guesses with feedback:
- **Bull (V)**: Correct letter in correct position
- **Cow (X)**: Correct letter in wrong position

**Technical Implementation:**
- Object-oriented programming principles
- Clean separation between UI and business logic
- External DLL usage (ConsoleUtils)
- Configurable number of attempts (4-10)

#### Game Screenshots
<div align="center">
<img width="500" alt="Bulls & Cows - Initial Setup" src="https://github.com/user-attachments/assets/bfa561fb-f1c6-4009-bade-612854bb40fc" />
</div>

<div align="center">
<img width="450" alt="Bulls & Cows - Gameplay" src="https://github.com/user-attachments/assets/28b13bce-c0a6-444c-9086-89382530219d" />
</div>

## Project 3: Garage Management System

**System Overview:**
Comprehensive garage management system supporting five vehicle types with inheritance hierarchy:
- **Motorcycles** (Regular/Electric): 2 wheels, fuel/battery systems
- **Cars** (Regular/Electric): 5 wheels, color and door properties
- **Trucks**: 12 wheels, cargo handling capabilities

**Architecture:**
- **Ex03.GarageLogic**: Core business logic DLL
- **Ex03.ConsoleUI**: Console interface
- Clean separation of concerns

**Key Features:**
- Advanced OOP with inheritance and polymorphism
- Vehicle management (add, update status, refuel/charge)
- File I/O operations and custom exception handling
- Factory pattern for vehicle creation

#### System Interface
<div align="center">
<img width="800" alt="Garage Management System" src="https://github.com/user-attachments/assets/460150c5-df83-4fe5-b6b4-66e4fa8fa00b" />
</div>

## Project 4: Interfaces, Delegates & Menu System

**System Description:**
Reusable hierarchical menu component for console applications with two implementation approaches:

### Implementation Approaches:
- **Ex04.Menus.Interfaces**: Interface-based communication
- **Ex04.Menus.Events**: Delegate and event-based architecture
- **Ex04.Menus.Test**: Demo application with both systems

**Menu Structure:**
```
Main Menu
├── Version and Letters
│   ├── Show Version
│   └── Count Lowercase Letters
└── Show Current Date/Time
    ├── Show Current Date
    └── Show Current Time
```

**Key Features:**
- Unlimited menu nesting
- Automatic navigation and input validation
- Action<T> delegate usage
- Reusable across applications

## Project 5: Bulls & Cows Windows Application

**Application Features:**
Windows Forms version of the Bulls & Cows game with enhanced GUI experience:

- **Game Configuration**: Adjustable number of guesses (4-10)
- **Interactive Color Selection**: 8-color palette with no duplicates
- **Visual Feedback**: Bulls (black) and Cows (yellow) result indicators
- **Progressive Gameplay**: Row-by-row activation system

**Technical Implementation:**
- Event-driven Windows Forms architecture
- Dynamic control generation
- State management for game progression

#### Windows Application Screenshots

**Game Setup:**
<div align="center">
<img width="280" alt="Game Setup Window" src="https://github.com/user-attachments/assets/6022e2c3-aa8a-47b7-a49e-f1385634bf13" />
</div>

**Game Interface & Color Selection:**
<div align="center">
<img width="350" alt="Game Board" src="https://github.com/user-attachments/assets/351d6d93-2375-4d56-8f42-ec921b6b7835" />
<img width="350" alt="Color Selection" src="https://github.com/user-attachments/assets/cd416b3f-6c83-4e34-a1bd-2421e18daeb3" />
</div>

## Technologies Used

- **Framework**: .NET Framework
- **Language**: C# 
- **IDE**: Microsoft Visual Studio
- **UI Technologies**: Console Applications, Windows Forms
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
2. Build and run the application
3. Follow the GUI prompts to configure and play the game

### Project Dependencies
- **Project 2**: Requires Ex02.ConsoleUtils.dll (provided)
- **Project 3**: Multi-project solution with internal references
- **Project 4**: Multi-project solution demonstrating both interface and delegate patterns

## Course Objectives

This course progression demonstrates mastery of:

### Fundamental Concepts
- .NET Framework architecture and assembly structure
- C# syntax, data types, and control structures
- Input validation and error handling

### Object-Oriented Programming
- Class design and encapsulation
- Inheritance hierarchies and polymorphism
- Abstract classes and interface implementation

### Advanced Topics
- Collections and generic types
- Exception handling and custom exceptions
- Delegates, events, and functional programming concepts
- Multi-project solutions and DLL creation
- Windows Forms development

### Software Engineering Practices
- Separation of concerns (UI vs Business Logic)
- Code reusability and modularity
- Clean architecture principles
  
