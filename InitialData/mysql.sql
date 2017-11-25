DROP DATABASE IF EXISTS `leathergoods`;
CREATE DATABASE `leathergoods` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `leathergoods`;

CREATE TABLE `AspNetUsers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Email` varchar(255) DEFAULT NULL,
  `EmailConfirmed` int(11) DEFAULT '0',
  `PasswordHash` varchar(3000) DEFAULT NULL,
  `SecurityStamp` varchar(3000) DEFAULT NULL,
  `PhoneNumber` varchar(45) DEFAULT NULL,
  `PhoneNumberConfirmed` int(11) DEFAULT '0',
  `TwoFactorEnabled` int(11) DEFAULT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` int(11) DEFAULT '0',
  `AccessFailedCount` int(11) DEFAULT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

CREATE TABLE `AspNetRoles` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC)
);

CREATE TABLE `AspNetUserRoles` (
  `UserId` INT NOT NULL,
  `RoleId` INT NOT NULL,
  PRIMARY KEY (`UserId`, `RoleId`),
  INDEX `UserRole_Role_idx` (`RoleId` ASC),
  CONSTRAINT `UserRole_User`
    FOREIGN KEY (`UserId`)
    REFERENCES `AspNetUsers` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `UserRole_Role`
    FOREIGN KEY (`RoleId`)
    REFERENCES `AspNetRoles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE `Category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8 NOT NULL,
  `CreatedOn` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` int(11) DEFAULT NULL,
  `ChangedOn` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ChangedBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

CREATE TABLE `Product` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(100) NOT NULL,
  `Description` VARCHAR(255) NULL,
  `DealerId` INT NULL,
  `Image` VARCHAR(255) NULL,
  `Price` DECIMAL(2) NULL,
  `QuantitySold` INT NULL DEFAULT 0,
  `AvgStars` DECIMAL(5) NULL DEFAULT 2.5,
  `RowId` VARCHAR(255) NULL,
  `CreatedOn` DATETIME NULL,
  `CreatedBy` INT NULL,
  `ChangedOn` DATETIME NULL,
  `ChangedBy` INT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC));

INSERT INTO `leathergoods`.`AspNetUsers` (`Email`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `PhoneNumber`,
`PhoneNumberConfirmed`, `TwoFactorEnabled`, `UserName`) VALUES ('admin@admin.com', 1,
'fYsznLkr49rxD1Vkm12FbaDRqpSAzkuE7Pbtg8qYrFk=', 'ASDASDnu2dn9210dn0d21idn2mdi', '1111-1111', 1, 0, 'admin');
