CREATE TABLE [tbl_user] (
	user_id integer(255) NOT NULL UNIQUE,
	rfid_tag varchar(11) NOT NULL UNIQUE,
	user_type integer(255) NOT NULL,
  CONSTRAINT [PK_TBL_USER] PRIMARY KEY CLUSTERED
  (
  [user_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [tbl_user_type] (
	user_type_id integer(255) NOT NULL UNIQUE,
	user_type varchar(255) NOT NULL UNIQUE,
  CONSTRAINT [PK_TBL_USER_TYPE] PRIMARY KEY CLUSTERED
  (
  [user_type_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [tbl_student] (
	student_id varchar(255) NOT NULL UNIQUE,
	user_id integer(255) NOT NULL UNIQUE,
	last_name varchar(255) NOT NULL,
	middle_name varchar(255),
	first_name varchar(255) NOT NULL,
	department_id integer(255),
	course_id integer(255),
  CONSTRAINT [PK_TBL_STUDENT] PRIMARY KEY CLUSTERED
  (
  [student_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [tbl_department] (
	department_id integer(255) NOT NULL,
	department varchar(255) NOT NULL,
  CONSTRAINT [PK_TBL_DEPARTMENT] PRIMARY KEY CLUSTERED
  (
  [department_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [tbl_employee] (
	employee_id varchar(255) NOT NULL UNIQUE,
	user_id integer(255) NOT NULL UNIQUE,
	last_name varchar(255) NOT NULL,
	middle_name varchar(255),
	first_name varchar(255) NOT NULL,
	position varchar(255) NOT NULL,
	department_id integer(255),
	course_id integer(255),
  CONSTRAINT [PK_TBL_EMPLOYEE] PRIMARY KEY CLUSTERED
  (
  [employee_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [tbl_course] (
	course_id integer(255) NOT NULL,
	department_id integer(255) NOT NULL,
	course varchar(255) NOT NULL,
  CONSTRAINT [PK_TBL_COURSE] PRIMARY KEY CLUSTERED
  (
  [course_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [tbl_visitor] (
	visitor_id integer(255) NOT NULL UNIQUE,
	user_id integer(255) NOT NULL UNIQUE,
	last_name varchar(255) NOT NULL,
	middle_name varchar(255),
	first_name varchar(255) NOT NULL,
  CONSTRAINT [PK_TBL_VISITOR] PRIMARY KEY CLUSTERED
  (
  [visitor_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [tbl_user] WITH CHECK ADD CONSTRAINT [tbl_user_fk0] FOREIGN KEY ([user_type]) REFERENCES [tbl_user_type]([user_type_id])
ON UPDATE CASCADE
GO
ALTER TABLE [tbl_user] CHECK CONSTRAINT [tbl_user_fk0]
GO


ALTER TABLE [tbl_student] WITH CHECK ADD CONSTRAINT [tbl_student_fk0] FOREIGN KEY ([user_id]) REFERENCES [tbl_user]([user_id])
ON UPDATE CASCADE
GO
ALTER TABLE [tbl_student] CHECK CONSTRAINT [tbl_student_fk0]
GO
ALTER TABLE [tbl_student] WITH CHECK ADD CONSTRAINT [tbl_student_fk1] FOREIGN KEY ([department_id]) REFERENCES [tbl_department]([department_id])
ON UPDATE CASCADE
GO
ALTER TABLE [tbl_student] CHECK CONSTRAINT [tbl_student_fk1]
GO
ALTER TABLE [tbl_student] WITH CHECK ADD CONSTRAINT [tbl_student_fk2] FOREIGN KEY ([course_id]) REFERENCES [tbl_course]([course_id])
ON UPDATE CASCADE
GO
ALTER TABLE [tbl_student] CHECK CONSTRAINT [tbl_student_fk2]
GO


ALTER TABLE [tbl_employee] WITH CHECK ADD CONSTRAINT [tbl_employee_fk0] FOREIGN KEY ([user_id]) REFERENCES [tbl_user]([user_id])
ON UPDATE CASCADE
GO
ALTER TABLE [tbl_employee] CHECK CONSTRAINT [tbl_employee_fk0]
GO
ALTER TABLE [tbl_employee] WITH CHECK ADD CONSTRAINT [tbl_employee_fk1] FOREIGN KEY ([department_id]) REFERENCES [tbl_department]([department_id])
ON UPDATE CASCADE
GO
ALTER TABLE [tbl_employee] CHECK CONSTRAINT [tbl_employee_fk1]
GO
ALTER TABLE [tbl_employee] WITH CHECK ADD CONSTRAINT [tbl_employee_fk2] FOREIGN KEY ([course_id]) REFERENCES [tbl_course]([course_id])
ON UPDATE CASCADE
GO
ALTER TABLE [tbl_employee] CHECK CONSTRAINT [tbl_employee_fk2]
GO

ALTER TABLE [tbl_course] WITH CHECK ADD CONSTRAINT [tbl_course_fk0] FOREIGN KEY ([department_id]) REFERENCES [tbl_department]([department_id])
ON UPDATE CASCADE
GO
ALTER TABLE [tbl_course] CHECK CONSTRAINT [tbl_course_fk0]
GO

ALTER TABLE [tbl_visitor] WITH CHECK ADD CONSTRAINT [tbl_visitor_fk0] FOREIGN KEY ([user_id]) REFERENCES [tbl_user]([user_id])
ON UPDATE CASCADE
GO
ALTER TABLE [tbl_visitor] CHECK CONSTRAINT [tbl_visitor_fk0]
GO

