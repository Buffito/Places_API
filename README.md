# Places API

The **Places API** is a RESTful web service built with ASP.NET Core targeting .NET 8. It allows users to manage places and categories, including creating, updating, deleting, and retrieving information about places and their associated categories.

## Features

- **Places Management**:
  - Create, update, delete, and retrieve places.
  - Mark places as visited or unvisited.
- **Categories Management**:
  - Create and retrieve categories.

## Technologies Used

- **.NET 8**
- **C# 12**
- **Entity Framework Core** (SQLite for database)
- **AutoMapper** (for object mapping)

## Endpoints

### Place Endpoints

| Method | Endpoint                  | Description                     |
|--------|---------------------------|---------------------------------|
| GET    | `/api/place`              | Get all places                 |
| GET    | `/api/place/{id}`         | Get a place by ID              |
| POST   | `/api/place`              | Create a new place             |
| PUT    | `/api/place/{id}`         | Update a place by ID           |
| DELETE | `/api/place/{id}`         | Delete a place by ID           |
| PATCH  | `/api/place/{id}/visit`   | Mark a place as visited        |
| PATCH  | `/api/place/{id}/unvisit` | Mark a place as unvisited      |

### Category Endpoints

| Method | Endpoint                  | Description                     |
|--------|---------------------------|---------------------------------|
| GET    | `/api/category`           | Get all categories             |
| GET    | `/api/category/{id}`      | Get a category by ID           |
| POST   | `/api/category`           | Create a new category          |

## Setup Instructions

1. **Clone the Repository**:
   git clone <repository-url> cd Places_API
2. **Install Dependencies**:
   Ensure you have the .NET 8 SDK installed. Then, restore the dependencies:
   dotnet restore
3. **Configure the Database**:
   Update the connection string in `appsettings.json` if needed. The default setup uses SQLite.
4. **Run Migrations**:
   Apply the database migrations:
   dotnet ef database update
5. **Run the Application**:
   Start the application:
   dotnet run

6. **Access the API**:
   The API will be available at `http://localhost:5242`. Swagger documentation can be accessed at `http://localhost:5242/swagger`.

## Testing the API

You can use the `Places_API.http` file to test the API endpoints directly from Visual Studio. Open the file, place the cursor on a request, and execute it.

## Project Structure

- **Controllers**: Contains API controllers for handling HTTP requests.
- **Services**: Contains business logic for managing places and categories.
- **DTOs**: Data Transfer Objects for input/output models.
- **Data**: Database context and migrations.
