@ECHO OFF

SET TargetPath=%~1
SET SvcName=SautomServerWcfHost

SETLOCAL ENABLEDELAYEDEXPANSION

ECHO STOP SERVICE:
net start %SvcName%

REM ECHO UNISTALL:
REM installutil %TargetPath%