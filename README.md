1.Simple Task manager API


1. Project Setup
	• Use .NET 6 or .NET 7 for long-term support.
	• Set up an API project in Visual Studio or via CLI using dotnet new webapi -n TaskManagerAPI.
	• Use Entity Framework Core for database handling (SQL Server or SQLite for simplicity).
2. Core Requirements
	• Models: Define a Task model with fields such as:
		○ Id (int, Primary Key)
		○ Title (string, max 255 characters)
		○ Description (string, optional)
		○ Status (enum: e.g., To-Do, In-Progress, Completed)
		○ Priority (enum: Low, Medium, High)
		○ DueDate (DateTime, optional)
		○ CreatedAt (DateTime, default to current timestamp)
		○ UpdatedAt (DateTime, updated on each modification)
	• DTOs (Data Transfer Objects): Create DTOs for adding and updating tasks to separate user inputs from the database models.
3. Controllers
	• Implement a TasksController with endpoints for:
		○ GET /tasks: Retrieve all tasks with optional query filters for status, priority, or due date.
		○ GET /tasks/{id}: Retrieve a specific task by ID.
		○ POST /tasks: Create a new task.
		○ PUT /tasks/{id}: Update an existing task.
		○ DELETE /tasks/{id}: Delete a task by ID.
4. Business Logic
	• Implement service classes to handle business logic, especially if you plan to extend features.
	• Add methods for task sorting, filtering, and pagination within the service layer.
5. Database Setup
	• Use EF Core to set up database context and handle migrations.
	• Define relationships if you intend to add more models (e.g., User, Project).
	• Use In-Memory Database for unit testing or SQLite if persistence is required without a heavy setup.
6. Authentication and Authorization (Optional)
	• For simplicity, you might skip this initially, but eventually consider adding user authentication (e.g., JWT) to manage tasks per user.
7. Validation
	• Use Data Annotations to validate required fields, max lengths, and value ranges for the Priority and Status enums.
	• Implement global exception handling and return clear error messages.
8. Logging and Monitoring
	• Set up basic logging to track API requests, errors, and responses.
	• Use health check endpoints for monitoring, especially in production.
9. Documentation
	• Use Swagger for API documentation to easily test and share API endpoints.
10. Testing
	• Write unit tests for each service method and controller endpoint using xUnit or NUnit.
	• Set up integration tests to ensure end-to-end functionality.
![image](https://github.com/user-attachments/assets/dda0d439-1ca4-4339-bd81-20f65bfa9f25)
