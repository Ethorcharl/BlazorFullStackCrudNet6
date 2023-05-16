using System.Net.Http.Json;

namespace BlazorFullStackCrudNet6.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService //I open menu and press implement interface
    {
        private readonly HttpClient _http;

        public SuperHeroService(HttpClient http) //controller
        {
            _http = http;
        }
        public List<SuperHero> Heroes { get ; set ; } =new List<SuperHero>(); // delete exception and add list
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task GetComic()
        {
            var result = await _http.GetFromJsonAsync<List<Comic>>("api/superhero/comics"); 
            if (result != null)
                Comics = result;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}"); 
            if (result != null)
                return  result;
            throw new Exception("Hero not found!");
        }


        public async Task GetSuperHero()
        {
            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero"); //name our controller but without controller in the name
            if (result != null)
                Heroes = result;
        }
    }
}
