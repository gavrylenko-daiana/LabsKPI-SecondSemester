namespace Lab1;

internal class FileManager
{
    public void GenerateFile(string fileName, string[] text) // створення і заповнення файлу
    {
        StreamWriter streamWriter = new StreamWriter(fileName, append: false); // Параметр append: false вказує, що файл буде перезаписаний, а не дописаний
 
        foreach (string line in text)
        {
            streamWriter.WriteLine(line);
        }

        streamWriter.Close();
    }

    public string ReadAllFromFile(string fileName) // зчитування тексту з файлу
    {
        StreamReader streamReader = new StreamReader(fileName);
        string text = streamReader.ReadToEnd();
        
        streamReader.Close(); 
        
        return text;
    }

    public void PrintFromFile(string fileName) // виведення тексту з файлу
    {
        StreamReader streamReader = new StreamReader(fileName);
        
        Console.WriteLine($"\nFile name is {fileName}");
        Console.WriteLine(streamReader.ReadToEnd());
        
        streamReader.Close();
    }
}