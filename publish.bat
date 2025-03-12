@echo off
echo Publishing Win11 Tweaker...
cd Win11 Tweaker
dotnet publish -c Release -r win-x64 --self-contained true
echo Publish complete!
pause
