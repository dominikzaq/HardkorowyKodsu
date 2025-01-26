namespace SharedLibrary.Models
{
    public class ColumnInfo
    {
        public string ColumnName { get; set; } = null!;
        public string DataType { get; set; } = null!;
        public string IsNullable { get; set; } = null!;
        public string ColumnDefault { get; set; } = null!;
    }
}
