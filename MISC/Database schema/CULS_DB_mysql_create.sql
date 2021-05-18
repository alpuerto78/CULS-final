CREATE TABLE `Users` (
	`UserId` INT(1000) NOT NULL AUTO_INCREMENT,
	`RFIDtag` varchar(11) NOT NULL,
	`UTId` INT(1000) NOT NULL,
	PRIMARY KEY (`UserId`)
);

CREATE TABLE `UserType` (
	`UTId` INT(1000) NOT NULL AUTO_INCREMENT,
	`StudentId` varchar(10) NOT NULL,
	`EmployeeId` INT(10) NOT NULL AUTO_INCREMENT,
	`VisitorId` INT(10) NOT NULL,
	PRIMARY KEY (`UTId`)
);

CREATE TABLE `Department` (
	`DepartmentId` INT(10) NOT NULL AUTO_INCREMENT,
	`DepartmentName` varchar(10) NOT NULL AUTO_INCREMENT,
	PRIMARY KEY (`DepartmentId`)
);

CREATE TABLE `Courses` (
	`CourseID` INT(10) NOT NULL AUTO_INCREMENT,
	`CourseName` varchar(255) NOT NULL,
	`DepartmentId` INT(10) NOT NULL,
	PRIMARY KEY (`CourseID`)
);

CREATE TABLE `Visitor` (
	`VisitorID` INT(10) NOT NULL AUTO_INCREMENT,
	`LastName` varchar(255) NOT NULL,
	`FirstName` varchar(255) NOT NULL,
	`MiddleInitial` varchar(255) NOT NULL,
	`School` varchar(255) NOT NULL,
	PRIMARY KEY (`VisitorID`)
);

CREATE TABLE `Employee` (
	`EmployeeId` INT(10) NOT NULL AUTO_INCREMENT,
	`LastName` varchar(255) NOT NULL,
	`FirstName` varchar(255) NOT NULL,
	`MiddleInitial` varchar(255) NOT NULL,
	`Position` varchar(255) NOT NULL,
	PRIMARY KEY (`EmployeeId`)
);

CREATE TABLE `Student` (
	`StudentId` INT(10) NOT NULL AUTO_INCREMENT,
	`StudentId_no` varchar(250) NOT NULL,
	`LastName` varchar(255) NOT NULL,
	`FirstName` varchar(255) NOT NULL,
	`MiddleInitial` varchar(255) NOT NULL,
	`DepartmentId` INT(10) NOT NULL,
	PRIMARY KEY (`StudentId`)
);

ALTER TABLE `Users` ADD CONSTRAINT `Users_fk0` FOREIGN KEY (`UTId`) REFERENCES `UserType`(`StudentId`);

ALTER TABLE `UserType` ADD CONSTRAINT `UserType_fk0` FOREIGN KEY (`StudentId`) REFERENCES `Student`(`StudentId`);

ALTER TABLE `UserType` ADD CONSTRAINT `UserType_fk1` FOREIGN KEY (`EmployeeId`) REFERENCES `Employee`(`EmployeeId`);

ALTER TABLE `UserType` ADD CONSTRAINT `UserType_fk2` FOREIGN KEY (`VisitorId`) REFERENCES `Visitor`(`VisitorID`);

ALTER TABLE `Courses` ADD CONSTRAINT `Courses_fk0` FOREIGN KEY (`DepartmentId`) REFERENCES `Department`(`DepartmentId`);

ALTER TABLE `Student` ADD CONSTRAINT `Student_fk0` FOREIGN KEY (`DepartmentId`) REFERENCES `Department`(`DepartmentId`);

