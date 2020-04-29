# Dime.Messaging

![Build status](https://dev.azure.com/dimenicsbe/Utilities/_apis/build/status/Dime.Messaging?branchName=master)

## Introduction

Extensions to the System.Messaging namespace.

## Getting Started

- You must have Visual Studio 2019 Community or higher.
- The dotnet cli is also highly recommended.

## About this project

The most notable types in this assembly include:

- `MsmqInstaller`: creates MSMQ queues

## Build and Test

- Run dotnet restore
- Run dotnet build
- Run dotnet test

## Installation

Use the package manager NuGet to install Dime.Messaging:

`dotnet add package Dime.Messaging`

## Usage

``` csharp
using System.Messaging;

public void Main(params string[] args)
{
    IMsmqInstaller msmqInstaller = new MsmqInstaller();
    msmqInstaller.Install("myApp_newItems", "myApp_updatedItems").Wait();
}
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)