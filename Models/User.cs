namespace trello;

public partial class User
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime SignupDate { get; set; } = DateTime.Today;
    public List<Comment>? CommentList;
    public List<ProjectUser>? ProjectUserList;

    public User()
    {
    }
}
