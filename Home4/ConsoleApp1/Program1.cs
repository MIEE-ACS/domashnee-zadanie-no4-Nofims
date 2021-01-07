using System;


namespace ConsoleApp1
{
    class Program1
    {
        static void Main()
        {
            Console.Write("Введите количество чисел: ");
            int N;
            Random rnd = new Random();

            try
            {
                N = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong data!");
                Console.Write("\nВведите количество чисел (числом): ");
                N = int.Parse(Console.ReadLine());
                Console.ReadKey();
            }


            if (N <= 0)
            {
                Console.WriteLine("Введены неправельные данные!");
                Console.ReadKey();
            }
            else
            {
                int[] nums = new int[N];
                int max = Math.Abs(nums[0]);
                bool positiveinNums = false;//для проверки есть ли положителные числа в массиве

                //Заполняем массив и ищем максимальный по модулю элемент
                for (int i = 0; i < N; i++)
                {
                    nums[i] = rnd.Next(-10, 10);
                    Console.Write($"{nums[i]} ");
                    if (Math.Abs(nums[i]) > max)
                    {
                        max = nums[i];
                    }
                    if (nums[i] > 0) {positiveinNums = true;}
                }

                Console.WriteLine($"\n\nМаксимальный по модулю элемент: {max}\n");

                // Считаем сумму элементов между первыми положительными элементами (либо между пол.элем. и концом массива)
                if (positiveinNums)
                {
                    int firstPositive = 0;
                    for (int n = 0; n < N; n++)//ищем первое появление положительного числа
                    {
                        if(nums[n] > 0)
                        {
                            firstPositive = n;
                            break;
                        }
                    }                
                    int i = firstPositive;
                    int sum = 0;

                    if ((firstPositive != N - 1) || (firstPositive != N - 2 && (N - 1 <= 0)))
                    {
                        while (i != N - 1)
                        {
                            i++;
                            if (nums[i] > 0) { break; }
                            sum += nums[i];
                        }
                    }                 
                    Console.WriteLine($"Сумма элементов массива, расположенных между первым и вторым " +
                        $"положительными числами элементами: {sum}\n");
                }
                else { Console.WriteLine("В массиве нет положительных элементов!\n"); }

                Console.WriteLine("Отсортированный массив");

                int[] nums2 = new int[N];
                int j = 0;

                for (int m = 0; m < N; m++) //вписываем все числа кроме нулей
                { 
                    if (nums[m] != 0)
                    {
                        nums2[j] = nums[m];
                        j++;
                    }
                }

                int NumofNulls = N - j;

                for(int h = j; h <= NumofNulls; h++) //вписываем в конец нули
                {
                    nums2[h] = 0;
                }

                for (int l = 0; l < N; l++) { Console.Write($"{nums2[l]} "); }

                Console.ReadKey();
            }
                
            
        }
    }
}
