-- Doctors provided
INSERT INTO Doctors (Name) VALUES ('Dr. Gipsz Jakab');
INSERT INTO Doctors (Name) VALUES ('Dr. Teszt Elek');
INSERT INTO Doctors (Name) VALUES ('Dr. Kedvező Áron');
INSERT INTO Doctors (Name) VALUES ('Dr. Gipsz Elek');
INSERT INTO Doctors (Name) VALUES ('Dr. Doktor Doloróza');
-- More Doctors
INSERT INTO Doctors (Name) VALUES ('Dr. Mária Kovács');
INSERT INTO Doctors (Name) VALUES ('Dr. Gergő Nagy');
INSERT INTO Doctors (Name) VALUES ('Dr. Éva Tóth');
INSERT INTO Doctors (Name) VALUES ('Dr. Béla Fekete');
INSERT INTO Doctors (Name) VALUES ('Dr. Zsuzsa Szabó');
INSERT INTO Doctors (Name) VALUES ('Dr. István Varga');
INSERT INTO Doctors (Name) VALUES ('Dr. Katalin Horváth');
INSERT INTO Doctors (Name) VALUES ('Dr. Attila Kiss');
INSERT INTO Doctors (Name) VALUES ('Dr. Judit Papp');
INSERT INTO Doctors (Name) VALUES ('Dr. Levente Balázs');

-- Specialties provided
INSERT INTO Specialties (Name) VALUES ('Háziorvos');
INSERT INTO Specialties (Name) VALUES ('Belgyógyász');
INSERT INTO Specialties (Name) VALUES ('Sebész');
INSERT INTO Specialties (Name) VALUES ('Belgyógyász');
INSERT INTO Specialties (Name) VALUES ('Bőrgyógyász');
-- More specialties
INSERT INTO Specialties (Name) VALUES ('Gyermekorvos');
INSERT INTO Specialties (Name) VALUES ('Reumatológus');
INSERT INTO Specialties (Name) VALUES ('Pszichiáter');
INSERT INTO Specialties (Name) VALUES ('Onkológus');


-- Union table with the relationships between Doctors and Specialties

-- Dr. Gipsz Jakab -> Háziorvos & Belgyógyász
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (1, 1); -- Dr. Gipsz Jakab -> Háziorvos
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (1, 3); -- Dr. Gipsz Jakab -> Belgyógyász

-- Dr. Kedvező Áron -> Belgyógyász & Sebész
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (3, 3); -- Dr. Kedvező Áron -> Belgyógyász
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (3, 2); -- Dr. Kedvező Áron -> Sebész

-- Dr. Doktor Doloróza -> Belgyógyász & Bőrgyógyász
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (5, 3); -- Dr. Doktor Doloróza -> Belgyógyász
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (5, 4); -- Dr. Doktor Doloróza -> Bőrgyógyász

-- More relations:

-- Dr. Teszt Elek -> Belgyógyász & Gyermekorvos
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (2, 3); -- Dr. Teszt Elek -> Belgyógyász
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (2, 5); -- Dr. Teszt Elek -> Gyermekorvos

-- Dr. Gipsz Elek -> Szemész & Reumatológus
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (4, 6); -- Dr. Gipsz Elek -> Szemész
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (4, 6); -- Dr. Gipsz Elek -> Reumatológus (repetido)

-- Dr. Mária Kovács -> Nőgyógyász & Gyermekorvos
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (6, 7); -- Dr. Mária Kovács -> Nőgyógyász
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (6, 5); -- Dr. Mária Kovács -> Gyermekorvos

-- Dr. Gergo Nagy -> Ortopéd & Onkológus
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (7, 8); -- Dr. Gergo Nagy -> Ortopéd
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (7, 8); -- Dr. Gergo Nagy -> Onkológus (repetido)

-- Dr. Éva Tóth -> Pszichiáter & Gyermekorvos
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (8, 7); -- Dr. Éva Tóth -> Pszichiáter
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (8, 5); -- Dr. Éva Tóth -> Gyermekorvos

-- Dr. Béla Fekete -> Reumatológus & Onkológus
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (9, 6); -- Dr. Béla Fekete -> Reumatológus
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (9, 8); -- Dr. Béla Fekete -> Onkológus

-- Dr. Zsuzsa Szabó -> Onkológus & Dermatólogo
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (10, 8); -- Dr. Zsuzsa Szabó -> Onkológus
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (10, 4); -- Dr. Zsuzsa Szabó -> Dermatólogo

-- Dr. István Varga -> Belgyógyász & Gyermekorvos & Dermatólogo
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (11, 3); -- Dr. István Varga -> Belgyógyász
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (11, 5); -- Dr. István Varga -> Gyermekorvos
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (11, 4); -- Dr. István Varga -> Dermatólogo

-- Dr. Katalin Horváth -> Dermatólogo & Bőrgyógyász
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (12, 4); -- Dr. Katalin Horváth -> Dermatólogo
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (12, 6); -- Dr. Katalin Horváth -> Bőrgyógyász

-- Dr. Attila Kiss -> Gyermekorvos & Pszichiáter
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (13, 5); -- Dr. Attila Kiss -> Gyermekorvos
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (13, 7); -- Dr. Attila Kiss -> Pszichiáter

-- Dr. Judit Papp -> Dermatólogo & Reumatológus
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (14, 4); -- Dr. Judit Papp -> Dermatólogo
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (14, 6); -- Dr. Judit Papp -> Reumatológus

-- Dr. Levente Balázs -> Sebész & Ortopéd
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (15, 2); -- Dr. Levente Balázs -> Sebész
INSERT INTO DoctorSpecialties (DoctorId, SpecialtyId) VALUES (15, 8); -- Dr. Levente Balázs -> Ortopéd


-- Query example to filter Doctors by specialty
SELECT 
    D.DoctorId,
    D.Name AS DoctorName,
    S.SpecialtyId,
    S.Name AS SpecialtyName
FROM 
    Doctors AS D
JOIN 
    DoctorSpecialties AS DS ON D.DoctorId = DS.DoctorId
JOIN 
    Specialties AS S ON DS.SpecialtyId = S.SpecialtyId
WHERE 
    S.Name = 'Belgyógyász';

 