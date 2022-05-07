#drop schema dexlk;
create schema dexlk;
use dexlk;
CREATE TABLE dexlk.`Wallet` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Balance` decimal(19,2) NOT NULL,
  `createdUserId` int NOT NULL,  
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE dexlk.`Exchange` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FromWalletId` int NOT NULL,  
  `ToWalletId` int NOT NULL, 
  `Amount` decimal(19,2) NOT NULL,
  `createdUserId` int NOT NULL,  
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;