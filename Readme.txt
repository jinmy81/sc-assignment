System Requirements:
- Visual studio 2015
- MSSQL 2008 and above.

Setup steps for testing:

1. Clone the repo to your local.
2. Restore database
- Restore the backup test database name sitecore.bak located at database folder
to  your local system. 

3. Open the SsoService solution, change the connection string of your system.
4. F5 to start the service.
5. Open the SiteClient solution, view the web config file, make sure the endpoint service address port number
tally with the service you had just started.
6. F5 to start the web application.