
---

## **Backend README**

### **backend/README.md**
```markdown
# Loan Application Quote Calculator - Backend

This repository contains the **ASP.NET Core Web API backend** for the Loan Application Quote Calculator. It validates loan application data and saves it to a SQL Server database.

---

## **Features**

1. **API Endpoint**
   - Accepts loan application submissions.
   - Validates user inputs before saving.
   - Saves loan details in a SQL Server database.

2. **Database Integration**
   - SQL Server is used to store application details.
   - Entity Framework Core manages the database schema.

---

## **Technologies Used**

- **ASP.NET Core Web API** (.NET 6+)
- **Entity Framework Core** for ORM.
- **SQL Server** for database management.

---

## **Project Structure**

/backend ├── Controllers │ └── ApplicationController.cs # Handles API requests ├── Migrations │ └── <EF Core Migration Files> ├── Models │ └── Application.cs # Loan application model ├── appsettings.json # Configuration for database connection └── Program.cs # Entry point for the application


### **Backend Setup**
1. Install Prerequisites
   Ensure the following are installed on your machine:

   - .NET 6 SDK or later: Download .NET
   - SQL Server: Download SQL Server
   - SQL Server Management Studio (SSMS) (optional): Use for database management.

2. Clone the Repository
   - Navigate to your preferred directory and clone the repository:

      git clone https://github.com/your-repository-url.git
      cd loan-application/backend

3. Configure the Database Connection

   - Open the appsettings.json file in the backend folder.

   - Update the DefaultConnection string to match your SQL Server setup:

      {
      "ConnectionStrings": {
         "DefaultConnection": "Server=localhost;Database=LoanApplicationDB;Trusted_Connection=True;"
         }
      }

   Replace:
   - localhost with your SQL Server instance name.
   - LoanApplicationDB with the name of your database.

4. Apply Migrations to Set Up the Database

   - Open a terminal and navigate to the backend folder:
      cd backend
      
   - Ensure the dotnet-ef tool is installed. If not, install it globally:
      dotnet tool install --global dotnet-ef

   - Apply the existing migrations to create the database schema:
      dotnet ef database update

      This will:
      - Create the database specified in appsettings.json (if it doesn’t exist).
      - Generate the Applications table and other schema defined in the migrations.

5. Run the Backend Server
   - Build the backend project:   
      dotnet build

   - Start the backend server:
      dotnet run

   - The backend API will be accessible at:
      https://localhost:44382