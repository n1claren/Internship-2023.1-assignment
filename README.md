# Internship-2023.1-assignment

# 1. Setup Guide: 

The application is not deployed so it runs trough Visual Studio. Start EmployeeTaskSystem.sln and press Ctrl+F5.

# 2. Folder structure overview (architecture):

I have used the Model-View-Controller (MVC) architectural pattern that separates the logic into three layers, Models (EmployeeTaskSystem.Data.Models and EmployeeTaskSystem.Models), Views (EmployeeTaskSystem.Views) and Controllers (EmployeeTaskSystem.Controllers). The controllers handle the business logic, the views handle the presentation logic and the models (with the help of the services) handle the data. Lastly, there is a class in the infrastructure folder that extends the application builder to make sure the database is migrated and seeds data if there is none.

# 3. Description of additional functionalities

I have not added any aditional functionalies by including a new entity. 

I have added an API.

Head to /api/eployees to get all employee data.

Head to /api/tasks to get all the data for tasks waiting to be done.

Head to /api/completedTasks to get all the data for the completed tasks.

Head to /api/statsCount to get the number of employees / tasks / completedTasks in the database.
