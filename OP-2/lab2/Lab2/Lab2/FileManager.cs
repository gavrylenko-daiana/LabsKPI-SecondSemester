using System.Text;

namespace Lab2;

public class FileManager
{
    public void CreateFile(string pathToFile, List<Applicant> applicants) // Створення файлу з інформацією про заявників
    {
        using (StreamWriter sw = new StreamWriter(pathToFile))
        {
            foreach (Applicant applicant in applicants)
            {
                sw.WriteLine($"{applicant.FullName} {applicant.DateOfBirth.ToString("dd.MM.yyyy")} {applicant.Gender}");
            }
        }
    }
    
    public void CreateFileWithMale(string pathToGetFile, List<Applicant> applicants) // Створення нового файлу з інформацією про кандидатів чоловічої статі призовного віку (від 18 до 27 років)
    {
        using (StreamWriter sw = new StreamWriter(pathToGetFile))
        {
            ApplicantManager applicantManager = new ApplicantManager();
            IEnumerable<Applicant> maleApplicants = applicantManager.CheckingMenOfMilitaryAge(applicants); // Отримання списку кандидатів чоловічої статі призовного віку
            
            foreach (Applicant applicant in maleApplicants)
            {
                sw.WriteLine($"{applicant.FullName} {applicant.DateOfBirth.ToString("dd.MM.yyyy")} {applicant.Gender}");
            }
        }
    }
    
    public void PrintFromFile(string fileName) // Виведення тексту з файлу на консоль
    {
        StreamReader streamReader = new StreamReader(fileName);
        Console.WriteLine($"\nFile name is {fileName}");
        Console.WriteLine(streamReader.ReadToEnd());
        streamReader.Close();
    }
}