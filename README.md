## Getting Started

Make sure you already have .NET SDK on your machine (The code is using .NET 8)

Go to a directory and clone the git repository (git clone https://github.com/mrizalrizky/tech-test-kalbe-dotnet)

1. Set your PostgreSQL Database credentials in "appsettings.json" > "ConnectionStrings>DefaultConnection"
2. Set your preferred JWT Secret Token (Leave as default if you don't want to customize)
3. Run the migration using "dotnet ef database update" to create tables on your database
4. Run "dotnet run", the app will be built and run.

Open the address on your local using http://localhost:5130 (or port as specified in the console when running)

## Postman Documentation

https://www.postman.com/material-geoscientist-99033053/kalbepedia/collection/tlbgown/kalbepedia?action=share&creator=0
