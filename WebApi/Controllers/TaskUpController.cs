//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using webapitaskup.Helper;
//using webapitaskup.Models;
//using webapitaskup.Interface;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TaskUpController : ControllerBase
//    {
//        private readonly AppDbContext _dbContext;
//        //private readonly IErrorLogger _errorLogger;
//        public TaskUpController(AppDbContext context)//, IErrorLogger errorLogger
//        {
//            _dbContext = context;
//           // _errorLogger = errorLogger;
//        }
//        // GET: api/Persons
//        [HttpGet("GetTasks/{id}")]
//        public PageDetail GetTasks(int id)
//        {
//            int roleId = 1;// Convert.ToInt32(SessionManager.GetSessionValue<string>(HttpContext, "roleId"));
//            int usereId = 1;// Convert.ToInt32(SessionManager.GetSessionValue<string>(HttpContext, "usereId"));
//            var projectList = _dbContext.Projects.ToList();
//            string projectName = projectList.Where(x => x.ProjectId == id).Select(y => y.Project_Name).FirstOrDefault();
//            string projectDescription = projectList.Where(x => x.ProjectId == id).Select(y => y.Project_Description).FirstOrDefault();
//            List<SidebarItem> projectLisFromDb = new List<SidebarItem>();
//            foreach (var item in projectList)
//            {
//                SidebarItem obj = new SidebarItem();
//                obj.Title = item.Project_Name;
//                obj.Url = "/TaskUp/index?id=" + item.ProjectId;
//                projectLisFromDb.Add(obj);
//            }


//            //ViewData["SidebarItems"] = projectLisFromDb;

//            //------------------------------------------------
//            List<Tasks> tasksList = new List<Tasks>();
//            PageDetail pagedetails = new PageDetail();
//            var resultList = new List<TaskWithAssigneeAndRole>();
//            List<Team_Members> teamMembersList = new List<Team_Members>();
//            List<TaskWithAssigneeAndRole> resultListafterProj = resultList.Where(x => x.ProjectId == id).ToList();
//            int currntAssigneeId = 0;
//            List<TaskWithAssigneeAndRole> queryResult = new List<TaskWithAssigneeAndRole>();
//            try
//            {
//                if (id != 0)
//                {
//                    var query = from t in _dbContext.Tasks
//                                join a in _dbContext.Team_Members on t.AssigneeId equals a.MemberId
//                                join r in _dbContext.Role on a.RoleID equals r.RoleID
//                                where t.AssigneeId == usereId && t.ProjectId == id // Apply both filters here
//                                select new TaskWithAssigneeAndRole
//                                {
//                                    TaskId = t.TaskId,
//                                    TaskName = t.TaskName,
//                                    AssigneeId = t.AssigneeId,
//                                    DueDate = t.DueDate,
//                                    PriorityId = t.PriorityId,
//                                    StatusId = t.StatusId,
//                                    Comments = t.Comments,
//                                    ComplexityId = t.ComplexityId,
//                                    ProjectId = t.ProjectId,
//                                    CompletedDate = t.CompletedDate,
//                                    RoleID = r.RoleID,
//                                    RoleName = r.RoleName
//                                };
//                    queryResult = query.ToList();
//                }
//                else
//                {

//                    var query = from t in _dbContext.Tasks
//                                join a in _dbContext.Team_Members on t.AssigneeId equals a.MemberId
//                                join r in _dbContext.Role on a.RoleID equals r.RoleID
//                                where t.AssigneeId == usereId && t.ProjectId == id // Apply both filters here
//                                select new TaskWithAssigneeAndRole
//                                {
//                                    TaskId = t.TaskId,
//                                    TaskName = t.TaskName,
//                                    AssigneeId = t.AssigneeId,
//                                    DueDate = t.DueDate,
//                                    PriorityId = t.PriorityId,
//                                    StatusId = t.StatusId,
//                                    Comments = t.Comments,
//                                    ComplexityId = t.ComplexityId,
//                                    ProjectId = t.ProjectId,
//                                    CompletedDate = t.CompletedDate,
//                                    RoleID = r.RoleID,
//                                    RoleName = r.RoleName
//                                };
//                    queryResult = query.ToList();
//                    pagedetails.userId = usereId;
//                }

