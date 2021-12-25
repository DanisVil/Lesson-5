using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Homework.exe "vowels consonant.TXT"
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    string text = File.ReadAllText(args[0]);
                    int[] vc = CountVowelsAndConsonant(text.ToCharArray());
                    Console.WriteLine($"Гласных - {vc[0]}, согласных - {vc[1]}");
                }
            }
            int[,] a = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int[,] b = new int[2, 3] { { 7, 9, 11 }, { 8, 10, 12 } };
            int[,] c = MultiplyMatricies(a, b);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(c[i, j] + " ");
                }
                Console.WriteLine();
            }

            int[,] temperature = new int[12, 30];
            Random rand = new Random();
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = rand.Next(-25, 30);
                    Console.Write(temperature[i, j] + " ");
                }
                Console.WriteLine();
            }
            double[] average = GetAverageTemp(temperature);
            foreach (var month in average)
            {
                Console.Write(month + " ");
            }
            Console.WriteLine("\n\n\n");

            Console.WriteLine(FromStringToChar("11100000"));

            Console.ReadKey();
        }
        public static int[] CountVowelsAndConsonant(char[] symbols)
        {
            string vowels = "ауоыэяюёиеaeiou";
            string consonant = "бвгджзйклмнпрстфхцчшщBCDFGHJKLMNPQRSTVWXYZ".ToLower();
            int vowelsCount = 0, consonantCount = 0;
            foreach (char symbol in symbols)
            {
                if (vowels.Contains(symbol))
                {
                    vowelsCount++;
                }
                else if (consonant.Contains(symbol))
                {
                    consonantCount++;
                }
            }
            return new int[2] { vowelsCount, consonantCount };
        }
        public static List<int> CountVowelsAndConsonant(List<char> symbols)
        {
            string vowels = "ауоыэяюёиеaeiou";
            string consonant = "бвгджзйклмнпрстфхцчшщBCDFGHJKLMNPQRSTVWXYZ".ToLower();
            int vowelsCount = 0, consonantCount = 0;
            foreach (char symbol in symbols)
            {
                if (vowels.Contains(symbol))
                {
                    vowelsCount++;
                }
                else if (consonant.Contains(symbol))
                {
                    consonantCount++;
                }
            }
            return new List<int> { vowelsCount, consonantCount };
        }
        public static int[,] MultiplyMatricies(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1).Equals(matrix2.GetLength(0)))
            {
                int[,] product = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        int linearCombination = 0;
                        for (int k = 0; k < matrix1.GetLength(1); k++)
                        {
                            linearCombination += matrix1[i, k] * matrix2[k, j];
                        }
                        product[i, j] = linearCombination;
                    }
                }
                return product;
            }
            throw new Exception("InvalidMatriciesMultiplication");
        }
        public static double[] GetAverageTemp(int[,] temperature)
        {
            double[] average = new double[12];
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                double tempSum = 0;
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    tempSum += temperature[i, j];
                }
                average[i] = tempSum / temperature.GetLength(1);
            }
            Array.Sort(average);
            return average;
        }
        public static List<double> GetAvgTempByDictionary(Dictionary<string, int[]> temps)
        {
            List<double> average = new List<double>();
            foreach (var key in temps.Keys)
            {
                double tempSum = 0;
                for (int i = 0; i < temps[key].Length; i++)
                {
                    tempSum += temps[key][i];
                }
                average.Add(tempSum / temps[key].Length);
            }
            return average;
        }
        public static char FromStringToChar(string str)
        {
            int a = 0;
            for (int i = 0; i < 8; i++)
            {
                int digit = str[i] - '0';
                a += digit * (int)Math.Pow(2, 7 - i);
            }
            char b = (char)a;
            return b;
        }
    }
}
