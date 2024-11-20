CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory"
(
    "MigrationId"
    character
    varying
(
    150
) NOT NULL,
    "ProductVersion" character varying
(
    32
) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY
(
    "MigrationId"
)
    );

START TRANSACTION;
CREATE TABLE "Customers"
(
    "Id"           uuid                   NOT NULL,
    "CompanyName"  character varying(150) NOT NULL,
    "ECompanySize" integer                NOT NULL,
    CONSTRAINT "PK_Customers" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241119230952_InitialCreate', '9.0.0');

ALTER TABLE "Customers" DROP CONSTRAINT "PK_Customers";

ALTER TABLE "Customers" RENAME TO customers;

ALTER TABLE customers
    ADD CONSTRAINT "PK_customers" PRIMARY KEY ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241119232255_RenameCustomersTable', '9.0.0');

COMMIT;