-- SQLite
create table List(
   ListID INT PRIMARY KEY NOT NULL,
   ListNAME TEXT NOT NULL,  
   CreatedDate DateTime, 
   ModifiedDate DateTime
);

CREATE table Task(
   TaskID INT PRIMARY KEY NOT NULL,  
   TaskNAME TEXT NOT NULL,  
   IsTaskComplete bool,
   CreatedDate DateTime, 
   ModifiedDate DateTime
);