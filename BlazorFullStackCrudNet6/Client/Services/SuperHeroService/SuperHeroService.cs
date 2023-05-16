using BlazorFullStackCrudNet6.Client.Pages;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrudNet6.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService //I open menu and press implement interface
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SuperHeroService(HttpClient http, NavigationManager navigationManager) //controller
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>(); // delete exception and add list
        public List<Comic> Comics { get; set; } = new List<Comic>();

        private async Task SetHeroes(HttpResponseMessage result) // we extract code and create new method
        {
            var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            Heroes = response;
            _navigationManager.NavigateTo("superheroes");
        }

        public async Task CreateHero(SuperHero hero)
        {
            var result = await _http.PostAsJsonAsync("api/superhero", hero);
            await SetHeroes(result);
        }

        public async Task GetSuperHero()
        {
            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero"); //name our controller but without controller in the name
            if (result != null)
                Heroes = result;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task UpdateHero(SuperHero hero)
        {
            var result = await _http.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
            await SetHeroes(result);
        }

        public async Task DeleteHero(int id)
        {
            var result = await _http.DeleteAsync($"api/superhero/{id}");
            await SetHeroes(result);
        }

        public async Task GetComic()
        {
            var result = await _http.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
            if (result != null)
                Comics = result;
        }

    }
}
