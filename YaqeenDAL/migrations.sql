Build started...
Build succeeded.
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Articles" (
    "ArticleId" integer GENERATED BY DEFAULT AS IDENTITY,
    "Title" text NOT NULL,
    "Content" text NOT NULL,
    "Category" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Articles" PRIMARY KEY ("ArticleId")
);

CREATE TABLE "CancerStages" (
    "StageId" integer GENERATED BY DEFAULT AS IDENTITY,
    "StageName" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_CancerStages" PRIMARY KEY ("StageId")
);

CREATE TABLE "CancerTypes" (
    "CancerId" integer GENERATED BY DEFAULT AS IDENTITY,
    "CancerTypeName" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_CancerTypes" PRIMARY KEY ("CancerId")
);

CREATE TABLE "Users" (
    "UserId" integer GENERATED BY DEFAULT AS IDENTITY,
    "FirstName" text NOT NULL,
    "LastName" text NOT NULL,
    "MobileNumber" text NULL,
    "Email" text NOT NULL,
    "AgreedTerms" boolean NOT NULL,
    "Gender" text NULL,
    "IsEmailVerified" boolean NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("UserId")
);

CREATE TABLE "Doctors" (
    "UserId" integer NOT NULL,
    "University" text NOT NULL,
    "Degree" text NOT NULL,
    "MedicalField" text NOT NULL,
    "VerificationStatus_VerifierUserId" integer NOT NULL,
    "VerificationStatus_RowVersion" bytea NOT NULL,
    "VerificationStatus_Notes" text NOT NULL,
    "AnswerId" text NOT NULL,
    "BookmarkId" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    CONSTRAINT "PK_Doctors" PRIMARY KEY ("UserId"),
    CONSTRAINT "FK_Doctors_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE,
    CONSTRAINT "FK_Doctors_Users_VerificationStatus_VerifierUserId" FOREIGN KEY ("VerificationStatus_VerifierUserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE TABLE "Patients" (
    "UserId" integer NOT NULL,
    "AgeGroup" integer NOT NULL,
    "CancerTypeId" integer NOT NULL,
    "CancerStageId" integer NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    CONSTRAINT "PK_Patients" PRIMARY KEY ("UserId"),
    CONSTRAINT "FK_Patients_CancerStages_CancerStageId" FOREIGN KEY ("CancerStageId") REFERENCES "CancerStages" ("StageId") ON DELETE CASCADE,
    CONSTRAINT "FK_Patients_CancerTypes_CancerTypeId" FOREIGN KEY ("CancerTypeId") REFERENCES "CancerTypes" ("CancerId") ON DELETE CASCADE,
    CONSTRAINT "FK_Patients_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE TABLE "Bookmarks" (
    "BookmarkId" integer NOT NULL,
    "UserId" integer NOT NULL,
    "ArticleId" integer NULL,
    "Type" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Bookmarks" PRIMARY KEY ("BookmarkId"),
    CONSTRAINT "FK_Bookmarks_Articles_ArticleId" FOREIGN KEY ("ArticleId") REFERENCES "Articles" ("ArticleId"),
    CONSTRAINT "FK_Bookmarks_Doctors_BookmarkId" FOREIGN KEY ("BookmarkId") REFERENCES "Doctors" ("UserId") ON DELETE CASCADE,
    CONSTRAINT "FK_Bookmarks_Doctors_UserId" FOREIGN KEY ("UserId") REFERENCES "Doctors" ("UserId") ON DELETE CASCADE,
    CONSTRAINT "FK_Bookmarks_Patients_UserId" FOREIGN KEY ("UserId") REFERENCES "Patients" ("UserId") ON DELETE CASCADE
);

CREATE TABLE "Interests" (
    "InterestId" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "LogoURL" text NOT NULL,
    "PatientUserId" integer NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Interests" PRIMARY KEY ("InterestId"),
    CONSTRAINT "FK_Interests_Patients_PatientUserId" FOREIGN KEY ("PatientUserId") REFERENCES "Patients" ("UserId")
);

CREATE TABLE "Questions" (
    "QuestionId" integer GENERATED BY DEFAULT AS IDENTITY,
    "UserId" integer NOT NULL,
    "Title" text NOT NULL,
    "Category" text NOT NULL,
    "Description" text NOT NULL,
    "PatientUserId" integer NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Questions" PRIMARY KEY ("QuestionId"),
    CONSTRAINT "FK_Questions_Patients_PatientUserId" FOREIGN KEY ("PatientUserId") REFERENCES "Patients" ("UserId"),
    CONSTRAINT "FK_Questions_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE TABLE "InterestUser" (
    "UserId" integer NOT NULL,
    "UsersUserId" integer NOT NULL,
    CONSTRAINT "PK_InterestUser" PRIMARY KEY ("UserId", "UsersUserId"),
    CONSTRAINT "FK_InterestUser_Interests_UserId" FOREIGN KEY ("UserId") REFERENCES "Interests" ("InterestId") ON DELETE CASCADE,
    CONSTRAINT "FK_InterestUser_Users_UsersUserId" FOREIGN KEY ("UsersUserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE TABLE "Answers" (
    "AnswerId" integer NOT NULL,
    "DoctorId" integer NOT NULL,
    "QuestionId" integer NOT NULL,
    "Content" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Answers" PRIMARY KEY ("AnswerId"),
    CONSTRAINT "FK_Answers_Doctors_AnswerId" FOREIGN KEY ("AnswerId") REFERENCES "Doctors" ("UserId") ON DELETE CASCADE,
    CONSTRAINT "FK_Answers_Doctors_DoctorId" FOREIGN KEY ("DoctorId") REFERENCES "Doctors" ("UserId") ON DELETE CASCADE,
    CONSTRAINT "FK_Answers_Questions_QuestionId" FOREIGN KEY ("QuestionId") REFERENCES "Questions" ("QuestionId") ON DELETE CASCADE
);

CREATE INDEX "IX_Answers_DoctorId" ON "Answers" ("DoctorId");

CREATE INDEX "IX_Answers_QuestionId" ON "Answers" ("QuestionId");

CREATE INDEX "IX_Bookmarks_ArticleId" ON "Bookmarks" ("ArticleId");

CREATE INDEX "IX_Bookmarks_UserId" ON "Bookmarks" ("UserId");

CREATE INDEX "IX_Doctors_VerificationStatus_VerifierUserId" ON "Doctors" ("VerificationStatus_VerifierUserId");

CREATE INDEX "IX_Interests_PatientUserId" ON "Interests" ("PatientUserId");

CREATE INDEX "IX_InterestUser_UsersUserId" ON "InterestUser" ("UsersUserId");

CREATE INDEX "IX_Patients_CancerStageId" ON "Patients" ("CancerStageId");

CREATE INDEX "IX_Patients_CancerTypeId" ON "Patients" ("CancerTypeId");

CREATE INDEX "IX_Questions_PatientUserId" ON "Questions" ("PatientUserId");

CREATE INDEX "IX_Questions_UserId" ON "Questions" ("UserId");

CREATE UNIQUE INDEX "IX_Users_Email" ON "Users" ("Email");

CREATE UNIQUE INDEX "IX_Users_MobileNumber" ON "Users" ("MobileNumber");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230927222335_schema-relationships', '7.0.11');

COMMIT;


