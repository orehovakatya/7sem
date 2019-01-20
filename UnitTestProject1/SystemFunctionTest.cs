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
        /// <summary>
        /// Точи лежат на одной прямой
        /// </summary>
        [TestMethod]
        public void PointInOneLen()
        {
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm1.aspx" };

            driver.FindElementById("TextBox1").SendKeys("0");
            driver.FindElementById("TextBox2").SendKeys("1");
            driver.FindElementById("TextBox3").SendKeys("2");
            driver.FindElementById("TextBox4").SendKeys("0");
            driver.FindElementById("TextBox5").SendKeys("0");
            driver.FindElementById("TextBox6").SendKeys("0");

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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm1.aspx" };

            driver.FindElementById("TextBox1").SendKeys("0");
            driver.FindElementById("TextBox2").SendKeys("3");
            driver.FindElementById("TextBox3").SendKeys("3");
            driver.FindElementById("TextBox4").SendKeys("0");
            driver.FindElementById("TextBox5").SendKeys("0");
            driver.FindElementById("TextBox6").SendKeys("4");

            driver.FindElement(By.Id("Button1")).Click();

            Assert.IsTrue(driver.FindElementById("Label1").Text == "6");
            driver.Dispose();
        }

        /// <summary>
        /// NNN Точи образуют треугольник, периметр которого равен 12
        /// </summary>
        [TestMethod]
        public void TrianglPIs12()
        {
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm1.aspx" };

            driver.FindElementById("TextBox1").SendKeys("0");
            driver.FindElementById("TextBox2").SendKeys("3");
            driver.FindElementById("TextBox3").SendKeys("3");
            driver.FindElementById("TextBox4").SendKeys("0");
            driver.FindElementById("TextBox5").SendKeys("0");
            driver.FindElementById("TextBox6").SendKeys("4");

            driver.FindElement(By.Id("Button1")).Click();

            Assert.IsTrue(driver.FindElementById("Label2").Text == "12");
            driver.Dispose();
        }

        /// <summary>
        /// Первая точка неправильная
        /// </summary>
        [TestMethod]
        public void FirstPointError()
        {
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm1.aspx" };

            driver.FindElementById("TextBox1").SendKeys("0");
            driver.FindElementById("TextBox2").SendKeys("1");
            driver.FindElementById("TextBox3").SendKeys("2");
            driver.FindElementById("TextBox4").SendKeys("h");
            driver.FindElementById("TextBox5").SendKeys("0");
            driver.FindElementById("TextBox6").SendKeys("0");

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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm1.aspx" };

            driver.FindElementById("TextBox1").SendKeys("0");
            driver.FindElementById("TextBox2").SendKeys("l");
            driver.FindElementById("TextBox3").SendKeys("2");
            driver.FindElementById("TextBox4").SendKeys("2");
            driver.FindElementById("TextBox5").SendKeys("k");
            driver.FindElementById("TextBox6").SendKeys("0");

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
            var driver = new ChromeDriver { Url = "http://localhost:62912/WebForm1.aspx" };

            driver.FindElementById("TextBox1").SendKeys("0");
            driver.FindElementById("TextBox2").SendKeys("1");
            driver.FindElementById("TextBox3").SendKeys("п");
            driver.FindElementById("TextBox4").SendKeys("0");
            driver.FindElementById("TextBox5").SendKeys("0");
            driver.FindElementById("TextBox6").SendKeys("з");

            driver.FindElement(By.Id("Button1")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text == "Error Point!");
            driver.Dispose();
        }

    }
}
