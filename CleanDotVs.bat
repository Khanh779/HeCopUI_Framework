@echo off
echo. Deleting ...
Del /s /q /f ./.vs
Del /s /q /f ./*/.vs
Del /s /q /f ./*/obj
pause