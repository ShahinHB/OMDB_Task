using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OMDB_Task.Models;

public class MoviesController : Controller
{
    private readonly HttpClient _httpClient;

    public MoviesController()
    {
        _httpClient = new HttpClient();
    }

    public async Task<IActionResult> Index()
    {
        string url = "https://www.omdbapi.com/?s=Rev&apikey=93bfb228";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var movieList = JsonConvert.DeserializeObject<MovieListModel>(json);
            movieList.Search = movieList.Search.Take(4).ToList();
            return View(movieList);
        }

        return BadRequest();
    }

    public async Task<IActionResult> Details(string title)
    {
        string url = $"https://www.omdbapi.com/?t={title}&apikey=93bfb228";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            return View(movie);
        }

        return BadRequest();
    }

    [Route("Movies/List")]
    public async Task<IActionResult> List()
    {
        string url = "https://www.omdbapi.com/?s=Rev&apikey=93bfb228";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var movieList = JsonConvert.DeserializeObject<MovieListModel>(json);
            movieList.Search = movieList.Search.Take(4).ToList();
            return Ok(movieList);
        }

        return BadRequest();
    }

    [Route("Movies/Single/{title}")]
    public async Task<IActionResult> SingleMovie(string title)
    {
        string url = $"https://www.omdbapi.com/?t={title}&apikey=93bfb228";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            return Ok(movie);
        }

        return BadRequest();
    }
}
