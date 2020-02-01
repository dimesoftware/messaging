# Dime.System

[![Build Status](https://dev.azure.com/dimenicsbe/Utilities/_apis/build/status/System%20-%20MASTER%20-%20CI?branchName=master)](https://dev.azure.com/dimenicsbe/Utilities/_build/latest?definitionId=84&branchName=master)

## Introduction

Extensions to the System namespace.

## Getting Started

- You must have Visual Studio 2019 Community or higher.
- The dotnet cli is also highly recommended.

## About this project

The most notable types in this assembly include:

- `Ensure`: a handy and lightweight validation class.

## Build and Test

- Run dotnet restore
- Run dotnet build
- Run dotnet test

## Installation

Use the package manager NuGet to install Dime.System:

`dotnet add package Dime.System`

## Usage

``` csharp
using System;

public void MyMethod(MyClass myClassParameter)
{
    Ensure.Argument.NotNull(myClassParameter, nameof(myClassParameter), "Parameter cannot be null");
}
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

MIT