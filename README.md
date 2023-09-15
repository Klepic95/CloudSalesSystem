# CloudSalesSystem

How to successfully configure the project locally:

1. Clone repository
2. Install and configure Docker locally
3. Open PowerShell and run this exact script, however replace specified parameters:

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=cssPass1!" -p 1433:1433 
--name cssCrayonSqlServer -v C:\Users\{your-name}\DockerVolumes\sqlserver:/var/opt/mssql/data 
-d mcr.microsoft.com/mssql/server:latest

Note: in above script, replace {your-name} with the actual name of your local machine

4. After ensuring that connection with the SQL server exists, in the Package Manager Console execute following script: "Update-Database"
NOTE: Setup startup and Default project in Package Manager Console to: "CloudSalesSystem.DAL"

It is necessary to follow these steps in order to sucessfully run application locally!
