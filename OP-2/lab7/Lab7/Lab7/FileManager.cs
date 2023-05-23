namespace Lab7;

internal class FileManager
{
    public void GenerateFile(string fileName, string[] text)
    {
        using (StreamWriter streamWriter = new StreamWriter(fileName, false))
        {
            foreach (string line in text)
            {
                streamWriter.WriteLine(line);
            }
        }
    }

    public void PrintFromFile(string fileName)
    {
        using (StreamReader streamReader = new StreamReader(fileName))
        {
            Console.WriteLine($"\nFile name is {fileName}");
            Console.WriteLine(streamReader.ReadToEnd());
        }
    }
}
