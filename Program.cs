using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            int N = Program.InputN();
            int[,] Matrix = Program.InputMatrix(N);

            
            int CheckContinue = 0;
            for (int a = 0; a < N - 1; a++)
            {
                for (int m = 0; m < a + 1; m++)
                {
                    for (int n = 0; n < a + 1; n++)
                    {

                        int[,] Submatrix = new int[N - a, N - a];
                        for (int i = 0; i < N - a; i++)
                        {
                            for (int j = 0; j < N - a; j++)
                            {

                                Submatrix[i, j] = Matrix[i + m, j + n];
                            }
                        }
                        if (CheckTotalDiagonal(Submatrix))
                        {
                            CheckContinue = CheckContinue + 1;
                            Console.WriteLine("Kết quả là: ");
                            Program.PrintMatrix(Submatrix);
                        }
                        if (CheckContinue == 1)
                        {
                            break;
                        }
                    }
                    if (CheckContinue == 1)
                    {
                        break;
                    }
                }
                if (CheckContinue == 1)
                {
                    break;
                }
            }
            if (CheckContinue == 0)
            {
                Console.WriteLine("Không có ma trận con nào thỏa mãn bài toán");
            }
        }


        static int InputN()
        {
            int N;
        InputN:
            Console.WriteLine("Nhập vào số tự nhiên N: ");
            string NInput = Console.ReadLine();
            try
            {
                N = Int32.Parse(NInput);
                if (N < 2 || N > 20)
                {
                    Console.WriteLine("N trong khoảng từ 2 tới 20");
                    goto InputN;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Đầu vào không phù hợp. Vui lòng nhập lại !");
                goto InputN;
            }
            return N;
        }

        static int[,] InputMatrix(int N)
        {
            InputMatrix:
            Console.OutputEncoding = Encoding.UTF8;
            int[,] matrixn = new int[N, N];
            try
            {
                Console.WriteLine("Người dùng nhập vào các phần tử của ma trận: ");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write("Nhập a[{0},{1}]=", i, j);
                        matrixn[i, j] = Convert.ToInt32(Console.ReadLine());

                    }
                }
                Console.WriteLine("Ma trận vừa nhập là: ");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write("{0,4}", matrixn[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Nhập sai kiểu dữ liệu là kiểu nguyên");
                goto InputMatrix;
            }
            return matrixn;
        }

        static void PrintMatrix(int[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}",Matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool CheckTotalDiagonal(int[,] Matrix)
        {
            int Td1 = 0;
            int Td2 = 0;

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                Td1 = Td1 + Matrix[i, i];
            }

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                Td2 = Td2 + Matrix[i, Matrix.GetLength(1) - i - 1];
            }

            if (Td1 == Td2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}


