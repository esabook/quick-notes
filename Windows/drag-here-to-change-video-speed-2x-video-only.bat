@echo off
for %%a in (%*.*) do ffmpeg -i "%%a" -filter:v "setpts=0.5*PTS" "%%a.mp4"
