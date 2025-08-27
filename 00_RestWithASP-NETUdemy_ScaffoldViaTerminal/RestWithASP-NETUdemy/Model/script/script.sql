create database rest_with_asp_net_udemy;
	
    
use rest_with_asp_net_udemy;

CREATE TABLE IF NOT EXISTS person (
                                      id int primary key AUTO_INCREMENT,
                                      adress VARCHAR(100) NOT NULL,
    first_name VARCHAR(80) NOT NULL,
    gender VARCHAR(6) NOT NULL,
    last_name VARCHAR(80) NOT NULL
    );

INSERT INTO person(adress, first_name, gender, last_name)
VALUES("Adress", "Kaik", "Male", "Alves");
    

