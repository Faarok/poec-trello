namespace trello;

public partial class List
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public List<Card>? CardList;
    public int ProjectID { get; set; }
    public virtual Project Project { get; set; } = null!;
}
