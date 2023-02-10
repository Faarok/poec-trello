namespace trello;

public class ProjectUser
{
	public int ProjectID { get; set; }
	public Project Project { get; set; }
	public int UserID { get; set; }
	public User User { get; set; }
}