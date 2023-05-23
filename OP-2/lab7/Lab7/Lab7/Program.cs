using System;
using System.IO;
using System.Linq;

namespace Lab7;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath = "input.txt";
            string outputFilePath = "output.txt";

            FileManager fileManager = new FileManager();
            ConsoleManager consoleManager = new ConsoleManager();
            
            consoleManager.PrintInfoForUser();
            
            string[] consoleText = consoleManager.WorkWithConsoleText(); // Отримання тексту від користувача
            
            fileManager.GenerateFile(inputFilePath, consoleText); // Запис тексту у вхідний файл

            TextFile textFile = new TextFile(inputFilePath);

            // Видалення розділових знаків та запис до нового файлу
            textFile.RemovePunctuationAndWriteToNewFile(outputFilePath);

            fileManager.PrintFromFile(inputFilePath);
            fileManager.PrintFromFile(outputFilePath);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

/*
Hello, vcds;sodk . dmis, idj,q vijd!
Some 1, text-dsds,"dicosp" - (isaojas)
sl;dc wmqk  dps[sdf] /'punctuation'a
 */