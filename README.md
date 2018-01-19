# EF CodeFirst

### With New Database
1. Create a project
2. Add Entity Framework from Nuget
3. Create Domain Classes
4. Create DbContext class with DbSets
5. Add connection string in App.config
6. If the name of the connection string is different from DbContext class then add the name in the constructor
7. In the Package Manager Console, Run this command to enable migrations
	`enable-migrations`
	This command only use once in application life time.
8. Create a migration with a name (Any Name)
	`add-migration InitialModel`
	We run this command every time we change the model
9. After adding migration we update the database
	`update-database`

### With Existing Database
1. Create a project
2. Add Entity Framework
3. Right Click on Project Name > Add > New Items > select ADO.NET Entity DataModel > Click OK > 
	select Code First from Database > hit Next > choose your Data Connection > Hit Next >
	select Tables/View > hit Finish.
	This will create all the domain classes and also update App.config file.
4. In the Package Manager Console, Run this command to enable migrations
	`enable-migrations`
	This command only use once in application life time.
5. Create a migration with a name (Any Name)
	`add-migration InitialModel -IgnoreChanges -Force `
	This command will not add any changes that are existing in the database
6. After adding migration we update the database
	`update-database`

### Migration Naming Convension
1. Model Centric - add-migration AddCategory
2. Database Centric - add-migration AddCategoriesTable

Migration Scenario
1. Adding a new class
    a. Add a new class in the Project
    b. make it public
    c. Add a DbSet of this class (If not added, the migration class will be empty)
    d. add-migration AddCategoriesTable
        If AddCategoriesTable migration already exists, 
        `add-migration AddCategoriesTable -Force`
    e. update-database
2. Modifying an existing class
...Scenario
......a. Adding a new property
......b. Modifying an existing property
.........Rename a column is tricky. Generated migration drop the existing column and add a new column.
.........We could use RenameColumn() or Sql() to fix this. See RenameTitleToNameInCourseTable migration.
.........c. Deleting an existing property
3. Deleting an exising class
......a. Remove all foriegn key for this class (migration and update db)
......b. Delete the class and remove it from DebSet (migration and update db)
......c. If you want to keep the data from deleting table then create a new table, copy data from deleting table to new table, then delete the table.

### Migration Downgrading a db
...`Update-Database -TargetMigration:DeleteDatePublishColumnFromCourseTable`
...This command revert migrations to the target migration using the Down() in Migration class.

### Seeding the database
...if you want to seeding your database use empty Migration or use Seed() in Configuration.cs
...Everytime we use update-database, Seed() will run.

### Deployment
...1. `Update-Database -Script -SourceMigration:0`
......It will create all migration script
...2. `Update-­Database ­‐Script ­‐SourceMigration:Migr1 ­‐TargetMigration:Migr2`





	
