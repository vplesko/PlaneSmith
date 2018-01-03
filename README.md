# PlaneSmith

PlaneSmith is a level editor for 2D games. It allows you to define the different elements that appear in your game and to design all of its levels and sections.

A typical PlaneSmith project consists of a single dictionary and multiple levels. Dictionary is a collection of definitions - these are the types of elements that appear in your game. A Level is compromised of Objects - each object knows its definition and presents an actual instance of it within a Level. While there is complete support for grid-based levels, you aren't limited to grids and tiles and can place your objects freely at any 2D coordinates.

One of the main advantages of PlaneSmith is that it allows you to specify the format of the output of your levels. You are free to configure your output to be in the form of an XML or JSON, or a simple text file, or perhaps you want actual code that you'll paste in your project.

PlaneSmith is a .NET application written in C#. As a downloadable, open-source tool, you are free to use it in your own projects.

## How to use

You will find a working executable in the releases section. You must have .NET framework installed to be able to run it.

Aside from the executable, there are also two documents about how to use PlaneSmith. Make sure to at least go through Quick Guide and things will make a lot more sense.

You will also find example projects. You can open any of these inside PlaneSmith to better understand this tool.

## How to build

Contents of this repository are organized as a Visual Studio C# project. Once you clone it, you should be able to open the solution file with Visual Studio and compile it normally.

This project uses ScintillaNET for its text-editor components. All DLLs are included in the project.
