using SQLite;
namespace LizardSpockDroid
{
    [Table("Scores")]
    public class Scores
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(10)]
        public string WinnerName { get; set; }
        public int Score { get; set; }
    }
}