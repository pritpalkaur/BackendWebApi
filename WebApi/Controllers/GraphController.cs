//using Microsoft.EntityFrameworkCore;
//using webapitaskup.Helper;
//using webapitaskup.Models;
//using webapitaskup.Interface;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using webapitaskup.Models.Graph;

//namespace WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GraphController : ControllerBase
//    {
//        private readonly AppDbContext _dbContext;
//        public int assigneeId = 1;
//        public int projectId = 1;
//        public GraphController(AppDbContext context)
//        {
//            _dbContext = context;
//        }
//        //this data is for a
//        // GET: api/<UserController>
//        [HttpGet("GetChartData/{projectId}")]
//        public async Task<ActionResult<IEnumerable<ChartsDataDto>>> GetChartData(int projectId)
//        {
//            ChartsDataDto chartdataObj = new ChartsDataDto();
//            try
//            {
//                var taskStatusCounts = await _dbContext.Tasks
//                    .Join(
//                        _dbContext.Statuses,
//                        task => task.StatusId,
//                        status => status.id,
//                        (task, status) => new { task, status }
//                    )
//                    .Where(ts => ts.task.AssigneeId == assigneeId)
//                    .GroupBy(ts => new { ts.status.id, StatusName = ts.status.StatusName })
//                    .Select(g => new TaskStatusCountDto
//                    {
//                        Status = g.Key.id,
//                        Count = g.Count(),
//                        StatusName = g.Key.StatusName // Use the status name from the grouping key
//                    })
//                    .ToListAsync();
//                // Dummy data for Chart2 and Chart3, replace with your actual logic
//                var chart2Data = new List<TaskStatusCountDto>
//            {
//                new TaskStatusCountDto { Status = 1, Count = 2, ProjectId = 2, StatusName = "To do" },
//                new TaskStatusCountDto { Status = 2, Count = 5, ProjectId = 2, StatusName = "In Progress" },
//                new TaskStatusCountDto { Status = 3, Count = 3, ProjectId = 2, StatusName = "Completed" }
//            };

//                var chart3Data = new List<TaskStatusCountDto>
//            {
//                new TaskStatusCountDto { Status = 1, Count = 6, ProjectId = 3, StatusName = "To do" },
//                new TaskStatusCountDto { Status = 2, Count = 4, ProjectId = 3, StatusName = "In Progress" },
//                new TaskStatusCountDto { Status = 3, Count = 1, ProjectId = 3, StatusName = "Completed" }
//            };

//                var tasks = await _dbContext.Tasks
//                   .Join(
//                       _dbContext.Statuses,
//                       task => task.StatusId,
//                       status => status.id,
//                       (task, status) => new { task, status }
//                   )
//                   .Join(
//                       _dbContext.complexity,
//                       ts => ts.task.ComplexityId,
//                       complexity => complexity.Id,
//                       (ts, complexity) => new { ts.task, ts.status, complexity }
//                   )
//                   .Join(
//                       _dbContext.Priority,
//                       tsc => tsc.task.PriorityId,
//                       priority => priority.Id,
//                       (tsc, priority) => new { tsc.task, tsc.status, tsc.complexity, priority }
//                   )
//                   .Join(
//                       _dbContext.Team_Members,
//                       tscp => tscp.task.AssigneeId,
//                       teamMember => teamMember.MemberId,
//                       (tscp, teamMember) => new { tscp.task, tscp.status, tscp.complexity, tscp.priority, teamMember }
//                   )
//                   .Join(
//                       _dbContext.Projects,
//                       tscptm => tscptm.task.ProjectId,
//                       project => project.ProjectId,
//                       (tscptm, project) => new { tscptm.task, tscptm.status, tscptm.complexity, tscptm.priority, tscptm.teamMember, project }
//                   )
//                   .Where(tscptmp => tscptmp.task.AssigneeId == assigneeId)
//                   .Select(tscptmp => new TasksDto
//                   {
//                       TaskId = tscptmp.task.TaskId,
//                       TaskName = tscptmp.task.TaskName,
//                       AssigneeId = tscptmp.task.AssigneeId,
//                       AssigneeName = tscptmp.teamMember.Name,
//                       DueDate = tscptmp.task.DueDate,
//                       DueDatetxt = tscptmp.task.DueDatetxt,
//                       PriorityId = tscptmp.task.PriorityId,
//                       Prioritytxt = tscptmp.priority.PriorityTxt,
//                       StatusId = tscptmp.task.StatusId,
//                       Statustxt = tscptmp.status.StatusName,
//                       Comments = tscptmp.task.Comments,
//                       ComplexityId = tscptmp.task.ComplexityId,
//                       ComplexityTxt = tscptmp.complexity.complexityTxt,
//                       ComplexitystyleTxt = tscptmp.task.ComplexitystyleTxt,
//                       CompletedDate = tscptmp.task.CompletedDate,
//                       CompletedDateTxt = tscptmp.task.CompletedDateTxt,
//                       ProjectId = tscptmp.task.ProjectId,
//                       ProjectName = tscptmp.project.Project_Name,
//                       RowClsName = tscptmp.task.DueDate < DateTime.Now ? "table-danger" : "" // Add new row class name property
//                   })
//                   .ToListAsync();


