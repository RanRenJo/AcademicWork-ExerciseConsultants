using System.Text;

namespace AW_Consultant_Registry
{
    static class ConsultantManager
    {
        public static void AddConsultant(List<Consultant> consultants)
        {
            string? name;
            string? phone;

            Print.MessageToConsole("Please enter new consultant name: ", false);
            name = Console.ReadLine();
            Print.MessageToConsole("Please enter new consultant phone number: ", false);
            phone = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrWhiteSpace(phone))
                {
                    phone = "Unknown";
                }
                consultants.Add(new(name, phone));
                Print.MessageToConsole($"{name} added to the registry.");
            }
            else
            {
                Print.MessageToConsole("Cannot create new consultant without name.");
            }
        }

        public static void PrintRegistryToConsole(List<Consultant> consultants)
        {
            foreach (var consultant in consultants)
            {
                Print.ConsultantToConsole(consultant);
            }

            Print.MessageToConsole("");
        }

        public static void SaveToFile(List<Consultant> consultants)
        {
            string projectDir = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(@"\bin") + 1);
            string path = projectDir + @"consultants.txt";

            try
            {
                using (StreamWriter streamWriter = new(path, false, Encoding.Unicode))
                {
                    foreach (Consultant consultant in consultants)
                    {
                        streamWriter.WriteLine(Print.ConsultantToString(consultant));
                    }

                    Print.MessageToConsole("Consultants saved to file.");
                }
            }
            catch (Exception e)
            {
                Print.MessageToConsole(e.ToString());
            }
        }

        public static void LoadFromFile()
        {
            string projectDir = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(@"\bin") + 1);
            string path = projectDir + @"consultants.txt";

            using (StreamReader streamReader = new(path, Encoding.Unicode))
            {
                string? line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Print.MessageToConsole(line);
                }
            }
        }

        public static void ChangePhoneNumber(List<Consultant> consultants)
        {
            Consultant? consultantToChange = null;
            string? searchWord;
            string? newNumber;

            Print.MessageToConsole("Please enter full or partial consultant name: ", false);
            searchWord = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(searchWord))
            {
                foreach (var consultant in consultants)
                {
                    if (consultant.Name.ToLower().Contains(searchWord.ToLower()))
                    {
                        consultantToChange = consultant;
                    }
                }

                if (consultantToChange == null)
                {
                    Print.MessageToConsole("Search yielded no results.");
                }
            }
            else
            {
                Print.MessageToConsole("Search term must contain at least one character.");
            }

            if (consultantToChange != null)
            {
                Print.MessageToConsole($"{consultantToChange.Name} found. Enter new phone number, or null to exit: ", false);
                newNumber = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newNumber))
                {
                    Print.MessageToConsole($"{consultantToChange.Name}'s phone number successfully changed.");
                    consultantToChange.PhoneNumber = newNumber;
                    Print.ConsultantToConsole(consultantToChange);
                    Print.MessageToConsole("");
                }
                else
                {
                    Print.MessageToConsole("Invalid phone number input.");
                }
            }
        }

        public static void StopClear()
        {
            Print.MessageToConsole("Press any key to clear console and return to menu.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}