/* Любовь Соколова */

using System;
using System.Linq;

namespace Lesson2
{
    class Program
    {
        ///1. Написать метод, возвращающий минимальное из трёх чисел.
        static int MinNumber(int a, int b, int c)
        {
            int[] numbers = { a, b, c };
            int min = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];
            }
            return min;
        }

        /// <summary>
        /// 2. Написать метод подсчета количества цифр числа
        /// </summary>
        static void SumOfNumbers1(int number)
        {
            string str = number.ToString();
            Console.WriteLine($"Количество цифр в числе: {str.Length}");
        }

        static void SumOfNumbers2(int number)
        {
            Console.Write("Введите число: ");
            int numbers = int.Parse(Console.ReadLine());
            int count = 0;
            while (number != 0)
            {
                count++;
                number = number / 10;
            }
            Console.WriteLine($"Количество цифр в числе: {count}");
        }

        /// 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных
        /// положительных чисел
        static void SumOddNumbers()
        {
            int sum = 0;
            int[] numbers = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            foreach (var i in numbers)
            {
                if (i % 2 == 1 && i > 0)
                    sum += i;
                if (i == 0)
                    Console.WriteLine(sum);
            }
        }


        /// <summary>
        /// 4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На
        ///выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин: root, Password:
        ///GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь
        ///вводит логин и пароль, программа пропускает его дальше или не пропускает.С помощью
        ///цикла do while ограничить ввод пароля тремя попытками.
        /// </summary>
        static void LoginDetails()  
        {
            int counter = 3;
            string login, password;
            do
            {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();
                if (login == "root" && password == "GeekBrains")
                {
                    Console.WriteLine("Добро пожаловать!");
                    break;
                }
                else
                    counter--;
                    Console.WriteLine($"Осталось попыток {counter}");
            }
            while (counter!=0);
        }

        /// <summary>
        /// 5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
        /// массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
        /// б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        /// </summary>
        static void BodyMassIndex()
        {
            double index = 0;
            Console.Write("Введите массу тела в кг: ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Введите рост тела в метрах: ");
            double height = double.Parse(Console.ReadLine());
            index = weight / (height * height);
            Console.Write($"Ваш индекс массы равен: {index}") ;
            double standart = (18.5 * (height * height) + 25 * (height * height)) / 2;
            weight = index * (height * height);


            if (index < 16)
            {
                Console.WriteLine("Выраженный дефицит массы тела");
                weight = standart - weight;
                Console.WriteLine($"Пора толстеть на {weight:f0}");
            }


            if (16 < index && index < 18.5)
            {
                Console.WriteLine("Недостаточная (дефицит) масса тела");
                weight = standart - weight;
                Console.WriteLine($"Пора толстеть на {weight:f0}");
            }

            if (19 < index && index < 25)
                Console.WriteLine("Норма");

            if (25 < index && index < 30)
            {
                Console.WriteLine("Избыточная масса тела (предожирение)");
                weight = weight - standart;
                Console.WriteLine($"Пора худеть на {weight:f0}");
            }

            if (30 < index && index < 35)
            {
                Console.WriteLine("Ожирение 1 степени");
                weight = weight - standart;
                Console.WriteLine($"Пора худеть на {weight:f0}");
            }

            if (35 < index && index < 40)
            {
                Console.WriteLine("Ожирение 2 степени");
                weight = weight - standart;
                Console.WriteLine($"Пора худеть на {weight:f0}");
            }

            if (index >= 40)
            {
                Console.WriteLine("Ожирение 3 степени");
                weight = weight - standart;
                Console.WriteLine($"Пора худеть на {weight:f0}");
            }
        }


        ///6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000
        // 000. «Хорошим» называется число, которое делится на сумму своих цифр.Реализовать
        // подсчёт времени выполнения программы, используя структуру DateTime.

        static void HarshadNumbers()
        {
            DateTime start = DateTime.Now;
            int counter = 0;
            for (int i = 1; i <= 1000000000; i++)
            {
                int numbers = i;
                int sum = 0;
                while (numbers != 0)
                {
                    sum = sum + numbers % 10;
                    numbers = numbers / 10;
                }

                if (i % sum == 0)
                    counter++; 
            }
            DateTime finish = DateTime.Now;
            Console.WriteLine($"Количество харшад-чисел: {counter}");
            Console.WriteLine($"Время работы: {finish-start}");
        }

        /// <summary>
        ///7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        /// </summary>
        static void NumberRange(int a, int b)
        {
            Console.Write("{0,2}", a);
            if (a < b) NumberRange(a + 1, b);
        }

        /// <summary>
        /// 7. б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int RecursiveSum(int a, int b)
        {
            if (a < b)
                return a + RecursiveSum(a + 1, b); 
            else return b;
        }


        static void Main(string[] args)
        {
            //MinNumber(6, 5, 4);
            //SumOfNumbers2(1250);
            //SumOddNumbers();
            // LoginDetails();
            //BodyMassIndex();
            // HarshadNumbers();
            //NumberRange(2,4);
            Console.WriteLine(RecursiveSum(2,5));
        }
    }
}
