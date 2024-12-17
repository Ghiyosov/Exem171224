create table Users(
    UserId serial primary key,
    FullName varchar(150),
    Email varchar(150),
    Phone varchar(20),
    Role varchar(20),
    CreatedAt timestamp
);

create table Jobs(
    JobId serial primary key,
    EmployeeId int references Users(UserId),
    Title varchar(150),
    Description text,
    Salary decimal,
    Country varchar(100),
    City varchar(100),
    Status varchar(20),
    CreatedAt timestamp,
    UpdatedAt timestamp
);

create table Applications(
    ApplicationId serial primary key,
    JobId int references Jobs(JobId),
    ApplicantId int references Users(UserId),
    Resume text,
    Status varchar(20),
    CreatedAt timestamp,
    UpdatedAt timestamp
);