using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class GuildRepository : IRepository<IGuild>
    {
        private List<IGuild> _guilds;

        public GuildRepository()
        {
            _guilds = new List<IGuild>();
        }

        public void AddModel(IGuild entity)
        {
            _guilds.Add(entity);
        }

        public IReadOnlyCollection<IGuild> GetAll()
        {
            return _guilds.ToList().AsReadOnly();
        }

        public IGuild GetModel(string guildName)
        {
            IGuild guild = _guilds.FirstOrDefault(g => g.Name == guildName);

            return guild;
        }
    }
}
