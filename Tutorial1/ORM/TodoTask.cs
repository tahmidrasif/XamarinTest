using SQLite;

namespace Tutorial1.ORM
{
    [Table("TodoTask")]
    public class TodoTask
    {
        [PrimaryKey,AutoIncrement,Column("_Id")]
        public int Id { get; set; }
        public string Task { get; set; }

    }
}