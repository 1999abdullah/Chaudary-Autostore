@ECHO OFF
ECHO Demo Automation Executed Started.


set testcategory=login
set dllpath=C:\Users\samiiabd\source\repos\1999abdullah\Chaudary-Autostore\Chaudary_Autostore\bin\Debug\Chaudary_Autostore.dll
set trxerpath=C:\Users\samiiabd\source\repos\1999abdullah\Chaudary-Autostore\Chaudary_Autostore\bin\Debug\
set SummaryReportPath=C:\Users\samiiabd\source\repos\1999abdullah\Chaudary-Autostore\Chaudary_Autostore\test_summery

FOR /f %%a IN ('WMIC OS GET LocalDateTime ^| FIND "."') DO SET DTS=%%a
SET filename=%testcategory%_%DTS:~0,4%%DTS:~4,2%%DTS:~6,2%%DTS:~8,2%%DTS:~10,2%%DTS:~12,2%
echo %filename%

call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"


VSTest.Console.exe  %dllpath% /TestCaseFilter:"TestCategory=%testcategory%" /Logger:"trx;LogFileName=%SummaryReportPath%\%filename%.trx"

cd %trxerpath%

TrxToHTML %SummaryReportPath%

PAUSE