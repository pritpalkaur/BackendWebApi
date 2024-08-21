using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.Models; 

namespace WebApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class MoviesController : ControllerBase
        {
            private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "movies.json");

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Movies>>> GetMovies()
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    return NotFound();
                }

                var jsonData = await System.IO.File.ReadAllTextAsync(_filePath);

                // Log JSON data for debugging
                System.Diagnostics.Debug.WriteLine("JSON Data: " + jsonData);

                if (string.IsNullOrEmpty(jsonData))
                {
                    return NotFound("No data found in the JSON file.");
                }

                try
                {
                    var movies = JsonSerializer.Deserialize<List<Movies>>(jsonData);

                    // Check if the deserialized object is null
                    if (movies == null)
                    {
                        return NotFound("Deserialized movie list is null.");
                    }

                    return Ok(movies);
                }
                catch (JsonException jsonEx)
                {
                    // Log exception details
                    System.Diagnostics.Debug.WriteLine($"Error deserializing JSON data: {jsonEx.Message}");
                    return BadRequest($"Error deserializing JSON data: {jsonEx.Message}");
                }
            }
        }
    }
