Configure and run WorkflowServer:
1. Extract the 'workflowserver.zip' archive
2. Run the folowing SQL-scripts on a Database (for MS SQL Server from SQL\MSSQL folder, for PostgreSQL from SQL\PostgreSQL, for Oracle from SQL\Oracle folder,for MySql from SQL\MySql folder):
   1. CreatePersistenceObjects.sql
   2. WorkflowServerScripts.sql
3. Make the following changes to the bin\config.json file:
   1. Change the URL parameter to the IP and the port of the HTTP listener. Most likely you'll need to leave it as it is.
   2. Specify "mssql" or "postgresql" in the "provider" parameter depending on what database provider you are using
   3. Change the ConnectionString parameter to match your database provider connection settings. For more information, have a look at these instructions for MS SQL and PostgreSQL.
4. Run DB scripts present in **WorkflowServices** folder. Run in following order:
   1. create-db-tables.sql
   2. data-insert.sql
5. Workflow Server supports console and service modes on Windows:
   1. Run the 'installservice.bat' as administrator to run it in the Service mode
6. Open http://localhost:8077 in a browser.
7. Fill in Callback API urls at http://localhost:8077/?apanel=callbackapi to perform integration. Run WebAPI project present in **WorkflowServices** folder. Get the respective URL's and provide them in **CallbackAPI** as follows:
   1. For Getting a list of conditions, provide URL - http://localhost:44328/api/workflow/Conditions
   2. For Execution of the condition, provide URL - http://localhost:44328/api/workflow/ExecuteCondition
   3. For Getting Rules, provide URL - http://localhost:44328/api/workflow/rules
   4. For Checking the rule, provide URL - http://localhost:44328/api/workflow/ExecuteRuleCheck
8. Open http://localhost:8077/?apanel=workflow:
   1. Create a new scheme named "leave-request-wf"
   2. Upload "leave-request-wf.xml" and save the scheme
9. Go to **workflow-angular** project and run angular project using **ng serve** and open angular website by going to http://localhost:4200
