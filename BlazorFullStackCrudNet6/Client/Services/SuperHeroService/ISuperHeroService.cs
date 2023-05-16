namespace BlazorFullStackCrudNet6.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> Heroes { get; set; }
        List<Comic> Comics { get; set; }
        Task GetComic();
        Task GetSuperHero();
        Task<SuperHero> GetSingleHero(int id);

        Task CreateHero(SuperHero hero);
        Task UpdateHero(SuperHero hero);
        Task DeleteHero(int id);
    }
}
