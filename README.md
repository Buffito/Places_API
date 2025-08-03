# Places API

The **Places API** is a RESTful web service built with ASP.NET Core (.NET 8) that allows users to manage places and categories, including authentication, star ratings, and visit tracking. It uses SQLite as the database and supports JWT-based authentication.

---

## Features

- **Places Management**
  - Create, update, delete, and retrieve places
  - Mark places as visited or unvisited
  - Assign a star rating (1-5) to each place
- **Categories Management**
  - Create and retrieve categories
- **Authentication**
  - Register and login with JWT token issuance
- **API Documentation**
  - Interactive Swagger UI for exploring and testing endpoints

---

## Technologies Used

- .NET 8 / C# 12
- ASP.NET Core Web API
- Entity Framework Core (SQLite)
- AutoMapper
- JWT Authentication
- Swagger (Swashbuckle)

---

## Getting Started

### Setup Instructions

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/Buffito/finance-api.git
   cd Places_API
   ```
2. **Install Dependencies**:
   Ensure you have the .NET 8 SDK installed. Then, restore the dependencies:
   ```sh
   dotnet restore
   ```
3. **Configure the Database**:
   Update the connection string in `appsettings.json` if needed. The default setup uses SQLite.
4. **Run Migrations**:
   Apply the database migrations:
   ```sh
   dotnet ef database update
   ```
5. **Run the Application**:
   Start the application:
   ```sh
   dotnet run
   ```

6. **Access the API**
- The API will be available at `http://localhost:5242`
- Swagger UI: `http://localhost:5242/swagger`

---

## API Endpoints

### Place Endpoints

| Method | Endpoint                        | Description                  |
|--------|---------------------------------|------------------------------|
| GET    | `/api/place`                    | Get all places               |
| GET    | `/api/place/{id}`               | Get a place by ID            |
| POST   | `/api/place`                    | Create a new place           |
| PUT    | `/api/place/{id}`               | Update a place by ID         |
| DELETE | `/api/place/{id}`               | Delete a place by ID         |
| PATCH  | `/api/place/{id}/visit`         | Mark a place as visited      |
| PATCH  | `/api/place/{id}/unvisit`       | Mark a place as unvisited    |
| PATCH  | `/api/place/{id}/rate`          | Update star rating           |

### Category Endpoints

| Method | Endpoint                        | Description                  |
|--------|---------------------------------|------------------------------|
| GET    | `/api/category`                 | Get all categories           |
| GET    | `/api/category/{id}`            | Get a category by ID         |
| POST   | `/api/category`                 | Create a new category        |

### Auth Endpoints

| Method | Endpoint                        | Description                  |
|--------|---------------------------------|------------------------------|
| POST   | `/api/auth/register`            | Register a new user          |
| POST   | `/api/auth/login`               | Login and get JWT token      |

---

## Testing the API

- Use the included `Places_API.http` file in Visual Studio to test endpoints.
- Or, use Swagger UI for interactive testing.

---
