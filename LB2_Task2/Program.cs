using System;

public class Ar
{
    //поля
    int n; //кількість елементів в масиві
    int[] a; //одновимірний цілочисельний масив
    int k; //кількість парних елементів масиву
    public Ar(int a, int b)
    {
        //конструктор 1
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
    public Ar(string s)
    {
        //конструктор 2
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
    public int K
    {
        //властивість для читання поля k і отримання кількості парних елементів
        get
        {
            int count = 0;
            foreach (int number in a)
            {
                if (number % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
    public int N
    {
        //властивість для читання поля n
        get { return n; }
    }
    public void Print()
    {
        //метод виведення масиву на екран
        Console.WriteLine();
        for (int i = 0; i < n; i++)
            Console.Write(" {0} ", a[i]);
        Console.WriteLine();
    }
    public int P()
    {
        //метод, який повертає індекс першого позитивного елементу
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > 0)
            {
                return i; 
            }
        }

        return -1;
    }
    public int Pr(int i1, int i2)
    {
        //обчислення добутку елементів масиву
        //з індексами від і1 до і2 включно
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
        //опис об'єкту
        Ar mas;
        //вибір конструктору
        Console.Write("Конструктор 1/2 -->  ");
        int r = Convert.ToInt32(Console.ReadLine());
        if (r == 1)
        {
            //конструктор 1    
            //введеня чисел a i b
            Console.Write("Введiть перше число масиву:\na = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введiть останнє число масиву (бiльше нiж а):\nb = ");
            int b = Convert.ToInt32(Console.ReadLine());
            mas = new Ar(a, b);
        }
        else
        {
            //конструктор 2
            //введення рядку з числами
            Console.WriteLine("Введiть числа почерзi через символ ':' ");
            mas = new Ar(Console.ReadLine());
        }
        //виведення масиву
        mas.Print();
        
        //знаходимо кількість парних елементів
        int k = mas.K;
        Console.WriteLine($"Кiлькiсть парних елементiв = {k}");

        //знаходимо індекс першого позитивного значення
        int fp = mas.P();
        Console.WriteLine($"Iндекс першого позитивного значення {fp} ");

        //якщо елемент існує то обчислюємо добуток
        if (mas.K > 0)
        {
            //знаходимо добуток чисел правіше максимального
            //використовуючи властивість mas.N для визначення кількості елемемнтів
            //mas.N - 1 індекс останнього елементу масиву
            int p = mas.Pr(fp, mas.N - 1); 
            Console.WriteLine("Добуток всiх елементiв правiше знайденого позитивного: {0}", p);
        }
        else
            Console.WriteLine("Позитивних елементiв немає.");


        Console.ReadKey();
    }
}