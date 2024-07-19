namespace webapitaskup.Helper
{
	public class Utilities
	{
		public static readonly string SessionName = "x_ses_ath";
		public static readonly string LastVisitedUrl = "x_ses_last_url";
		public enum TaskStatus
		{
			Completed = 3,
			InPro = 2,
			ToDo = 1
		}
		public enum ProjectStatus
		{
			isActive = 1,
			notActive = 0
		}
		public enum Teams
		{
			Finance_BI_and_Automation_team = 1
		}
		public enum Roles
		{
			Admin = 1,
			User = 2
		}
		public enum Priority
		{
			Low = 1,
			Medium = 2,
			High=3
		}
	}
}
