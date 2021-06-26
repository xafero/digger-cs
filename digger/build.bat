@echo off

del *.7z

dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true --self-contained true Digger.GtkSharp
7z a -t7z -mx9 linux-x64.7z ./Digger.GtkSharp/bin/Release/netcoreapp3.1/linux-x64/publish/Digger.GtkSharp

dotnet publish -c Release -r win-x64   -p:PublishSingleFile=true --self-contained true Digger.GtkSharp
7z a -t7z -mx9 wing-x64.7z  ./Digger.GtkSharp/bin/Release/netcoreapp3.1/win-x64/publish/Digger.GtkSharp.exe

dotnet publish -c Release -r win-x64   -p:PublishSingleFile=true --self-contained true Digger.WinForms
7z a -t7z -mx9 winf-x64.7z  ./Digger.WinForms/bin/Release/netcoreapp3.1/win-x64/publish/Digger.WinForms.exe

dotnet publish -c Release -r win-x64   -p:PublishSingleFile=true --self-contained true Digger.Wpf
7z a -t7z -mx9 winp-x64.7z  ./Digger.Wpf/bin/Release/netcoreapp3.1/win-x64/publish/Digger.Wpf.exe

