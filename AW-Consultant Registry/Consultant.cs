namespace AW_Consultant_Registry
{
    class Consultant
    {
        public string Name { get; }
        public string PhoneNumber { get; set; }

        public Consultant(string name)
        {
            Name = name;
            PhoneNumber = "Unknown";
        }

        public Consultant(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}