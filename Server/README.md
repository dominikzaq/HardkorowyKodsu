# Configuration

To configure the database connection, update the `appsettings.Development.json` file with the appropriate settings.

### Example Configuration

```json
"SqlConnection": "Server=localhost,1433 Database=AdventureWorks;User Id=sa;Password=StrongPass1!;TrustServerCertificate=True"
```

### Notes:

- **`Server`**: Specifies the database server's hostname and port. In the example, it is `localhost` with port `1433`.
- **`Database`**: Indicates the name of the database, e.g., `AdventureWorks`.
- **`User Id`**: The username to authenticate with the database server.
- **`Password`**: The password for the specified user.
- **`TrustServerCertificate`**: Set to `True` if you are using a self-signed SSL certificate or testing locally.
