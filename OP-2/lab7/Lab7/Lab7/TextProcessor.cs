namespace Lab7;

public class TextProcessor
{
    public string RemovePunctuation(string text) // Видаляємо всі розділові знаки з тексту
    {
        char[] punctuation = text.Where(char.IsPunctuation).ToArray();
        string[] words = text.Split(punctuation);
        return string.Join(" ", words);
    }
}
