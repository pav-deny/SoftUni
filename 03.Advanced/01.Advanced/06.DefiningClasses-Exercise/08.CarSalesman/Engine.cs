namespace CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string? Efficiency { get; set; }

        public Engine(string model, int power, int? displacement, string? efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public override string ToString()
        {
            string efficiency = Efficiency == null ? "n/a" : Efficiency.ToString();
            string displacement = Displacement == null ? "n/a" : Displacement.ToString();

            return $@"{Model}:
  Power: {Power}
  Displacement: {displacement}
  Efficiency: {efficiency}";
        }
    }
}
