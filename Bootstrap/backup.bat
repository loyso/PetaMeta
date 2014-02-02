@echo off
xcopy /Y /E /I /R MetaMetadata .\Backup\MetaMetadata
copy /Y *.cs .\Backup\
