using Database.Application.Interfaces;
using Database.Domain.Interfaces;
using SharedLibrary.Models;

namespace Database.Application.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDatabaseRepository _databaseRepository;

        public DatabaseService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public async Task<IEnumerable<ColumnInfo>> GetColumnsAsync(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("Table name cannot be null or empty.", nameof(tableName));
            }

            var columnInfo = await _databaseRepository.GetColumnsAsync(tableName);

            return columnInfo ?? Enumerable.Empty<ColumnInfo>();
        }

        public async Task<IEnumerable<TableInfo>> GetTablesAsync()
        {
            var tableInfo = await _databaseRepository.GetTablesAsync();

            return tableInfo ?? Enumerable.Empty<TableInfo>();
        }

        public async Task<IEnumerable<TableInfo>> GetViewsAsync()
        {
            var columnInfo = await _databaseRepository.GetViewsAsync();

            return columnInfo ?? Enumerable.Empty<TableInfo>();
        }
    }
}
