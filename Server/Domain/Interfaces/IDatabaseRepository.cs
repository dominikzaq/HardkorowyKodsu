using SharedLibrary.Models;

namespace Database.Domain.Interfaces
{
    public interface IDatabaseRepository
    {
        Task<IEnumerable<TableInfo>> GetTablesAsync();
        Task<IEnumerable<TableInfo>> GetViewsAsync();
        Task<IEnumerable<ColumnInfo>> GetColumnsAsync(string tableName);
    }
}
