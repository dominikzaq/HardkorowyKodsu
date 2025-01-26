using Client.Services;
using SharedLibrary.Models;

namespace Client
{
    public partial class MainForm : Form
    {
        private readonly ApiClient _apiClient;

        public MainForm()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
        }



        private async void btnLoadViews_Click(object sender, EventArgs e)
        {
            await LoadViewsAsync();

            gridColumns.DataSource = null;
        }

        private async Task LoadTablesAsync()
        {
            try
            {
                var tables = await _apiClient.GetTablesAsync();
                list.DataSource = tables.Select(t => t.TableName).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d podczas pobierania danych: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadViewsAsync()
        {
            try
            {
                var views = await _apiClient.GetViewsAsync();
                list.DataSource = views.Select(t => t.TableName).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d podczas pobierania danych: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void listTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTable = list.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(selectedTable))
            {
                await LoadColumnsForTableAsync(selectedTable);
            }
        }
        private void GridColumns_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (var item in columnTitleMappings)
            {
                if (gridColumns.Columns.Contains(item.Key))
                {
                    gridColumns.Columns[item.Key].HeaderText = item.Value;
                }
            }

            // Optional: Adjust column styles or widths
            gridColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private async void listViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTable = list.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(selectedTable))
            {
                await LoadColumnsForTableAsync(selectedTable);
            }
        }

        Dictionary<string, string> columnTitleMappings = new Dictionary<string, string>
        {
            { "ColumnName", "Column Name" },
            { "DataType", "Data Type" },
            { "IsNullable", "Nullable" },
            { "ColumnDefault", "Default" }
        };
        private async Task LoadColumnsForTableAsync(string tableName)
        {
            try
            {
                List<ColumnInfo> columns = await _apiClient.GetColumnsAsync(tableName);
                foreach (var column in gridColumns.Columns.Cast<DataGridViewColumn>())
                {
                    if (columnTitleMappings.ContainsKey(column.Name))
                    {
                        column.HeaderText = columnTitleMappings[column.Name];
                    }
                }
                gridColumns.DataSource = columns;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d podczas pobierania kolumn dla tabeli '{tableName}': {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLoadTables_Click(object sender, EventArgs e)
        {
            await LoadTablesAsync();

            gridColumns.DataSource = null;
        }
    }
}
