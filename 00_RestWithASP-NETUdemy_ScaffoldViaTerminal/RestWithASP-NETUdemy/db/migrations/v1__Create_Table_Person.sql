CREATE TABLE IF NOT EXISTS person
(
    id         int primary key AUTO_INCREMENT,
    address    VARCHAR(100) NOT NULL,
    first_name VARCHAR(80)  NOT NULL,
    last_name  VARCHAR(80)  NOT NULL,
    gender     VARCHAR(6)   NOT NULL

);