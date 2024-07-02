using System;
using MISA.WebFresher062023.Demo;

namespace MISA.WebFresher062023.Demo
{
    public class Calculator
    {
        /// <summary>
        /// Hàm cộng 2 số
        /// </summary>
        /// <param name="x">toán tử 1</param>
        /// <param name="y">toán tử 2</param>
        /// <returns>Tổng của 2 số</returns>
        /// Author: dtthanh (13/08/2023)
        public long Add(int x, int y)
        {
            return x + (long)y;
        }

        /// <summary>
        /// Hàm trừ 2 số
        /// </summary>
        /// <param name="x">toán từ 1</param>
        /// <param name="y">toán tử 2</param>
        /// <returns>Hiệu của 2 số</returns>
        /// Author: dtthanh (13/08/2023)
        public long Sub(int x, int y)
        {
            return x - (long)y;
        }

        /// <summary>
        /// Hàm tích của 2 số
        /// </summary>
        /// <param name="x">toán tử 1</param>
        /// <param name="y">toán tử 2</param>
        /// <returns>Tích của 2 số</returns>
        /// Author: dtthanh (13/08/2023)
        public long Mul(int x, int y)
        {
            return x * (long)y;
        }

        /// <summary>
        /// Hàm chia 2 số
        /// </summary>
        /// <param name="x">toán tử 1</param>
        /// <param name="y">toán tử 2</param>
        /// <returns>Thương của 2 số</returns>
        /// Author: dtthanh (13/08/2023)
        public double Div(int x, int y)
        {
            if (y == 0)
            {
                throw new Exception("Không thể chia cho 0");
            }

            return x / (double)y;
        }

        /// <summary>
        /// Hàm tính tổng nhập vào từ string
        /// </summary>
        /// <param name="str">chuõi nhập vào</param>
        /// <returns>tổng các toán tử trong chuỗi</returns>
        /// Author: dtthanh (13/08/2023)
        public long Add(string str)
        {
            if (str == null)
            {
                throw new Exception("Kí tự không hợp lệ");
            }
            else
            {
                if (str == "")
                {
                    return 0;
                }
                else
                {
                    //Chuyển sang dãy string để check xem tất cả các phần tử có thể chuyển sang int hay không
                    string[] numberStrings = str.Split(',');

                    int[] intArr = new int[numberStrings.Length];

                    string negativeNumber = "";

                    //Duyệt xem tất cả các phần tử có thể chuyển sang int hay không
                    for (int i = 0; i < numberStrings.Length; i++)
                    {
                        if (int.TryParse(numberStrings[i], out int value))
                        {
                            intArr[i] = value;
                        }
                        else
                        {
                            throw new Exception("Kí tự không hợp lệ");
                        }
                    }

                    long sum = 0;
                    for (int i = 0; i < intArr.Length; ++i)
                    {
                        if (intArr[i] >= 0)
                        {
                            sum += (long)intArr[i];
                        }
                        else
                        {
                            negativeNumber += intArr[i] + ", ";
                        }
                    }
                    if (negativeNumber.Length > 0)
                    {
                        throw new Exception($"Không chấp nhận toán tử âm: {negativeNumber.Remove(negativeNumber.Length - 2, 2)}");
                    }
                    else
                    {
                        return sum;
                    }
                }
            }
        }
    }
}