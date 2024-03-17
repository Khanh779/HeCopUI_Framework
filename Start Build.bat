call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"
Msbuild.exe "D:\Data\Tailieu\Projects\C#\HeCop_UI\HeCop_UI.sln"
copy "D:\Data\Tailieu\Projects\C#\HeCop_UI\HeCopUI_Framework\bin\Debug\HeCopUI_Framework.dll" "C:\C:\Lib\HecopUI_Framework\HeCopUI_Framework.dll"
pause