//                foreach (var item in queryResult)
//                {
//                    TaskWithAssigneeAndRole obj = new TaskWithAssigneeAndRole
//                    {
//                        TaskId = item.TaskId,
//                        TaskName = item.TaskName,
//                        AssigneeId = item.AssigneeId,
//                        DueDate = item.DueDate,
//                        PriorityId = item.PriorityId,
//                        StatusId = item.StatusId,
//                        Comments = item.Comments,
//                        ComplexityId = item.ComplexityId,
//                        ProjectId = item.ProjectId,
//                        CompletedDate = item.CompletedDate,
//                        RoleID = item.RoleID,
//                        RoleName = item.RoleName
//                    };
//                    resultList.Add(obj);
//                }
//                teamMembersList = _dbContext.Team_Members.ToList();
//                foreach (var item in resultList)
//                {
//                    Tasks taskObj = new Tasks();
//                    pagedetails.LoggedinUserId = 1;
//                    var t1 = _dbContext.Team_Members.FirstOrDefault(m => m.RoleID == pagedetails.LoggedinUserId);
//                    currntAssigneeId = item.AssigneeId;
//                    if (t1 != null)
//                    {
//                        if (t1.RoleID == (int)Utilities.Roles.Admin)
//                        {
//                            // A row with the specified RoleID exists in the table
//                            taskObj.RoleID = (int)Utilities.Roles.Admin;
//                        }
//                        else if (t1.RoleID == (int)Utilities.Roles.User)
//                        {
//                            // No row with the specified RoleID exists in the table
//                            taskObj.RoleID = (int)Utilities.Roles.User;
//                        }

//                    }


//                    var teamMember = teamMembersList.FirstOrDefault(x => x.MemberId == item.AssigneeId);
//                    if (teamMember != null)
//                    {
//                        string AssigneeName = teamMember.Name;

//                        taskObj.AssigneeName = AssigneeName; // Or handle accordingly
//                    }
//                    item.DueDate = item.DueDate;//.ToString("yyyy-MM-dd");
//                    string DueDateTxtVal = item.DueDate.ToString("yyyy-MM-dd");
//                    if (item.StatusId == 3)
//                    {
//                        taskObj.Statustxt = "Completed";
//                    }
//                    else if (item.StatusId == 2)
//                    {
//                        taskObj.Statustxt = "In Progress";
//                    }
//                    else if (item.StatusId == 1)
//                    {
//                        taskObj.Statustxt = "To do";
//                    }

//                    if (item.PriorityId == 3)
//                    {
//                        taskObj.Prioritytxt = "High";
//                    }
//                    else if (item.PriorityId == 2)
//                    {
//                        taskObj.Prioritytxt = "Medium";
//                    }
//                    else if (item.PriorityId == 1)
//                    {
//                        taskObj.Prioritytxt = "Low";
//                    }
//                    //---------------
//                    if (item.ComplexityId == 3)
//                    {
//                        taskObj.ComplexityTxt = "High";
//                        taskObj.ComplexitystyleTxt = "btn btn-outline-danger btn-sm";
//                    }
//                    else if (item.ComplexityId == 2)
//                    {
//                        taskObj.ComplexityTxt = "Medium";
//                        taskObj.ComplexitystyleTxt = "btn btn-outline-warning btn-sm";
//                    }
//                    else if (item.ComplexityId == 1)
//                    {
//                        taskObj.ComplexityTxt = "Low";
//                        taskObj.ComplexitystyleTxt = "btn btn-outline-info btn-sm";
//                    }
//                    taskObj.StatusId = item.StatusId;
//                    taskObj.TaskId = item.TaskId;
//                    taskObj.AssigneeId = item.AssigneeId;
//                    taskObj.PriorityId = item.PriorityId;
//                    taskObj.ComplexityId = item.ComplexityId;
//                    taskObj.PriorityId = item.PriorityId;
//                    taskObj.TaskName = item.TaskName;
//                    taskObj.Comments = item.Comments;
//                    taskObj.DueDatetxt = DueDateTxtVal;
//                    taskObj.ProjectId= item.ProjectId;
//                    tasksList.Add(taskObj);
//                }


//                projectList = _dbContext.Projects.ToList();

//            }
//            catch (Exception ex)
//            {

//               // _errorLogger.LogMessage(ex);
//            }

//            List<SelectListItem> projectsSelectList = projectList.ConvertAll(a =>
//            {
//                return new SelectListItem()
//                {
//                    Text = a.Project_Name.ToString(),
//                    Value = a.ProjectId.ToString(),
//                    Selected = (a.ProjectId == 1)

//                };
//            });
//            #region assignee
//            // Create a default SelectListItem for "Select Assignee"
//            SelectListItem selectAssigneeItem = new SelectListItem()
//            {
//                Text = "Select Assignee",
//                Value = "0", // You can assign any value for the default option
//                Selected = true // Make it selected by default
//            };
//            teamMembersList = _dbContext.Team_Members.ToList();
//            List<SelectListItem> teamMembersSelectList = teamMembersList.ConvertAll(a =>
//            {
//                return new SelectListItem()
//                {
//                    Text = a.Name.ToString(),
//                    Value = a.MemberId.ToString(),
//                    Selected = false

