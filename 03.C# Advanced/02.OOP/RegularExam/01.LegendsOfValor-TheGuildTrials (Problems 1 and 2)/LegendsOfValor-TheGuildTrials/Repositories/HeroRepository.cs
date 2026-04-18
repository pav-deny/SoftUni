using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> _heroes;

        public HeroRepository()
        {
            _heroes = new List<IHero>();
        }


        public void AddModel(IHero entity)
        {
           _heroes.Add(entity);
        }

        public IReadOnlyCollection<IHero> GetAll()
        {
            return _heroes.ToList().AsReadOnly(); //NOTE: ToList() could break things
        }

        public IHero GetModel(string runeMark)
        {
           IHero hero = _heroes.FirstOrDefault(h => h.RuneMark == runeMark);

            return hero;
        }
    }
}
