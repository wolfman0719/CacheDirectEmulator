# .Net class mimics Cache Direct(VisM.OCX) interface for IRIS

Implemented the VisM.OCX interface for .Net Applications using IRIS .Net Native API .


## How to use

### IRIS Server 

The version used is IRIS for Windows (x86-64) 2020.1 (Build 215U) Mon Mar 30 2020 20:14:33 EDT.

In 2019.3 it will crash with a null pointer error.

### IRIS Server side class definition

Importing CacheDirect.Emulator.cls into the appropriate namespace.
(The sample console application assumes that the namespace is USER)

### Load C# Project file into Visual Studio

Load C_SharpConsoleApplication.csproj file into Visual Studio.

The version I used is as follows.

Microsoft Visual Studio Community 2019
Version 16.6.0

### reference setting

Choose Add Reference from the project settings in Visual Studio and add the following files.

<InstallDIr>\InterSystems\IRIS\dev\dotnet\bin\v4.0.30319

InterSystems.Data.IRISClient.dll

InterSystems.Data.Gateway64.exe

### Build

Click Build C_SharpConsoleApplication from the Visual Studio build menu.

Make sure there are no errors in the output window.

If you get an error, there's something wrong with the reference settings being not working properly.

### run

1. From the Visual Studio debug menu, click Start Debugging.
2. you need to press any key to finish the sample application
3. you can see the program output in the Visual Studio output window

### for VB.Net

Module1.vb is a samle VB.Net code to use the emulator.

to run the sample

1. create a c# class library project
2. add cacheDirectWapper.cs to the project
3. add references to InterSystems.Data.Gateway64.exe and InterSystems.Data.IRISClient.dll
4. build the project
4. create a VB.Net console application project
5. add Module1.vb to the project
6. add a refernce to the class library dll 

## Unsupported features

### Unsupported Property

ConnectionState

ConTag

ElapsedTime

ErrorTrap

KeepAliveInterval

KeepAliveTimeOut

LogMask

MServer

MsgText

NameSpace

PromptInterval

Server

Tag

TimeOut

### Unsupported Method

DeleteConnection

SetMServer

SetServer

Shutdown Event

### Unsupported Additinal features

ErrorTrapping

The Keep Alive Feature

Server Read Loop and Quick Check

Read and Write Hooks

Other Server Side Hooks

User Cancel Option

### Visual Basic Specific functions

It does not support any features specific to Visual Basic in the Cache Direct features as follows:.

Callback function, MessageBox, DoEvents, etc.

