namespace AW_Consultant_Registry
{
    static class UserInterface
    {
        public static void RunMenu(List<Consultant> consultants)
        {
            string? choice = string.Empty;
            Print.MessageToConsole("Welcome to the AW-Consultant Registry!\n");

            while (true)
            {
                Print.MessageToConsole("\n\t*** MENU ***\n" +
                    "\n\t1. Exit program" +
                    "\n\t2. Add consultant to list" +
                    "\n\t3. Write list to console" +
                    "\n\t4. Empty the list" +
                    "\n\t5. Save list to file" +
                    "\n\t6. Load list from file and print to console" +
                    "\n\t7. Change consultant phone number\n");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    break;
                }
                else if (choice == "2")
                {
                    ConsultantManager.AddConsultant(consultants);
                }
                else if (choice == "3")
                {
                    ConsultantManager.PrintRegistryToConsole(consultants);
                }
                else if (choice == "4")
                {
                    consultants.Clear();
                    Print.MessageToConsole("List of consultants has been cleared.");
                }
                else if (choice == "5")
                {
                    ConsultantManager.SaveToFile(consultants);
                }
                else if (choice == "6")
                {
                    ConsultantManager.LoadFromFile();
                }
                else if (choice == "7")
                {
                    ConsultantManager.ChangePhoneNumber(consultants);
                }

                ConsultantManager.StopClear();
            }
        }
    }
}