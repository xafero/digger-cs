@echo off

dotnet build -f net8.0-windows10.0.19041.0 -r win10-x86 -c Debug Digger.WinUI

dotnet run -f net8.0-windows10.0.19041.0 -r win10-x86 -c Debug --project Digger.WinUI

