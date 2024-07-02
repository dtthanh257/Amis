using System;
using MISA.WebFresher062023.Demo;

namespace MISA.WebFresher062023.Demo.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        /// <summary>
        /// Test hàm cộng 2 số
        /// </summary>
        /// <param name="x">toán tử 1</param>
        /// <param name="y">toán tử 2</param>
        /// <param name="expectedResult">kết quả mong đợi</param>
        /// Author: dtthanh (13/08/2023)
        [TestCase(1, 2, 3)]
        [TestCase(1, 3, 4)]
        [TestCase(-1, 5, 4)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue * (long)2)]
        public void Add_ValidInput_SumTwoNumber(int x, int y, long expectedResult)
        {
            //Act
            var actualResult = new Calculator().Add(x, y);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Test hàm trừ 2 số nguyên
        /// </summary>
        /// <param name="x">toán tử 1</param>
        /// <param name="y">toán tử 2</param>
        /// <param name="expectedResult">kết quả mong đợi</param>
        /// Author: dtthanh (13/08/2023)
        [TestCase(1, 2, -1)]
        [TestCase(1, 3, -2)]
        [TestCase(-1, 5, -6)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long)2 + 1)]
        public void Sub_ValidInput_SubTwoNumber(int x, int y, long expectedResult)
        {
            //Act
            var actualResult = new Calculator().Sub(x, y);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Test hàm nhân 2 số nguyên
        /// </summary>
        /// <param name="x">toán tử 1</param>
        /// <param name="y">toán tử 2</param>
        /// <param name="expectedResult">kết quả mong đợi</param>
        /// Author: dtthanh (13/08/2023)
        [TestCase(1, 2, 2)]
        [TestCase(1, 3, 3)]
        [TestCase(-1, 5, -5)]
        [TestCase(5, 0, 0)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long)int.MinValue)]
        public void Mul_ValidInput_MulTwoNumber(int x, int y, long expectedResult)
        {
            //Act
            var actualResult = new Calculator().Mul(x, y);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Test hàm chia cho 0
        /// </summary>
        /// Author: dtthanh (13/08/2023)
        [Test]
        public void Div_ZeroInput_ThrowException()
        {
            //Arrange
            var x = 1;
            var y = 0;
            var expectedMessage = "Không thể chia cho 0";

            //Act & Assert
            var exception = Assert.Throws<Exception>(() => new Calculator().Div(x, y));

            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Test hàm chia với giá trị đầu vào khác 0
        /// </summary>
        /// <param name="x">toán tử 1</param>
        /// <param name="y">toán tử 2</param>
        /// <param name="expectedResult">kết quả mong đợi</param>
        /// Author: dtthanh (13/08/2023)
        [TestCase(1, 2, 0.5f)]
        [TestCase(1, 3, 1 / (float)3)]
        [TestCase(int.MaxValue, 3, int.MaxValue / (double)3)]
        public void Div_ValidInput_Success(int x, int y, double expectedResult)
        {
            //Act
            var actualResult = new Calculator().Div(x, y);

            //Assert
            Assert.That(Math.Abs(actualResult - expectedResult), Is.LessThan(10e-3));
        }

        /// <summary>
        /// Test hàm tổng của các số trong string
        /// </summary>
        /// <param name="str">chuỗi nhập vào</param>
        /// <param name="expectedResult">kết quả mong đợi</param>
        /// Author: dtthanh (13/08/2023)
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1, 2, 3, 4, 5 , 9, 1", 25)]
        [TestCase("1, 2, 3, 4, 5 ,6 ,7 ,8 ,9", 45)]
        public void Add_ValidInput_Success(string str, long expectedResult)
        {
            //Act
            var actualResult = new Calculator().Add(str);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Test hàm tổng với input null
        /// </summary>
        /// Author: dtthanh (13/08/2023)
        [Test]
        public void Add_NullInput_ThrowException()
        {
            //Arrange
            string str = null;
            var expectedMessage = "Kí tự không hợp lệ";

            //Act
            var exception = Assert.Throws<Exception>(() => new Calculator().Add(str));

            //Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Test hàm tổng với input có phần tử không chuyền được thành int
        /// </summary>
        /// Author: dtthanh (13/08/2023)
        [Test]
        public void Add_NonStringInput_ThrowException()
        {
            //Arrange
            string str = "1, str, str, 2";
            var expectedMessage = "Kí tự không hợp lệ";

            //Act
            var exception = Assert.Throws<Exception>(() => new Calculator().Add(str));

            //Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Test hàm tổng với input có số âm
        /// </summary>
        /// Author: dtthanh (13/08/2023)
        [Test]
        public void Add_NegativeInput_ThrowException()
        {
            //Arrange
            string str = "1, -2, -3, -4";
            var expectedMessage = "Không chấp nhận toán tử âm: -2, -3, -4";

            //Act
            var exception = Assert.Throws<Exception>(() => new Calculator().Add(str));

            //Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}