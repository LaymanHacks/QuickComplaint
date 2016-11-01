# QuickComplaint

## View video demo at the following location
https://youtu.be/RrHYNX8PzcY

## Setup for new development box

1. Install SqlServer 2008R2 or later if not already installed.
2. Create a new database called **"QuickComplaint"** in the server instance. 
3. Clone repository from github to a directory of your choice.
	* git clone https://github.com/LaymanHacks/QuickComplaint.git
4. Run the script **"Setup_DB.sql"** found in the root directory of the source code on new **"QuickComplaint"** database to setup the schema and prime data.
5. Run the script **"QuickComplaint_StoredProcedures.sql"** found in the root directory of the source code on new **"QuickComplaint"** database to install stored procedures. 
6. Open the Visual Studio solution **"QuickComplaint.sln"** found in the root directory of the source code.
7. Open to the **"Web.Config"** file in the root directory of the **"QuickComplaint.Web.UI"** project and update the connection string called **"QuickComplaintConnection"**  and change the data source to your named SqlServer instance.
8. Build the project in Visual Studio which will install all the required nuget packages.
9. Make sure the project **"QuickComplaint.Web.UI"** is set as the startup project and run the solution.
