using Database.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace Database.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        public DatabaseController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet("tables")]
        public async Task<ActionResult<IEnumerable<TableInfo>>> GetTables()
        {
            var tables = await _databaseService.GetTablesAsync();
            return Ok(tables);
        }

        [HttpGet("views")]
        public async Task<ActionResult<IEnumerable<TableInfo>>> GetViews()
        {
            var views = await _databaseService.GetViewsAsync();
            return Ok(views);
        }

        [HttpGet("columns/{tableName}")]
        public async Task<ActionResult<IEnumerable<ColumnInfo>>> GetTableColumns(string tableName)
        {
            var columns = await _databaseService.GetColumnsAsync(tableName);
            return Ok(columns);
        }
    }
}
