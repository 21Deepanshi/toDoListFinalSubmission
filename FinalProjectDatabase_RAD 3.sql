CREATE DATABASE ToDoTasks;

USE ToDoTasks;

CREATE TABLE Tasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Description NVARCHAR(255),
    Category NVARCHAR(100),
    StartDate DATETIME,
    EndDate DATETIME,
    Status NVARCHAR(50)
);
 
 
INSERT INTO Tasks (Description, Category, StartDate, EndDate, Status)
VALUES 
('Finish assignment', 'Education', '2024-11-15 14:00:00', '2024-11-16 18:00:00', 'Pending'),
('Call mom', 'Personal', '2024-11-17 09:00:00', '2024-11-17 09:30:00', 'Pending'),
('Attend team meeting', 'Work', '2024-11-18 10:00:00', '2024-11-18 11:00:00', 'Completed'),
('Go for a run', 'Personal', '2024-11-20 06:30:00', '2024-11-20 07:30:00', 'Pending'),
('Submit report', 'Work', '2024-11-22 13:00:00', '2024-11-22 14:00:00', 'Completed');
 
SELECT * FROM Tasks;
DROP TABLE Tasks;
 
CREATE TABLE CategoryTable(
    categoryId INT IDENTITY(101,1) PRIMARY KEY,
    Category VARCHAR(255) NOT NULL
);
 
INSERT INTO CategoryTable (Category) VALUES
('Work'),
('Health'),
('Education'),
('Personal'),
('Shopping');
 
SELECT * FROM CategoryTable;
DROP TABLE CategoryTable;