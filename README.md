# DepuradorBin

[![.NET](https://github.com/erickorlando/depuradorbin/actions/workflows/dotnet.yml/badge.svg)](https://github.com/erickorlando/depuradorbin/actions/workflows/dotnet.yml)

## SPANISH

Esta utilidad te permite borrar los archivos binarios de cualquier solucion de .NET, solo debes especificar la carpeta donde se encuentra la Solucion.

Construido con .NET 6

## ENGLISH

This utility allows you to delete the binary files of any .NET solution, you just have to specfied the folder where the solution is located.

Built with .NET 6

### How to use

**If you use the source code:**

First check if you are under the solution folder.
If you need to see documentation:

`dotnet run --project .\RemoveBinaries\ -- --help`

Deleting binaries from a directory:

`dotnet run --project .\RemoveBinaries\ -- --path {pathLocation}`

**If you use the terminal (cmd, PowerShell, Windows Terminal, etc.) from the compiled binaries:**

* To see documentation.
`.\RemoveBinaries.exe --help`

* To delete binaries from directory
`.\RemoveBinaries.exe --path {pathLocation}`

Note: If your path have blank spaces, you should mark it with quotes.

## Authored by
Erick Orlando © 2022
