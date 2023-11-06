namespace AW_Consultant_Registry
{
    static class Print
    {
        public static void ConsultantToConsole(Consultant consultant) {
            Console.WriteLine($"\t-----------------------------------------------" +
                $"\n\tName: {consultant.Name}\tPhoneNumber: {consultant.PhoneNumber}");
        }

        public static string ConsultantToString(Consultant consultant)
        {
            return $"\t-----------------------------------------------" +
                $"\n\tName: {consultant.Name}\tPhoneNumber: {consultant.PhoneNumber}";
        }

        public static void MessageToConsole(string message, bool newLine = true)
        {
            if (newLine)
            {
                Console.WriteLine("\t" + message);
            }
            else
            {
                Console.Write("\t" + message);
            }
        }
    }
}