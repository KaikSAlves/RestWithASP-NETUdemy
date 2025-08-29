CREATE TABLE books
(
    id          INT PRIMARY KEY AUTO_INCREMENT,
    author      VARCHAR(100) NOT NULL,
    launch_date DATETIME     NOT NULL,
    price       DOUBLE       NOT NULL,
    title       VARCHAR(100) NOT NULL
);