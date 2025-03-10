using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _1_lp
{
    internal class Program
    {
        public static string Caesar(string text, int shift)
        {
            char[] buffer = text.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                if (char.IsLetter(letter))
                {
                    char letterOffset = char.IsUpper(letter) ? 'A' : 'a';
                    letter = (char)((((letter + shift) - letterOffset) % 26) + letterOffset);
                }

                buffer[i] = letter;
            }

            return new string(buffer);
        }


        static void Main()
        {
            #region 1 задание 
            //  int[] A = new int[5];

            //  Console.WriteLine("Введите 5 целых чисел для массива A:");
            //  for (int i = 0; i < A.Length; i++)
            //  {
            //      Console.Write($"Введите элемент { i + 1}: ");
            //      A[i] = int.Parse(Console.ReadLine());


            //  }
            //int Max = A[0], Min = A[0];
            //  for (int j = 1; j < 5; j++)
            //      {
            //          if (Max < A[j])
            //          {
            //              Max = A[j];
            //          }
            //          if (Min > A[j])
            //          {
            //              Min = A[j];
            //          }
            //      }
            //  int sum = 0;
            //  for (int i =0; i < A.Length; i++ )
            //  {
            //      sum += A[i];

            //  }
            //  int com = 1;
            //  for (int i = 0;i < A.Length; i++ )
            //  {
            //      if (A[i] % 2 == 0)
            //          com = (com * A[i]);
            //      else
            //          continue;
            //  }

            //  Console.WriteLine($"Максимальное {Max}, минимальное {Min}");
            //  Console.WriteLine($"Сумма: {sum}");
            //  Console.WriteLine($"Произведение: {com}");

            //  Random random = new Random();
            //  float[,] B = new float[3, 4];
            //  Console.WriteLine("\nДвумерный массив B (3 строки, 4 столбца):");
            //  for (int i = 0; i < B.GetLength(0); i++)
            //  {
            //      for (int j = 0; j < B.GetLength(1); j++)
            //      {
            //          B[i, j] = (float)(random.NextDouble() * 10);
            //      }
            //  }
            //  float Bmax;
            //  float Bmin;
            //  Bmin = B[0, 0];
            //  Bmax = B[0, 0];
            //  for (int i = 0; i < B.GetLength(0); i++)
            //  {
            //      for (int j = 0; j < B.GetLength(1); j++)
            //          if (Bmin > B[i, j])
            //          {
            //              Bmin = B[i, j];
            //          }
            //          else if (Bmax < B[i, j])
            //          {
            //              Bmax = B[i,j];
            //      }
            //  }
            // float sum2 = 0;
            //  for (int i = 0; i < B.GetLength(0); i++)
            //  {
            //      for (int j = 0;j < B.GetLength(1); j++)
            //      {
            //          sum2 += B[i, j];
            //      }

            //  }


            //  Console.WriteLine("\nМассив A:");
            //  foreach (var item in A)
            //  {
            //      Console.Write(item + " ");
            //  }

            //  Console.WriteLine("\nМассив B:");
            //  for (int i = 0; i < B.GetLength(0); i++)
            //  {
            //      for (int j = 0; j < B.GetLength(1); j++)
            //      {
            //          Console.Write($"{B[i, j]:F2} "); 
            //      }
            //      Console.WriteLine();
            //  }
            //  float com2 = 1;
            //  for (int i = 0; i < B.GetLength(0); i++)
            //  {
            //      for (int j = 0; j < B.GetLength(1); j++)
            //      {
            //         if (j % 2 == 0)
            //              com2 *= B[i, j];


            //      }
            //  }
            //Console.WriteLine($"Максимальное: {Bmax}, минимальное: {Bmin}");
            //Console.WriteLine($"Сумма: {sum2}");
            //Console.WriteLine($"Проиведение: {com2}");
            #endregion
            #region 2 задание
            //Random random = new Random();
            //float[,] B = new float[5, 5];
            //Console.WriteLine("\nДвумерный массив B (5 строк, 5 столбцов):");
            //for (int i = 0; i < B.GetLength(0); i++)
            //{
            //    for (int j = 0; j < B.GetLength(1); j++)
            //    {


            //        B[i, j] = (float)(random.NextDouble() + random.Next(-100, 100));




            //    }
            //}
            //float Bmax;
            //float Bmin;
            //Bmin = B[0, 0];
            //Bmax = B[0, 0];
            //for (int i = 0; i < B.GetLength(0); i++)
            //{
            //    for (int j = 0; j < B.GetLength(1); j++)
            //        if (Bmin > B[i, j])
            //        {
            //            Bmin = B[i, j];
            //        }
            //        else if (Bmax < B[i, j])
            //        {
            //            Bmax = B[i, j];
            //        }
            //}
            //float sum = 0;
            //for (float i = 0; i < B.GetLength(0); i++)
            //{
            //    for (float j = 0; j < B.GetLength(1); j++)
            //    {
            //        for (float k = Bmin; k < Bmax; k++)
            //        {
            //            sum += B[(int)i, (int)j];
            //        }
            //    }
            //}

            //    Console.WriteLine("\nМассив 5x5:");
            //    for (int i = 0; i < B.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < B.GetLength(1); j++)
            //        {
            //            Console.Write($"{B[i, j]:F2} ");
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine($"Максимальное: {Bmax}, минимальное: {Bmin}");
            //Console.WriteLine($"Сумма: {sum}") ;
            #endregion
            #region 3 задание
            string originalText = "Hello World!";
            int key = 2;

            string encryptedText = Caesar(originalText, key);
            Console.WriteLine("Encrypted Text: " + encryptedText);
            string decryptedText = Caesar(encryptedText, -key);
            Console.WriteLine("Decrypted Text: " + decryptedText);

            #endregion
            #region 4 задание
            Random random = new Random();
            float[,] A = new float[3, 3];
            int a;
            Console.WriteLine("\nДвумерный массив B (3 строки, 3 столбца):");
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = (float)(random.NextDouble() * 10);
                    
                }
            }
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write($"{A[i, j]:F2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("На сколько желаете умножить матрицу А: ") ;
            a = int.Parse(Console.ReadLine());
            float itog;
            for (int i = 0; i < A.GetLength(0); i++ )
            {
                for (int j = 0;j < A.GetLength(1);j++)
                {
                   itog = A[i, j] * a;
                    A[i, j] = itog;
                }
            }
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write($"{A[i, j]:F2} ");
                }
                Console.WriteLine();
            }

            float[,] B = new float[3, 3];
            Console.WriteLine("\nДвумерный массив B (3 строки, 3 столбца):");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = (float)(random.NextDouble() * 10);
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write($"{B[i, j]:F2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            float[,] D = new float[3, 3];
            for (int i = 0; i < A.GetLength(0);i++)
            {
                for (int j = 0;j < A.GetLength(1);j++)
                {
                    D[i, j]= A[i, j] + B[i, j];
                    
                }
            }
            Console.WriteLine("Итог сложения двух матриц А и В: ");
            for (int i = 0; i < D.GetLength(0); i++)
            {
                for (int j = 0; j < D.GetLength(1); j++)
                {
                    Console.Write($"{D[i, j]:F2} ");
                }
                Console.WriteLine();
            }




            #endregion
        }
    }

    }


