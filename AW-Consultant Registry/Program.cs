using System.Reflection.Metadata;

namespace AW_Consultant_Registry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var consultants = CreateRegistry();
            UserInterface.RunMenu(consultants);
        }

        public static List<Consultant> CreateRegistry()
        {
            List<Consultant> consultants = new()
            {
            new("Terry Pratchett"),
            new("Neil Gaiman", "10051990"),
            new("Douglas Adams", "42424242")
            };

            return consultants;
        }
    }
}