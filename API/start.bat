@echo off
title API server
echo ---------------------- START (%DATE:~0,2%.%DATE:~3,2% %TIME:~0,8%) ----------------------
venv\Scripts\uvicorn.exe main:app --log-level critical --reload
echo ---------------------- STOP  (%DATE:~0,2%.%DATE:~3,2% %TIME:~0,8%) ----------------------
pause