# .Net class mimics Cache Direct(VisM.OCX) interface for IRIS

日本語でのREADMEは、README-Japanese.mdを参照してください。

Implemented the VisM.OCX interface for .Net Applications using IRIS .Net Native API .


## How to use

### IRIS Server 

IRIS for Windows (x86-64) 2022.2 (Build 368U) Fri Oct 21 2022 16:43:20 EDT or later can work.

Native API for .Net Framework (4.x) has not been included from 2024.2.

### IRIS Server side class definition

Importing CacheDirect.Emulator.cls into the appropriate namespace.

(The sample console application assumes that the namespace is USER)

### Create C# Project file in Visual Studio

#### .Net Framework(4.x)

Create a Console C# application project in Visual Studio 2019.

The version I used is as follows.

Microsoft Visual Studio Community 2019
Version 16.11.15

Add the following files to the project

- net4/cacheDirectWapper.cs
- ConsoleApp/ConsoleApp.cs

Delete Program.cs

#### .Net 6.0 or later

When building with Visual Studio 2022, add the following files

- net60later/cacheDirectWapper.cs
- ConsoleApp/ConsoleApp.cs

### reference setting

#### for Visual Studio 2019

Choose Add Reference from the project settings in Visual Studio and add the following files.

```
<InstallDir>\InterSystems\IRIS\dev\dotnet\bin\v4.6.2

InterSystems.Data.IRISClient.dll
```

#### For Visual Studio 2022

```
<InstallDir>\InterSystems\IRIS\dev\dotnet\bin\net8.0

InterSystems.Data.IRISClient.dll
```
  
### Build

Click Build from the Visual Studio build menu.

Make sure there are no errors in the output window.

If you get an error, there's something wrong with the reference settings being not working properly.

### run

1. From the Visual Studio debug menu, click Start Debugging.
2. you need to press any key to finish the sample application
3. you can see the program output in the Visual Studio output window

### for VB.Net

VB/Module1.vb is a samle VB.Net code to use the emulator.

to run the sample

1. create a c# class library project
2. add cacheDirectWapper.cs to the project
3. add references to InterSystems.Data.IRISClient.dll
4. build the project
4. create a VB.Net console application project
5. add VB/Module1.vb to the project
6. add references to InterSystems.Data.IRISClient.dll
6. add refernce to the class library dll 

## Unsupported features

### Unsupported Property

- ConnectionState
- ConTag
- ElapsedTime
- ErrorTrap
- KeepAliveInterval
- KeepAliveTimeOut
- LogMask
- MServer
- MsgText
- PromptInterval
- Server
- Tag

### Unsupported Method

- DeleteConnection
- SetMServer
- SetServer
- Shutdown Event

### Unsupported Additinal features

- ErrorTrapping
- The Keep Alive Feature
- Server Read Loop and Quick Check
- Read and Write Hooks
- Other Server Side Hooks
- User Cancel Option

### Visual Basic Specific functions

It does not support any features specific to Visual Basic in the Cache Direct features as follows:.

- Callback function
- MessageBox
- DoEvents, etc.

## Constructors

2 Constructors are defined

cacheDirectWapper(string constr)

cacheDirectWapper(IRISConnection irisconn)

## Using Multiple Namespaces

If you need to switch namespaces within your application, you must import CacheDirect.Emulator class into each namespace or do package mapping.
