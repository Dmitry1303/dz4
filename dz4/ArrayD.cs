using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    class ArrayD
    {
        public static void Start()
        {

        }

        private int[,] _Elements;

        public int this[int index1, int index2]
        {
            // индексаторы
            get
            {
                if (index1 < 0 || index2 < 0)
                    throw new IndexOutOfRangeException("Индекс <0");
                if (index1 >= _Elements.GetLength(0) || index2 >= _Elements.GetLength(1))
                    throw new IndexOutOfRangeException("Индекс больше индекса массива");
                return _Elements[index1, index2];
            }
            set
            {
                if (index1 < 0 || index2 < 0)
                    throw new IndexOutOfRangeException("Индекс <0");
                if (index1 >= _Elements.GetLength(0) || index2 >= _Elements.GetLength(1))
                    throw new IndexOutOfRangeException("Индекс больше индекса массива");
                _Elements[index1, index2] = value;
            }
        }

        public int ElementsCount
        {
            get
            { return _Elements.Length; }
        }

        public ArrayD(int[,] Elements)
        {
            // простое создание массива
            if (Elements == null)
                throw new NullReferenceException("Указана пустая ссылка на массив");
            _Elements = Elements;
        }

        public ArrayD(int N, int Element)
        {
            //квадратная матрица из одинаковых чисел
            _Elements = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    _Elements[i, j] = Element;
        }

        public ArrayD(int N, int Min, int Max)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            //квадратная матрица из рандомных чисел
            _Elements = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    _Elements[i, j] = rnd.Next(Min, Max + 1); ;
        }

        public ArrayD(int N, int M, int Min, int Max)
        {
            // n - размерность m - размер
            Random rnd = new Random((int)DateTime.Now.Ticks);
            //квадратная матрица из одинаковых чисел
            _Elements = new int[N, M];
            try
            {
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M; j++)
                        _Elements[i, j] = rnd.Next(Min, Max + 1);
            }
            catch
            {
                Helps.Printm("Неверно задан минимум и максимум!!!");
                Helps.Pause();
                Environment.Exit(0); // выход
            }
        }

        public int SumAll()
        {
            // возвращает сумму элементов
            int summary = 0;
            foreach (int element in _Elements)
            {
                summary += element;
            }
            return summary;
        }

        public int SumAfter(int Limit)
        {
            // возвращает сумму элементов
            int summary = 0;
            foreach (int element in _Elements)
            {
                if (element > Limit)
                    summary += element;
            }
            return summary;
        }

        public int Min
        {
            // свойство - минимум
            get
            {
                int min = _Elements[0, 0]; //первый элемент для сравнения
                for (int i = 0; i < _Elements.GetLength(0); i++)
                    for (int j = 1; j < _Elements.GetLength(1); j++) // с 1 т.к. уже взяли первый элемент
                        if (_Elements[i, j] < min)
                            min = _Elements[i, j];
                return min;
            }
        }

        public int Max
        {
            // свойство - максимум
            get
            {
                int max = _Elements[0, 0]; //первый элемент для сравнения
                for (int i = 0; i < _Elements.GetLength(0); i++)
                    for (int j = 1; j < _Elements.GetLength(1); j++) // с 1 т.к. уже взяли первый элемент
                        if (_Elements[i, j] > max)
                            max = _Elements[i, j];
                return max;
            }
        }

        public string IndexOfMax(out int ind1, out int ind2)
        {
            string index_of_max = "Такого элемента не существует";

            int max = _Elements[0, 0]; //первый элемент для сравнения
            int n = 0;
            int m = 0;
            for (int i = 0; i < _Elements.GetLength(0); i++)
                for (int j = 1; j < _Elements.GetLength(1); j++) // с 1 т.к. уже взяли первый элемент
                    if (_Elements[i, j] > max)
                    {
                        max = _Elements[i, j];
                        n = i;
                        m = j;
                    }
            index_of_max = "[" + n + ";" + m + "]";
            ind1 = n;
            ind2 = m;
            return index_of_max;
        }
    }
}
