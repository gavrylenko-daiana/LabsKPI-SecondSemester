namespace Lab7;

public class ConsoleManager
{
    public void PrintInfoForUser() //вивести інформацію для вводу користувачу
    {
        Console.WriteLine("Enter your text:\t" +
                          "(Please, press \"Ctrl + E\" to end entering text)");
    }

    public string[] WorkWithConsoleText() //отримати текст від користувача
    {
        List<string> text = new List<string>(); // створення нового об’єкта класу List<string>
        bool continueEntering = true;
        string str = "";

        void AddNewString() // додавання значення до списку та очищення рядку
        {
            if (str != "")
            {
                text.Add(str);
                str = "";
            }
        }

        while (continueEntering)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(); 

            switch (keyInfo.Key)
            {
                case ConsoleKey.E when keyInfo.Modifiers == ConsoleModifiers.Control:
                    AddNewString();
                    Console.Write(' ');
                    continueEntering = false;
                    break;
                case ConsoleKey.Enter:
                    AddNewString();
                    Console.CursorTop++; // позиція курсору у консолі перейде на наступний рядок у тому самому стовпці
                    break;
                case ConsoleKey.Backspace:
                    str = str.Substring(0, str.Length - 1); 
                    Console.Write(' ');
                    Console.CursorLeft--; // позиція курсору у консолі перейде на один символ ліворуч у тому самому рядку
                    break;
                default:
                    str += keyInfo.KeyChar;
                    break;
            }
        }

        return text.ToArray();
    }
}