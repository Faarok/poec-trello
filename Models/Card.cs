namespace trello;

public partial class Card
{
    public int ID { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public int ListID { get; set; }
    public List List { get; set; } = null!;
    public List<Comment>? CommentList;
    public List<Tag>? TagList;
}
