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

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231012143125_test-model-change', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "CancerStages" ADD "LogoURL" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231015043744_add-logourl-cancerstage', '7.0.11');

COMMIT;

START TRANSACTION;

CREATE TABLE "Photos" (
    "PhotoId" integer GENERATED BY DEFAULT AS IDENTITY,
    "PhotoURL" text NOT NULL,
    "Usage" integer NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Photos" PRIMARY KEY ("PhotoId")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231017031908_welcome-photos', '7.0.11');

COMMIT;

START TRANSACTION;

CREATE TABLE "Countries" (
    "CountryId" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "AlphaCode" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Countries" PRIMARY KEY ("CountryId")
);

CREATE TABLE "CountryStates" (
    "CountryStateId" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "CountryId" integer NOT NULL,
    "StateCode" text NOT NULL,
    "Latitude" text NOT NULL,
    "Longitude" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_CountryStates" PRIMARY KEY ("CountryStateId"),
    CONSTRAINT "FK_CountryStates_Countries_CountryId" FOREIGN KEY ("CountryId") REFERENCES "Countries" ("CountryId") ON DELETE CASCADE
);

CREATE INDEX "IX_CountryStates_CountryId" ON "CountryStates" ("CountryId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231023184403_add-university', '7.0.11');

COMMIT;

START TRANSACTION;

CREATE TABLE "Universities" (
    "UniversityId" integer GENERATED BY DEFAULT AS IDENTITY,
    "CountryName" text NOT NULL,
    "CountryCode" text NOT NULL,
    "StateCode" text NOT NULL,
    "StateName" text NOT NULL,
    "UniversityName" text NOT NULL,
    "Id" integer NOT NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "LastModifiedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Universities" PRIMARY KEY ("UniversityId")
);

CREATE INDEX "IX_Universities_CountryCode" ON "Universities" ("CountryCode");

CREATE INDEX "IX_Universities_CountryCode_StateCode" ON "Universities" ("CountryCode", "StateCode");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231109041156_add-university-model', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Doctors" ADD "CertificationPath" text NOT NULL DEFAULT '';

ALTER TABLE "Doctors" ADD "NationalIDPath" text NOT NULL DEFAULT '';

CREATE TABLE "Contents" (
    "ContentId" integer GENERATED BY DEFAULT AS IDENTITY,
    "ParentContentId" integer NULL,
    "Type" integer NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone NULL,
    "DeletedAt" timestamp with time zone NULL,
    "Raw" jsonb NOT NULL,
    "AuthorUserId" text NOT NULL,
    "AssignedTo" integer NULL,
    "Phase" integer NOT NULL,
    "Tags" text[] NOT NULL,
    "Visibility" integer NOT NULL,
    "Attachments" text[] NOT NULL,
    CONSTRAINT "PK_Contents" PRIMARY KEY ("ContentId"),
    CONSTRAINT "FK_Contents_Contents_ParentContentId" FOREIGN KEY ("ParentContentId") REFERENCES "Contents" ("ContentId"),
    CONSTRAINT "FK_Contents_Users_AuthorUserId" FOREIGN KEY ("AuthorUserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE INDEX "IX_Contents_AssignedTo" ON "Contents" ("AssignedTo");

CREATE INDEX "IX_Contents_AuthorUserId" ON "Contents" ("AuthorUserId");

CREATE INDEX "IX_Contents_ParentContentId" ON "Contents" ("ParentContentId");

CREATE INDEX "IX_Contents_Tags" ON "Contents" ("Tags");

CREATE INDEX "IX_Contents_Type" ON "Contents" ("Type");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231117065846_questions', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Users" DROP COLUMN "DeletedAt";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231118161837_deletedAt', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Users" DROP COLUMN "Id";

ALTER TABLE "Universities" DROP COLUMN "Id";

ALTER TABLE "Universities" DROP COLUMN "LastModifiedDate";

ALTER TABLE "Questions" DROP COLUMN "Id";

ALTER TABLE "Questions" DROP COLUMN "LastModifiedDate";

ALTER TABLE "Photos" DROP COLUMN "Id";

ALTER TABLE "Photos" DROP COLUMN "LastModifiedDate";

ALTER TABLE "Patients" DROP COLUMN "Id";

ALTER TABLE "Interests" DROP COLUMN "Id";

ALTER TABLE "Interests" DROP COLUMN "LastModifiedDate";

ALTER TABLE "Doctors" DROP COLUMN "CertificationPath";

ALTER TABLE "Doctors" DROP COLUMN "Id";

ALTER TABLE "Doctors" DROP COLUMN "NationalIDPath";

ALTER TABLE "CountryStates" DROP COLUMN "Id";

ALTER TABLE "CountryStates" DROP COLUMN "LastModifiedDate";

ALTER TABLE "Countries" DROP COLUMN "Id";

ALTER TABLE "Countries" DROP COLUMN "LastModifiedDate";

ALTER TABLE "Contents" DROP COLUMN "CreatedAt";

ALTER TABLE "CancerTypes" DROP COLUMN "Id";

ALTER TABLE "CancerTypes" DROP COLUMN "LastModifiedDate";

ALTER TABLE "CancerStages" DROP COLUMN "Id";

ALTER TABLE "CancerStages" DROP COLUMN "LastModifiedDate";

ALTER TABLE "Bookmarks" DROP COLUMN "Id";

ALTER TABLE "Bookmarks" DROP COLUMN "LastModifiedDate";

ALTER TABLE "Articles" DROP COLUMN "Id";

ALTER TABLE "Articles" DROP COLUMN "LastModifiedDate";

ALTER TABLE "Answers" DROP COLUMN "Id";

ALTER TABLE "Answers" DROP COLUMN "LastModifiedDate";

ALTER TABLE "VerificationStatus" ADD "Active" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE "VerificationStatus" ADD "CreatedDate" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "VerificationStatus" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "VerificationStatus" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Users" ADD "CreatedDate" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "Users" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Users" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Universities" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Universities" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Questions" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Questions" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Photos" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Photos" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Patients" ADD "CreatedDate" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "Patients" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Patients" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Interests" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Interests" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Doctors" ADD "CreatedDate" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "Doctors" ADD "CredentialsAttachments" text[] NOT NULL DEFAULT ARRAY[]::text[];

ALTER TABLE "Doctors" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Doctors" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "CountryStates" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "CountryStates" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Countries" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Countries" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Contents" ADD "Active" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE "Contents" ADD "CreatedDate" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "CancerTypes" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "CancerTypes" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "CancerStages" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "CancerStages" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Bookmarks" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Bookmarks" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Articles" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Articles" ADD "UpdatedAt" timestamp with time zone NULL;

ALTER TABLE "Answers" ADD "DeletedAt" timestamp with time zone NULL;

ALTER TABLE "Answers" ADD "UpdatedAt" timestamp with time zone NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231118162100_delete-users-deleted-at-2', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Doctors" DROP CONSTRAINT "FK_Doctors_VerificationStatus_VerificationStatusId";

DROP TABLE "VerificationStatus";

DROP INDEX "IX_Doctors_VerificationStatusId";

ALTER TABLE "Interests" DROP COLUMN "TargetUserType";

ALTER TABLE "Doctors" DROP COLUMN "VerificationStatusId";

CREATE TYPE user_type AS ENUM ('patient', 'doctor');
CREATE TYPE verification_status AS ENUM ('pending', 'approved', 'more_info_needed', 'rejected');

ALTER TABLE "Doctors" ADD "VerificationStatus" verification_status NOT NULL DEFAULT 'pending'::verification_status;

CREATE TABLE "VerificationStatusEvent" (
    "TargetDoctorUserId" text NOT NULL,
    "VerifierUserId" text NOT NULL,
    "Notes" text NOT NULL,
    "UserId" text NULL,
    "Active" boolean NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone NULL,
    "DeletedAt" timestamp with time zone NULL,
    CONSTRAINT "PK_VerificationStatusEvent" PRIMARY KEY ("TargetDoctorUserId"),
    CONSTRAINT "FK_VerificationStatusEvent_Doctors_TargetDoctorUserId" FOREIGN KEY ("TargetDoctorUserId") REFERENCES "Doctors" ("UserId") ON DELETE CASCADE,
    CONSTRAINT "FK_VerificationStatusEvent_Doctors_UserId" FOREIGN KEY ("UserId") REFERENCES "Doctors" ("UserId"),
    CONSTRAINT "FK_VerificationStatusEvent_Users_VerifierUserId" FOREIGN KEY ("VerifierUserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

CREATE INDEX "IX_VerificationStatusEvent_UserId" ON "VerificationStatusEvent" ("UserId");

CREATE INDEX "IX_VerificationStatusEvent_VerifierUserId" ON "VerificationStatusEvent" ("VerifierUserId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231120004545_remove-target-user-type', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Interests" ADD "TargetUserType" user_type NOT NULL DEFAULT 'patient'::user_type;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231120004718_verification-status', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "VerificationStatusEvent" DROP CONSTRAINT "PK_VerificationStatusEvent";

ALTER TABLE "VerificationStatusEvent" ADD "EventId" integer GENERATED BY DEFAULT AS IDENTITY;

ALTER TABLE "VerificationStatusEvent" ADD CONSTRAINT "PK_VerificationStatusEvent" PRIMARY KEY ("EventId");

CREATE INDEX "IX_VerificationStatusEvent_TargetDoctorUserId" ON "VerificationStatusEvent" ("TargetDoctorUserId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231120023322_auto-generated-id-events-table', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "VerificationStatusEvent" ADD "Status" verification_status NOT NULL DEFAULT 'pending'::verification_status;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231120025658_verification-status-field', '7.0.11');

COMMIT;

START TRANSACTION;

ALTER TYPE verification_status ADD VALUE 'more_info_needed' BEFORE 'approved';
ALTER TYPE verification_status ADD VALUE 'rejected' BEFORE 'more_info_needed';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231120204839_reorder-verificationstatus', '7.0.11');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231130044407_hasura', '7.0.11');

COMMIT;


