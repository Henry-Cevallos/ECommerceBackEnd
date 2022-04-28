CREATE DATABASE ECommerce;
USE ECommerce;

CREATE TABLE Users(
	UserId INT NOT NULL auto_increment,
	username VARCHAR(255) NOT NULL UNIQUE,
	pass varchar(255) NOT NULL,
	email varchar(255) NOT NULL,
	balance FLOAT,
	PRIMARY KEY (UserId)
);

CREATE TABLE Cards (
	CardId INT NOT NULL auto_increment,
    cvv VARCHAR(3) NOT NULL,
    experation VARCHAR(5) NOT NULL,
    numbers VARCHAR(16) NOT NULL,
    UserId INT NOT NULL,
    PRIMARY KEY (CardId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Items (
	ItemId INT NOT NULL auto_increment,
    UserId INT NOT NULL,
    title varchar(255),
    price FLOAT NOT NULL,
    descrip TEXT NOT NULL,
    PRIMARY KEY (ItemId),
    foreign key (UserId) references Users(UserId)
);


    
INSERT INTO Users (username, pass, email, balance) VALUES
	("cooluser1", "abc123", "coolemail@email.com", 400.45),
	("applelover", "supersecure", "email@email.com", 20.76);

INSERT INTO Cards (cvv, experation, numbers, UserId) VALUES 
	("123", "02/26", "1234567891234567", 1),
	("321", "10/23", "5235876702354960", 2);
        
INSERT INTO Items(UserId, title, price, descrip) VALUES
	(1, "COOL CHAIR", 25.99, "totally cool and comfortable chair"),
	(1, "COOL ART", 50.25, "totally cool and interesting peice of art"),
	(2, "Book", 7.99, "Ok book");
    