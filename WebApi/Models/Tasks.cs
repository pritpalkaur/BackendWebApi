using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class dashboard
    {
        public string UserName { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string completedtaskCount { get; set; }
        public string inProgresstaskCount { get; set; }
        public string toDotaskCount { get; set; }
        public List<Tasks> tasksList { get; set; }
        public string userChoice { get; set; }

    }
    public class PageDetail
    {
        public int LoggedinUserId { get; set; }
        public List<SelectListItem> projects { get; set; }
        public string project { get; set; }
        public List<SelectListItem> AssigneeNameList { get; set; }
        public string AssigneeName { get; set; }
        public List<SelectListItem> priorityList { get; set; }
        public string PriortyName { get; set; }
        public int projectIdFromMenu { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public List<Tasks> _completed { get; set; }
        public List<Tasks> _inpro { get; set; }
        public List<Tasks> _todo { get; set; }
        public int RoleId { get; set; }
        public int userId { get; set; }
        public string UserName { get; set; }
    }
    public class teamspage
    {
        public List<Teams> teamsList { get; set; }
        public List<Team_Members> team_MembersList { get; set; }
        public List<Role> roleList { get; set; }
        public Team_Members team_Members { get; set; }
        public List<SelectListItem> teamsDrpdn { get; set; }
        public string teamName { get; set; }
        public List<SelectListItem> rolesDrpdn { get; set; }
        public string roleName { get; set; }
    }
    public class editTeamsPage
    {
        public Team_Members team_Member { get; set; }
        public Teams teams4tab { get; set; }
        public List<Teams> teams { get; set; }
        public List<Team_Members> teamMembersList { get; set; }
        public List<SelectListItem> teamsDrpdn { get; set; }
        public string teamName { get; set; }
        public List<SelectListItem> rolesDrpdn { get; set; }
        public string roleName { get; set; }

    }
    public class EditData
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string IsActive { get; set; }
        public int TeamID { get; set; }
        public int RoleID { get; set; }
    }
    public class ProjectPageDetail
    {
        public List<SelectListItem> Projects { get; set; }
        public List<Project> ProjectList { get; set; }
        public int RoleID { get; set; }
        public List<SelectListItem> teamsDrpdn { get; set; }
        public string teamName { get; set; }
        public string UserName { get; set; }
        public String canAccessClass { get; set; }

    }
    [Table("Tasks_L3")]
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        [Column("TaskName")]
        public string TaskName { get; set; }
        [Column("AssigneeId")]
        public int AssigneeId { get; set; }
        [NotMapped]
        public string? AssigneeName { get; set; }
        [NotMapped]
        public int RoleID { get; set; }
        [Column("DueDate")]
        public DateTime DueDate { get; set; }
        [NotMapped]
        public string DueDatetxt { get; set; }

        [Column("PriorityId")]
        public int PriorityId { get; set; }
        [NotMapped]
        public string Prioritytxt { get; set; }

        [Column("StatusId")]
        public int StatusId { get; set; }
        [NotMapped]
        public string Statustxt { get; set; }
        [Column("Comments")]
        public string? Comments { get; set; }
        [Column("ComplexityId")]
        public int ComplexityId { get; set; }
        [NotMapped]
        public string ComplexityTxt { get; set; }
        [NotMapped]
        public string ComplexitystyleTxt { get; set; }
        [Column("CompletedDate")]
        public DateTime CompletedDate { get; set; }
        [NotMapped]
        public string CompletedDateTxt { get; set; }
        [Column("ProjectId")]
        public int ProjectId { get; set; }
        [NotMapped]
        public string DelBtnVisiblity { get; set; }
    }

    [Table("Team_Members_L2")]
    public class Team_Members
    {
        [Key]
        [Column("MemberId")]
        public int MemberId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("isActive")]
        public string isActive { get; set; }

        [Column("TeamID")]
        public int TeamID { get; set; }
        [Column("RoleID")]
        public int RoleID { get; set; }
        [NotMapped]
        public string TeamTxt { get; set; }
        [NotMapped]
        public string RoleTxt { get; set; }
    }

    [Table("Projects_L2")]
    public class Project
    {
        public int ProjectId { get; set; }
        public string Project_Name { get; set; }
        public string Project_Description { get; set; }
        public string isActive { get; set; }
        [NotMapped]
        public string TeamName { get; set; }
        [NotMapped]
        public string isActiveName { get; set; }
        public int TeamId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CeatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int isDeleted { get; set; }

    }
    public class CreateProjectDto
    {
        public string Project_Name { get; set; }
        public string Project_Description { get; set; }
        public string isActive { get; set; }
        public string TeamId { get; set; }
    }
    public class UpdateProjectDto
    {
        public int projectId { get; set; }
        public string Project_Name { get; set; }
        public string Project_Description { get; set; }
        public string isActive { get; set; }
        //public string TeamId { get; set; }
        //public string isActiveName { get; set; }
        public int TeamId { get; set; }
       // public string teamName { get; set; }
    }
    public class ProjectwithTeams
    {
        public int ProjectId { get; set; }
        public string Project_Name { get; set; }
        public string Project_Description { get; set; }
        public string isActive { get; set; }
        [NotMapped]
        public string TeamName { get; set; }
        [NotMapped]
        public string isActiveName { get; set; }
        public int TeamId { get; set; }

    }
    [Table("Roles_L1")]
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    [Table("Statuses")]
    public class Statuses
    {
        public int id { get; set; }
        public string StatusName { get; set; }
    }
    [Table("Teams_L1")]
    public class Teams
    {
        [Key]
        public int TeamID { get; set; }
        public string Team_Name { get; set; }
        public string Team_Descriptoin { get; set; }
        public string isActive { get; set; }
    }

    public class complexity
    {
        public int Id { get; set; }
        public string complexityTxt { get; set; }
    }
    public class Priority
    {
        public int Id { get; set; }
        public string PriorityTxt { get; set; }

    }
    public class TaskWithAssigneeAndRole
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int AssigneeId { get; set; }
        public DateTime DueDate { get; set; } // Assuming DueDate is nullable in your database
        public string DueDateTxtVal { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public string Comments { get; set; }
        public int ComplexityId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? CompletedDate { get; set; } // Assuming CompletedDate is nullable in your database
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
    public class TaskUpdate
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public int assigneeId { get; set; }
        public string assigneeName { get; set; }
        public string comments { get; set; }
        public int complexityId { get; set; }
        public string complexityTxt { get; set; }
        public string dueDatetxt { get; set; }
        public int priorityId { get; set; }
        public int projectId { get; set; }
        public string prioritytxt { get; set; }
        public string DueDate { get; set; }
    }
    public class DeleteTaskRequest
    {
        public int taskId { get; set; }
    }
    public class CreateTaskRequest
    {
        public int projectID { get; set; }
        public string assigneeId { get; set; }
        public string comments { get; set; }
        public int complexity { get; set; }
        public DateTime dueDate { get; set; }
        public int priority { get; set; }
        public string taskName { get; set; }
    }
    public class SpExceptionsDetals
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("message")]
        public string message { get; set; }
        [Column("stack_trace")]
        public string stack_trace { get; set; }
        [Column("inner_exception")]
        public string inner_exception { get; set; }
        [Column("created_at")]
        public DateTime created_at { get; set; }
    }

    public class GetUserInfoDto
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string IsActive { get; set; }
        public int TeamID { get; set; }
        public int RoleID { get; set; }
        public string Team_Name { get; set; }
        public string Team_Descriptoin { get; set; }
    }

}
