using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class TrianglUnitTest
    {
       
        // 1 private readonly Mock<Triangl> triangl;
        [TestMethod]
        public void TestMethodLoadLengthAZero()
        {
            var triangl = new Mock<IPointTriangl>();
            triangl.Setup(x => x.AB).Returns(-1.0);
            triangl.Setup(x => x.AC).Returns(1.0);
            triangl.Setup(x => x.BC).Returns(2.0);


            Triangl tr = new Triangl();
            var error = tr.LoadLength(triangl.Object);
            Assert.AreEqual(MyError.ErrorLength, error);
        }

        //2 Длина b меньше 0
        [TestMethod]
        public void TestMethodLoadLengthBZero()
        {
            var triangl = new Mock<IPointTriangl>();
            triangl.Setup(x => x.AB).Returns(3.0);
            triangl.Setup(x => x.AC).Returns(-2.0);
            triangl.Setup(x => x.BC).Returns(2.0);


            Triangl tr = new Triangl();
            var error = tr.LoadLength(triangl.Object);
            Assert.AreEqual(MyError.ErrorLength, error);
        }

        //3 Длина c меньше 0
        [TestMethod]
        public void TestMethodLoadLengthCZero()
        {
            var triangl = new Mock<IPointTriangl>();
            triangl.Setup(x => x.AB).Returns(3.0);
            triangl.Setup(x => x.AC).Returns(5.0);
            triangl.Setup(x => x.BC).Returns(-1.0);


            Triangl tr = new Triangl();
            var error = tr.LoadLength(triangl.Object);
            Assert.AreEqual(MyError.ErrorLength, error);
        }

        //4 Треугольник превращаестя в отрезок
        [TestMethod]
        public void TestMethodLoadLengthLine()
        {
            var triangl = new Mock<IPointTriangl>();
            triangl.Setup(x => x.AB).Returns(3.0);
            triangl.Setup(x => x.AC).Returns(7.0);
            triangl.Setup(x => x.BC).Returns(2.0);


            Triangl tr = new Triangl();
            var error = tr.LoadLength(triangl.Object);
            Assert.AreEqual(MyError.ErrorTriangl, error);
        }

        //5 Записали то, что надо
        [TestMethod]
        public void TestMethodLoadLengthData()
        {
            double a = 2;
            double b = 4;
            double c = 5;

            var triangl = new Mock<IPointTriangl>();
            triangl.Setup(x => x.AB).Returns(a);
            triangl.Setup(x => x.AC).Returns(b);
            triangl.Setup(x => x.BC).Returns(c);

            Triangl tr = new Triangl();
            double error = tr.LoadLength(triangl.Object);
            Assert.AreEqual(a, tr.A);
            Assert.AreEqual(b, tr.B);
            Assert.AreEqual(c, tr.C);
        }

        
        //6 площадь возвращает ОК
        [TestMethod]
        public void TestMethodCalculateS()
        {
            double a = 3;
            double b = 4;
            double c = 5;

            var triangl = new Mock<IPointTriangl>();
            triangl.Setup(x => x.AB).Returns(a);
            triangl.Setup(x => x.AC).Returns(b);
            triangl.Setup(x => x.BC).Returns(c);

            Triangl tr = new Triangl();
            double error = tr.CalculateS(triangl.Object);
            Assert.AreEqual(MyError.OK, error);
        }

        
        //7 Площадь возвращает ошибку
        [TestMethod]
        public void TestMethodCalculateSError()
        {
            double a = 1;
            double b = 1;
            double c = 3;

            var triangl = new Mock<IPointTriangl>();
            triangl.Setup(x => x.AB).Returns(a);
            triangl.Setup(x => x.AC).Returns(b);
            triangl.Setup(x => x.BC).Returns(c);

            Triangl tr = new Triangl();
            double error = tr.CalculateS(triangl.Object);
            Assert.AreEqual(MyError.ErrorTriangl, error);
        }

        
        //8 Площадь = 6
        [TestMethod]
        public void TestMethodCalculateSValue()
        {
            double a = 3;
            double b = 4;
            double c = 5;
            Triangl tr = new Triangl();

            var triangl = new Mock<IPointTriangl>();
            triangl.Setup(x => x.AB).Returns(a);
            triangl.Setup(x => x.AC).Returns(b);
            triangl.Setup(x => x.BC).Returns(c);

            tr.CalculateS(triangl.Object);
            double s = tr.S;
            Assert.AreEqual(6.0, s);
        }

        /// <summary>
        /// 11. Периметр посчитан верно
        /// </summary>
        [TestMethod]
        public void TestMethodCalculateSValueP()
        {
            double a = 3;
            double b = 4;
            double c = 5;
            Triangl tr = new Triangl();

            var triangl = new Mock<IPointTriangl>();
            triangl.Setup(x => x.AB).Returns(a);
            triangl.Setup(x => x.AC).Returns(b);
            triangl.Setup(x => x.BC).Returns(c);

            tr.CalculateS(triangl.Object);
            double s = tr.P;
            Assert.AreEqual(12.0, s);
        }

    }


    [TestClass]
    public class PointTrianglUnitTest
    {

        //9 Вычисления длины отрезков треугольни
        [TestMethod]
        public void TestMethodPointTriangl()
        {
            var A = new PointF(0, 0);
            var B = new PointF(3,0);
            var C = new PointF(3,4);
            var tr = new PointTriangl(A, B, C);

            Assert.AreEqual(3, tr.AB);
            Assert.AreEqual(5, tr.AC);
            Assert.AreEqual(4, tr.BC);
        }

        //10 Функция подсчета длины по 2м точкам
        [TestMethod]
        public void TestMethodLength()
        {
            var A = new PointF(0, 0);
            var B = new PointF(3, 0);

            var len = PointTriangl.Length(A, B);

            Assert.AreEqual(3, len);
        }
    }
}
