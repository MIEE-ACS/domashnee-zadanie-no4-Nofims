using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Как заполнить двумерный массив (10х10)?\n0-рандомно\n1-вручную\n2-готовый");
            int choise;
            int[][] arr = new int[10][];
            Random rnd = new Random();

            try
            {
                choise = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong data!");
                Console.WriteLine("\n0-рандомно\n1-вручную\n");
                choise = int.Parse(Console.ReadLine());
                Console.ReadKey();
            }

            if (choise == 0)//заполняем рандомно
            {
                for (int i = 0; i < 10; i++)
                {
                    int[] newarr = new int[10];
                    for (int j = 0; j < 10; j++)
                    {
                        newarr[j] = rnd.Next(0, 10);
                    }
                    arr[i] = newarr;
                }
            }

            else if (choise == 1)//заполняем вручную
            {

                Console.WriteLine("Пример ввода значений: 1 2 3\nВ массиве первый элемент строки будет равен 1, второй 2 и т.д.");
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine($"Введите 10 элементов {i + 1} строки (через пробел!) ");
                        arr[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                    }
                }
                catch
                {
                    Console.WriteLine("Проблема при вводе значений, перезапустите программу и попробуйте снова!");
                    Console.ReadKey();
                }

            }
            else if (choise == 2)//берём готовый
            {
                arr[0] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                arr[1] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                arr[2] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                arr[3] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                arr[4] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                arr[5] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                arr[6] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                arr[7] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                arr[8] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                arr[9] = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            }
            else { Console.WriteLine("Ну и чего вы добились? Теперь программа не заработает. Нужно было ввести 0 1 или 2"); Console.ReadKey(); }

            try//выводим массив
            {
                foreach (int[] row in arr)
                {
                    foreach (int number in row)
                    {
                        Console.Write($"{number} \t");
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Проблема при выводе значений, перезапустите программу и попробуйте снова!");
                Console.ReadKey();
            }

            try
            {
                arr = Smooth(arr);//сглаживаем

                Console.WriteLine("\nСглаженный массив:\n");
                foreach (int[] row in arr)
                {
                    foreach (int number in row)
                    {
                        Console.Write($"{number} \t");
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Проблема при сглаживании матрицы, это может говорить о том что в какой-то строке не 10 элементов." +
                    "\nПерезапустите программу и попробуйте снова!");
                Console.ReadKey();
            }


            int summ = 0;

            for (int l = 0; l < 10; l++)
                for (int m = 0; m < l; m++)
                    summ += Math.Abs(arr[l][m]);

            Console.WriteLine($"Сумма модулей элементов, расположенных ниже главной диагонали: {summ}");

            Console.ReadKey();
        }
        static int[][] Smooth(int[][] array)//функция для сглаживания
        {
            int[][] now = array;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    int avg = 0;
                    int elements_count = 0;

                    if (j - 1 >= 0)
                    {

                        if (i - 1 >= 0)
                        {
                            avg += array[i - 1][j - 1];
                            elements_count++;
                        }

                        avg += array[i][j - 1];
                        elements_count++;

                        if (i + 1 < 10)
                        {
                            avg += array[i + 1][j - 1];
                            elements_count++;
                        }
                    }

                    if (i - 1 >= 0)
                    {
                        avg += array[i - 1][j];
                        elements_count++;
                    }

                    if (i + 1 < 10)
                    {
                        avg += array[i + 1][j];
                        elements_count++;
                    }

                    if (j + 1 < 10)
                    {

                        if (i - 1 >= 0)
                        {
                            avg += array[i - 1][j + 1];
                            elements_count++;
                        }

                        avg += array[i][j + 1];
                        elements_count++;

                        if (i + 1 < 10)
                        {
                            avg += array[i + 1][j + 1];
                            elements_count++;
                        }
                    }

                    now[i][j] = avg / elements_count;
                }
            }    
            return now;
        }
    }
}
