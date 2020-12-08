/*
* FILE : TMS Database.sql
* PROJECT : TSM FinalProject
* PROGRAMMER : Justin Langevin
* FIRST VERSION : 11/14/2020 
* DESCRIPTION : This is an sql script to create the local TMS DataBase.
*/
CREATE DATABASE TMSDatabase;
 
 /*Order table*/
CREATE TABLE OD (
travelID int auto_increment,
travel varchar(255),
carriers varchar(255),
direction varchar(255),
tTime double,
cost double,
primary key(travelID)
);

/*admin password table*/
create table adminPass(
password varchar(255)
);
insert into adminPass(password) values('admin123');

/*User accounts table*/
CREATE TABLE accounts (
   acountID int auto_increment,
  UserName VARCHAR(255),
  Password varchar(255),
  primary key(acountID)
);






