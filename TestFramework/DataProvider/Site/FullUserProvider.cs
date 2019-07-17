using System;

namespace TestFramework.DataProvider
{
    public class FullUserProvider :UserProvider
    {
        public string FirstName { get; } = "Test_First_Name";
        public string LastName { get; } = "Test_Last_Name";
        public string ConfirmEmail { get; }
        public string CountryOfResidence { get; } = "804";
        public string CityOfResidence { get; } = "Kiev";
        public string Cell { get; }
        public string ConfirmPassword { get; } = "12345633_AA";
        public string SecretQuestion { get; } = "ПИН код (4 знака)";
        public string SecretAnswer { get; } = "1111";

        //TODO Remove Random to separate method
        public FullUserProvider() //: base(5)
        {
            ConfirmEmail = Email;
            Random rnd = new Random();
            int num = rnd.Next(1000000, 9999999);
            Cell = $"+38000{num}";
        }

    }
}