# Configuration

To configure the `App.config` file, update the `ApiBaseAddress` setting with the appropriate backend application address.

### Example Configuration

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="ApiBaseAddress" value="https://localhost:7230/api/" />
  </appSettings>
</configuration>
```

### Notes:

- **`ApiBaseAddress`**: Replace `https://localhost:7230/api/` with the base address of your backend application.
  - Example: `https://api.yourdomain.com/` or `http://192.168.1.100:5000/api/`.
- Ensure the backend application is running and accessible from your application’s environment.
