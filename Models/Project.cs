namespace trello;

public partial class Project
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreationDate { get; set; } = DateTime.Today;
    public List<List>? ListList;
    public List<ProjectUser>? ProjectUserList;
}
