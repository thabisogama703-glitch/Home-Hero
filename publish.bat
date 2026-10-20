@echo off
REM ------------------------------------------------------------------
REM  Builds a ready-to-run HomeHero.exe that works on ANY Windows 10/11
REM  64-bit laptop - no .NET install needed on the other computer.
REM  Needs the .NET 8 SDK on THIS computer only.
REM  Output: publish\HomeHero.exe  (send that one file to your group)
REM ------------------------------------------------------------------
cd /d "%~dp0"
dotnet publish "Home Hero.csproj" -c Release -r win-x64 --self-contained true ^
  -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true ^
  -p:EnableCompressionInSingleFile=true -o publish
if errorlevel 1 (
  echo.
  echo BUILD FAILED - read the errors above.
  pause
  exit /b 1
)
echo.
echo Done. Your app is in the "publish" folder: publish\HomeHero.exe
pause
