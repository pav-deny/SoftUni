namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string? Color { get; set; }

        public Car(string model, Engine engine, int? weight, string? color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            string weight = Weight == null ? "n/a" : Weight.ToString();
            string color = Color == null ? "n/a" : Color.ToString();

            return $@"{Model}:
 {Engine.ToString()}
 Weight: {weight}
 Color: {color}";
        }
    }
}
