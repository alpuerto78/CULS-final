CREATE TABLE "tbl_user" (
	"user_id" serial(255) NOT NULL UNIQUE,
	"rfid_tag" varchar(11) NOT NULL UNIQUE,
	"user_type" integer(255) NOT NULL,
	CONSTRAINT "tbl_user_pk" PRIMARY KEY ("user_id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "tbl_user_type" (
	"user_type_id" integer(255) NOT NULL UNIQUE,
	"user_type" varchar(255) NOT NULL UNIQUE,
	CONSTRAINT "tbl_user_type_pk" PRIMARY KEY ("user_type_id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "tbl_student" (
	"student_id" varchar(255) NOT NULL UNIQUE,
	"user_id" integer(255) NOT NULL UNIQUE,
	"last_name" varchar(255) NOT NULL,
	"middle_name" varchar(255),
	"first_name" varchar(255) NOT NULL,
	"department_id" integer(255),
	"course_id" integer(255),
	CONSTRAINT "tbl_student_pk" PRIMARY KEY ("student_id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "tbl_department" (
	"department_id" serial(255) NOT NULL,
	"department" varchar(255) NOT NULL,
	CONSTRAINT "tbl_department_pk" PRIMARY KEY ("department_id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "tbl_employee" (
	"employee_id" varchar(255) NOT NULL UNIQUE,
	"user_id" integer(255) NOT NULL UNIQUE,
	"last_name" varchar(255) NOT NULL,
	"middle_name" varchar(255),
	"first_name" varchar(255) NOT NULL,
	"position" varchar(255) NOT NULL,
	"department_id" integer(255),
	"course_id" integer(255),
	CONSTRAINT "tbl_employee_pk" PRIMARY KEY ("employee_id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "tbl_course" (
	"course_id" serial(255) NOT NULL,
	"department_id" integer(255) NOT NULL,
	"course" varchar(255) NOT NULL,
	CONSTRAINT "tbl_course_pk" PRIMARY KEY ("course_id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "tbl_visitor" (
	"visitor_id" serial(255) NOT NULL UNIQUE,
	"user_id" integer(255) NOT NULL UNIQUE,
	"last_name" varchar(255) NOT NULL,
	"middle_name" varchar(255),
	"first_name" varchar(255) NOT NULL,
	CONSTRAINT "tbl_visitor_pk" PRIMARY KEY ("visitor_id")
) WITH (
  OIDS=FALSE
);



ALTER TABLE "tbl_user" ADD CONSTRAINT "tbl_user_fk0" FOREIGN KEY ("user_type") REFERENCES "tbl_user_type"("user_type_id");


ALTER TABLE "tbl_student" ADD CONSTRAINT "tbl_student_fk0" FOREIGN KEY ("user_id") REFERENCES "tbl_user"("user_id");
ALTER TABLE "tbl_student" ADD CONSTRAINT "tbl_student_fk1" FOREIGN KEY ("department_id") REFERENCES "tbl_department"("department_id");
ALTER TABLE "tbl_student" ADD CONSTRAINT "tbl_student_fk2" FOREIGN KEY ("course_id") REFERENCES "tbl_course"("course_id");


ALTER TABLE "tbl_employee" ADD CONSTRAINT "tbl_employee_fk0" FOREIGN KEY ("user_id") REFERENCES "tbl_user"("user_id");
ALTER TABLE "tbl_employee" ADD CONSTRAINT "tbl_employee_fk1" FOREIGN KEY ("department_id") REFERENCES "tbl_department"("department_id");
ALTER TABLE "tbl_employee" ADD CONSTRAINT "tbl_employee_fk2" FOREIGN KEY ("course_id") REFERENCES "tbl_course"("course_id");

ALTER TABLE "tbl_course" ADD CONSTRAINT "tbl_course_fk0" FOREIGN KEY ("department_id") REFERENCES "tbl_department"("department_id");

ALTER TABLE "tbl_visitor" ADD CONSTRAINT "tbl_visitor_fk0" FOREIGN KEY ("user_id") REFERENCES "tbl_user"("user_id");

