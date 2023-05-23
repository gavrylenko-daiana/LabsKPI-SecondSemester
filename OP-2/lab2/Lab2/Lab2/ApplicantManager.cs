namespace Lab2;

public class ApplicantManager
{
    public void FillFileFromConsole(List<Applicant> applicants) // Заповнити файл інформацією з консолі
    {
        Console.WriteLine(
            "Enter applicant information (Full Name, Date of Birth (DD.MM.YYYY), Gender (Male/Female)). Enter 'exit' to finish.");
        
        while (true) // Цикл для зчитування даних з консолі
        {
            string input = Console.ReadLine()!;
            
            if (input.ToLower() == "exit")
            {
                break;
            }

            string[] parts = input.Split(',');
            
            if (parts.Length != 3) // Перевірка на правильність введених даних
            {
                Console.WriteLine(
                    "Invalid input. Please enter Full Name, Date of Birth (DD.MM.YYYY), Gender (Male/Female).");
                continue;
            }
            
            string fullName = parts[0].Trim(); // Отримання повного імені заявника
            
            // Отримання дати народження заявника
            if (!DateTime.TryParseExact(parts[1].Trim(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None,
                    out DateTime dateOfBirth))
            {
                Console.WriteLine("Invalid date of birth. Please enter in format DD.MM.YYYY.");
                continue;
            }

            // Отримання статі заявника
            if (!Enum.TryParse(parts[2].Trim(), true, out Gender gender))
            {
                Console.WriteLine("Invalid gender. Please enter Male or Female.");
                continue;
            }
            
            applicants.Add(new Applicant { FullName = fullName, DateOfBirth = dateOfBirth, Gender = gender });
        }
    }

    public void RemoveApplicant(List<Applicant> applicants) // Видалити кандидатів старше 35 років
    {
        applicants.RemoveAll(a => (DateTime.Now.Year - a.DateOfBirth.Year) > 35);
    }

    public IEnumerable<Applicant> CheckingMenOfMilitaryAge(List<Applicant> applicants) // Перевірка юнаків призовного віку
    {
        IEnumerable<Applicant> maleApplicants = applicants.Where(a =>
            a.Gender == Gender.Male &&
            ((DateTime.Now.Year - a.DateOfBirth.Year) > 18 ||
             ((DateTime.Now.Year - a.DateOfBirth.Year) == 18 &&
              (DateTime.Now.Month > a.DateOfBirth.Month ||
               (DateTime.Now.Month == a.DateOfBirth.Month && DateTime.Now.Day >= a.DateOfBirth.Day)))) &&
            ((DateTime.Now.Year - a.DateOfBirth.Year) < 27 ||
             ((DateTime.Now.Year - a.DateOfBirth.Year) == 27 &&
              (DateTime.Now.Month < a.DateOfBirth.Month ||
               (DateTime.Now.Month == a.DateOfBirth.Month && DateTime.Now.Day < a.DateOfBirth.Day)))));

        return maleApplicants;
    }
}