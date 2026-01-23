using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System.Text;

namespace LegendsOfValor_TheGuildTrials.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private GuildRepository guilds;

        public Controller()
        {
            heroes = new HeroRepository();
            guilds = new GuildRepository();
        }

        public string AddHero(string heroTypeName, string heroName, string runeMark) //Works (Tested)
        {
            if (heroTypeName != nameof(Warrior) && heroTypeName != nameof(Sorcerer) && heroTypeName != nameof(Spellblade))
                return string.Format(OutputMessages.InvalidHeroType, heroTypeName);

            if (heroes.GetModel(runeMark) != null)
                return string.Format(OutputMessages.HeroAlreadyExists, runeMark);

            IHero hero = null;

            switch(heroTypeName)
            {
                case nameof(Warrior):
                    hero = new Warrior(heroName, runeMark);
                break;

                case nameof(Sorcerer):
                    hero = new Sorcerer(heroName, runeMark);
                    break;

                case nameof(Spellblade):
                    hero = new Spellblade(heroName, runeMark);
                    break;
            }

            heroes.AddModel(hero);

            return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
        }

        public string CreateGuild(string guildName)//Works (Tested)
        {
            if (guilds.GetModel(guildName) != null)
                return string.Format(OutputMessages.GuildAlreadyExists, guildName);

            IGuild guild = new Guild(guildName);
            guilds.AddModel(guild);

            return string.Format(OutputMessages.GuildCreated, guildName);
        }

        public string RecruitHero(string runeMark, string guildName)//Works (Tested)
        {
            IHero hero = heroes.GetModel(runeMark);
            IGuild guild = guilds.GetModel(guildName);

            if (hero == null)
                return string.Format(OutputMessages.HeroNotFound, runeMark);

            if (guild == null)
               return string.Format(OutputMessages.GuildNotFound, guildName);

            if (!string.IsNullOrEmpty(hero.GuildName))
                return string.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);

            if (guild.IsFallen)
                return string.Format(OutputMessages.GuildIsFallen, guild.Name);

            if (guild.Wealth < 500)
                return string.Format(OutputMessages.GuildCannotAffordRecruitment, guild.Name);

            if (!CheckIfValidGuildForHero(hero, guild))
                return string.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guild.Name);

            hero.JoinGuild(guild);
            guild.RecruitHero(hero);
            return string.Format(OutputMessages.HeroRecruited, hero.Name, guild.Name);
        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            IGuild attackerGuild = guilds.GetModel(attackerGuildName);
            IGuild defenderGuild = guilds.GetModel(defenderGuildName);

            if (attackerGuild == null || defenderGuild == null)
                return OutputMessages.OneOfTheGuildsDoesNotExist;

            if (attackerGuild.IsFallen || defenderGuild.IsFallen)
                return OutputMessages.OneOfTheGuildsIsFallen;

            int attackerGuildStrength = GetGuildCombatStrenght(attackerGuild);//NOTE: if it doesn't work try long
            int defenderGuildStrength = GetGuildCombatStrenght(defenderGuild);

            if (attackerGuildStrength > defenderGuildStrength)
            {
                int goldWon = EndWar(attackerGuild, defenderGuild);
                return string.Format(OutputMessages.WarWon, attackerGuild.Name, defenderGuild.Name, goldWon);
            }
            else
            {
                int goldWon = EndWar(defenderGuild, attackerGuild);
                return string.Format(OutputMessages.WarLost, defenderGuild.Name, goldWon, attackerGuild.Name);
            }
        }

        public string TrainingDay(string guildName)//Works (Tested)
        {
            IGuild guild = guilds.GetModel(guildName);

            if (guild == null)
                return string.Format(OutputMessages.GuildNotFound, guildName);

            if (guild.IsFallen)
                return string.Format(OutputMessages.GuildTrainingDayIsFallen, guild.Name);

            long totalTrainingCost = guild.Legion.Count * 200; //NOTE: long could cause issues with Judge

            if (guild.Wealth < totalTrainingCost)
                return string.Format(OutputMessages.TrainingDayFailed, guild.Name);

            List<IHero> heroesToTrain = heroes.GetAll().Where(h => guild.Legion.Contains(h.RuneMark)).ToList();
            guild.TrainLegion(heroesToTrain);

            return string.Format(OutputMessages.TrainingDayStarted, guild.Name, heroesToTrain.Count, totalTrainingCost);
        }

        public string ValorState()//NOTE: StringBuilder uses /r/n so if something is wrong remove it
        {
            StringBuilder sb = new();
            sb.AppendLine("Valor State:");

            foreach (IGuild guild in guilds.GetAll().OrderByDescending(g => g.Wealth))
            {
                sb.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");

                foreach (IHero hero in heroes.GetAll().Where(h => guild.Legion.Contains(h.RuneMark)).OrderBy(h => h.Name))
                {
                    sb.AppendLine($"-{hero.ToString()}");
                    sb.AppendLine($"--{hero.Essence()}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private bool CheckIfValidGuildForHero(IHero hero, IGuild guild)
        {
            string notAllowedGuildName = "";
            string heroTypeName = hero.GetType().Name;

            if (heroTypeName == nameof(Warrior))
            {
                notAllowedGuildName = "SorcererGuild";
            }
            else if (heroTypeName == nameof(Sorcerer))
            {
                notAllowedGuildName = "WarriorGuild";
            }
            else if (heroTypeName == nameof(Spellblade))
            {
                notAllowedGuildName = "ShadowGuild";
            }

            if (guild.Name == notAllowedGuildName)
                return false;

            return true;
        }

        private int GetGuildCombatStrenght(IGuild guild)
        {
            List<IHero> guildHeroes = heroes.GetAll().Where(h => guild.Legion.Contains(h.RuneMark)).ToList();
            int guildStrength = 0;

            foreach (IHero hero in guildHeroes)
            {
                guildStrength += hero.Mana + hero.Stamina + hero.Power;
            }

            return guildStrength;
        }

        private int EndWar(IGuild winner, IGuild loser)
        {
            int goldWon = loser.Wealth;
            winner.WinWar(goldWon);
            loser.LoseWar();

            return goldWon;
        }
    }
}
