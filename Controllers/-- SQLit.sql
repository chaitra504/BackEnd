-- SQLit
CREATE TABLE TaskList(
   TaskListID INT PRIMARY KEY NOT NULL,
   TaskListName TEXT NOT NULL,  
   CreatedDate DateTime, 
   ModifiedDate DateTime
);

CREATE TABLE TaskItem(
   TaskItemID INT PRIMARY KEY NOT NULL,
   TaskItemName TEXT NOT NULL,  
   IsTaskComplete bool,
   CreatedDate DateTime, 
   ModifiedDate DateTime,
   TaskListID INT NOT NULL, 
   FOREIGN KEY (TaskListID) REFERENCES TaskList(TaskListID));