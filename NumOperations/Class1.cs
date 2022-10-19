using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumOperations
{
    /// <summary>
    /// Библиотека упрощенных рутинных операций 
    /// </summary>
    public class Int
    {
        static Random random = new Random();

        /// <summary>
        /// Разбивает число int на цифры
        /// </summary>
        /// <param name="number">Исходное число</param>
        /// <returns>Возвращает массив цифр исходного числа</returns>
        public static int[] getLenght(int number)
        {
            number = Math.Abs(number);        

            if (number < 10)
            {
                return new int[] {number};
            }          

            var result = new int[(int)Math.Log10(number) + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[result.Length - i - 1] = number % 10;              
                number /= 10;
            }
            return result;
        }

        /// <summary>
        /// Определяет длину числа int
        /// </summary>
        /// <param name="number">Исходное число</param>
        /// <returns>Возвращает число, равное количеству цифр в исходном числе</returns>
        public static int lenght(int number)
        {
            number = Math.Abs(number);
            
            if (number < 10)
            {
                return 1;
            }

            var result = new int[(int)Math.Log10(number) + 1];

            return result.Length;
        }
        
        /// <summary>
        /// Выполняет математические операции над цифрами в числе
        /// </summary>
        /// <param name="value">Число</param>
        /// <param name="operation">Операция '+' '-' '/' '*'</param>
        /// <returns>Возвращает результат выполнения операции</returns>
        public static int Operation(int value, char operation)
        {
            int result = 0;

            int[] Outvalue = Int.getLenght(value);

            if (operation == '+')
            {                       
                for (int i = 0; i < Outvalue.Length; i++)
                {
                    result += Outvalue[i];
                }
                return result;
            }
            if (operation == '-')
            {
                result = Outvalue[0];

                for (int i = 1; i < Outvalue.Length; i++)
                {
                    result -= Outvalue[i];
                }
                return result;
            }
            if (operation == '/')
            {
                result = Outvalue[0];

                for (int i = 1; i < Outvalue.Length; i++)
                {
                    result /= Outvalue[i];
                }
                return result;
            }
            if (operation == '*')
            {
                result = Outvalue[0];

                for (int i = 1; i < Outvalue.Length; i++)
                {
                    result *= Outvalue[i];
                }
                return result;
            }
            return 0;
        }

        /// <summary>
        /// Поиск индекса указанного элемента в двумерном массиве
        /// </summary>
        /// <param name="Array">Двумерный массив</param>
        /// <param name="value">Искомый элемент</param>
        /// <returns>Возвращает одномерный массив с двумя элементами индекса (null в случае отсутствия искомого элемента)</returns>
        public static int[] getIndex<T>(int[,] Array, int value)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] == value)
                    {
                        int[] result = new int[2] { i, j }; 
                        return result;
                    }                
                }              
            }
            return null;
        }

        /// <summary>
        /// Генерирует двумерный массив, заполненный случайными числами 
        /// </summary>
        /// <param name="lenght0">Количество строк</param>
        /// <param name="lenght1">Количество столбцов</param>
        /// <param name="minValue">Минимальное значение генерации элементов (default = 10)</param>
        /// <param name="maxValue">Максимальное значение генерации элементов (default = 99)</param>
        /// <returns>Возвращает двумерный массив, заполненный случайными элементами</returns>
        public static int[,] getArray(int lenght0, int lenght1, int minValue = 10, int maxValue = 99)
        {           
            int[,] Array = new int[lenght0, lenght1];

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Array[i, j] = random.Next(minValue, maxValue);
                }
            }         
            return Array;
        }

        /// <summary>
        /// Генерирует одномерный массив, заполненный случайными числами 
        /// </summary>
        /// <param name="lenght0">Количество элементов</param>
        /// <param name="minValue">Минимальное значение генерации элементов</param>
        /// <param name="maxValue">Максимальное значение генерации элементов</param>
        /// <returns>Возвращает одномерный массив, заполненный случайными элементами</returns>
        public static int[] getArray(int lenght0, int minValue, int maxValue)
        {
            int[] Array = new int[lenght0];

            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = random.Next(minValue, maxValue);
            }
            return Array;
        }

        /// <summary>
        /// Выводит двумерный массив в консоль
        /// </summary>
        /// <param name="Array">Двумерный массив</param>
        public static void arrayPrint<T>(T[,] Array)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write(Array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выводит одномерный массив в консоль
        /// </summary>
        /// <param name="Array">Одномерный массив</param>
        public static void arrayPrint<T>(T[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write(Array[i] + " ");
            }
        }

        /// <summary>
        /// Изменяет размер двумерного массива
        /// </summary>
        /// <param name="Array">Двумерный массив</param>
        /// <param name="ySize">Новое количество строк</param>
        /// <param name="xSize">Новое количество столбцов</param>
        public static void Resize<T>(ref T[,] Array, int ySize, int xSize)
        {
            T[,] newArray = new T[ySize, xSize];
            for (int i = 0; i < Array.GetLength(0) && i < newArray.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1) && j < newArray.GetLength(1); j++)
                {
                    newArray[i, j] = Array[i, j];
                }
            }
            Array = newArray;
        }

        /// <summary>
        /// Изменяет элемент в указанном индексе двумерного массива
        /// </summary>
        /// <param name="Array">Двумерный массив</param>
        /// <param name="indexY">Строка</param>
        /// <param name="indexX">Столбец</param>
        /// <param name="Element">Элемент</param>
        public static void changeElement<T>(ref T[,] Array, int indexY, int indexX, T Element)
        {
            Array[indexY, indexX] = Element;
        }      

        /// <summary>
        /// Добавляет элемент по указанному индексу в одномерный массив
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array">Одномерный массив</param>
        /// <param name="index">Индекс</param>
        /// <param name="Element">Элемент</param>
        public static void addElement<T>(ref T[] Array, int index, T Element)
        {
            T[] newArray = new T[Array.Length + 1];

            newArray[index] = Element;

            for (int i = 0; i < index; i++)
                newArray[i] = Array[i];
            for (int j = index; j < Array.Length; j++)
                newArray[j + 1] = Array[j];
            
            Array = newArray;
        }

        /// <summary>
        /// Удаляет элемент по указанному индексу из одномерного массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array">Одномерный массив</param>
        /// <param name="index">Индекс</param>
        public static void deleteElement<T>(ref T[] Array, int index)
        {
            T[] newArray = new T[Array.Length - 1];

            for (int i = 0; i < index; i++)
                newArray[i] = Array[i];
            for (int j = index + 1; j < Array.Length; j++)
                newArray[j - 1] = Array[j];

            Array = newArray;
        }

        /// <summary>
        /// Удаляет первый элемент одномерного массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array">Одномерный массив</param>
        public static void deleteFirstElement<T>(ref T[] Array)
        {
            deleteElement(ref Array, 0);
        }

        /// <summary>
        /// Удаляет последний элемент одномерного массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array">Одномерный массив</param>
        public static void deleteLastElement<T>(ref T[] Array)
        {
            deleteElement(ref Array, Array.Length - 1);
        }

        /// <summary>
        /// Добавляет указанный элемент в начало одномерного массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array">Одномерный массив</param>
        /// <param name="Element">Элемент</param>
        public static void addFirstElement<T>(ref T[] Array, T Element)
        {
            addElement(ref Array, 0, Element);
        }

        /// <summary>
        /// Добавляет указанный элемент в конец одномерного массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array">Одномерный массив</param>
        /// <param name="Element">Элемент</param>
        public static void addLastElement<T>(ref T[] Array, T Element)
        {
            addElement(ref Array, Array.Length, Element);
        }

        /// <summary>
        /// Очищает элемент (set default) по указанному индексу в двумерном массиве
        /// </summary>
        /// <param name="Array">Двумерный массив</param>
        /// <param name="indexY">Строка</param>
        /// <param name="indexX">Столбец</param>
        public static void clearElement<T>(ref T[,] Array, int indexY, int indexX)
        {
            Array[indexY, indexX] = default;
        }

        /// <summary>
        /// Очищает элемент (set default) по указанному индексу в одномерном массиве
        /// </summary>
        /// <param name="Array">Одномерный массив</param>
        /// <param name="index">Индекс</param>
        public static void clearElement<T>(ref T[] Array, int index)
        {
            Array[index] = default;
        }
    }
}
