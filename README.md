# MongoDB .NET Minimal API Example with Scalar

This project demonstrates a simple CRUD API using MongoDB and .NET Minimal APIs, with API documentation and testing provided via Scalar.

## Prerequisites
- .NET 8 or later
- MongoDB instance (local or remote)

## MongoDB Connection Setup
Edit the `appsettings.json` (or `appsettings.Development.json`) file to configure your MongoDB connection:

```json
  "MongoDBSettings": {
    "CollectionName": "Games",           // Name of the MongoDB collection
    "ConnectionString": "<your-connection-uri>", // MongoDB connection URI
    "DatabaseName": "GamesDB"            // Name of the database
  }
```

Replace `<your-connection-uri>`, `GamesDB`, and `Games` with your actual MongoDB details.

## Running the Application
1. **Clone the repository**
   ```sh
   git clone <repo-url>
   cd mongodb-dotnet-minimal-api-example
   ```

2. **Configure MongoDB connection** as described above.

3. **Run the application**
   ```sh
   dotnet run
   ```
   - The API will start at `http://localhost:5216` (or the port specified in `launchSettings.json`).

4. **Launch the Scalar UI**
   - Open your browser and go to `http://localhost:5216/scalar`.
   - If using Visual Studio or VS Code, you can use the Debug or Run feature to automatically launch the browser to the Scalar UI (see `launchSettings.json`).

## Testing the API via Scalar
- Use the Scalar UI at `/scalar` to view API documentation and interactively test the endpoints.
- Basic error handling is implemented for POST, PUT, and DELETE endpoints. If an error occurs, you will receive a problem response with details.

## License
Apache 2.0
