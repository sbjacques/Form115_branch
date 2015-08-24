use Form115


ALTER TABLE dbo.Hotels
ADD CONSTRAINT Hotels_Villes_fk FOREIGN KEY (IdVille) 
  REFERENCES dbo.Villes (IdVille) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION;

ALTER TABLE dbo.Reservations
ADD CONSTRAINT Reservations_Utilisateurs_fk FOREIGN KEY (IdUtilisateur) 
  REFERENCES dbo.Utilisateurs (IdUtilisateur) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION;