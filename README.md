Conference Room Management Project
This is a comprehensive system designed to manage conference room bookings, availability, and related services for a company that rents out conference rooms to businesses. The system allows users to search for available rooms, create bookings, update bookings, and calculate rental costs based on time, services, and other room-specific parameters.

Table of Contents
Features
Technologies Used
Architecture Overview
Installation
Database Schema
API Endpoints
Usage Examples
Optimistic Concurrency Handling
Error Handling
Testing
Future Improvements

Features
Room Management: Manage conference rooms with specific attributes like capacity, base hourly rate, and available services.
Booking Management: Create, update, retrieve, and delete bookings. Handle conflicts and overlapping bookings.
Availability Search: Check room availability within a given time frame, filter based on capacity and other parameters.
Service Management: Attach additional services (e.g., catering, technical support) to rooms or bookings.
Optimistic Concurrency Control: Handle potential concurrency conflicts when multiple users try to modify the same entity.
Cost Calculation: Dynamically calculate rental costs based on time and selected services.

Technologies Used
.NET 8.0: Backend framework to build the API.
Entity Framework Core: ORM for database interactions.
SQL Server: The database used to store room and booking data.
Microsoft Dependency Injection: For managing services and repositories.
AutoMapper: For mapping domain entities to DTOs.
LINQ: For querying data.
MSTest/xUnit/NUnit: For unit testing.
Swagger: API documentation and testing.

Architecture Overview
This project follows a Clean Architecture approach, separating the code into layers:

Domain Layer: Contains the business logic and core domain entities, interfaces, and value objects.
Application Layer: Holds the service implementations, DTOs, and interfaces for application logic (e.g., room and booking services).
Infrastructure Layer: Handles persistence, repositories, and external dependencies like databases.
Presentation Layer: The API endpoints that interact with clients (users, UI).

Installation
Clone the repository:



git clone https://github.com/your-repo/conference-room-management.git
cd conference-room-management

Install dependencies: Make sure you have .NET SDK installed and run:
dotnet restore

Set up the database: Update the connection string in appsettings.json to point to your SQL Server instance:
"ConnectionStrings": {
   "DefaultConnection": "Server=.;Database=ConferenceRoomDB;Trusted_Connection=True;"
}

Run Entity Framework migrations to set up the database:
dotnet ef database update


Run the project:
dotnet run

Access the API: The API will be available at:
http://localhost:5000

Swagger documentation will be available at:
http://localhost:xxxx/swagger

Database Schema
Tables:
Rooms

Id: Guid (Primary Key)
Name: string
Capacity: int?
BaseHourlyRate: decimal?
Services: ICollection<Service>
Bookings

Id: Guid (Primary Key)
RoomId: Guid (Foreign Key)
Date: DateTime
StartTime: DateTime
EndTime: DateTime
Services: ICollection<Service>
TotalPrice: decimal
Services

Id: Guid
Name: string
Price: decimal

Relationships:
A Room can have multiple Bookings.
Each Booking can include multiple Services.
Each Room can offer multiple Services.

API Endpoints
Rooms
GET /api/rooms: Get all rooms.
GET /api/rooms/available: Get available rooms based on date, time, and capacity.
POST /api/rooms: Add a new room.
PUT /api/rooms/{id}: Update a room.
DELETE /api/rooms/{id}: Delete a room.

Bookings
GET /api/bookings: Get all bookings.
GET /api/bookings/room/{roomId}: Get bookings for a specific room.
POST /api/bookings: Create a new booking.
PUT /api/bookings/{id}: Update a booking.
DELETE /api/bookings/{id}: Delete a booking.

Services
GET /api/services: Get all available services.
POST /api/services: Add a new service to a room or booking.

Usage Examples
1. Get Available Rooms
http

GET /api/rooms/available?date=2024-09-25&startTime=09:00&endTime=11:00&capacity=20
Response:

[
  {
    "name": "Room A",
    "capacity": 25,
    "basePricePerHour": 50,
    "services": [
      { "name": "Projector", "price": 10 },
      { "name": "Catering", "price": 25 }
    ]
  }
]
2. Create a Booking
http
POST /api/bookings
Request Body:


{
  "roomId": "3d8e9385-1f36-4d3e-b6c1-e10406f2c2ae",
  "date": "2024-09-25",
  "startTime": "09:00",
  "endTime": "11:00",
  "services": [
    { "name": "Projector", "price": 10 }
  ]
}

Optimistic Concurrency Handling
This system uses optimistic concurrency to handle situations where multiple users may try to modify the same entity at the same time. Each entity includes a RowVersion (or equivalent concurrency token), which is checked during updates. If the entity has changed since it was loaded, an exception is thrown.

Handling Example:
In case of a conflict during update:

csharp

try
{
    await _context.SaveChangesAsync();
}
catch (DbUpdateConcurrencyException ex)
{
    // Handle the concurrency conflict
    // Notify the user or reload the entity
}
Error Handling
Errors are captured and returned as standardized JSON responses. For example:

400 Bad Request (Invalid Input)

{
  "error": "Invalid input. Start time must be earlier than end time."
}
404 Not Found (Room/Booking Not Found)

{
  "error": "The room no longer exists."
}
Testing
To run the tests:

Unit Tests:


dotnet test
The project includes tests for:

Room availability logic.
Booking creation and conflict handling.
Database CRUD operations using an in-memory database.

Якщо виникли питання, зв'яжіться зі мною через email: ihor.ziubin@gmail.com
