using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Linq;

namespace Domashka
{

    class DzTumak
    {
        /// <summary>
        /// Считает количество гласных и согласных букв в файле, а также другие символы, не являющиеся буквами
        /// </summary>
        /// <param name="file"></param>
        /// <param name="glasBukvi"></param>
        /// <param name="soglasBukvi"></param>
        /// <returns>Возвращает allOther - количество других символов, а две </returns>
        static int Schet(out int glasBukvi, out int soglasBukvi, params char[] file)
        {
            int allOther, kolvoTab;
            glasBukvi = 0;
            soglasBukvi = 0;
            allOther = 0;
            kolvoTab = 0;
            string allGlas = "EYUIOAУЕЫАОЭЯИЮЁ";
            string allSoglas = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩBCDFGHJKLMNPQRSTVWXZЪЬ";
            foreach (char c in file)
            {
                if (allGlas.Contains(c.ToString().ToUpper()))
                {
                    glasBukvi++;
                }
                else if (allSoglas.Contains(c.ToString().ToUpper()))
                {
                    soglasBukvi++;
                }
                else if (c == '\n')
                {
                    kolvoTab++;
                }
                else
                {
                    allOther++;
                }
            }
            return (allOther-kolvoTab);

        }
        /// <summary>
        /// К Д.З. 6.1. Все тоже самое что и в упр 6.1. но с List<T> !!!перегрузка
        /// </summary>
        /// <param name="file"></param>
        /// <param name="glasBukvi"></param>
        /// <param name="soglasBukvi"></param>
        /// <returns>Возвращает allOther - количество других символов, а две </returns>
        static int Schet(out int glasBukvi, out int soglasBukvi, List<char> file)
        {
            int allOther, kolvoTab;
            glasBukvi = 0;
            soglasBukvi = 0;
            allOther = 0;
            kolvoTab = 0;
            string allGlas = "EYUIOAУЕЫАОЭЯИЮЁ";
            string allSoglas = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩBCDFGHJKLMNPQRSTVWXZЪЬ";
            foreach (char c in file)
            {
                if (allGlas.Contains(c.ToString().ToUpper()))
                {
                    glasBukvi++;
                }
                else if (allSoglas.Contains(c.ToString().ToUpper()))
                {
                    soglasBukvi++;
                }
                else if (c == '\n')
                {
                    kolvoTab++;
                }
                else
                {
                    allOther++;
                }
            }
            return (allOther - kolvoTab);

        }
        /// <summary>
        /// Вычисляет матрицу, являющуюся произведением двух входных матриц 2 на 2
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns>Возвращает матрицу 2 на 2 равную произведению двух матриц</returns>
        static int[][] MatricProizv(int[][] mat1, int[][] mat2)
        {
            int[][] itogMatrica = new int[2][];
            itogMatrica[0] = new int[2];
            itogMatrica[1] = new int[2];
            itogMatrica[0][0] = mat1[0][0] * mat2[0][0] + mat1[0][1] * mat2[1][0];
            itogMatrica[0][1] = mat1[0][0] * mat2[1][0] + mat1[0][1] * mat2[1][1];
            itogMatrica[1][0] = mat1[1][0] * mat2[0][0] + mat1[1][0] * mat2[1][0];
            itogMatrica[1][1] = mat1[1][0] * mat2[0][1] + mat1[1][1] * mat2[1][1];
            return itogMatrica;
        }
        /// <summary>
        /// Тоже самое что и в упр.6.2. но с  LinkedList<LinkedList<int>>
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns>Возвращает  LinkedList<LinkedList<int>> матрицу</returns>
        static LinkedList<LinkedList<int>> MatricProizv(LinkedList<LinkedList<int>> mat1, LinkedList<LinkedList<int>> mat2)
        {
            LinkedList<LinkedList<int>> itogMat = new LinkedList<LinkedList<int>>();
            LinkedList<int> matTest1 = new LinkedList<int>();
            LinkedList<int> matTest2 = new LinkedList<int>();
            matTest1.AddLast(mat1.First().First() * mat2.First().First() + mat1.First().Last() * mat2.Last().First());
            matTest1.AddLast(mat1.First().First() * mat2.Last().First() + mat1.First().Last() * mat2.Last().Last());
            matTest2.AddLast(mat1.Last().First() * mat2.First().First() + mat1.Last().First() * mat2.Last().First());
            matTest2.AddLast(mat1.Last().First() * mat2.First().Last() + mat1.Last().Last() * mat2.Last().Last());
            itogMat.AddLast(matTest1);
            itogMat.AddLast(matTest2);
            return itogMat;

        }
        /// <summary>
        /// Выводит на экран матрицу
        /// </summary>
        /// <param name="mat1"></param>
        static void MatricPrint(int[][] mat1)
        {
            int count = 0;
            for (int i = 0; i < mat1.Length; i++)
            {
                for (int j = 0; j < mat1[i].Length; j++)
                {
                    if (count % mat1[i].Length == 0 && count != 0)
                    {
                        Console.Write("\n");
                    }
                    Console.Write($"{mat1[i][j]} ");
                    count++;
                }
            }
        }
        /// <summary>
        /// К Д.З. 6.2. Тоже самое что и MatrixPrint(int[][]) но с LinkedList<LinkedList<int>>
        /// </summary>
        /// <param name="mat"></param>
        static void MatricPrint(LinkedList<LinkedList<int>> mat)
        {
            foreach (LinkedList<int> matric in mat)
            {
                Console.WriteLine($"{matric.First()} {matric.Last()}");
            }
        }
        /// <summary>
        /// Вычисляет средние температуры дней в месяцах, заданных в виде двумерного массива вида [номер месяца][номер дня]
        /// </summary>
        /// <param name="temps"></param>
        /// <returns>Возвращает массив средних температур дней в месяцах</returns>
        static double[] SrTempMonths(int[][] temps)
        {
            double[] temp = new double[temps.Length];
            for (int i = 0; i < temps.Length; i++)
            {
                temp[i] = temps[i].Average();
            }
            return temp;
        }
        /// <summary>
        /// Подсчитывает для каждого Key среднее значение температур
        /// </summary>
        /// <param name="temps"></param>
        /// <returns>Возвращает словарь вида <месяц, его средняя температура></returns>
        static Dictionary<string, double> SrTempMonths(Dictionary<string, int[]> temps)
        {
            Dictionary<string, double> srTemp = new Dictionary<string, double>();
            foreach (string i in temps.Keys)
            {
                srTemp.Add(i, temps[i].Average());
            }
            return srTemp;
        }
        static void Main(string[] args)
        {
            Zadanie1();
            Zadanie2();
            Zadanie3();
            Zadanie4();
            Zadanie5();
            Zadanie6();


        }
        static void Zadanie1()
        {
            /*Упражнение 6.1 Написать программу, которая вычисляет число гласных и согласных букв в
            файле. Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла
            заносится в массив символов. Количество гласных и согласных букв определяется проходом
            по массиву. Предусмотреть метод, входным параметром которого является массив символов.
            Метод вычисляет количество гласных и согласных букв.*/
            Console.WriteLine("\nУпражнение 6.1. Создание метода подсчета гласных и согласных букв в файле\n");
            string target = Path.GetFullPath("Zad1.txt").Replace("bin\\Debug\\net8.0\\", "");
            int glasBukvi, soglasBukvi;
            char[] file = File.ReadAllText(target).ToUpper().ToCharArray();
            int others = Schet(out glasBukvi, out soglasBukvi, file);
            Console.WriteLine($"Количество гласных: {glasBukvi}\nКоличество согласных: {soglasBukvi}\nКоличество других символов: {others}");
            Console.WriteLine($"Текст в файле:\n{File.ReadAllText(target)}");
        }
        static void Zadanie2()
        {
            /*Упражнение 6.2 Написать программу, реализующую умножению двух матриц, заданных в
            виде двумерного массива. В программе предусмотреть два метода: метод печати матрицы,
            метод умножения матриц (на вход две матрицы, возвращаемое значение – матрица).*/
            Console.WriteLine("\nУпражнение 6.2. Умножение двух матриц\n");
            int[][] matrica1 = new int[2][];
            matrica1[0] = new int[2];
            matrica1[1] = new int[2];
            int[][] matrica2 = new int[2][];
            matrica2[0] = new int[2];
            matrica2[1] = new int[2];
            matrica1[0][0] = 1;
            matrica1[0][1] = 2;
            matrica1[1][0] = 3;
            matrica1[1][1] = 4;
            matrica2[0][0] = 5;
            matrica2[0][1] = 6;
            matrica2[1][0] = 7;
            matrica2[1][1] = 8;
            Console.WriteLine("Произведение матрицы");
            MatricPrint(matrica1);
            Console.WriteLine("\nи матрицы");
            MatricPrint(matrica2);
            Console.WriteLine("\nравно");
            MatricPrint(MatricProizv(matrica1, matrica2));
        }
        static void Zadanie3()
        {
            /*Упражнение 6.3 Написать программу, вычисляющую среднюю температуру за год. Создать
            двумерный рандомный массив temperature[12,30], в котором будет храниться температура
            для каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать
            значения температур случайным образом. Для каждого месяца распечатать среднюю
            температуру. Для этого написать метод, который по массиву temperature [12,30] для каждого
            месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
            средних температур. Полученный массив средних температур отсортировать по
            возрастанию.*/
            Console.WriteLine("\nУпражнение 6.3. Поиск средних температур, записанных в виде двумерного массива\n");
            int[][] tempMonths = new int[12][];
            Random rand = new Random();
            for (int i = 0; i < tempMonths.Length; i++)
            {
                tempMonths[i] = new int[30];
            }
            for (int i = 0; i < tempMonths.Length; i++)
            {
                for (int j = 0; j < tempMonths[i].Length; j++)
                {
                    tempMonths[i][j] = rand.Next(-30, 100);
                }
            }
            double[] temp = SrTempMonths(tempMonths);
            Array.Sort(temp);
            for (int i = 0; i < temp.Length; i++)
            {
                Console.WriteLine(temp[i]);
            }
        }
        static void Zadanie4()
        {
            /*Домашнее задание 6.1 Упражнение 6.1 выполнить с помощью коллекции List<T>.*/
            Console.WriteLine("\nДомашнее задание 6.1. Заменить в упражнении 6.1. аргумент на List<T>\n");
            Console.WriteLine("\nУпражнение 6.1. Создание метода подсчета гласных и согласных букв в файле\n");
            string target = Path.GetFullPath("Zad1.txt").Replace("bin\\Debug\\net8.0\\", "");
            int glasBukvi, soglasBukvi;
            List<char> file = File.ReadAllText(target).ToUpper().ToList();
            int others = Schet(out glasBukvi, out soglasBukvi, file);
            Console.WriteLine($"Количество гласных: {glasBukvi}\nКоличество согласных: {soglasBukvi}\nКоличество других символов: {others}");
            Console.WriteLine($"Текст в файле:\n{File.ReadAllText(target)}");
        }
        static void Zadanie5()
        {
            /*Домашнее задание 6.2 Упражнение 6.2 выполнить с помощью коллекций
            LinkedList<LinkedList<T>>.*/
            Console.WriteLine("\nДомашнее задание 6.2. упр. 6.2. но с LinkedList<LinkedList<T>>\n");
            LinkedList<LinkedList<int>> matric1 = new LinkedList<LinkedList<int>>();
            LinkedList<int> matTest11 = new LinkedList<int>();
            LinkedList<int> matTest12 = new LinkedList<int>();
            matTest11.AddLast(1);
            matTest11.AddLast(2);
            matTest12.AddLast(3);
            matTest12.AddLast(4);
            matric1.AddLast(matTest11);
            matric1.AddLast(matTest12);
            LinkedList<LinkedList<int>> matric2 = new LinkedList<LinkedList<int>>();
            LinkedList<int> matTest21 = new LinkedList<int>();
            LinkedList<int> matTest22 = new LinkedList<int>();
            matTest21.AddLast(5);
            matTest21.AddLast(6);
            matTest22.AddLast(7);
            matTest22.AddLast(8);
            matric2.AddLast(matTest21);
            matric2.AddLast(matTest22);
            Console.WriteLine("Произведение матрицы");
            MatricPrint(matric1);
            Console.WriteLine("и матрицы");
            MatricPrint(matric2);
            Console.WriteLine("равно матрице");
            MatricPrint(MatricProizv(matric1, matric2));
        }
        static void Zadanie6()
        {
            /*Домашнее задание 6.3 Написать программу для упражнения 6.3, использовав класс
            Dictionary<TKey, TValue>. В качестве ключей выбрать строки – названия месяцев, а в
            качестве значений – массив значений температур по дням.*/
            Console.WriteLine("Домашнее задание 6.3. упр.6.3. только со словарем");
            Dictionary<string, int[]> months = new Dictionary<string, int[]>();
            Random rand = new Random();
            string[] allMonths = new string[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            foreach (string month in allMonths)
            {
                months.Add(month, new int[30]);
                for (int i = 0; i <  months[month].Length; i++)
                {
                    months[month][i] = rand.Next(-30,100);
                }
            }
            foreach (KeyValuePair<string, int[]> i in months)
            {
                Console.Write($"\n{i.Key}: ");
                foreach (int j in i.Value)
                {
                    Console.Write($"{j} ");
                }
            }
            Dictionary<string, double> temps = SrTempMonths(months);
            foreach (string i in temps.Keys)
            {
                Console.WriteLine($"\nМесяц - {i} ; Среднее значение - {temps[i]}");
            }
        }
    }
}
