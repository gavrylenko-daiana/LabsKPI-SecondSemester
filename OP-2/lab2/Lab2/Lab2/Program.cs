namespace Lab2;

class Program
{
    static void Main(string[] args)
    {
        List<Applicant> applicants = new List<Applicant>();
        FileManager fileManager = new FileManager(); 
        ApplicantManager applicantManager = new ApplicantManager(); 
        
        // Імена файлів для збереження даних
        const string firstFileName = "set_file";
        const string secondFileName = "get_file";
        
        applicantManager.FillFileFromConsole(applicants); // Заповнення списку заявників даними з консолі
        fileManager.CreateFile(firstFileName, applicants); // Створення файлу з інформацією про заявників
        fileManager.PrintFromFile(firstFileName);
        
        applicantManager.RemoveApplicant(applicants); // Видалення кандидатів старше 35 років зі списку
        fileManager.CreateFileWithMale(secondFileName, applicants); // Створення нового файлу
        fileManager.PrintFromFile(secondFileName);
    }
}

/*
Valeri Shyshmakova, 12.09.2002, Female
Oleksandr Shut, 17.11.2006, Male
Denys Shpak, 02.01.1999, Male
Artem Protsenko, 20.03.1972, Male
Milena Tsymbal, 20.03.2012, Female
Nikita Melnychenko, 19.09.1996, Male
Yaroslav Ivanov, 30.04.2005, Male
Oleg Bilan, 30.05.2005, Male
*/