//                chartdataObj.BarChart = taskStatusCounts;
//                chartdataObj.Chart2 = chart2Data;
//                chartdataObj.Chart3 = chart3Data;
//                chartdataObj.taskTbleData = tasks;

//                return Ok(chartdataObj);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception (using your preferred logging method)
//                return StatusCode(500, "Internal server error");
//            }
//        }
//        [HttpGet("GetUserTaskStatusCounts/{projectId}")]
//        public async Task<ActionResult<ChartsDataDto>> GetUserTaskStatusCounts(int projectId)
//        {
//            try
//            {
//                DateTime now = DateTime.Now;

//                var UserBarChart = await _dbContext.Tasks
//                               .Join(
//                                   _dbContext.Projects,
//                                   tscptm => tscptm.ProjectId,
//                                   project => project.ProjectId,
//                                   (tscptm, project) => new { tscptm.AssigneeId, tscptm.TaskName, tscptm.CompletedDate, tscptm.DueDate, project.Project_Name, project.ProjectId }
//                               )
//                               .Where(tscptm => tscptm.ProjectId == projectId)
//                                .Select(g => new ProjectTaskSDto
//                                {
//                                    TaskName = g.TaskName,
//                                    CompletedDate = g.CompletedDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                                    DueDate = g.DueDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                                    ProjectId = g.ProjectId,
//                                    TodaysDate = now.ToString("yyyy-MM-dd HH:mm:ss"),
//                                    ProjectName = g.Project_Name
//                                })
//                                .ToListAsync();

//                var taskAssigneeCount = await _dbContext.Tasks
//                    .Join(
//                        _dbContext.Team_Members,
//                        task => task.AssigneeId,
//                        teamMember => teamMember.MemberId,
//                        (task, teamMember) => new { task, teamMember }
//                    )
//                    .Where(tscptm => tscptm.task.ProjectId == projectId)
//                    .GroupBy(
//                        // Group by team member properties you need
//                        x => new { x.teamMember.MemberId, x.teamMember.Name }
//                    )
//                    .Select(g => new TaskAssigneeDto
//                    {
//                        AssigneeId = g.Key.MemberId,
//                        AssigneeName = g.Key.Name,
//                        Count = g.Count()
//                    })
//                    .ToListAsync();

//                var chart2Data = taskAssigneeCount;

//                var chartsData = new UserChartsDataDto
//                {
//                    UserBarChart = UserBarChart,
//                    PieChart = taskAssigneeCount

//                };

//                return Ok(chartsData);
//            }
//            catch (Exception ex)
//            {
//                // Handle the exception as needed
//                return StatusCode(500, ex.Message);
//            }
//        }
//    }

//}

