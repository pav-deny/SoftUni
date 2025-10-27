using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string type = Console.ReadLine();
                if (type == "Beast!")
                {
                    break;
                }

                string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Animal animal;

                    if (type == "Dog")
                    {
                        animal = new Dog(parts[0], int.Parse(parts[1]), parts[2]);
                    }
                    else if (type == "Frog")
                    {
                        animal = new Frog(parts[0], int.Parse(parts[1]), parts[2]);
                    }
                    else if (type == "Cat")
                    {
                        animal = new Cat(parts[0], int.Parse(parts[1]), parts[2]);
                    }
                    else if (type == "Kitten")
                    {
                        animal = new Kitten(parts[0], int.Parse(parts[1]));
                    }
                    else if (type == "Tomcat")
                    {
                        animal = new Tomcat(parts[0], int.Parse(parts[1]));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    Console.WriteLine(animal);
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}

//Solved with ChatGPT
//Part of the "Solve with AI" problems
