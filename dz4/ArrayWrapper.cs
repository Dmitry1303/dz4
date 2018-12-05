using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    class ArrayWrapper
    {
        public static void Test()
        {
            var int_elements = new int[40];

            ArrayWrapper array_wrapper = new ArrayWrapper(int_elements);
            //array_wrapper = new ArrayWrapper(null);
            array_wrapper.InitializeWithRandomNumbers(-70, 70);

            array_wrapper.SortArrayBubble();
            int a = 5;
            // Console.WriteLine(array_wrapper[5]);

            array_wrapper.SaveToFile("data.txt");

            var array_wrapper2 = ArrayWrapper.LoadFromFile("data.txt");
        }
        private int[] _Elements;

        public void Inverse()
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                _Elements[i] = -1 * _Elements[i];
            }
        }
        public void Multi(int mult)
        {
            for (int i = 0; i < ElementsCount; i++)
            {
                _Elements[i] = mult * _Elements[i];
            }
        }
        public int MaxCount
        {
            get
            {
                int maxcounter = 0;
                int maxval = int.MinValue;
                for (int i = 0; i < ElementsCount; i++)
                    if (_Elements[i] > maxval) maxval = _Elements[i];

                for (int i = 0; i < ElementsCount; i++)
                    if (_Elements[i] == maxval) maxcounter += 1;

                return maxcounter;
            }



        }
        public int this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException("Индекс <0");
                if (index >= _Elements.Length)
                    throw new IndexOutOfRangeException("Индекс больше индекса массива");
                return _Elements[index];
            }
            set
            {
                if (index < 0)
                    throw new IndexOutOfRangeException("Индекс <0");
                if (index >= _Elements.Length)
                    throw new IndexOutOfRangeException("Индекс больше индекса массива");
                _Elements[index] = value;
            }
        }


        public int ElementsCount
        {
            get
            { return _Elements.Length; }
        }
        public int ElementsSumm
        {
            get
            {
                int Sum = 0;
                for (int i = 0; i < ElementsCount; i++) { Sum += _Elements[i]; }
                return Sum;
            }
        }

        public ArrayWrapper(int[] Elements)
        {
            if (Elements == null)
                throw new NullReferenceException("Указана пустая ссылка на массив");
            _Elements = Elements;
        }

        public void InitializeWithRandomNumbers(int Min = -50, int Max = 50)
        {
            InitializeArray(_Elements, Min, Max);
        }

        public void SortStandart()
        {
            Array.Sort(_Elements);
        }

        public static void InitializeArray(int[] array, int min, int max)
        {
            var rnd = new Random((int)DateTime.Now.Ticks);

            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(min, max + 1);
                }
            }
            catch
            {
                Helps.Printm("Неверно задан минимум и максимум!!!");
                Helps.Pause();
                Environment.Exit(0); // выход
            }
        }

        public void SortArrayBubble()
        {
            bool do_work = true;

            while (do_work)
            {
                do_work = false;

                for (var i = 1; i < _Elements.Length; i++)
                {
                    var last = _Elements[i - 1];
                    var current = _Elements[i];

                    if (last > current) //знак который определяет сортировку массива
                    {
                        do_work = true;
                        _Elements[i - 1] = current;
                        _Elements[i] = last;
                    }
                }
            }
        }

        public void SaveToFile(string FilePath)
        {
            using (var file_stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(file_stream))
            {
                for (var i = 0; i < _Elements.Length; i++)
                {
                    writer.WriteLine(_Elements[i]);
                }
            }
        }

        public static ArrayWrapper LoadFromFile(string FilePath)
        {
            var list = new List<int>();
            using (var file_stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(file_stream))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = int.Parse(line);
                    list.Add(value);
                }
            }

            return new ArrayWrapper(list.ToArray());
        }
    }
}
