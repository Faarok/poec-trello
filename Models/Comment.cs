namespace trello;

public partial class Comment
{
    public int ID { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public int CardID { get; set; }
    public Card Card { get; set; } = null!;
    public int UserID { get; set; }
    public User User { get; set; } = null!;
}
