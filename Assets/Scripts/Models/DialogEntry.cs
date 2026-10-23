using SQLite;

[Table("DialogEntries")]
public class DialogEntry
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public string CharacterName { get; set; }
    [NotNull]
    public string Text { get; set; }
    public string Condition { get; set; }
}
