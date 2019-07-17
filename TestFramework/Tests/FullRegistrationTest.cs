using NUnit.Framework;
using TestFramework.DataProvider;
using TestFramework.DataProvider.TestData;
using TestFramework.Pages;

namespace TestFramework.Tests
{
    public class FullRegistrationTest : BaseUITest
    {
        private FullRegistrationPage _registrationPage;
        private SuccessRegistrationPage _successRegistrationPage;

        [SetUp]
        public void BeforeTest()
        {
            _registrationPage = new FullRegistrationPage();
            _successRegistrationPage = new SuccessRegistrationPage();
        }

        [TestCaseSource(typeof(RegistrationTestData), nameof(RegistrationTestData.GetFullUserData))]
        public void Register(FullUserProvider userData)
        {
            _registrationPage
                .InsertFirstName(userData.FirstName)
                .InsertLastName(userData.LastName)
                .SelectBirthDay(userData.Year, userData.Month, userData.Day)
                .InsertEmail(userData.Email)
                .ConfirmEmail(userData.ConfirmEmail)
                .ContryOfResidence(userData.CountryOfResidence)
                .CityOfResidence(userData.CityOfResidence)
                .Cell(userData.Cell)                
                .SelectCurrency(userData.Currency)
                .SelectQuestion(userData.SecretQuestion)
                .SecretAnswer(userData.SecretAnswer)
                .InsertPassword(userData.Password)
                .ConfirmPassword(userData.ConfirmPassword)
                .ConfirmAge()
                .SubmitRegistration();

            Assert.AreEqual($"{userData.FirstName} {userData.LastName}", _successRegistrationPage .GetRegistredUserName());
        }
    }
}