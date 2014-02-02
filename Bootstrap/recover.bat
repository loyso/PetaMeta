@echo off
mkdir MetaMetadata
xcopy /Y /E /I /R .\Backup\MetaMetadata MetaMetadata
copy /Y .\Backup\*.cs .\
MSBuild Bootstrap.csproj /p:Configuration=Debug
MSBuild Bootstrap.csproj /p:Configuration=Release
