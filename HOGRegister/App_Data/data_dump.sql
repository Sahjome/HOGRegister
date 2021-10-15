create table if not exists Log(
Id Bigint Primary Key Not Null,
WorkerId int not null,
UnitId int not null,
SignIn DateTime Default Current_Timestamp,
SignOut DateTime,
Tag int not null,
Service int
);

create table if not exists Unit(
Id Bigint Primary Key Not Null,
Name varchar(50) not null,
Leader varchar(150) not null,
Overview varchar(150) not null,
Responsibilities tinytext
);

create table if not exists Worker(
 Id int not null Primary Key,
 Title varchar(100),
 Firstname varchar(100) not null,
 Midname varchar(100),
 Lastname varchar(100) not null,
 Phone bigint not null,
 Email varchar(100),
 Gender enum('male', 'female'),
 Address varchar(100) not null,
 `Status` enum('active', 'suspended', 'disabled') not null default 'active',
 FingerPrint binary
);

