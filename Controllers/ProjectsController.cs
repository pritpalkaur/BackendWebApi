using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapitaskup.Helper;
using webapitaskup.Models;
using webapitaskup.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace webapitaskup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public ProjectsController(AppDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet("GetProjects")]
        public async Task<ActionResult<IEnumerable<ProjectwithTeams>>> GetProjects()
        {
            var projectwithTeams = new List<ProjectwithTeams>();

            var projectdata = await _dbContext.Projects.ToListAsync();
            var teams = await _dbContext.Teams.ToListAsync();

            foreach (var project in projectdata)
            {
                var projectwithTeamsObj = new ProjectwithTeams
                {
                    ProjectId = project.ProjectId,
                    Project_Description = project.Project_Description,
                    Project_Name = project.Project_Name,
                    isActive = project.isActive,
                    TeamId = project.TeamId,
                    TeamName = teams.Where(x => x.TeamID == project.TeamId)
                                    .Select(y => y.Team_Name)
                                    .SingleOrDefault()
                };

                projectwithTeams.Add(projectwithTeamsObj);
            }

            return projectwithTeams;
        }

        [HttpGet("GetTeams")]
        public async Task<ActionResult<IEnumerable<Teams>>> GetTeams()
        {
            return await _dbContext.Teams.ToListAsync();
        }
        [HttpGet("GetProjectsById/{id}")]
        public async Task<ActionResult<IEnumerable<ProjectwithTeams>>> GetProjectsBy(int id)
        {
            var projectwithTeams = new List<ProjectwithTeams>();

            var userId = 1;// get the current user ID somehow

            try
            {
                var projectdata = await _dbContext.Projects.Where(p => p.CeatedBy == userId && p.isDeleted==0)
                                .OrderByDescending(p => p.UpdatedOn)
                                .ToListAsync();

                var teams = await _dbContext.Teams.ToListAsync();

                foreach (var project in projectdata)
                {
                    var projectwithTeamsObj = new ProjectwithTeams
                    {
                        ProjectId = project.ProjectId,
                        Project_Description = project.Project_Description,
                        Project_Name = project.Project_Name,
                        isActive = project.isActive,
                        TeamId = project.TeamId,
                        TeamName = teams.Where(x => x.TeamID == project.TeamId)
                                        .Select(y => y.Team_Name)
                                        .SingleOrDefault()
                    };

                    projectwithTeams.Add(projectwithTeamsObj);
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return projectwithTeams;

        }
        [HttpPost("CreateProject")]
        public async Task<ActionResult<Project>> CreateProject([FromBody] CreateProjectDto createProjectDto)
        {
            if (createProjectDto == null)
            {
                return BadRequest("Project data is null.");
            }

            string activeString = createProjectDto.isActive; // Example string input from DTO
            string isActive;

            try
            {
                // Convert string input to a boolean value using custom logic
                if (activeString.ToUpper() == "1")
                {
                    isActive = "1";
                }
                else if (activeString.ToUpper() == "0")
                {
                    isActive = "0";
                }
                else
                {
                    throw new ArgumentException("Invalid input string format for boolean conversion");
                }

                // Mapping DTO to Project entity
                var project = new Project
                {
                    Project_Name = createProjectDto.Project_Name,
                    Project_Description = createProjectDto.Project_Description,
                    isActive = isActive, // Set the parsed boolean value
                    TeamId = Convert.ToInt16(createProjectDto.TeamId),
                    CreatedOn= DateTime.Now,
                    UpdatedOn= DateTime.Now,
                };

                // Add the project to the database
                _dbContext.Projects.Add(project);
                await _dbContext.SaveChangesAsync();

                // Return the created project with a 201 status code
                return CreatedAtAction(nameof(GetProjectByIdFromDatabase), new { id = project.ProjectId }, project);
            }
            catch (ArgumentException ex)
            {
                // Handle invalid input format exceptions
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions accordingly
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectByIdFromDatabase(int id)
        {
            var project = await _dbContext.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        [HttpDelete("DeleteProject/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            project.isDeleted = 1;
            if (project == null)
            {
                return NotFound(new { message = "Project not found." });
            }
            try
            {
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();
                return Ok(new { message = "Project successfully deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the project.", error = ex.Message });
            }
        }

        [HttpPut("UpdateProject/{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, [FromBody] UpdateProjectDto updateProjectDto)
        {
            if (updateProjectDto == null)
            {
                return BadRequest("Project data is null.");
            }

            string activeString = updateProjectDto.isActive; // Example string input from DTO
            string isActive;

            try
            {
                // Convert string input to a boolean value using custom logic
                if (activeString.ToUpper() == "1")
                {
                    isActive = "1";
                }
                else if (activeString.ToUpper() == "0")
                {
                    isActive = "0";
                }
                else
                {
                    throw new ArgumentException("Invalid input string format for boolean conversion");
                }

                // Fetch the existing project from the database
                var project = await _dbContext.Projects.FindAsync(id);
                if (project == null)
                {
                    return NotFound("Project not found.");
                }

                // Update the project properties
                project.Project_Name = updateProjectDto.Project_Name;
                project.Project_Description = updateProjectDto.Project_Description;
                project.isActive = isActive; // Set the parsed boolean value
                project.TeamId = Convert.ToInt16(updateProjectDto.TeamId);
                project.UpdatedOn = DateTime.Now;
                // Save the changes to the database
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                // Return the updated project
                return Ok(project);
            }
            catch (ArgumentException ex)
            {
                // Handle invalid input format exceptions
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions accordingly
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet("SearchProjects/{query}")]
        public async Task<ActionResult<IEnumerable<Project>>> SearchProjects(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Query string cannot be null or empty.");
            }

            var projects = await SearchProjectsAsync(query);
            return Ok(projects);
        }
        public async Task<IEnumerable<Project>> SearchProjectsAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                // If the query is empty or null, return all projects
                return await _dbContext.Projects.ToListAsync();
            }
            else
            {
                // Otherwise, return the filtered list of projects
                return await _dbContext.Projects
                    .Where(p => p.Project_Name.Contains(query) || p.Project_Description.Contains(query))
                    .ToListAsync();
            }

        }

        // GET: api/TeamMembers
        [HttpGet("GetTeamMembers")]
        public async Task<ActionResult<IEnumerable<Team_Members>>> GetTeamMembers()
        {
            try
            {
                var teamMembers = await _dbContext.Team_Members.ToListAsync();
                return Ok(teamMembers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/TeamMembers/{id}
        [HttpGet("/TeamMembers/{id}")]
        public async Task<ActionResult<Team_Members>> GetTeamMember(int id)
        {
            try
            {
                var teamMember = await _dbContext.Team_Members.FindAsync(id);

                if (teamMember == null)
                {
                    return NotFound();
                }

                return Ok(teamMember);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