//                };
//            });
//            // Insert the default SelectListItem at the beginning of the list
//            // teamMembersSelectList.Insert(0, selectAssigneeItem);



//            #endregion

//            #region priority
//            List<SelectListItem> priorityList = new List<SelectListItem>();

//            priorityList.Add(new SelectListItem { Value = "1", Text = "high" });
//            priorityList.Add(new SelectListItem { Value = "2", Text = "medium" });
//            priorityList.Add(new SelectListItem { Value = "3", Text = "low" });

//            pagedetails.priorityList = priorityList;
//            #endregion
//            //--------------------username---------------------------
//            Team_Members teamMemberfordb = new Team_Members();
//            teamMemberfordb = _dbContext.Team_Members.Where(x => x.MemberId == usereId).SingleOrDefault();
//            //pagedetails.UserName = teamMemberfordb.Name;
//            //-------------------------------------------------------------------------------------
//            pagedetails.AssigneeNameList = teamMembersSelectList;
//           // pagedetails._todo = tasksList.Where(x => x.StatusId == (int)Utilities.TaskStatus.ToDo).ToList();
//           // pagedetails._inpro = tasksList.Where(x => x.StatusId == (int)Utilities.TaskStatus.InPro).ToList();
//            pagedetails._completed = tasksList.ToList();
//           // pagedetails.projects = projectsSelectList;
//           // pagedetails.projectIdFromMenu = id;
//           // pagedetails.projectName = projectName;
//           // pagedetails.projectDescription = projectDescription;
//           // pagedetails.RoleId = roleId;




//            return pagedetails; // _dbContext.Tasks.ToListAsync();
//        }

//        [HttpPost("CreateTask")]
//        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
//        {
//            if (request == null)
//            {
//                return BadRequest("Invalid task data.");
//            }

//            var task = new Tasks
//            {
//                ProjectId= request.projectID,
//                TaskName = request.taskName,
//                AssigneeId = Convert.ToInt16(request.assigneeId),
//                DueDate = request.dueDate,
//                PriorityId = request.priority,
//                Comments = request.comments,
//                ComplexityId = request.complexity,
//                StatusId = 1, // Assuming 1 is the default status for new tasks
//            };
//            try
//            {
//                _dbContext.Tasks.Add(task);
//                await _dbContext.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
  

//            return Ok(task);
//        }


//        [HttpPost("UpdateTask")]
//        public IActionResult UpdateTask([FromBody] TaskUpdate updatedTask)
//        {
          
//            if (updatedTask == null || updatedTask.taskId == 0)
//            {
//                return BadRequest("Invalid task data.");
//            }

//            var existingTask = _dbContext.Tasks.FirstOrDefault(t => t.TaskId == updatedTask.taskId);
//            if (existingTask == null)
//            {
//                return NotFound("Task not found.");
//            }
//            if (updatedTask.prioritytxt=="High")
//            {
//                existingTask.PriorityId= (int)Utilities.Priority.High;

//            }
//            else if (updatedTask.prioritytxt == "Medium")
//            {
//                 existingTask.PriorityId = (int)Utilities.Priority.Medium;
//            }
//            else if (updatedTask.prioritytxt == "Low")
//            {
//                existingTask.PriorityId = (int)Utilities.Priority.Low;
//            }
//            DateTime newDate = DateTime.Now;
//            try
//            {
//                newDate = Convert.ToDateTime(updatedTask.DueDate);
//            }
//            catch (FormatException ex)
//            {
//                // Handle the format exception
//                Console.WriteLine("Invalid date format: " + ex.Message);
//            }
//            // Update task properties
//            existingTask.TaskName = updatedTask.taskName;
//            existingTask.AssigneeId = updatedTask.assigneeId;
//            existingTask.DueDate = newDate;
//            //existingTask.StatusId = updatedTask.StatusId;
//            existingTask.Comments = updatedTask.comments;
//            existingTask.ComplexityId = updatedTask.complexityId;
//           // existingTask.ProjectId = updatedTask.projectId;

//            // Save changes to the database
//            _dbContext.SaveChanges();

//            return Ok("Task updated successfully.");
//        }
//        [HttpPost("DeleteTask")]
//        public async Task<IActionResult> DeleteTask([FromBody] DeleteTaskRequest request)
//        {
//            if (request == null || request.taskId == 0)
//            {
//                return BadRequest("Invalid task ID.");
//            }

//            var task = await _dbContext.Tasks.FindAsync(request.taskId);
//            if (task == null)
//            {
//                return NotFound("Task not found.");
//            }

//            _dbContext.Tasks.Remove(task);
//            await _dbContext.SaveChangesAsync();

//            return Ok("Task deleted successfully.");
//        }
//    }

//}

