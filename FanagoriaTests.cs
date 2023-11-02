using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Fanagoria
{
    public class FanagoriaTests
    {
        private WebDriver driver;
        


        [SetUp]
        public void Setup()
        {

            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        [TearDown]

        public void Teardown() 
        { 
            this.driver.Quit();
        
        }

        [Test]
        public void Test_SignUpInvalidAccount()
        {
            driver.Url = "https://fanagoriatravel.com/";

            var signUpLink = driver.FindElement(By.XPath("//a[contains(@title,'Signup')]"));
            signUpLink.Click(); 

            var userNameField = driver.FindElement(By.Id("username"));
            userNameField.SendKeys("nikita@abv.bg");  

            var passField = driver.FindElement(By.Id("password"));
            passField.SendKeys("bibibi");

            var loginButton = driver.FindElement(By.Name("login"));
            loginButton.Click();

            var errorMessage = driver.FindElement(By.CssSelector("body > div.layout-content > div.container.layout-container.margin-top.margin-bottom > div > main > div > div > " +
                "div.woocommerce-notices-wrapper > ul > li > i"));

            Assert.That(errorMessage.Text, Is.Not.Null);

        }

        [Test]
        public void Test_SignUpInvalidAccountAlt()
        {
            driver.Url = "https://fanagoriatravel.com/";

            var signUpLink = driver.FindElement(By.XPath("//a[contains(@title,'Signup')]"));
            signUpLink.Click();

            var userNameField = driver.FindElement(By.Id("username"));
            userNameField.SendKeys("nikita@abv.bg");

            var passField = driver.FindElement(By.Id("password"));
            passField.SendKeys("bibibi");

            var loginButton = driver.FindElement(By.Name("login"));
            loginButton.Click();

            var pageSource = driver.PageSource;
            Assert.True(pageSource.Contains("Непознат имейл адрес. Проверете отново или опитайте с потребителско име."));

            

        }

        [Test]
        public void Test_FindExcursion()
        {
            driver.Url = "https://fanagoriatravel.com/";

            var searchButton = driver.FindElement(By.ClassName("popup-search-form"));
            searchButton.Click();

            var inputFieldSearch = driver.FindElement(By.ClassName("search-field"));
            inputFieldSearch.SendKeys("Париж");

            var buttonSearchOk = driver.FindElement(By.ClassName("search-submit"));
            buttonSearchOk.Click();

            var parisLink = driver.FindElement(By.ClassName("atlist__item__title"));

            Assert.That(parisLink.Text, Is.EqualTo("Париж – градът на вечната любов"));


        }
    }
}