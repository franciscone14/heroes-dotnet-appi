using FluentNHibernate.Mapping;
using TourOfHeroes.Models;

namespace TourOfHeroes.Maping
{
    public class HeroMap : ClassMap<Hero>
    {
        public HeroMap()
        {
            Id(h => h.Id);
            Map(h => h.Nome);
            Table("Heroes");
        }
    }
}