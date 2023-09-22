using System;

public class Ar
{
    //поля
    int n; //кількість елементів в масиві
    int[] a; //одновимірний цілочисельний масив
    int k; //кількість парних елементів масиву
    public Ar(int a, int b) //конструктор 1
    {        
        //створюємо масив і заповнюємо його числами з а до b
        Random r = new Random();
        n = b - a + 1;
        this.a = new int[n];
        //знак числа випадковий
        for (int i = 0; i < n; i++)
        {
            int rNum = r.Next(a, b + 1);
            int rSign = r.Next(2) == 0 ? -1 : 1;
            this.a[i] = rNum * rSign;            
        }
    }
    public Ar(string s)  //конструктор 2
    {       
        //заповнюємо масив через рядок в якому числа написані через символ ':'
        string[] numStr = s.Split(':');
        n = numStr.Length; 
        a = new int[n];
        for (int i = 0; i < numStr.Length; i++)
        {
            if (int.TryParse(numStr[i], out int pNum))
            {
                a[i] = pNum;            
            }           
        }
    }
    public int K //властивість для читання поля k і отримання кількості парних елементів
    {        
        get
        {
            int k = 0;
            foreach (int number in a)
            {
                if (number % 2 == 0)
                {
                    k++;
                }
            }
            return k;
        }
    }
    public int N //властивість для читання поля n
    {        
        get { return n; }
    }
    public void Print() //метод виведення масиву на екран
    {        
        Console.WriteLine();
        for (int i = 0; i < n; i++)
            Console.Write(" {0} ", a[i]);
        Console.WriteLine();
    }
    public int P()  //метод, який повертає індекс першого позитивного елементу
    {       
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > 0)
            {
                return i; 
            }
        }

        return -1;
    }
    public int Pr(int i1, int i2) //обчислення добутку елементів масиву з індексами від і1 до і2 включно
    {
        int p = 1;
        for (int i = i1; i <= i2; i++)
            p *= a[i];
        return p;
    }
}
class Program
{
    static void Main(string[] args)
    {        
        Ar mas; // Опис об'єкту
        bool repeat = true;
        while (repeat) //цикл
        {
            // Вибір конструктору
            Console.Write("\nКонструктор 1/2 -->  ");
            string oneortwo = Console.ReadLine();
            if (int.TryParse(oneortwo, out int r)) //якщо введені символи чі букви виникне помилка
            {
                if (r != 1 && r != 2) //перевірка чи правильно обрано конструктор (1 або 2)
                {
                    Console.WriteLine("Некоректне значення. Введiть 1 або 2");
                }
                else
                {
                    if (r == 1) //конструктор 1
                    {
                        int a, b;
                        while (true) //просимо користувача ввести правильні значення після кожної помилки
                        {
                            // Введеня чисел a i b
                            Console.Write("Введiть перше число масиву (цiле додатнє число):\na = ");
                            if (int.TryParse(Console.ReadLine(), out a) && a > 0) // перевірка числа а
                            {
                                Console.Write("Введiть останнє число масиву (цiле додатнє число та бiльше за a):\nb = ");
                                if (int.TryParse(Console.ReadLine(), out b) && b > a) //перевірка числа b
                                {
                                    mas = new Ar(a, b);
                                    break; //дані введено правильно і цикл завершується
                                }
                                else
                                {
                                    Console.WriteLine("Некоректне значення для b. b повинно бути цiим додатнiм числом i більше за a.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некоректне значення для a. a повинно бути цiлим додатнiм числом.");
                            }
                        }
                    }
                    else // конструктор 2
                    {                        
                        string str;
                        while (true) //при неправильному введені просимо знову
                        {
                            // Введення рядку з числами
                            Console.WriteLine("Введiть числа почергово через символ ':' ");
                            str=Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(str)) //перевіряємо чи рядок не пустий
                            {
                                mas = new Ar(str);
                                break; //дані введено правильно і цикл завершується
                            }
                            else
                            {
                                Console.WriteLine("Некоректний рядок. Введiть числа через ':'.");
                            }
                        }
                    }                   
                    mas.Print();  // виведення масиву                    
                    int k = mas.K; //знаходимо кількість парних
                    Console.WriteLine($"Кiлькiсть парних елементiв = {k}");                    
                    int fp = mas.P(); // знаходимо індекс першого позитивного 
                    Console.WriteLine($"Iндекс першого позитивного значення {fp} ");
                    if (mas.K > 0) //якщо елемент існує то обчислюємо добуток
                    {
                        int p = mas.Pr(fp, mas.N - 1);
                        Console.WriteLine("Добуток всiх елементiв правiше знайденого позитивного: {0}", p);
                    }
                    else
                        Console.WriteLine("Позитивних елементiв немає.");
                }
            }
            else
            {
                Console.WriteLine("Некоректне значення. Введiть 1 або 2");
            }
            // запитуємо у користувача чи хочевін знову виконати програму
            Console.Write("\nСпробувати знову? (Y/N): ");
            ConsoleKeyInfo yesno = Console.ReadKey();

            if (yesno.Key == ConsoleKey.N) //якщо N, то завершаємо
            {
                break;
            }
            else if (yesno.Key != ConsoleKey.Y) 
            {
                Console.WriteLine("\nНевiрне введення. Натиснiть Y або N.");
            }
        }
    }

}
