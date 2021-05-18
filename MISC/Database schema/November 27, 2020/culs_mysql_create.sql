CREATE TABLE `tbl_user` (
	`user_id` INT(255) NOT NULL AUTO_INCREMENT UNIQUE,
	`rfid_tag` varchar(11) NOT NULL UNIQUE,
	`user_type` INT(255) NOT NULL,
	PRIMARY KEY (`user_id`)
);

CREATE TABLE `tbl_user_type` (
	`user_type_id` INT(255) NOT NULL UNIQUE,
	`user_type` varchar(255) NOT NULL UNIQUE,
	PRIMARY KEY (`user_type_id`)
);

CREATE TABLE `tbl_student` (
	`student_id` varchar(255) NOT NULL UNIQUE,
	`user_id` INT(255) NOT NULL UNIQUE,
	`last_name` varchar(255) NOT NULL,
	`middle_name` varchar(255),
	`first_name` varchar(255) NOT NULL,
	`department_id` INT(255),
	`course_id` INT(255),
	PRIMARY KEY (`student_id`)
);

CREATE TABLE `tbl_department` (
	`department_id` INT(255) NOT NULL AUTO_INCREMENT,
	`department` varchar(255) NOT NULL,
	PRIMARY KEY (`department_id`)
);

CREATE TABLE `tbl_employee` (
	`employee_id` varchar(255) NOT NULL UNIQUE,
	`user_id` INT(255) NOT NULL UNIQUE,
	`last_name` varchar(255) NOT NULL,
	`middle_name` varchar(255),
	`first_name` varchar(255) NOT NULL,
	`position` varchar(255) NOT NULL,
	`department_id` INT(255),
	`course_id` INT(255),
	PRIMARY KEY (`employee_id`)
);

CREATE TABLE `tbl_course` (
	`course_id` INT(255) NOT NULL AUTO_INCREMENT,
	`department_id` INT(255) NOT NULL,
	`course` varchar(255) NOT NULL,
	PRIMARY KEY (`course_id`)
);

CREATE TABLE `tbl_visitor` (
	`visitor_id` INT(255) NOT NULL AUTO_INCREMENT UNIQUE,
	`user_id` INT(255) NOT NULL UNIQUE,
	`last_name` varchar(255) NOT NULL,
	`middle_name` varchar(255),
	`first_name` varchar(255) NOT NULL,
	PRIMARY KEY (`visitor_id`)
);

ALTER TABLE `tbl_user` ADD CONSTRAINT `tbl_user_fk0` FOREIGN KEY (`user_type`) REFERENCES `tbl_user_type`(`user_type_id`);

ALTER TABLE `tbl_student` ADD CONSTRAINT `tbl_student_fk0` FOREIGN KEY (`user_id`) REFERENCES `tbl_user`(`user_id`);

ALTER TABLE `tbl_student` ADD CONSTRAINT `tbl_student_fk1` FOREIGN KEY (`department_id`) REFERENCES `tbl_department`(`department_id`);

ALTER TABLE `tbl_student` ADD CONSTRAINT `tbl_student_fk2` FOREIGN KEY (`course_id`) REFERENCES `tbl_course`(`course_id`);

ALTER TABLE `tbl_employee` ADD CONSTRAINT `tbl_employee_fk0` FOREIGN KEY (`user_id`) REFERENCES `tbl_user`(`user_id`);

ALTER TABLE `tbl_employee` ADD CONSTRAINT `tbl_employee_fk1` FOREIGN KEY (`department_id`) REFERENCES `tbl_department`(`department_id`);

ALTER TABLE `tbl_employee` ADD CONSTRAINT `tbl_employee_fk2` FOREIGN KEY (`course_id`) REFERENCES `tbl_course`(`course_id`);

ALTER TABLE `tbl_course` ADD CONSTRAINT `tbl_course_fk0` FOREIGN KEY (`department_id`) REFERENCES `tbl_department`(`department_id`);

ALTER TABLE `tbl_visitor` ADD CONSTRAINT `tbl_visitor_fk0` FOREIGN KEY (`user_id`) REFERENCES `tbl_user`(`user_id`);

