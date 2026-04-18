namespace _09.PadawanEquip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float money = float.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            float lightsaberPrice = float.Parse(Console.ReadLine());
            float robePrice = float.Parse(Console.ReadLine());
            float beltPrice = float.Parse(Console.ReadLine());

            int lightsaberCount = students;
            int robeCount = students;
            int beltCount = students;

            lightsaberCount += (int)Math.Ceiling(lightsaberCount * 0.1);

            if (beltCount >= 6)
            {
                beltCount -= (beltCount / 6);
            }

            float totalPrice = (lightsaberPrice * lightsaberCount) + (robePrice * robeCount) + (beltPrice * beltCount);
            
            if (money >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                float neededMoney = totalPrice - money;
                Console.WriteLine($"John will need {neededMoney:f2}lv more.");
            }
            
            

        }
    }
}
