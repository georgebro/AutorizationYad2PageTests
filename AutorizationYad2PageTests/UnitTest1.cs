using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutorizationYad2PageTests
{
    public class Tests
    {
        private const string _login = "***********";
        private const string _password = "*******";
        private const string _expectedLogIn = "GB";

        private IWebDriver driver;
        private readonly By _signInButton = By.XPath("//a[@title='אזור אישי']");
        private readonly By _loginInputButton = By.XPath("//input[@class='direction-ltr']");
        private readonly By _passwordInputButton = By.XPath("//input[@type='password']");
        private readonly By _enetrButton = By.XPath("//button[@type='submit']");
        private readonly By _loginName = By.XPath("//li[@class='no_sub_menu private_zone desktop_only']");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("C:\\Users\\George.b\\source\\tools");
            driver.Navigate().GoToUrl("https://www.yad2.co.il/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();

            var login = driver.FindElement(_loginInputButton);
            login.SendKeys(_login);

            var password = driver.FindElement(_passwordInputButton);
            password.SendKeys(_password);

            var enter = driver.FindElement(_enetrButton);
            enter.Click();

            Thread.Sleep(5000);
            var _actualLogIn = driver.FindElement(_loginName).Text;
            Assert.AreEqual(_expectedLogIn,_actualLogIn,"LogIn_is_Wrong_Or_Enter_Wasn't_Completed!");
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
