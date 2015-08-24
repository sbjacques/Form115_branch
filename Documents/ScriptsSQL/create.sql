-- Création BDD
USE form115

CREATE TABLE Produits ( 
	IdProduit			   int       NOT NULL IDENTITY,
	IdSejour               int       NOT NULL   ,
	NbPlaces               int       NOT NULL   ,
	DateDepart             date      NOT NULL   ,
	Description            ntext           ,
	Prix				   numeric         ,
	CONSTRAINT Pk_Produits PRIMARY KEY ( IdProduit )
 );


CREATE TABLE Sejours ( 
	IdSejour             int NOT NULL   IDENTITY,
	IdHotel              int NOT NULL   ,
	Duree				 tinyint    NOT NULL,
	CONSTRAINT Pk_Sejours PRIMARY KEY ( IdSejour )
 );

 
CREATE TABLE Hotels ( 
	IdHotel              int NOT NULL    IDENTITY,
	IdVille				 int,
	Categorie            tinyint,
	Description          ntext           ,
	Photo				 varchar(60),
	CONSTRAINT Pk_Hotels PRIMARY KEY ( IdHotel )
 );

  
CREATE TABLE Reservations ( 
	IdReservation		int NOT NULL    IDENTITY,
	IdProduit           int NOT NULL ,
	Quantity			int NOT NULL,
	IdUtilisateur		int NOT NULL,
	CONSTRAINT Pk_Reservations PRIMARY KEY ( IdReservation )
 );

  
CREATE TABLE Utilisateurs ( 
	IdUtilisateur	int NOT NULL    IDENTITY,
	Nom				nvarchar(60) ,
	Prenom			nvarchar(60) ,
	Telephone		varchar(12) ,
	CONSTRAINT Pk_Utilisateurs PRIMARY KEY ( IdUtilisateur )
);

ALTER TABLE Produits ADD CONSTRAINT fk_produits_sejours FOREIGN KEY ( IdSejour ) REFERENCES Sejours( IdSejour ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Sejours ADD CONSTRAINT fk_sejours_hotels FOREIGN KEY ( IdHotel ) REFERENCES Hotels ( IdHotel ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Reservations ADD CONSTRAINT fk_reservations_produits FOREIGN KEY ( IdProduit ) REFERENCES Produits ( IdProduit ) ON DELETE NO ACTION ON UPDATE NO ACTION;
