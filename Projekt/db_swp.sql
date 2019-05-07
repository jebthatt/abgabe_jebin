create database db_swp;
use db_swp;

Create table article(
id int not null auto_increment,
name varchar(100) not null,
description varchar(100) not null,
category varchar(100) not null, 
price decimal not null, 
imgPath varchar(100) not null,
constraint id_PK primary key(id)
)engine = InnoDB;