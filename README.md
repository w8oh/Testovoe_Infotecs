# Documentation

## For what?
This project was made as a test task for the internship at Infotecs. 

## What does it do?
This project is a simple worker service that allows you to copy files from one directory to another and do subsequent archiving in the destination folder. 

## How to use it?
1. Download the project.
2. Open the project in Visual Studio.
3. Build the project.
4. Open the project folder in the file explorer.
5. Open the bin folder.
6. Open the Debug folder.
7. Open the net7.0 folder.
8. Create the Settings.json file according to the model.
9. Run the CopyAppWorker.exe file.
10. Enjoy!

## Settings.json model
```json
{
  "PathFrom": "C:\\Users\\User\\Desktop\\Source",
  "PathTo": "C:\\Users\\User\\Desktop\\Destination",
  "FileTypes": [
    ".txt",
    ".docx",
    ".doc",
    ".pdf",
    ".png",
    ".jpg",
    ".jpeg",
    ".gif",
    ".bmp",
    ".tiff",
    ".tif",
    ".zip",
    ".rar",
    ".7z"
  ],
  "LogTypes": ["Info", "Debug", "Error"]
}
```
## About Logs

Logs are written to the Logs folder in the project folder. The name of the log file is the date and time of the start of the program. The log file contains information about the start of the program, the start of the copy process, the end of the copy process, the start of the archiving process, the end of the archiving process, and the end of the program.
