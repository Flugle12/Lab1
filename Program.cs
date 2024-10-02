using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.Runtime.InteropServices;

class Lab1
    {
    public int[] findAll(int[] arr, int x)
    {
        int counter = 0, counter1 = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x)
            {
                counter++;
            }
        }
        int[] newArr = new int[counter];

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x && counter1<counter)
            {
                newArr[counter1] = i;
                counter1++;
            }
        }
        return newArr;
    }

    public int[] reverseBack(int[] arr)
    {
        int[] newArr = new int[arr.Length];
        for (int i = arr.Length - 1, key = 0 ; i >= 0; i--, key++)
        {
            newArr[key] = arr[i];
        }
        return newArr;
    }

    public int[] add(int[] arr, int[] ins, int pos)
    {
        int[] newArray = new int[arr.Length + ins.Length];

        for (int i = 0; i < pos; i++)
        {
            newArray[i] = arr[i];
        }

        for (int i = 0; i < ins.Length; i++)
        {
            newArray[pos + i] = ins[i];
        }

        for (int i = pos; i < arr.Length; i++)
        {
            newArray[i + ins.Length] = arr[i];
        }

        return newArray;
    }

    public int maxAbs(int[] arr)
    {
        int maxsNum = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (abs(arr[i]) > abs(maxsNum)) maxsNum = arr[i];
        }
        return maxsNum;
    }

    public int findFirst(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x) return i;
        }
        return -1;
    }

    // loops
    public void rightTriangle(int x)
    {
        Console.WriteLine("9: ");
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (i + j >= x - 1)
                {
                    Console.Write("*");
                }
                else Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    public void square(int x)
    {
        Console.WriteLine("7: ");
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    public int numLen(long x)
    {
        int counter = 0;
        while (x > 0)
        {
            counter++;
            x /= 10;
        }
        return counter;
    }

    public String chet(int x)
    {
        string a = "";
        for (int i = 0; i < x + 1; i += 2)
        {
            a += i.ToString() + " ";
        }
        return a;
    }

    public String listNums(int x)
    {
        string a = "";
        for (int i = 0; i <= x; i++)
        {
            a += i.ToString() + " ";
        }
        return a;
    }

    // if 
    public String day(int x)
    {
        switch (x)
        {
            case 1: return "понедельник";
            case 2: return "вторник";
            case 3: return "среда";
            case 4: return "четверг";
            case 5: return "пятница";
            case 6: return "суббота";
            case 7: return "восскресенье";
            default: return "не день недели";
        }
    }

    public int sum2(int x, int y)
    {
        if (x + y > 9 && x + y < 20) return 20;
        else return x + y;
    }

    public int max3(int x, int y, int z)
    {
        if (x >= y && x >= z)
        {
            return x;
        }
        else if (y >= z && y >= x)
        {
            return y;
        }
        else
        {
            return z;
        }
    }

    public bool is35(int x)
    {
        if (x % 5 == 0 || x % 3 == 0)
        {
            return true;
        }
        else return false;
    }

    public int abs(int x)
    {
        if (x > 0) return x;
        else return x * (-1);
    }

    //  1 Methods
    public bool isEqual(int a, int b, int c)
    {
        return a == b && b == c;
    }

    public bool isInRange(int a, int b, int num)
    {
        return (a < b && num > a && num < b) || (b < a && num > b && num < a);
    }

    public bool is2Digit(int x)
    {
        return (x >= 10 && x < 100);
    }

    public int charToNum(char c)
    {
        return c - '0';
    }

    public double fraction(double x)
    {
        return x - ((int)x);
    }
}

class MainProramm
{
    static void Main(string[] args)
    {
        Type type = typeof(Lab1);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        string[] namesOfMethods = new string[methods.Length];

        for(int i = 0; i < namesOfMethods.Length; i++)
        {
            namesOfMethods[i] = methods[i].Name;
        }

        Console.WriteLine("Название Методов: ");
        foreach (string methodName in namesOfMethods)
        {
            Console.WriteLine(methodName);
        }

        string name;
        Console.Write("введите название метода который хотите проверить: ");
        name = Console.ReadLine();

        Lab1 lab1 = new Lab1();

        //////////////////////////////////////
        switch (name)
        {
            case "fraction":
                Console.WriteLine("Введите дробное число для получения его дробной части: ");
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine("Дробная часть числа x = " + lab1.fraction(x));
                break;

            case "findAll":
                Console.WriteLine("Введите длину массива n:");
                int n = int.Parse(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("Число элементов массива должно быть больше 0!");
                    break;
                }

                Console.WriteLine("Введите n чисел");
                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Введите число, которое хотите искать в массиве: ");
                int searchInt = int.Parse(Console.ReadLine());

                int[] resultFindAll = lab1.findAll(arr, searchInt);
                Console.Write("Индексы вхождения числа в массиве: ");
                foreach (int index in resultFindAll)
                {
                    Console.Write(index + " ");
                }
                Console.WriteLine();
                break;

            case "reverseBack":
                Console.WriteLine("Введите длину массива n:");
                int n1 = int.Parse(Console.ReadLine());
                if (n1 <= 0)
                {
                    Console.WriteLine("Число элементов массива должно быть больше 0!");
                    break;
                }

                Console.WriteLine("Введите n чисел");
                int[] arr1 = new int[n1];
                for (int i = 0; i < n1; i++)
                {
                    arr1[i] = int.Parse(Console.ReadLine());
                }

                int[] resultReverseBack = lab1.reverseBack(arr1);
                Console.Write("Элементы массива в обратном порядке: ");
                foreach (int index in resultReverseBack)
                {
                    Console.Write(index + " ");
                }
                Console.WriteLine();
                break;

            case "add":
                Console.WriteLine("Введите длину первого массива n1 и длину второго массива n2: ");
                int n3 = int.Parse(Console.ReadLine());
                int n4 = int.Parse(Console.ReadLine());
                if (n3 <= 0 || n4 <= 0)
                {
                    Console.WriteLine("Число элементов массива должно быть больше 0! ");
                    break;
                }
                int[] arr3 = new int[n3];
                int[] arr4 = new int[n4];
                Console.WriteLine("Введите сначала первые n1 чисел первого массива, затем n2 чисел второго массива: ");
                for (int i = 0; i < n3; i++)
                {
                    arr3[i] = int.Parse(Console.ReadLine());
                }

                for (int i = 0; i < n4; i++)
                {
                    arr4[i] = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Введите номер позиции pos, куда вы хотите вставить элементы второго массива: ");
                int pos = int.Parse(Console.ReadLine());
                if (pos < 0 || pos > n3)
                {
                    Console.WriteLine("!!!Позиция не может быть отрицательной или больше максимального индекса первого массива!!!");
                    break;
                }

                int[] resultAdd = lab1.add(arr3, arr4, pos);
                Console.Write("Элементы соединенных массивов: ");
                foreach (int index in resultAdd)
                {
                    Console.Write(index + " ");
                }
                Console.WriteLine();
                break;

            case "maxAbs":
                Console.WriteLine("Введите длину массива: ");
                int n5 = int.Parse(Console.ReadLine());
                if (n5 <= 0)
                {
                    Console.WriteLine("Число элементов массива должно быть больше 0! ");
                    break;
                }

                Console.WriteLine("Введите n чисел");
                int[] arr5 = new int[n5];
                for (int i = 0; i < n5; i++)
                {
                    arr5[i] = int.Parse(Console.ReadLine());
                }
                int maxAbsResult = lab1.maxAbs(arr5);
                Console.WriteLine("Наибольшее по модулю число в массиве: " + maxAbsResult);
                break;

            case "findFirst":
                Console.WriteLine("Введите длину массива: ");
                int n6 = int.Parse(Console.ReadLine());
                if (n6 <= 0)
                {
                    Console.WriteLine("Число элементов массива должно быть больше 0! ");
                    break;
                }

                Console.WriteLine("Введите n чисел");
                int[] arr6 = new int[n6];
                for (int i = 0; i < n6; i++)
                {
                    arr6[i] = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Введите число, которое хотите найти: ");
                int searchNum = int.Parse(Console.ReadLine());
                int firstIndex = lab1.findFirst(arr6, searchNum);
                Console.WriteLine("Первый индекс числа в массиве: " + (firstIndex >= 0 ? firstIndex.ToString() : "не найдено"));
                break;

            case "rightTriangle":
                Console.WriteLine("Введите размер треугольника: ");
                int sizeTriangle = int.Parse(Console.ReadLine());
                lab1.rightTriangle(sizeTriangle);
                break;

            case "square":
                Console.WriteLine("Введите размер квадрата: ");
                int sizeSquare = int.Parse(Console.ReadLine());
                lab1.square(sizeSquare);
                break;

            case "numLen":
                Console.WriteLine("Введите число: ");
                long number = long.Parse(Console.ReadLine());
                int length = lab1.numLen(number);
                Console.WriteLine("Длина числа: " + length);
                break;

            case "chet":
                Console.WriteLine("Введите число: ");
                int chetNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Четные числа: " + lab1.chet(chetNum));
                break;

            case "listNums":
                Console.WriteLine("Введите число: ");
                int listNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Числа от 0 до " + listNum + ": " + lab1.listNums(listNum));
                break;

            case "day":
                Console.WriteLine("Введите номер дня: ");
                int dayNum = int.Parse(Console.ReadLine());
                Console.WriteLine("День недели: " + lab1.day(dayNum));
                break;

            case "sum2":
                Console.WriteLine("Введите два числа: ");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("Сумма: " + lab1.sum2(a, b));
                break;

            case "max3":
                Console.WriteLine("Введите три числа: ");
                int x1 = int.Parse(Console.ReadLine());
                int y1 = int.Parse(Console.ReadLine());
                int z1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Максимальное число: " + lab1.max3(x1, y1, z1));
                break;

            case "is35":
                Console.WriteLine("Введите число: ");
                int is35Num = int.Parse(Console.ReadLine());
                Console.WriteLine("Делится ли на 3 или 5: " + lab1.is35(is35Num));
                break;

            case "abs":
                Console.WriteLine("Введите число: ");
                int absNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Модуль числа: " + lab1.abs(absNum));
                break;

            case "isEqual":
                Console.WriteLine("Введите три числа: ");
                int a1 = int.Parse(Console.ReadLine());
                int b1 = int.Parse(Console.ReadLine());
                int c1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Все числа равны: " + lab1.isEqual(a1, b1, c1));
                break;

            case "isInRange":
                Console.WriteLine("Введите два числа и число для проверки: ");
                int a2 = int.Parse(Console.ReadLine());
                int b2 = int.Parse(Console.ReadLine());
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("Число в диапазоне: " + lab1.isInRange(a2, b2, num));
                break;

            case "is2Digit":
                Console.WriteLine("Введите число: ");
                int is2DigitNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Двузначное число: " + lab1.is2Digit(is2DigitNum));
                break;

            case "charToNum":
                Console.WriteLine("Введите символ: ");
                char c = Console.ReadKey().KeyChar;
                Console.WriteLine("\nЧисловое значение: " + lab1.charToNum(c));
                break;

            default:
                Console.WriteLine("Такого метода нет.");
                break;
        }

    }

}
