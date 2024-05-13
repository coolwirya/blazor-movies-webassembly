using BlazorMovie.BlazorWebAssemblyStandaloneApp.Models;
using System.Net.Http.Json;

namespace BlazorMovie.BlazorWebAssemblyStandaloneApp.Services
{
    public class TMDBClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public TMDBClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));

            string apiKey = config["TMDBKey"] ?? throw new Exception("TMDBKey not found!");
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", apiKey);
        }

        public  Task<PopularMoviesPagedResponse?> GetPopularMoviesAsync()
        {
            return  _httpClient.GetFromJsonAsync<PopularMoviesPagedResponse>("movie/popular");
        }
        public Task<PopularMoviesPagedResponse?> GetPopularMoviesAsync(int page = 1)
        {
            if (page < 1) page = 1;
            if (page > 500) page = 500;

            return _httpClient.GetFromJsonAsync<PopularMoviesPagedResponse>($"movie/popular?page={page}");
        }

        public Task<MovieDetails?> GetMovieDetailsAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<MovieDetails>($"movie/{id}");
        }
    }
}
