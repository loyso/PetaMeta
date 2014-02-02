@echo off
xcopy /Y /E /I /R MetaMetadata ..\Bootstrap\MetaMetadata
copy /Y *.cs ..\Bootstrap
MSBuild ..\Bootstrap\Bootstrap.csproj /p:Configuration=Debug /p:Platform=AnyCPU /p:OutputPath=..\Bin\Debug\
MSBuild ..\Bootstrap\Bootstrap.csproj /p:Configuration=Release /p:Platform=AnyCPU /p:OutputPath=..\Bin\Release\
