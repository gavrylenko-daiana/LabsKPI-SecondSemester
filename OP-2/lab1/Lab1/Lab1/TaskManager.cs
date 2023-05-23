namespace Lab1;

internal class TaskManager
{
    public string[] SplitToNewLines(string str) //розбивання речення по рядочкам
    {
        str = str.Replace(".", ".\n").Replace("!", "!\n").Replace("?", "?\n");
        string[] sentences = str.Split('\n', StringSplitOptions.RemoveEmptyEntries); // розбиття рядка на масив підрядків за символом нового рядка та видалення порожніх елементів
        
        return sentences;
    }
    
    public string FindShortestInString(string str) //знайти найкоротше слово, після речення поставити довжину цього слова та саме слово
    {
        str = str.Trim();
        string[] words = str.Split(new char[] {' ', ',', '.', ';'}, StringSplitOptions.RemoveEmptyEntries);
        string minWord = words.First();
        int lenOfMinWord = minWord.Length;

        foreach (string word in words) // знаходження найкоротшого слова
        {
            if (word.Length < lenOfMinWord)
            {
                minWord = word;
                lenOfMinWord = word.Length;
            }
        }

        return $"{str} {lenOfMinWord}-{minWord}";
    }

    public string[] DefineLongestInText(string[] text) //виконати завдання для всіх рядків
    {
        string[] resultText = new string[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            resultText[i] = FindShortestInString(text[i]);
        }

        return resultText;
    }
}