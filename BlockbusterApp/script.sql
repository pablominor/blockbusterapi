CREATE DATABASE `blockbuster` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

create table user (
	id varchar(40) not null,
    email varchar(60) not null,
    password varchar(100) NOT NULL,
    first_name varchar(15),
    last_name varchar(30),
    role varchar(20),
    country_code varchar(2),
    created_at datetime,
    updated_at datetime,
    PRIMARY KEY (id),
	UNIQUE(email)
);

create table token (
	id int AUTO_INCREMENT not null,
    `hash` TEXT not null,
    id_user varchar(40) NOT NULL,    
    created_at datetime,
    updated_at datetime,
    PRIMARY KEY (id),
    foreign key(id_user) references user (id)
);

create table country (
	id int AUTO_INCREMENT not null,
    `code` varchar(2) not null,
    tax decimal(10,2) NOT NULL,        
    PRIMARY KEY (id)    
);

create table category (
	id varchar(40) not null,
    name varchar(30),
    created_at datetime,
    updated_at datetime,
    PRIMARY KEY (id)
);