using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab1;

internal static class Program
{
    static void Main(string[] args)
    {
        // створення екземплярів класів
        FileManager fileManager = new FileManager();
        TaskManager taskManager = new TaskManager();
        ConsoleManager consoleManager = new ConsoleManager();
        
        // створення констант, що містять імена текстових файлів
        const string firstNameOfFile = "set_file";
        const string secondNameOfFile = "get_file";

        consoleManager.PrintInfoForUser();
        string[] textFromUser = consoleManager.WorkWithConsoleText();

        fileManager.GenerateFile(firstNameOfFile, textFromUser);
        string textFromFirstFile = fileManager.ReadAllFromFile(firstNameOfFile);

        fileManager.GenerateFile(secondNameOfFile,
            taskManager.DefineLongestInText(taskManager.SplitToNewLines(textFromFirstFile)));
        fileManager.PrintFromFile(firstNameOfFile);
        fileManager.PrintFromFile(secondNameOfFile);
    }
}


/*
SAoinc aokcmp,iwnn .w ixmio1dsicoopi ;smom scsaaw! dmpsvmw,x.opcjsopvawn d,s;lv.awom dscknsvisdonio
dnicosn wiojaoic aksmckl,as aiscmnian, sdcmapo;ac asmcaos
*/