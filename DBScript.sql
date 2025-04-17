CREATE TABLE "Users" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
          "Nome" TEXT NOT NULL,
          "Email" TEXT NOT NULL,
          "Senha" TEXT NOT NULL
      );


CREATE TABLE "Families" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Families" PRIMARY KEY AUTOINCREMENT,
          "Nome" TEXT NOT NULL,
      );

ALTER TABLE "Users"
ADD COLUMN "FamilyId" INTEGER;

ALTER TABLE "Users"
ADD CONSTRAINT "FK_Users_Families_FamilyId"
FOREIGN KEY ("FamilyId")
REFERENCES "Families" ("Id");

INSERT INTO Users (Email, Nome, Senha)
VALUES ('admin@admin', 'Administrador', 'AQAAAAIAAYagAAAAEDTZdaNFfGte51kkSGMfoJI+fQXwDMnpQdQEOQzy26Y159pHQrjIVgzBX6x8baOfVw=='); --senha: admin123

INSERT INTO Users (Email, Nome, Senha)
VALUES ('admin2@admin', 'Administrador2', 'AQAAAAIAAYagAAAAEDTZdaNFfGte51kkSGMfoJI+fQXwDMnpQdQEOQzy26Y159pHQrjIVgzBX6x8baOfVw=='); --senha: admin123