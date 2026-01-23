using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var soldiers = new List<ISoldier>(); // all soldiers
            var privatesById = new Dictionary<int, IPrivate>(); // for quick lookup when adding to LieutenantGeneral

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var type = parts[0];

                try
                {
                    switch (type)
                    {
                        case "Private":
                            {
                                int id = int.Parse(parts[1]);
                                string firstName = parts[2];
                                string lastName = parts[3];
                                decimal salary = decimal.Parse(parts[4]);

                                var p = new Private(id, firstName, lastName, salary);
                                soldiers.Add(p);
                                privatesById[id] = p;
                                break;
                            }
                        case "LieutenantGeneral":
                            {
                                int id = int.Parse(parts[1]);
                                string firstName = parts[2];
                                string lastName = parts[3];
                                decimal salary = decimal.Parse(parts[4]);

                                var lg = new LieutenantGeneral(id, firstName, lastName, salary);

                                for (int i = 5; i < parts.Length; i++)
                                {
                                    int privateId = int.Parse(parts[i]);
                                    if (privatesById.ContainsKey(privateId))
                                    {
                                        lg.AddPrivate(privatesById[privateId]);
                                    }
                                }

                                soldiers.Add(lg);
                                break;
                            }
                        case "Engineer":
                            {
                                int id = int.Parse(parts[1]);
                                string firstName = parts[2];
                                string lastName = parts[3];
                                decimal salary = decimal.Parse(parts[4]);
                                string corps = parts[5];

                                // Corps validation happens in constructor
                                var eng = new Engineer(id, firstName, lastName, salary, corps);

                                for (int i = 6; i < parts.Length; i += 2)
                                {
                                    string partName = parts[i];
                                    int hoursWorked = int.Parse(parts[i + 1]);
                                    eng.AddRepair(new Repair(partName, hoursWorked));
                                }

                                soldiers.Add(eng);
                                break;
                            }
                        case "Commando":
                            {
                                int id = int.Parse(parts[1]);
                                string firstName = parts[2];
                                string lastName = parts[3];
                                decimal salary = decimal.Parse(parts[4]);
                                string corps = parts[5];

                                var comm = new Commando(id, firstName, lastName, salary, corps);

                                for (int i = 6; i < parts.Length; i += 2)
                                {
                                    string codeName = parts[i];
                                    string state = parts[i + 1];

                                    try
                                    {
                                        var mission = new Mission(codeName, state);
                                        comm.AddMission(mission);
                                    }
                                    catch
                                    {
                                        // skip invalid mission
                                    }
                                }

                                soldiers.Add(comm);
                                break;
                            }
                        case "Spy":
                            {
                                int id = int.Parse(parts[1]);
                                string firstName = parts[2];
                                string lastName = parts[3];
                                int codeNumber = int.Parse(parts[4]);

                                var spy = new Spy(id, firstName, lastName, codeNumber);
                                soldiers.Add(spy);
                                break;
                            }
                    }
                }
                catch
                {
                    // Skip entire line if invalid (e.g., invalid corps)
                    continue;
                }
            }

            // Print all soldiers
            foreach (var s in soldiers)
            {
                Console.WriteLine(s);
            }
        }
    }
}
