@echo off
setlocal
  PATH="C:\Program Files\7-Zip";%PATH%
  set MSBUILDSINGLELOADCONTEXT=1
  
  set FRAMEWORK=netcoreapp3.1
  set RELEASEBUILD=Release
  
  set WINDOWSVERSION=win-x64
  set MACVERSION=osx.10.12-x64
  set LINUXVERSION=ubuntu.16.04-x64
  
  dotnet publish --framework %FRAMEWORK% -c %RELEASEBUILD% --self-contained --runtime %WINDOWSVERSION% -p:PublishTrimmed=true
  dotnet publish --framework %FRAMEWORK% -c %RELEASEBUILD% --self-contained --runtime %MACVERSION% -p:PublishTrimmed=true
  dotnet publish --framework %FRAMEWORK% -c %RELEASEBUILD% --self-contained --runtime %LINUXVERSION% -p:PublishTrimmed=true
  
  7z a .\bin\%RELEASEBUILD%\%WINDOWSVERSION%.7z .\bin\%RELEASEBUILD%\%FRAMEWORK%\%WINDOWSVERSION%\publish\*
  7z a .\bin\%RELEASEBUILD%\%MACVERSION%.7z .\bin\%RELEASEBUILD%\%FRAMEWORK%\%MACVERSION%\publish\*
  7z a .\bin\%RELEASEBUILD%\%LINUXVERSION%.7z .\bin\%RELEASEBUILD%\%FRAMEWORK%\%LINUXVERSION%\publish\*
  7z a -tzip .\bin\%RELEASEBUILD%\%WINDOWSVERSION%.zip .\bin\%RELEASEBUILD%\%FRAMEWORK%\%WINDOWSVERSION%\publish\*
  7z a -tzip .\bin\%RELEASEBUILD%\%MACVERSION%.zip .\bin\%RELEASEBUILD%\%FRAMEWORK%\%MACVERSION%\publish\*
  7z a -tzip .\bin\%RELEASEBUILD%\%LINUXVERSION%.zip .\bin\%RELEASEBUILD%\%FRAMEWORK%\%LINUXVERSION%\publish\*
  
  pause
endlocal