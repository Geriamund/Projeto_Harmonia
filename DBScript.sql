CREATE TABLE "Users" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
          "Nome" TEXT NOT NULL,
          "Email" TEXT NOT NULL,
          "Senha" TEXT NOT NULL
      );

INSERT INTO Users (Email, Nome, Senha)
VALUES ('exemplo@email.com', 'nomeexemplo', 'senhaexemplo');