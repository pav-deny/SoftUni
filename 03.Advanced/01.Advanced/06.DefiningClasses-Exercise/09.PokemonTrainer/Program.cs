namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainersByName = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = data[0], pokemonName = data[1], element = data[2];
                int health = int.Parse(data[3]);

                Trainer trainer;

                if (!trainersByName.ContainsKey(trainerName))
                {
                    trainer = new(trainerName);
                    trainersByName.Add(trainerName, trainer);
                }
                else
                {
                    trainer = trainersByName[trainerName];
                }

                    Pokemon pokemon = new(pokemonName, element, health);
                trainer.Pokemons.Add(pokemon);
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainersByName.Values)
                {
                    bool hasElement = false;

                    foreach (Pokemon pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element == command)
                        {
                            hasElement = true;
                            break;
                        }
                    }

                    if (hasElement)
                        trainer.Badges++;

                    else
                    {
                        List<Pokemon> pokemons = new();

                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;

                            if (pokemon.Health > 0)
                               pokemons.Add(pokemon);
                        }

                        trainer.Pokemons = pokemons;
                    }
                }
            }

            foreach (Trainer trainer in trainersByName.Values.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
