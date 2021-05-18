CREATE TABLE "tbl_user" (
	"user_id" INT UNIQUE NOT NULL,
	"rfid_tag" VARCHAR2(11) UNIQUE NOT NULL,
	"user_type" INT NOT NULL,
	constraint TBL_USER_PK PRIMARY KEY ("user_id"));

CREATE sequence "TBL_USER_USER_ID_SEQ";

CREATE trigger "BI_TBL_USER_USER_ID"
  before insert on "tbl_user"
  for each row
begin
  select "TBL_USER_USER_ID_SEQ".nextval into :NEW."user_id" from dual;
end;

/
CREATE TABLE "tbl_user_type" (
	"user_type_id" INT UNIQUE NOT NULL,
	"user_type" VARCHAR2(255) UNIQUE NOT NULL,
	constraint TBL_USER_TYPE_PK PRIMARY KEY ("user_type_id"));


/
CREATE TABLE "tbl_student" (
	"student_id" VARCHAR2(255) UNIQUE NOT NULL,
	"user_id" INT UNIQUE NOT NULL,
	"last_name" VARCHAR2(255) NOT NULL,
	"middle_name" VARCHAR2(255),
	"first_name" VARCHAR2(255) NOT NULL,
	"department_id" INT,
	"course_id" INT,
	constraint TBL_STUDENT_PK PRIMARY KEY ("student_id"));


/
CREATE TABLE "tbl_department" (
	"department_id" INT NOT NULL,
	"department" VARCHAR2(255) NOT NULL,
	constraint TBL_DEPARTMENT_PK PRIMARY KEY ("department_id"));

CREATE sequence "TBL_DEPARTMENT_DEPARTMENT_ID_SEQ";

CREATE trigger "BI_TBL_DEPARTMENT_DEPARTMENT_ID"
  before insert on "tbl_department"
  for each row
begin
  select "TBL_DEPARTMENT_DEPARTMENT_ID_SEQ".nextval into :NEW."department_id" from dual;
end;

/
CREATE TABLE "tbl_employee" (
	"employee_id" VARCHAR2(255) UNIQUE NOT NULL,
	"user_id" INT UNIQUE NOT NULL,
	"last_name" VARCHAR2(255) NOT NULL,
	"middle_name" VARCHAR2(255),
	"first_name" VARCHAR2(255) NOT NULL,
	"position" VARCHAR2(255) NOT NULL,
	"department_id" INT,
	"course_id" INT,
	constraint TBL_EMPLOYEE_PK PRIMARY KEY ("employee_id"));


/
CREATE TABLE "tbl_course" (
	"course_id" INT NOT NULL,
	"department_id" INT NOT NULL,
	"course" VARCHAR2(255) NOT NULL,
	constraint TBL_COURSE_PK PRIMARY KEY ("course_id"));

CREATE sequence "TBL_COURSE_COURSE_ID_SEQ";

CREATE trigger "BI_TBL_COURSE_COURSE_ID"
  before insert on "tbl_course"
  for each row
begin
  select "TBL_COURSE_COURSE_ID_SEQ".nextval into :NEW."course_id" from dual;
end;

/
CREATE TABLE "tbl_visitor" (
	"visitor_id" INT UNIQUE NOT NULL,
	"user_id" INT UNIQUE NOT NULL,
	"last_name" VARCHAR2(255) NOT NULL,
	"middle_name" VARCHAR2(255),
	"first_name" VARCHAR2(255) NOT NULL,
	constraint TBL_VISITOR_PK PRIMARY KEY ("visitor_id"));

CREATE sequence "TBL_VISITOR_VISITOR_ID_SEQ";

CREATE trigger "BI_TBL_VISITOR_VISITOR_ID"
  before insert on "tbl_visitor"
  for each row
begin
  select "TBL_VISITOR_VISITOR_ID_SEQ".nextval into :NEW."visitor_id" from dual;
end;

/
ALTER TABLE "tbl_user" ADD CONSTRAINT "tbl_user_fk0" FOREIGN KEY ("user_type") REFERENCES "tbl_user_type"("user_type_id");


ALTER TABLE "tbl_student" ADD CONSTRAINT "tbl_student_fk0" FOREIGN KEY ("user_id") REFERENCES "tbl_user"("user_id");
ALTER TABLE "tbl_student" ADD CONSTRAINT "tbl_student_fk1" FOREIGN KEY ("department_id") REFERENCES "tbl_department"("department_id");
ALTER TABLE "tbl_student" ADD CONSTRAINT "tbl_student_fk2" FOREIGN KEY ("course_id") REFERENCES "tbl_course"("course_id");


ALTER TABLE "tbl_employee" ADD CONSTRAINT "tbl_employee_fk0" FOREIGN KEY ("user_id") REFERENCES "tbl_user"("user_id");
ALTER TABLE "tbl_employee" ADD CONSTRAINT "tbl_employee_fk1" FOREIGN KEY ("department_id") REFERENCES "tbl_department"("department_id");
ALTER TABLE "tbl_employee" ADD CONSTRAINT "tbl_employee_fk2" FOREIGN KEY ("course_id") REFERENCES "tbl_course"("course_id");

ALTER TABLE "tbl_course" ADD CONSTRAINT "tbl_course_fk0" FOREIGN KEY ("department_id") REFERENCES "tbl_department"("department_id");

ALTER TABLE "tbl_visitor" ADD CONSTRAINT "tbl_visitor_fk0" FOREIGN KEY ("user_id") REFERENCES "tbl_user"("user_id");

