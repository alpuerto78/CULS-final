CREATE TABLE tbl_user (
	user_id integer PRIMARY KEY AUTOINCREMENT,
	rfid_tag varchar,
	user_type integer
);

CREATE TABLE tbl_user_type (
	user_type_id integer,
	user_type varchar
);

CREATE TABLE tbl_student (
	student_id varchar,
	user_id integer,
	last_name varchar,
	middle_name varchar,
	first_name varchar,
	department_id integer,
	course_id integer
);

CREATE TABLE tbl_department (
	department_id integer PRIMARY KEY AUTOINCREMENT,
	department varchar
);

CREATE TABLE tbl_employee (
	employee_id varchar,
	user_id integer,
	last_name varchar,
	middle_name varchar,
	first_name varchar,
	position varchar,
	department_id integer,
	course_id integer
);

CREATE TABLE tbl_course (
	course_id integer PRIMARY KEY AUTOINCREMENT,
	department_id integer,
	course varchar
);

CREATE TABLE tbl_visitor (
	visitor_id integer PRIMARY KEY AUTOINCREMENT,
	user_id integer,
	last_name varchar,
	middle_name varchar,
	first_name varchar
);

