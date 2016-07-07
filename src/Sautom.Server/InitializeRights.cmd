del %TEMP%\DailyTemp.txt
whoami > %TEMP%\DailyTemp.txt
SET /p CurrentUser=<%TEMP%\DailyTemp.txt

netsh http add urlacl url=http://+:8000/SautomServices user=%CurrentUser%