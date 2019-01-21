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

    [TestClass]
    public class SystemFunctionTest
    {
        public IWebDriver driver = new ChromeDriver(@"C:\Users\Катя\Documents\7sem\WebApplication1Tests\bin\Debug");
        /// <summary>
        /// Точи лежат на одной прямой
        /// </summary>
        [TestMethod]
        public void PointInOneLen()
        {
            driver.Url = "http://localhost:62912/WebForm1.aspx";

            driver.FindElement(By.Id("TextBox1")).SendKeys("0");
            driver.FindElement(By.Id("TextBox2")).SendKeys("1");
            driver.FindElement(By.Id("TextBox3")).SendKeys("2");
            driver.FindElement(By.Id("TextBox4")).SendKeys("0");
            driver.FindElement(By.Id("TextBox5")).SendKeys("0");
            driver.FindElement(By.Id("TextBox6")).SendKeys("0");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text == "Error Point! Triangl not found");
            driver.Dispose();
        }

        /// <summary>
        /// Точи образуют треугольник, площадь которого равна 6
        /// </summary>
        [TestMethod]
        public void TrianglSIs6()
        {
            driver.Url = "http://localhost:62912/WebForm1.aspx";

            driver.FindElement(By.Id("TextBox1")).SendKeys("0");
            driver.FindElement(By.Id("TextBox2")).SendKeys("3");
            driver.FindElement(By.Id("TextBox3")).SendKeys("3");
            driver.FindElement(By.Id("TextBox4")).SendKeys("0");
            driver.FindElement(By.Id("TextBox5")).SendKeys("0");
            driver.FindElement(By.Id("TextBox6")).SendKeys("4");

            driver.FindElement(By.Id("Button1")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("Label1")).Text == "6");
            driver.Dispose();
        }

        /// <summary>
        /// NNN Точи образуют треугольник, периметр которого равен 12
        /// </summary>
        [TestMethod]
        public void TrianglPIs12()
        {
            driver.Url = "http://localhost:62912/WebForm1.aspx";

            driver.FindElement(By.Id("TextBox1")).SendKeys("0");
            driver.FindElement(By.Id("TextBox2")).SendKeys("3");
            driver.FindElement(By.Id("TextBox3")).SendKeys("3");
            driver.FindElement(By.Id("TextBox4")).SendKeys("0");
            driver.FindElement(By.Id("TextBox5")).SendKeys("0");
            driver.FindElement(By.Id("TextBox6")).SendKeys("4");

            driver.FindElement(By.Id("Button1")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("Label2")).Text == "12");
            driver.Dispose();
        }

        /// <summary>
        /// Первая точка неправильная
        /// </summary>
        [TestMethod]
        public void FirstPointError()
        {
            driver.Url = "http://localhost:62912/WebForm1.aspx";

            driver.FindElement(By.Id("TextBox1")).SendKeys("0");
            driver.FindElement(By.Id("TextBox2")).SendKeys("1");
            driver.FindElement(By.Id("TextBox3")).SendKeys("2");
            driver.FindElement(By.Id("TextBox4")).SendKeys("h");
            driver.FindElement(By.Id("TextBox5")).SendKeys("0");
            driver.FindElement(By.Id("TextBox6")).SendKeys("0");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text == "Error Point!");
            driver.Dispose();
        }

        /// <summary>
        /// Вторая точка неправльная
        /// </summary>
        [TestMethod]
        public void SecondPointError()
        {
            driver.Url = "http://localhost:62912/WebForm1.aspx";

            driver.FindElement(By.Id("TextBox1")).SendKeys("0");
            driver.FindElement(By.Id("TextBox2")).SendKeys("l");
            driver.FindElement(By.Id("TextBox3")).SendKeys("2");
            driver.FindElement(By.Id("TextBox4")).SendKeys("2");
            driver.FindElement(By.Id("TextBox5")).SendKeys("k");
            driver.FindElement(By.Id("TextBox6")).SendKeys("0");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text == "Error Point!");
            driver.Dispose();
        }

        /// <summary>
        /// Третья точка неправильная
        /// </summary>
        [TestMethod]
        public void ThirdPointError()
        {
            driver.Url = "http://localhost:62912/WebForm1.aspx";

            driver.FindElement(By.Id("TextBox1")).SendKeys("0");
            driver.FindElement(By.Id("TextBox2")).SendKeys("1");
            driver.FindElement(By.Id("TextBox3")).SendKeys("п");
            driver.FindElement(By.Id("TextBox4")).SendKeys("0");
            driver.FindElement(By.Id("TextBox5")).SendKeys("0");
            driver.FindElement(By.Id("TextBox6")).SendKeys("з");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text == "Error Point!");
            driver.Dispose();
        }

    }
}
