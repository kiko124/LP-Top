using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _18._022
{
    internal class Program
    {
        class CaesarCipher
        {
            static string Encrypt(string text, int shift)
            {
                return Process(text, shift);
            }

            static string Decrypt(string text, int shift)
            {
                return Process(text, -shift);
            }

            static string Process(string text, int shift)
            {
                char[] buffer = text.ToCharArray();
                for (int i = 0; i < buffer.Length; i++)
                {
                    char c = buffer[i];
                    if (char.IsLetter(c))
                    {
                        char offset = char.IsUpper(c) ? 'A' : 'a';
                        c = (char)(((c + shift - offset) % 26 + 26) % 26 + offset);
                    }
                    buffer[i] = c;
                }
                return new string(buffer);
            }
            class MatrixOperations
            {
                static void MultiplyByNumber(int[,] matrix, int number)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[i, j] *= number;
                        }
                    }
                }

                static int[,] AddMatrices(int[,] a, int[,] b)
                {
                    int[,] result = new int[a.GetLength(0), a.GetLength(1)];
                    for (int i = 0; i < a.GetLength(0); i++)
                    {
                        for (int j = 0; j < a.GetLength(1); j++)
                        {
                            result[i, j] = a[i, j] + b[i, j];
                        }
                    }
                    return result;
                }

                static int[,] MultiplyMatrices(int[,] a, int[,] b)
                {
                    int rowsA = a.GetLength(0);
                    int colsA = a.GetLength(1);
                    int colsB = b.GetLength(1);
                    int[,] result = new int[rowsA, colsB];

                    for (int i = 0; i < rowsA; i++)
                    {
                        for (int j = 0; j < colsB; j++)
                        {
                            for (int k = 0; k < colsA; k++)
                            {
                                result[i, j] += a[i, k] * b[k, j];
                            }
                        }
                    }
                    return result;
                }

                static void PrintMatrix(int[,] matrix)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                }

                static void Main(string[] args)
                {
                    #region
                    //double[] A = new double[5];
                    //Console.WriteLine("Введите 5 чисел для массива A:");
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    A[i] = Convert.ToDouble(Console.ReadLine());
                    //}


                    //double[,] B = new double[3, 4];
                    //Random rand = new Random();
                    //for (int i = 0; i < 3; i++)
                    //{
                    //    for (int j = 0; j < 4; j++)
                    //    {
                    //        B[i, j] = rand.NextDouble() * 100;
                    //    }
                    //}


                    //Console.WriteLine("\nМассив A: " + string.Join(" ", A));
                    //Console.WriteLine("Массив B:");
                    //for (int i = 0; i < 3; i++)
                    //{
                    //    for (int j = 0; j < 4; j++)
                    //    {
                    //        Console.Write($"{B[i, j]:F2} ");
                    //    }
                    //    Console.WriteLine();
                    //}


                    //double maxA = A.Max();
                    //double maxB = B.Cast<double>().Max();
                    //double globalMax = Math.Max(maxA, maxB);

                    //double minA = A.Min();
                    //double minB = B.Cast<double>().Min();
                    //double globalMin = Math.Min(minA, minB);


                    //double sumA = A.Sum();
                    //double sumB = B.Cast<double>().Sum();
                    //double totalSum = sumA + sumB;

                    //double productA = A.Aggregate((a, b) => a * b);
                    //double productB = B.Cast<double>().Aggregate((a, b) => a * b);
                    //double totalProduct = productA * productB;


                    //double evenSumA = A.Where(x => x % 2 == 0).Sum();


                    //double oddColumnSumB = 0;
                    //for (int j = 0; j < 4; j++)
                    //{
                    //    if (j % 2 != 0) 
                    //    {
                    //        for (int i = 0; i < 3; i++)
                    //        {
                    //            oddColumnSumB += B[i, j];
                    //        }
                    //    }
                    //}


                    //Console.WriteLine($"\nОбщий максимум: {globalMax:F2}");
                    //Console.WriteLine($"Общий минимум: {globalMin:F2}");
                    //Console.WriteLine($"Общая сумма: {totalSum:F2}");
                    //Console.WriteLine($"Общее произведение: {totalProduct:E2}");
                    //Console.WriteLine($"Сумма четных элементов A: {evenSumA:F2}");
                    //Console.WriteLine($"Сумма нечетных столбцов B: {oddColumnSumB:F2}");
                    #endregion
                    #region
                    //    int[,] matrix = new int[5, 5];
                    //    Random rand = new Random();
                    //    int min = int.MaxValue, max = int.MinValue;
                    //    int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;


                    //    for (int i = 0; i < 5; i++)
                    //    {
                    //        for (int j = 0; j < 5; j++)
                    //        {
                    //            matrix[i, j] = rand.Next(-100, 101);
                    //            if (matrix[i, j] < min)
                    //            {
                    //                min = matrix[i, j];
                    //                minRow = i;
                    //                minCol = j;
                    //            }
                    //            if (matrix[i, j] > max)
                    //            {
                    //                max = matrix[i, j];
                    //                maxRow = i;
                    //                maxCol = j;
                    //            }
                    //        }
                    //    }


                    //    int sum = 0;
                    //    bool isBetween = false;
                    //    for (int i = 0; i < 5; i++)
                    //    {
                    //        for (int j = 0; j < 5; j++)
                    //        {
                    //            int currentIndex = i * 5 + j;
                    //            int minIndex = minRow * 5 + minCol;
                    //            int maxIndex = maxRow * 5 + maxCol;

                    //            if (currentIndex == Math.Min(minIndex, maxIndex))
                    //            {
                    //                isBetween = true;
                    //            }
                    //            else if (currentIndex == Math.Max(minIndex, maxIndex))
                    //            {
                    //                isBetween = false;
                    //                sum += matrix[i, j]; 
                    //                break;
                    //            }

                    //            if (isBetween)
                    //            {
                    //                sum += matrix[i, j];
                    //            }
                    //        }
                    //    }

                    //    Console.WriteLine($"Сумма между min и max: {sum}");
                    //}
                    //}
                    //}
                    #endregion
                    #region
                    //Console.Write("Введите текст: ");
                    //string text = Console.ReadLine();
                    //Console.Write("Введите сдвиг: ");
                    //int shift = int.Parse(Console.ReadLine());

                    //string encrypted = Encrypt(text, shift);
                    //Console.WriteLine($"Зашифровано: {encrypted}");

                    //string decrypted = Decrypt(encrypted, shift);
                    //Console.WriteLine($"Расшифровано: {decrypted}");
                    #endregion
                    #region
                    //int[,] matrixA = { { 1, 2 }, { 3, 4 } };
                    //int[,] matrixB = { { 5, 6 }, { 7, 8 } };

                    //Console.WriteLine("Умножение на число 2:");
                    //MultiplyByNumber(matrixA, 2);
                    //PrintMatrix(matrixA);

                    //Console.WriteLine("\nСложение матриц:");
                    //int[,] sum = AddMatrices(matrixA, matrixB);
                    //PrintMatrix(sum);

                    //Console.WriteLine("\nПроизведение матриц:");
                    //int[,] product = MultiplyMatrices(matrixA, matrixB);
                    //PrintMatrix(product);
                    #endregion
                    #region
                //    Console.Write("Введите выражение: ");
                //    string input = Console.ReadLine().Replace(" ", "");
                //    int currentNumber = 0;
                //    int result = 0;
                //    char lastOperator = '+';

                //    foreach (char c in input)
                //    {
                //        if (char.IsDigit(c))
                //        {
                //            currentNumber = currentNumber * 10 + (c - '0');
                //        }
                //        else
                //        {
                //            result = ApplyOperator(result, currentNumber, lastOperator);
                //            lastOperator = c;
                //            currentNumber = 0;
                //        }
                //    }

                //    result = ApplyOperator(result, currentNumber, lastOperator);
                //    Console.WriteLine($"Результат: {result}");
                //}

                //static int ApplyOperator(int a, int b, char op)
                //{
                //    switch (op)
                //    {
                //        case '+':
                //            return a + b;
                //        case '-':
                //            return a - b;
                //        default:
                //            throw new ArgumentException("Недопустимый оператор");
                //    }
                //}
                #endregion
                #region
    //            Console.Write("Введите текст: ");
    //    string text = Console.ReadLine();
    //            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
    //            string result = textInfo.ToLower(text);

    //            bool newSentence = true;
    //            char[] chars = result.ToCharArray();

    //    for (int i = 0; i<chars.Length; i++)
    //    {
    //        if (newSentence && char.IsLetter(chars[i]))
    //        {
    //            chars[i] = char.ToUpper(chars[i]);
    //            newSentence = false;
    //        }
    //        if (chars[i] == '.' || chars[i] == '!' || chars[i] == '?')
    //        {
    //            newSentence = true;
    //        }
    //}

    //Console.WriteLine(new string (chars));
                    #endregion
                    #region
                    //Console.WriteLine("Введите текст:");
                    //string text = Console.ReadLine();
                    //Console.Write("Введите недопустимое слово: ");
                    //string forbiddenWord = Console.ReadLine();

                    //string pattern = $@"\b{Regex.Escape(forbiddenWord)}\b";
                    //string replacedText = Regex.Replace(text, pattern, m => new string('*', m.Length), RegexOptions.IgnoreCase);
                    //int replacements = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;

                    //Console.WriteLine("\nРезультат:");
                    //Console.WriteLine(replacedText);
                    //Console.WriteLine($"Статистика: {replacements} замен(ы) слова {forbiddenWord}.");
                    #endregion
                }
        }
        }
    }
}