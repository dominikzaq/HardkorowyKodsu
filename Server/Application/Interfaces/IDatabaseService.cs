using SharedLibrary.Models;

namespace Database.Application.Interfaces
{
    public interface IDatabaseService
    {
        Task<IEnumerable<TableInfo>> GetTablesAsync();
        Task<IEnumerable<TableInfo>> GetViewsAsync();
        Task<IEnumerable<ColumnInfo>> GetColumnsAsync(string tableName);
    }
}
