Here is the command to Scaffold the entities from a local database.  
Run this from the Package Manager Console window and make sure to pick the correct default project in the drop down : CollegeBooks.Data

dotnet linq2db scaffold -p SQLServer -o CollegeBooks.Data\Sql\Models  -c "Data Source=""(localdb)\MSSQLLocalDB;Database=CollegeBooks;" --overwrite true


