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
    "UserId" text NOT NULL,
    "FirstName" text NOT NULL,
    "LastName" text NOT NULL,
    "MobileNumber" text NULL,
    "Email" text NOT NULL,
    "AgreedTerms" boolean NOT NULL,
    "Gender" text NULL,
    "IsEmailVerified" boolean NOT NULL,
    "DeletedAt" bytea NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("UserId")
);

CREATE TABLE "Patients" (
    "UserId" text NOT NULL,
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

CREATE TABLE "Interests" (
    "InterestId" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "LogoURL" text NOT NULL,
    "PatientUserId" text NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Interests" PRIMARY KEY ("InterestId"),
    CONSTRAINT "FK_Interests_Patients_PatientUserId" FOREIGN KEY ("PatientUserId") REFERENCES "Patients" ("UserId")
);

CREATE TABLE "Questions" (
    "QuestionId" integer GENERATED BY DEFAULT AS IDENTITY,
    "UserId" text NOT NULL,
    "Title" text NOT NULL,
    "Category" text NOT NULL,
    "Description" text NOT NULL,
    "PatientUserId" text NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Questions" PRIMARY KEY ("QuestionId"),
    CONSTRAINT "FK_Questions_Patients_PatientUserId" FOREIGN KEY ("PatientUserId") REFERENCES "Patients" ("UserId"),
    CONSTRAINT "FK_Questions_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE TABLE "InterestUser" (
    "InterestsInterestId" integer NOT NULL,
    "UsersUserId" text NOT NULL,
    CONSTRAINT "PK_InterestUser" PRIMARY KEY ("InterestsInterestId", "UsersUserId"),
    CONSTRAINT "FK_InterestUser_Interests_InterestsInterestId" FOREIGN KEY ("InterestsInterestId") REFERENCES "Interests" ("InterestId") ON DELETE CASCADE,
    CONSTRAINT "FK_InterestUser_Users_UsersUserId" FOREIGN KEY ("UsersUserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE TABLE "Answers" (
    "AnswerId" integer GENERATED BY DEFAULT AS IDENTITY,
    "DoctorId" text NOT NULL,
    "QuestionId" integer NOT NULL,
    "Content" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Answers" PRIMARY KEY ("AnswerId"),
    CONSTRAINT "FK_Answers_Questions_QuestionId" FOREIGN KEY ("QuestionId") REFERENCES "Questions" ("QuestionId") ON DELETE CASCADE
);

CREATE TABLE "Bookmarks" (
    "BookmarkId" integer GENERATED BY DEFAULT AS IDENTITY,
    "UserId" text NOT NULL,
    "ArticleId" integer NULL,
    "Type" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Bookmarks" PRIMARY KEY ("BookmarkId"),
    CONSTRAINT "FK_Bookmarks_Articles_ArticleId" FOREIGN KEY ("ArticleId") REFERENCES "Articles" ("ArticleId"),
    CONSTRAINT "FK_Bookmarks_Patients_UserId" FOREIGN KEY ("UserId") REFERENCES "Patients" ("UserId") ON DELETE CASCADE
);

CREATE TABLE "Doctors" (
    "UserId" text NOT NULL,
    "University" text NOT NULL,
    "Degree" text NOT NULL,
    "MedicalField" text NOT NULL,
    "VerificationStatusId" integer NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    CONSTRAINT "PK_Doctors" PRIMARY KEY ("UserId"),
    CONSTRAINT "FK_Doctors_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE TABLE "VerificationStatus" (
    "VerificationId" integer GENERATED BY DEFAULT AS IDENTITY,
    "TargetDoctorUserId" text NOT NULL,
    "VerifierUserId" text NOT NULL,
    "RowVersion" bytea NOT NULL,
    "Notes" text NOT NULL,
    CONSTRAINT "PK_VerificationStatus" PRIMARY KEY ("VerificationId"),
    CONSTRAINT "FK_VerificationStatus_Doctors_TargetDoctorUserId" FOREIGN KEY ("TargetDoctorUserId") REFERENCES "Doctors" ("UserId") ON DELETE CASCADE,
    CONSTRAINT "FK_VerificationStatus_Users_VerifierUserId" FOREIGN KEY ("VerifierUserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE INDEX "IX_Answers_DoctorId" ON "Answers" ("DoctorId");

CREATE INDEX "IX_Answers_QuestionId" ON "Answers" ("QuestionId");

CREATE INDEX "IX_Bookmarks_ArticleId" ON "Bookmarks" ("ArticleId");

CREATE INDEX "IX_Bookmarks_UserId" ON "Bookmarks" ("UserId");

CREATE INDEX "IX_Doctors_VerificationStatusId" ON "Doctors" ("VerificationStatusId");

CREATE INDEX "IX_Interests_PatientUserId" ON "Interests" ("PatientUserId");

CREATE INDEX "IX_InterestUser_UsersUserId" ON "InterestUser" ("UsersUserId");

CREATE INDEX "IX_Patients_CancerStageId" ON "Patients" ("CancerStageId");

CREATE INDEX "IX_Patients_CancerTypeId" ON "Patients" ("CancerTypeId");

CREATE INDEX "IX_Questions_PatientUserId" ON "Questions" ("PatientUserId");

CREATE INDEX "IX_Questions_UserId" ON "Questions" ("UserId");

CREATE UNIQUE INDEX "IX_Users_Email" ON "Users" ("Email");

CREATE UNIQUE INDEX "IX_Users_MobileNumber" ON "Users" ("MobileNumber");

CREATE INDEX "IX_VerificationStatus_TargetDoctorUserId" ON "VerificationStatus" ("TargetDoctorUserId");

CREATE INDEX "IX_VerificationStatus_VerifierUserId" ON "VerificationStatus" ("VerifierUserId");

ALTER TABLE "Answers" ADD CONSTRAINT "FK_Answers_Doctors_DoctorId" FOREIGN KEY ("DoctorId") REFERENCES "Doctors" ("UserId") ON DELETE CASCADE;

ALTER TABLE "Bookmarks" ADD CONSTRAINT "FK_Bookmarks_Doctors_UserId" FOREIGN KEY ("UserId") REFERENCES "Doctors" ("UserId") ON DELETE CASCADE;

ALTER TABLE "Doctors" ADD CONSTRAINT "FK_Doctors_VerificationStatus_VerificationStatusId" FOREIGN KEY ("VerificationStatusId") REFERENCES "VerificationStatus" ("VerificationId") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231001155547_make-UserId-string', '7.0.11');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231001174541_optional-verification-status', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Doctors" DROP CONSTRAINT "FK_Doctors_VerificationStatus_VerificationStatusId";

ALTER TABLE "Doctors" ALTER COLUMN "VerificationStatusId" DROP NOT NULL;

ALTER TABLE "Doctors" ADD CONSTRAINT "FK_Doctors_VerificationStatus_VerificationStatusId" FOREIGN KEY ("VerificationStatusId") REFERENCES "VerificationStatus" ("VerificationId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231001183129_Optional-VerificationStatus-Id', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Interests" DROP CONSTRAINT "FK_Interests_Patients_PatientUserId";

DROP INDEX "IX_Interests_PatientUserId";

ALTER TABLE "Interests" DROP COLUMN "PatientUserId";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231002211535_rm-interests-patients', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Interests" ADD "TargetUserType" integer NOT NULL DEFAULT 0;

CREATE TABLE "ResourceLocalization" (
    "TranslationId" integer GENERATED BY DEFAULT AS IDENTITY,
    "Language" text NOT NULL,
    "Translation" jsonb NOT NULL,
    "CancerStageStageId" integer NULL,
    "CancerTypeCancerId" integer NULL,
    "InterestId" integer NULL,
    CONSTRAINT "PK_ResourceLocalization" PRIMARY KEY ("TranslationId"),
    CONSTRAINT "FK_ResourceLocalization_CancerStages_CancerStageStageId" FOREIGN KEY ("CancerStageStageId") REFERENCES "CancerStages" ("StageId"),
    CONSTRAINT "FK_ResourceLocalization_CancerTypes_CancerTypeCancerId" FOREIGN KEY ("CancerTypeCancerId") REFERENCES "CancerTypes" ("CancerId"),
    CONSTRAINT "FK_ResourceLocalization_Interests_InterestId" FOREIGN KEY ("InterestId") REFERENCES "Interests" ("InterestId")
);

CREATE INDEX "IX_ResourceLocalization_CancerStageStageId" ON "ResourceLocalization" ("CancerStageStageId");

CREATE INDEX "IX_ResourceLocalization_CancerTypeCancerId" ON "ResourceLocalization" ("CancerTypeCancerId");

CREATE INDEX "IX_ResourceLocalization_InterestId" ON "ResourceLocalization" ("InterestId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231009215401_translations-interests', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "CancerTypes" ADD "LogoURL" text NOT NULL DEFAULT '';

ALTER TABLE "CancerStages" ADD "LogoURL" text NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231012184207_test-model', '7.0.11');

COMMIT;


