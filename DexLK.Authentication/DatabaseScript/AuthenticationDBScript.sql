CREATE DATABASE `authentication` /!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /!80016 DEFAULT ENCRYPTION='N' */;

USE `authentication`;

CREATE TABLE `User` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LastName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Username` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;