using _00.Demos.Program;

namespace _00.Demos.Animals
{
    internal class Cat
    {
        public Cat(string name, Colour colour)
        {
            this.name = name;
            Age = 0;
            Colour = colour;
        }
        public Cat(int age, string name, Colour colour):this(name, colour)
        {
            Age = age;
        }

        private string name;
        private int age;
        public static int Legs = 4;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Age
        {
            get { return age; }
            private set 
            { 
                if (value < 0)
                {
                    throw new Exception($"Invalid Age {Age} (age >= 0)");
                }

                age = value;
            }
        }

        public Colour Colour { get; set; }

        public string Meow()
        {
            return $"Meow I am {name}, I'm {age} years old";
        }
    }
}
