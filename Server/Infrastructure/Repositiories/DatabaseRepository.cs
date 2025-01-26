using Dapper;
using Database.Domain.Interfaces;
using Database.Infrastructure.Context;
using SharedLibrary.Models;

namespace Database.Infrastructure.Repositiories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly DapperContext _context;

        public DatabaseRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TableInfo>> GetTablesAsync()
        {
            var query = "SELECT TABLE_NAME AS TableName FROM INFORMATION_SCHEMA.TABLES";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<TableInfo>(query);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<TableInfo>> GetViewsAsync()
        {
            var query = "SELECT TABLE_NAME AS TableName FROM INFORMATION_SCHEMA.VIEWS";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<TableInfo>(query);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<ColumnInfo>> GetColumnsAsync(string tableName)
        {
            using (var connection = _context.CreateConnection())
            {
                string query = @"SELECT COLUMN_NAME AS ColumnName, DATA_TYPE AS DataType,
                               IS_NULLABLE AS IsNullable,
                               COLUMN_DEFAULT AS ColumnDefault
                               FROM INFORMATION_SCHEMA.COLUMNS 
                               WHERE TABLE_NAME = @TableName
                               order by ORDINAL_POSITION";

                var parameters = new { TableName = tableName };

                var result = await connection.QueryAsync<ColumnInfo>(query, parameters);

                return result.ToList();
            }
        }
    }
}
