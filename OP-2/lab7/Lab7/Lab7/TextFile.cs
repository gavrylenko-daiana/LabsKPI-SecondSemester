namespace Lab7;

public class TextFile
{
    private readonly string _filePath;

    public TextFile(string filePath)
    {
        _filePath = filePath;
    }

    public void RemovePunctuationAndWriteToNewFile(string newFilePath)
    {
        TextProcessor textProcessor = new TextProcessor();
        
        ValidateFile();

        string text = File.ReadAllText(_filePath);
        string newText = textProcessor.RemovePunctuation(text);
        File.WriteAllText(newFilePath, newText);
    }

    private void ValidateFile()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException("Вхідний файл не знайдено.");
        }

        string text = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(text))
        {
            throw new Exception("Вхідний файл порожній.");
        }
    }
}