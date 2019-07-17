using System.Collections.Generic;
using NUnit.Framework;
using TestFramework.DataProvider.BackOffice;

namespace TestFramework.DataProvider.TestData
{
    public static class RegistrationTestData
    {
        public  static IEnumerable<TestCaseData> GetUserData()
        {
            yield return new TestCaseData(new UserProvider()); 
        }

        public static IEnumerable<TestCaseData> GetFullUserData()
        {
            yield return new TestCaseData(new FullUserProvider());
        }

        public static IEnumerable<TestCaseData> GetFullBackOfficeLoginData()
        {
            yield return new TestCaseData(new LoginProviderBackOffice());
        }
    }
}