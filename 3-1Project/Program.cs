﻿// See https://aka.ms/new-console-template for more information
 using System;

namespace Task31
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Двумерные  массивы");
            Console.WriteLine("Введите количество элементов в строке.");
            int colomnsN = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество элементов в столбце.");
            int linesM = int.Parse(Console.ReadLine());
            bool WayInpArr2D;
            Console.WriteLine("Хотите сами ввести массив? + = да, - = нет");
            if (Console.ReadLine() == "+")
            {
                WayInpArr2D = true;
            }
            else
            {
                WayInpArr2D = false;
            }
            TwoDimentionArr twoD = new TwoDimentionArr(colomnsN, linesM);
            twoD.TwoDimentionArrINP(WayInpArr2D, colomnsN, linesM);
            Console.WriteLine("Массив: ");
            twoD.TwoDimentionArrOUTPUT(colomnsN,linesM);
            Console.WriteLine("Среднее арифметическое элементов: " + twoD.countAverage(colomnsN, linesM));
            Console.WriteLine("Массив, в котором элементы четных строк напечатаны в обратном порядке: ");
            twoD.PrintArrBackw(colomnsN, linesM);
            //одномерные
            Console.WriteLine("Одномерные  массивы");
            Console.WriteLine("Введите количество элементов.");
            int ElementsNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Хотите сами ввести массив? + = да, - = нет");
            bool WayInpArr1D;
            if (Console.ReadLine() == "+")
            {
                WayInpArr1D = true;
            }
            else
            {
                WayInpArr1D = false;
            }
            OneDimentionArr oneD = new OneDimentionArr(ElementsNumber, WayInpArr1D);
            oneD.OneDimentionArrINP(ElementsNumber, WayInpArr1D);
            Console.WriteLine("Среднее арифметическое элементов: " + oneD.countAverage(ElementsNumber));
            Console.WriteLine("Массив, из которого удалили элементы, большие 100 по модулю: " + oneD.DeleteMoreThan100(ElementsNumber));
            Console.WriteLine("Массив, из которого удалили повторяющиеся элементы: " + oneD.DeleteTheRepeating(ElementsNumber));
            //ступенчатые
            Console.WriteLine("Ступенчатые  массивы");
            bool WayInpStepped;
            Console.WriteLine("Хотите сами ввести массив? + = да, - = нет");
            if (Console.ReadLine() == "+")
            {
                WayInpStepped= true;
            }
            else
            {
                WayInpStepped = false;
            }
            Console.WriteLine("Введите количество строк");
            int colN = int.Parse(Console.ReadLine());
            SteppedArray st = new SteppedArray(colN);
            st.SteppedINP(WayInpStepped, colN);
            Console.WriteLine("Массив: ");
            st.SteppedOUTPUT(colN);
            Console.WriteLine("Среднее арифметическое элементов: " + st.countAverage(colomnsN));
            Console.WriteLine("Средние арифметические строк массива");
            st.AverageInEveryStepped (colN);
            Console.WriteLine("Массив, в котором четные по значению элементы массива заменены на произведения их индексов");
            st.ChangeInd(colN);
            st.SteppedOUTPUT(colN);
        }
    }

    class OneDimentionArr
    {
        private int[] array = new int[100];
        public bool WayOfInputtingTheArray = false;
        int ElementsNumber;
        Random rnd = new Random();
        public OneDimentionArr(int ElementsNumber, bool WayOfInputtingTheArray)
        {
            //Console.WriteLine("Введите количество элементов.")
            //ElementsNumber = Console.ReadLine();
        }

        public void OneDimentionArrINP(int ElementsNumber, bool WayOfInputtingTheArray)
        {
            if (WayOfInputtingTheArray == false)
            {
                for (int i = 0; i < ElementsNumber; i++)
                {
                    array[i] = rnd.Next(-100, 100);
                }
            }
            else
            {
                for (int i = 0; i < ElementsNumber; i++)
                {
                    array[i] = int.Parse(Console.ReadLine());
                }
            }
        }

        private void oneDimentionArrOUTPUT(int ElementsNumber)
        {
            for (int i = 0; i < ElementsNumber; i++)
            {
                Console.WriteLine(array[i] + " ");
            }
        }
        public double countAverage(int ElementsNumber)
        {
            int m = 0;
            int k = 0;
            for (int i = 0; i < ElementsNumber; i++)
            {
                k += array[i];
                m++;
            }
            return k / m;
        }

        public string DeleteMoreThan100(int ElementsNumber)
        {
            string line = "";
            for (int i = 0; i < ElementsNumber; i++)
            {
                if (array[i] < 100 && array[i] > -100)
                {
                    line += array[i].ToString();
                    line += " ";
                }
            }
            return line;
        }

        public string DeleteTheRepeating(int ElementsNumber)
        {
            int[] arr = new int[100];
            string line = "";
            int t = 0;
            int[] b = array;
            for (int i = 0; i < ElementsNumber; i++)
            {
                if (Check(arr, b[i]) == false)
                {
                    arr[t] = b[i];
                    t++;
                    line += b[i];
                    line += " ";
                }
            }
            return line;
        }
            //static
            bool Check(int[] arr, int k)
            
            {
                foreach (int i in arr)
                {
                    if (i == k)
                        return true;
                }
                return false;
            }
            
        
    }

    class TwoDimentionArr
    {
        public int colomnsN, linesN;
        public int[,] array;
        Random rnd = new Random();
        public bool WayOfInputtingTheArray = false;
        public TwoDimentionArr(int colomnsN, int linesM)
        {


            array = new int[colomnsN, linesM];
        }

        public void TwoDimentionArrINP(bool WayOfInputtingTheArray, int colomnsN, int linesM)
        {
            if (WayOfInputtingTheArray == false)
            {
                for (int i = 0; i < colomnsN; i++)
                {
                    for (int j = 0; j < linesM; j++)
                    {
                        array[i, j] = rnd.Next(-100,100);
                    }

                }
            }
            else

            {
                for (int i = 0; i < colomnsN; i++)
                {
                    for (int j = 0; j < linesM; j++)
                    {
                        array[i, j] = int.Parse(Console.ReadLine());
                    }

                }
            }

        }
        public void TwoDimentionArrOUTPUT(int colomnsN, int linesM)
        {
            for (int i = 0; i < colomnsN; i++)
            {
                for (int j = 0; j < linesM; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();

            }
        }
        public int countAverage(int colomnsN, int linesM)
        {
            int m = 0;
            for (int i = 0; i < colomnsN; i++)
            {
                for (int j = 0; j < linesM; j++)
                {
                    m += array[i, j];
                }
            }
            return m / (colomnsN * linesM);
        }
        public void PrintArrBackw(int colomnsN, int linesM)
        {
            for (int i = 0; i < colomnsN; i++)
            {
                if (i % 2 == 1)
                {
                    for (int j = linesM - 1; j >= 0; j--)
                    {
                        Console.Write(array[i, j]+" ");
                    }
                }
                else
                {
                    for (int j = 0; j < linesM; j++)
                    {
                        Console.Write(array[i, j]+" ");
                    }
                }
                Console.WriteLine();

            }
        }
    }
    
    class SteppedArray
    {
        public int colN, lineN;
        public int[][]array;
        Random rnd = new Random();
        public bool WayOfInputtingTheArray = false;
        public SteppedArray(int colsN)
        {
            int[][]array=new int [colN][];
        }

        public void SteppedINP(bool WayOfInputtingTheArray, int colN)
        {
            if (WayOfInputtingTheArray == false)
            {
                for (int i = 0; i < colN; i++)
                {
                    lineM  = Console.ReadLine();
                    for (int j = 0; j < lineM; j++)
                    {
                        array[i][j] = rnd.Next(-100,100);
                    }

                }
            }
            else
            {
                for (int i = 0; i < colN; i++)
                {
                    lineM  = Console.ReadLine();
                    for (int j = 0; j < lineM; j++)
                    {
                        array[i][j] = int.Parse(Console.ReadLine());
                    }
                }
            }
        }
        
        public int countAverage(int colN)
        {
            int m = 0;
            int num =0;
            for (int i = 0; i < colN; i++)
            {
                int lineM = array[i].Length;
                for (int j = 0; j < lineM; j++)
                {
                    m += array[i][j];
                    num++;
                }
            }
            return m /num;
        }
        
        public void ChangeInd (int colN)
        {
            for (int i = 0; i < colN; i++)
	        {   
                int lineM = array[i].Length();
    	        for (int j = 0; j < lineM; j++)
    	        {
    	            if (array[i][j] % 2 == 0)
    		        {
    		            array[i][j] = i * j;
    		        }
    	        }

	        }
        }
        public void AverageInEveryStepped (int colN)
        {
            for (int i = 0; i < colN; i++)
	        {   
                int num = 0;
                int sum = 0;
                int lineM = array[i].Length();
    	        for (int j = 0; j <  lineM; j++)
    	        {
    	            num++;
                    sum+=array[i][j];
    	        }
                Console.WriteLine(sum/num);

	        }
        }

        public void SteppedOUTPUT(int colN)
        {
            for (int i = 0; i < colN; i++)
            {
                int lineM = array[i].Length();
                for (int j = 0; j < linesM; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();

            }
        }

    }
    
}
