Visual Studio >> using Entity Framework, SQLServer, and RabbitMQ

------------------------------------
ASSUMING RabbitMQ is set on your machine...... 
WITH Default settings intact,

If not, please locate code using rabbit MQ in the 2 apps and change pertinent values.


FIRST CREATE YOUR DATABASE USING THE 
CreatePangeaPracticum.sql script Provided..

THEN
--------------------------------------------------------------------------
within the 
PracticumPangea Project Directory

FILE LOCATION:
practicumpangea\src\practicumpangea\appsettings.json

Line:
"DefaultConnection": "Server=DESKTOP-D4VPA1R;Database=PangeaPracticum;Trusted_Connection=True;MultipleActiveResultSets=true"


change Server=DESKTOP-D4VPA1R to
Server=<<YourDataBaseServer>

 ------------------------------------------------------------
within the 
ConsumeRabbit  Project Directory

FILE LOCATION:
ConsumeRabbit\src\ConsumeRabbit\PangeaPracticumContext.cs


IN FUNCTION: OnConfiguring
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D4VPA1R;Database=PangeaPracticum;Trusted_Connection=True;");
        }

change Server=DESKTOP-D4VPA1R to
Server=<<YourDataBaseServer>