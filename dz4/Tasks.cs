using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    class Tasks
    {
        public static void Run()
        {
            do
            {
                switch (Helps.Msg_int("Выберите задачу 1,2,3 или 4:"))
                {
                    case 1:
                        Z1();
                        break;
                    case 2:
                        Z2();
                        break;
                    case 3:
                        Accs();
                        break;
                    case 4:
                        Z4();
                        break;
                    default:
                        break;
                }
            } while (Helps.Msg_int("1 - еще раз все задачи") == 1);

            Helps.Pause();


        }

        public static void Z1() //задача с массивом
        {
            int[] count_el = new int[20];
            ArrayWrapper Arr = new ArrayWrapper(count_el);
            Arr.InitializeWithRandomNumbers(-10_000, 10_000);

            int counter = 0;
            int totalcounter = 0;
            //Arr.Inverse();

            // Цикл пробега по элементам
            for (int i = 1; i < Arr.ElementsCount; i++)
            {
                totalcounter += 1;
                bool aski = (Arr[i - 1] % 3 == 0) || (Arr[i] % 3 == 0);
                counter = aski ? counter + 1 : counter + 0;
                //тернарный оператор
            }
            Helps.Printm($"Количество пар, в которых один из элементов делится на 3: {counter}\nВсего пар: {totalcounter}\n");

        }

        public static void Z2()
        {
            int[] count_el = new int[Helps.Msg_int("Введите размерность массива: ")];
            ArrayWrapper Arr = new ArrayWrapper(count_el);
            Arr.InitializeWithRandomNumbers(Helps.Msg_int("Введите min: "), Helps.Msg_int("Введите max: "));
            Helps.Printm($"Сумма элементов массива: {Arr.ElementsSumm}\n" +
                $"Количество элементов массива: {Arr.ElementsCount}\n" +
                $"Количество максимальных элементов: {Arr.MaxCount}\n" +
                $"Первый элемент массива: {Arr[0]}\n");
            Arr.Inverse();
            Helps.Printm($"Массив инвертирован!\nПервый элемент массива: {Arr[0]}\n");
            Arr.Multi(Helps.Msg_int("Введите число для умножения: "));
            Helps.Printm($"Умножение произведено!\nПервый элемент массива: {Arr[0]}\n");
            Arr.SaveToFile(Helps.Msg_string("Введите название файла для сохранения: "));
            ArrayWrapper array2 = ArrayWrapper.LoadFromFile(Helps.Msg_string("Введите название файла для выгрузки массива: "));
            Helps.Printm($"Сумма элементов массива: {Arr.ElementsSumm}\n" +
                $"Количество элементов массива: {Arr.ElementsCount}\n" +
                $"Количество максимальных элементов: {Arr.MaxCount}\n" +
                $"Первый элемент массива: {Arr[0]}\n");
        }

        static void Accs() // автоматический подбор логинов и паролей 
        {
            bool result = false;
            int count = 1;
            string[,] account_mass = Helps.LoadFromFile(Helps.Msg_string("Введите название файла(аккаунты в файле datapc.txt)"));
            // получился практически подборщик логинов и паролей :-)
            for (int i = 0; i < account_mass.GetLength(1); i++)
            {
                Account[] Accounts = new Account[account_mass.GetLength(1)]; //создаем массив Аккаунтов с размером - account_mass.GetLength(1)
                Accounts[i].Login = account_mass[0, i];
                Accounts[i].Password = account_mass[1, i];

                result = Z3(Accounts[i].Login, Accounts[i].Password); // момент вставки кода в *окно* логина и 

                if (result == true)
                {

                    Helps.Printm($"Подключение: {result}\n");
                    Helps.Printm($"{Accounts[i].ToString()}\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно! Осталось попыток {0}", 3 - count);
                    count++;
                }
            }
        }
        static bool Z3(string x, string y)
        {
            Helps.Printm($"Логин: {x}\n");
            Helps.Printm($"Пароль: {y}\n");
            if (x.Equals("root") && y.Equals("GeekBrains"))
            {
                return true;
            }
            return false;
        }
        public static void Z4()
        {
            //int[,] mass = new int[Helps.Msg_int("Введите размерность массива: ")
            //                     ,Helps.Msg_int("Введите размер массива: ")];
            //ArrayD massive1 = new ArrayD(5, 2, -50, 50);
            //ArrayD massive2 = new ArrayD(5, -100, 50);
            //ArrayD massive3 = new ArrayD(5,5);
            do
            {
                ArrayD massive = new ArrayD(Helps.Msg_int("Введите размерность массива:")
                                 , Helps.Msg_int("Введите размер массива: ")
                                 , Helps.Msg_int("Введите минимум: ")
                                 , Helps.Msg_int("Введите максимум: "));
                switch (Helps.Msg_int("1 - сумма всех элементов\n" +
                                    "2 - сумма всех элементов больше заданного\n" +
                                    "3-минимум, максимум и номер максимального элемента\n"))
                {
                    case 1:
                        Helps.Printm($"Сумма всех элементов: {massive.SumAll()}\n");
                        break;
                    case 2:
                        Helps.Printm("Сумма всех элементов: " +
                            $"{massive.SumAfter(Helps.Msg_int("Задайте число:"))}\n");
                        break;
                    case 3:
                        Helps.Printm($"Минимум: {massive.Min}\n" +
                            $"Максимум: {massive.Max}\n" +
                            $"Номер максимального элемента: {massive.IndexOfMax(out int index1,out int index2)}\n" +
                            $"Индексы в виде out int:\n" +
                            $"index1: {index1}\n" +
                            $"index2: {index2}\n");
                        break;
                    default:
                        break;
                }
            } while (Helps.Msg_int("1 - еще раз задачу\n") == 1);
            Helps.Pause();
        }
    }
}
