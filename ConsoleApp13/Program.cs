using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    public static List<Cat> Cats = [];
    public static List<Dog> Dogs = [];
    public static bool working = true;
    private static void Main(string[] args)
    {
        while (working)
        {
            if (Cats.Count == 0) { Console.WriteLine("\nСписок котів порожній.\n"); } else { Console.WriteLine("\nСписок котів:\n"); foreach (Cat a in Cats){ Console.WriteLine( Cats.IndexOf(a) + ". " + a.Name + "\n"); } }
            if (Dogs.Count == 0) { Console.WriteLine("\nСписок собак порожній.\n"); } else { Console.WriteLine("\nСписок собак:\n"); foreach (Dog a in Dogs){ Console.WriteLine( Dogs.IndexOf(a) + ". " + a.Name + "\n"); } }
            Console.WriteLine("1. - Додати\n2. - Видалити\n3. - Зберегти у файл\n4. - Завантажити з файла\n5. - Видати звук\n6. - Вийти\n");
            switch (int.Parse(Console.ReadLine()!))
            {
                case 1:
                    {
                        Console.WriteLine("Кого?(1 - Кіт, 2 - Пес)");
                        switch(int.Parse(Console.ReadLine()!))
                        {
                            case 1:
                                {
                                    Console.Write("Введіть ім'я:");
                                    Cats.Add(new Cat(Console.ReadLine()!));
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Введіть ім'я:");
                                    Dogs.Add(new Dog(Console.ReadLine()!));
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Помилка");
                                    break;
                                }
                        }

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Кого?(1 - Кіт, 2 - Пес)");
                        switch (int.Parse(Console.ReadLine()!))
                        {
                            case 1:
                                {
                                    Console.Write("Введіть індекс:");
                                    Cats.RemoveAt(int.Parse(Console.ReadLine()!));
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Введіть індекс:");
                                    Dogs.RemoveAt(int.Parse(Console.ReadLine()!));
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Помилка");
                                    break;
                                }
                        }

                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Кого?(1 - Котів, 2 - Собак)");
                        switch (int.Parse(Console.ReadLine()!))
                        {
                            case 1:
                                {
                                    Console.WriteLine("Введіть шлях до файлу:");
                                    string[] temp = new string[Cats.Count]; int i = 0;
                                    foreach (Cat a in Cats)
                                    {
                                        temp[i] = a.Name!;
                                        i++;
                                    }
                                    File.WriteAllLines(Console.ReadLine()!, temp);
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Введіть шлях до файлу:");
                                    string[] temp = new string[Dogs.Count]; int i = 0;
                                    foreach(Dog a in Dogs)
                                    {
                                        temp[i] = a.Name!;
                                        i++;
                                    }
                                    File.WriteAllLines(Console.ReadLine()!, temp);
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Помилка");
                                    break;
                                }
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Кого?(1 - Котів, 2 - Собак)");
                        switch (int.Parse(Console.ReadLine()!))
                        {
                            case 1:
                                {
                                    Console.WriteLine("Введіть шлях до файлу:");
                                    string[] temp = File.ReadAllLines(Console.ReadLine()!);
                                    foreach (string a in temp)
                                    {
                                        Cats.Add(new Cat(a!));
                                    }
                                   
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Введіть шлях до файлу:");
                                    string[] temp = File.ReadAllLines(Console.ReadLine()!);
                                    foreach (string a in temp)
                                    {
                                        Dogs.Add(new Dog(a!));
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Помилка");
                                    break;
                                }
                        }
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Кого?(1 - Кіт, 2 - Пес)");
                        switch (int.Parse(Console.ReadLine()!))
                        {
                            case 1:
                                {
                                    Console.Write("Введіть індекс:");
                                    int i = int.Parse(Console.ReadLine()!);
                                    Console.WriteLine("\n" + Cats[i].MakeSound() + "\n");
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Введіть індекс:");
                                    int i = int.Parse(Console.ReadLine()!);
                                    Console.WriteLine("\n" + Dogs[i].MakeSound() + "\n");
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Помилка");
                                    break;
                                }
                        }
                        break;
                    }
                case 6:
                    {
                        working = false;
                        break;
                    }
                default:
                    {
                        working = false;
                        break;
                    }
            }
        }
    }

    public class Animal
    {
        public string? Name { get; set; }
        public Animal(string name) {Name = name;}
    }

    public class Dog : Animal
    {
        public string? Sound { get; set; }
        public Dog(string name) : base(name)
        {
            Sound = "Гав";
        }
        public string MakeSound()
        {
            return $"Собака {this.Name} каже {this.Sound}";
        }
    }

    public class Cat : Animal
    {
        public string? Sound { get; set; }
        public Cat(string name) : base(name)
        {
            Sound = "Мяу";
        }
        public string MakeSound()
        {
            return $"Кіт {this.Name} каже {this.Sound}";
        }
    }
}