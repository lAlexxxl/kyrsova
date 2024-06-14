using System;

namespace Calculator_expressions_
{
    public static class MathOperation
    {
        private static bool TryParseDouble(string num, out double result)
        {
            return double.TryParse(num, out result);
        }

        public static string Add(string num1, string num2)
        {
            double a, b;
            if (!TryParseDouble(num1, out a) || !TryParseDouble(num2, out b))
                return null;
            return (a + b).ToString("F2");
        }

        public static string Sub(string num1, string num2)
        {
            double a, b;
            if (!TryParseDouble(num1, out a) || !TryParseDouble(num2, out b))
                return null;
            return (a - b).ToString("F2");
        }

        public static string Mul(string num1, string num2)
        {
            double a, b;
            if (!TryParseDouble(num1, out a) || !TryParseDouble(num2, out b))
                return null;
            return (a * b).ToString("F2");
        }

        public static string Dev(string num1, string num2)
        {
            double a, b;
            if (!TryParseDouble(num1, out a) || !TryParseDouble(num2, out b))
                return null;
            if (b == 0)
                return "Division by zero error";
            return (a / b).ToString("F2");
        }

        public static string Proc(string num1, string num2)
        {
            double number1, number2;
            if (!TryParseDouble(num1, out number1) || !TryParseDouble(num2, out number2))
                return null;
            double result = (number1 * number2) / 100;
            return result.ToString("F2");
        }

        public static string Sqr(string num1)
        {
            double a;
            if (!TryParseDouble(num1, out a))
                return null;
            return Math.Sqrt(a).ToString("F2");
        }

        public static string Pow(string num1)
        {
            double a;
            if (!TryParseDouble(num1, out a)) { return null; }
            return Math.Pow(a, 2).ToString("F2");
        }

        public static string OneDev(string num1)
        {
            double a;
            if (!TryParseDouble(num1, out a))
                return null;
            if (a == 0)
                return "Division by zero error";
            return (1 / a).ToString("F2");
        }
    }
}
