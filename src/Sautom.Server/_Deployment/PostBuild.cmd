@ECHO OFF

SET TargetPath=%~1
SET SvcName=WCFWindowsHostService

SETLOCAL ENABLEDELAYEDEXPANSION

ECHO STOP SERVICE:
net start %SvcName%

REM ECHO UNISTALL:
REM installutil %TargetPath%