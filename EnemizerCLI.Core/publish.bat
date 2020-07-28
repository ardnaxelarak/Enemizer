@echo off
setlocal
  set MSBUILDSINGLELOADCONTEXT=1
  dotnet publish --framework netcoreapp2.0 -c Release --self-contained --runtime win-x64 -p:PublishTrimmed=true
  dotnet publish --framework netcoreapp2.0 -c Release --self-contained --runtime osx.10.12-x64 -p:PublishTrimmed=true
  dotnet publish --framework netcoreapp2.0 -c Release --self-contained --runtime ubuntu.16.04-x64 -p:PublishTrimmed=true
endlocal