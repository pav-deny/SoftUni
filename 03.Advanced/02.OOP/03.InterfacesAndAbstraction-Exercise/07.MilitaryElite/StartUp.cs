using MilitaryElite.Models;
using MilitaryElite.Models.Abstract;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        private static Dictionary<int, ISoldier> soldiersById;
        static void Main(string[] args)
        {
            soldiersById = new Dictionary<int, ISoldier>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                ProcessInput(input);
            }

            foreach (ISoldier soldier in soldiersById.Values)
            {
                Console.WriteLine(soldier);
            }
        }

        static void ProcessInput(string input)
        {
            ISoldier soldier = null;
            string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int id = int.Parse(data[1]);
            string firstName = data[2], lastName = data[3];

            try
            {
                switch (data[0])
                {
                    case "Private":
                        soldier = GetPrivate(data, firstName, lastName, id);
                        break;

                    case "LieutenantGeneral":
                        soldier = GetLieutenantGeneral(data, firstName, lastName, id);
                        break;

                    case "Engineer":
                        soldier = GetEngineer(data, firstName, lastName, id);
                        break;

                    case "Spy":
                        soldier = GetSpy(data, firstName, lastName, id);
                        break;

                    case "Commando":
                        soldier = GetCommando(data, firstName, lastName, id);
                        break;
                }

                soldiersById.Add(soldier.Id, soldier);
            }
            catch (Exception ex) { }
        }

        static ISoldier GetPrivate(string[] data, string firstName, string lastName, int id)
        {
            decimal salary = decimal.Parse(data[4]);

            ISoldier soldier = new Private(firstName, lastName, id, salary);

            return soldier;
        }

        static ISoldier GetLieutenantGeneral(string[] data, string firstName, string lastName, int id)
        {
            decimal salary = decimal.Parse(data[4]);

            List<IPrivate> privates = new();

            for (int i = 5; i < data.Length; i++)
            {
                int soldierId = int.Parse(data[i]);
                IPrivate @private = (Private)soldiersById[soldierId];
                privates.Add(@private);
            }

            ISoldier soldier = new LieutenantGeneral(firstName, lastName, id, salary, privates);

            return soldier;
        }

        static ISoldier GetEngineer(string[] data, string firstName, string lastName, int id)
        {
            decimal salary = decimal.Parse(data[4]);
            string corps = data[5];

            List<IRepair> repairs = new();

            for (int i = 6; i < data.Length; i += 2)
            {
                Repair repair = new(data[i], int.Parse(data[i + 1]));
                repairs.Add(repair);
            }

            ISoldier soldier = new Engineer(firstName, lastName, id, salary, corps, repairs);
            return soldier;
        }

        static ISoldier GetCommando(string[] data, string firstName, string lastName, int id)
        {
            decimal salary = decimal.Parse(data[4]);
            string corps = data[5];

            List<IMission> missions = new();

            for (int i = 6; i < data.Length; i += 2)
            {
                Mission mission = new(data[i], data[i + 1]);
                missions.Add(mission);
            }

            ISoldier soldier = new Commando(firstName, lastName, id, salary, corps, missions);
            return soldier;
        }

        static ISoldier GetSpy(string[] data, string firstName, string lastName, int id)
        {
            int codeNumber = int.Parse(data[4]);

            ISoldier soldier = new Spy(firstName, lastName, id, codeNumber);
            return soldier;
        }
    }
}
