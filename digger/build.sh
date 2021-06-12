#!/bin/sh

rm *.7z

dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained true
7z a -t7z -mx9 linux-x64.7z ./Digger.Classic/bin/Debug/netcoreapp3.1/linux-x64/publish/Digger.Classic

dotnet publish -r win-x64   -p:PublishSingleFile=true --self-contained true
7z a -t7z -mx9 win-x64.7z   ./Digger.Classic/bin/Debug/netcoreapp3.1/win-x64/publish/Digger.Classic.exe

