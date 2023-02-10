namespace trello;

public partial class Tag
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
    public int CardID { get; set; }
    public Card Card { get; set; } = null!;
}
