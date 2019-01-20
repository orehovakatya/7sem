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
        /// <summary>
        /// Ссылка работает
        /// </summary>
        [TestMethod]
        public void TestUrl()
        {
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm2.aspx" };
            Assert.IsTrue(driver.Title == "");
            driver.Dispose();
        }

        /// <summary>
        /// Поля на странице логина пустые. Возникновение алерта
        /// </summary>
        [TestMethod]
        public void TestEmptyFields()
        {
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm2.aspx" };

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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm2.aspx" };
           
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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm2.aspx" };
            driver.FindElementById("LoginEmail").SendKeys("none@gmail.com");

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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm2.aspx" };
            driver.FindElementById("LoginEmail").SendKeys("ABC@gmail.com");

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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm2.aspx" };
            driver.FindElementById("LoginEmail").SendKeys("ABC@gmail.com");
            driver.FindElementById("LoginPassword").SendKeys("abc");

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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm1.aspx" };

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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm1.aspx" };

            driver.FindElementById("TextBox1").SendKeys("a");
            driver.FindElementById("TextBox2").SendKeys("b");
            driver.FindElementById("TextBox3").SendKeys("c");
            driver.FindElementById("TextBox4").SendKeys("d");
            driver.FindElementById("TextBox5").SendKeys("e");
            driver.FindElementById("TextBox6").SendKeys("f");

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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm1.aspx" };

            driver.FindElementById("TextBox1").SendKeys("a");
            driver.FindElementById("TextBox2").SendKeys("b");
            driver.FindElementById("TextBox3").SendKeys("c");
            driver.FindElementById("TextBox4").SendKeys("d");
            driver.FindElementById("TextBox5").SendKeys("e");
            driver.FindElementById("TextBox6").SendKeys("f");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            Assert.IsTrue(driver.Url == "http://localhost:62912/WebForm1.aspx");
            driver.Dispose();
        }


    }
}
