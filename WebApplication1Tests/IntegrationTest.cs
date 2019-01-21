using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Moq;

namespace UnitTestProject1
{
    /// <summary>
    /// Сводное описание для IntegrationTest
    /// </summary>
    [TestClass]
    public class IntegrationTest
    {
        public IWebDriver driver = new ChromeDriver(@"C:\Users\Катя\Documents\7sem\WebApplication1Tests\bin\Debug");
        
        /// <summary>
        /// Ссылка работает
        /// </summary>
        [TestMethod]
        public void TestUrl()
        {
            driver.Url = "http://localhost:62912/WebForm2.aspx";
            Assert.IsTrue(driver.Title == "");
            driver.Dispose();
        }

        /// <summary>
        /// Поля на странице логина пустые. Возникновение алерта
        /// </summary>
        [TestMethod]
        public void TestEmptyFields()
        {
            driver.Url = "http://localhost:62912/WebForm2.aspx";

            driver.FindElement(By.Id("Button1")).Click();
            IAlert alert = driver.SwitchTo().Alert();

            Assert.IsTrue(alert.Text == "Email not found. Try Again !");
            driver.Dispose();
        }

        /// <summary>
        /// Поля на странице логина пустые. Редирект на страницу логина после принятия аоерта
        /// </summary>
        [TestMethod]
        public void TestEmptyFieldsRedirect()
        {
            driver.Url = "http://localhost:62912/WebForm2.aspx";

            driver.FindElement(By.Id("Button1")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            Assert.IsTrue(driver.Url == "http://localhost:62912/WebForm2.aspx");
            driver.Dispose();
        }

        /// <summary>
        /// Неправильный Email на странице логина. Возникновение алерта
        /// </summary>
        [TestMethod]
        public void WrongEmail()
        {
            driver.Url = "http://localhost:62912/WebForm2.aspx";
            driver.FindElement(By.Id("LoginEmail")).SendKeys("none@gmail.com");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text == "Email not found. Try Again !");
            driver.Dispose();
        }

        /// <summary>
        /// Нерпавильный пароль. возникновение алерта
        /// </summary>
        [TestMethod]
        public void WrongPassword()
        {
            driver.Url = "http://localhost:62912/WebForm2.aspx";
            driver.FindElement(By.Id("LoginEmail")).SendKeys("ABC@gmail.com");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text == "Incorrect Password. Try Again !");
            driver.Dispose();
        }

        /// <summary>
        /// Правильный вход. Переход на следующую страницу
        /// </summary>
        [TestMethod]
        public void GoToNextPage()
        {
            driver.Url = "http://localhost:62912/WebForm2.aspx";
            driver.FindElement(By.Id("LoginEmail")).SendKeys("ABC@gmail.com");
            driver.FindElement(By.Id("LoginPassword")).SendKeys("abc");

            driver.FindElement(By.Id("Button1")).Click();

            Assert.IsTrue(driver.Url == "http://localhost:62912/WebForm1.aspx");
            driver.Dispose();
        }

        /// <summary>
        /// Пустые поля. Возникновение алерта.
        /// </summary>
        [TestMethod]
        public void ErrorPoint()
        {
            driver.Url = "http://localhost:62912/WebForm1.aspx";

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text == "Error Point!");
            driver.Dispose();
        }

        /// <summary>
        /// Неправильные поля. Возникновение алерта.
        /// </summary>
        [TestMethod]
        public void PointNotNumber()
        {
            driver.Url = "http://localhost:62912/WebForm1.aspx";

            driver.FindElement(By.Id("TextBox1")).SendKeys("a");
            driver.FindElement(By.Id("TextBox2")).SendKeys("b");
            driver.FindElement(By.Id("TextBox3")).SendKeys("c");
            driver.FindElement(By.Id("TextBox4")).SendKeys("d");
            driver.FindElement(By.Id("TextBox5")).SendKeys("e");
            driver.FindElement(By.Id("TextBox6")).SendKeys("f");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text == "Error Point!");
            driver.Dispose();
        }

        /// <summary>
        /// Ошибка поля. редирект
        /// </summary>
        [TestMethod]
        public void PointNotNumberRedirect()
        {
            driver.Url = "http://localhost:62912/WebForm1.aspx";

            driver.FindElement(By.Id("TextBox1")).SendKeys("a");
            driver.FindElement(By.Id("TextBox1")).SendKeys("b");
            driver.FindElement(By.Id("TextBox1")).SendKeys("c");
            driver.FindElement(By.Id("TextBox1")).SendKeys("d");
            driver.FindElement(By.Id("TextBox1")).SendKeys("e");
            driver.FindElement(By.Id("TextBox1")).SendKeys("f");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            Assert.IsTrue(driver.Url == "http://localhost:62912/WebForm1.aspx");
            driver.Dispose();
        }


    }
}
