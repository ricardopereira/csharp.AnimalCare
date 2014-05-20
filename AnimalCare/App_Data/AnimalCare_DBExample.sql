/*==============================================================*/ 
/* INSERE AnimalSpecies                                         */ 
/*==============================================================*/ 
  
INSERT INTO AnimalSpecies VALUES ('Cão'); 
INSERT INTO AnimalSpecies VALUES ('Gato'); 
INSERT INTO AnimalSpecies VALUES ('Cavalo'); 
INSERT INTO AnimalSpecies VALUES ('Cobra'); 
INSERT INTO AnimalSpecies VALUES ('Escorpião'); 

/*==============================================================*/ 
/* INSERE AnimalRaces                                           */ 
/*==============================================================*/ 
  
INSERT INTO AnimalRaces VALUES (1,'Labrador'); 
INSERT INTO AnimalRaces VALUES (1,'Pastor Alemão'); 
INSERT INTO AnimalRaces VALUES (1,'Pinscher'); 
INSERT INTO AnimalRaces VALUES (1,'Bulldog'); 
INSERT INTO AnimalRaces VALUES (2,'Persa'); 
INSERT INTO AnimalRaces VALUES (2,'Havana'); 
INSERT INTO AnimalRaces VALUES (1,'Beagle'); 
INSERT INTO AnimalRaces VALUES (1,'Boxer'); 
INSERT INTO AnimalRaces VALUES (1,'Caniche'); 
INSERT INTO AnimalRaces VALUES (1,'Cocker'); 
INSERT INTO AnimalRaces VALUES (1,'Jack Russel'); 
INSERT INTO AnimalRaces VALUES (1,'S. Bernardo'); 
INSERT INTO AnimalRaces VALUES (1,'Dogue Alemão'); 

/*==============================================================*/ 
/* INSERE AnimalConditions                                      */ 
/*==============================================================*/ 
  
INSERT INTO AnimalConditions VALUES ('Calmo'); 
INSERT INTO AnimalConditions VALUES ('Violento'); 

/*==============================================================*/ 
/* INSERE AnimalHabitats                                        */ 
/*==============================================================*/ 
  
INSERT INTO AnimalHabitats VALUES ('Vivenda'); 
INSERT INTO AnimalHabitats VALUES ('Apartamento'); 
INSERT INTO AnimalHabitats VALUES ('Exterior sem abrigo'); 
INSERT INTO AnimalHabitats VALUES ('Exterior com abrigo'); 
INSERT INTO AnimalHabitats VALUES ('Estábulo'); 

/*==============================================================*/ 
/* INSERE AnimalDiaryTypes                                       */ 
/*==============================================================*/ 
  
INSERT INTO AnimalDiaryTypes VALUES ('Quantidade de leite'); 
INSERT INTO AnimalDiaryTypes VALUES ('Quantidade de mel'); 
INSERT INTO AnimalDiaryTypes VALUES ('Temperatura'); 

/*==============================================================*/ 
/* INSERE AppointmentTypes                                      */ 
/*==============================================================*/ 
  
INSERT INTO AppointmentTypes VALUES ('Urgente'); 
INSERT INTO AppointmentTypes VALUES ('Orçamento'); 
INSERT INTO AppointmentTypes VALUES ('Rotina'); 

/*==============================================================*/ 
/* INSERE ServiceKinds                                         */ 
/*==============================================================*/ 
  
INSERT INTO ServiceKinds VALUES ('Tratamento'); 
INSERT INTO ServiceKinds VALUES ('Especialidade'); 
INSERT INTO ServiceKinds VALUES ('Vacinação'); 
INSERT INTO ServiceKinds VALUES ('Consulta de Rotina'); 
INSERT INTO ServiceKinds VALUES ('Urgência'); 

/*==============================================================*/ 
/* INSERE Cities                                                */ 
/*==============================================================*/ 
  
INSERT INTO Cities VALUES ('Coimbra'); 
INSERT INTO Cities VALUES ('Cantanhede'); 
INSERT INTO Cities VALUES ('Aveiro'); 
INSERT INTO Cities VALUES ('Praia de Mira'); 
INSERT INTO Cities VALUES ('Mira'); 

/*==============================================================*/ 
/* INSERE Countries                                             */ 
/*==============================================================*/ 
  
INSERT INTO Countries VALUES ('Portugal',620); 
INSERT INTO Countries VALUES ('Espanha',724); 
INSERT INTO Countries VALUES ('França',250); 
INSERT INTO Countries VALUES ('Alemanha',276); 
INSERT INTO Countries VALUES ('Itália',370); 

/*==============================================================*/ 
/* INSERE BusinessSector                                        */ 
/*==============================================================*/ 
  
INSERT INTO BusinessSector VALUES ('Apicultura'); 
INSERT INTO BusinessSector VALUES ('Suinicultura'); 
INSERT INTO BusinessSector VALUES ('Bovinocultura'); 
INSERT INTO BusinessSector VALUES ('Ovinocultura'); 
INSERT INTO BusinessSector VALUES ('Cunicultura'); 

/*==============================================================*/ 
/* INSERE Clinics                                               */ 
/*==============================================================*/ 
  
INSERT INTO Clinics VALUES ('Sede',2,'Rua da Liberdade','3000','',1,'239 239 000','','geral@animalcare.com'); 

/*==============================================================*/ 
/* INSERE Expertises                                            */ 
/*==============================================================*/ 
  
INSERT INTO Expertises VALUES ('Funcionário');
INSERT INTO Expertises VALUES ('Médico geral');

/*==============================================================*/ 
/* INSERE Users                                                 */ 
/*==============================================================*/ 
  
INSERT INTO Users VALUES ('r@animalcare.com','Ricardo Pereira','qwerty',NULL);
INSERT INTO Users VALUES ('m@animalcare.com','Mário Silva','qwerty',NULL);

/*==============================================================*/ 
/* INSERE UserGroups                                            */ 
/*==============================================================*/ 
  
INSERT INTO UserGroups VALUES ('Administradores',1);
INSERT INTO UserGroups VALUES ('Médicos',0);
INSERT INTO UserGroups VALUES ('Funcionários',0);
INSERT INTO UserGroups VALUES ('Clientes',0);

/*==============================================================*/ 
/* INSERE UserGroupsRelation                                    */ 
/*==============================================================*/ 
  
  INSERT INTO UserGroupsRelation VALUES (1,1);
  INSERT INTO UserGroupsRelation VALUES (2,2);