namespace webapitaskup.Models.Graph
{
    
    public class ChartsDataDto
    {
        public List<TaskStatusCountDto> BarChart { get; set; }
        public List<TaskStatusCountDto> Chart2 { get; set; }
        public List<TaskStatusCountDto> Chart3 { get; set; }
        public List<TasksDto> taskTbleData { get; set; }
    }
    public class TaskStatusCountDto
    {
        public int Status { get; set; }
        public int Count { get; set; }
        public int ProjectId { get; set; }
        public string StatusName { get; set; }
        public int AssigneeId { get; set; }
    }

    public class TasksDto
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int AssigneeId { get; set; }
        public string? AssigneeName { get; set; }
        public DateTime DueDate { get; set; }
        public string DueDatetxt { get; set; }
        public int PriorityId { get; set; }
        public string Prioritytxt { get; set; }
        public int StatusId { get; set; }
        public string Statustxt { get; set; }
        public string? Comments { get; set; }
        public int ComplexityId { get; set; }
        public string ComplexityTxt { get; set; }
        public string ComplexitystyleTxt { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CompletedDateTxt { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string RowClsName { get; set; }
    }

    //-----------------------------------------------------------------------------------------------------------------------
    public class ProjectTaskSDto
    {
        public string DueDate { get; set; }
        public string CompletedDate { get; set; }
        public string TodaysDate { get; set; }
        public string MonthName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
    }
    public class TaskAssigneeDto
    {
        public int Status { get; set; }
        public int Count { get; set; }
        public int ProjectId { get; set; }
        public string AssigneeName { get; set; }
        public int AssigneeId { get; set; }
    }
    public class UserChartsDataDto
    {
        public List<ProjectTaskSDto> UserBarChart { get; set; }
        public List<TaskAssigneeDto> PieChart { get; set; }
    }
}
