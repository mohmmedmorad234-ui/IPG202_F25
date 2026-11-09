using System;
using System.Text;

namespace ProceduralProgrammingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;


            int M = 4;
            int N = 5;

            // 1. استدعاء دالة التهيئة المطورة (المدمج بها تصحيح كود الطلاب لتوليد الصناديق التالفة -1)
            int[,] mailBoxes = InitializeBoxes(M, N);

            Console.WriteLine("شبكة الصناديق عند التهيئة (قبل الموازنة):");
            PrintBoxes(mailBoxes);

            // 2. استدعاء دالة الموازنة التلقائية المعتمدة في الحل
            BalanceRowWeights(mailBoxes);

            Console.WriteLine("\nشبكة الصناديق بعد عملية الموازنة التلقائية:");
            PrintBoxes(mailBoxes);



            string originalText = "Programming in Csharp is beautiful and fun";
            int shiftKey = 3;
            Console.WriteLine($"النص الأصلي المطلوب تشفيره:\n{originalText}");


            string encryptedText = EncryptText(originalText, shiftKey);
            Console.WriteLine($"\nالنص بعد التشفير (Encrypt):\n{encryptedText}");

            string decryptedText = DecryptText(encryptedText, shiftKey);
            Console.WriteLine($"\nالنص بعد فك التشفير (Decrypt):\n{decryptedText}");

            Console.WriteLine("\n==========================================================");
            Console.WriteLine("اضغط على أي مفتاح لإغلاق البرنامج...");
            Console.ReadKey();
        }


        // 1. دالة التهيئة: تعبئة مصفوفة الصناديق
        static int[,] InitializeBoxes(int m, int n)
        {
            int[,] matrix = new int[m, n];
            Random rand = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(-1, 52);
                }
            }
            return matrix;
        }

        // 2. دالة الموازنة التلقائية
        static void BalanceRowWeights(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 30)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            if (matrix[i, k] == 0)
                            {
                                matrix[i, k] = matrix[i, j];
                                matrix[i, j] = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        // 3. دالة طباعة مصفوفة الصناديق
        static void PrintBoxes(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }