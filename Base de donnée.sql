-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: localhost    Database: ifrocean
-- ------------------------------------------------------
-- Server version	5.7.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `animaux`
--

DROP TABLE IF EXISTS `animaux`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `animaux` (
  `idAnimaux` int(11) NOT NULL AUTO_INCREMENT,
  `espece` varchar(255) NOT NULL,
  PRIMARY KEY (`idAnimaux`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `animaux`
--

LOCK TABLES `animaux` WRITE;
/*!40000 ALTER TABLE `animaux` DISABLE KEYS */;
INSERT INTO `animaux` VALUES (1,'test');
/*!40000 ALTER TABLE `animaux` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `animauxparzone`
--

DROP TABLE IF EXISTS `animauxparzone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `animauxparzone` (
  `idAnimaux` int(11) NOT NULL,
  `nombre` int(11) NOT NULL,
  `idEtude` int(11) NOT NULL,
  `idPlage` int(11) NOT NULL,
  `idZoneEtude` int(11) NOT NULL,
  PRIMARY KEY (`idAnimaux`,`idEtude`,`idPlage`,`idZoneEtude`),
  KEY `fk_ZoneEtude_has_Animaux_Animaux1_idx` (`idAnimaux`),
  KEY `fk_ZoneEtude_has_Animaux_ZoneEtude1_idx` (`idEtude`,`idPlage`,`idZoneEtude`),
  KEY `fk_ZoneEtude_has_Animaux_ZoneEtude1` (`idZoneEtude`),
  CONSTRAINT `fk_ZoneEtude_has_Animaux_Animaux1` FOREIGN KEY (`idAnimaux`) REFERENCES `animaux` (`idAnimaux`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ZoneEtude_has_Animaux_ZoneEtude1` FOREIGN KEY (`idZoneEtude`) REFERENCES `zoneetude` (`idZoneEtude`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `animauxparzone`
--

LOCK TABLES `animauxparzone` WRITE;
/*!40000 ALTER TABLE `animauxparzone` DISABLE KEYS */;
/*!40000 ALTER TABLE `animauxparzone` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commune`
--

DROP TABLE IF EXISTS `commune`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commune` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `codePostal` varchar(5) NOT NULL,
  `idDepartement` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Commune_Departement1_idx` (`idDepartement`),
  CONSTRAINT `fk_Commune_Departement1` FOREIGN KEY (`idDepartement`) REFERENCES `departement` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commune`
--

LOCK TABLES `commune` WRITE;
/*!40000 ALTER TABLE `commune` DISABLE KEYS */;
INSERT INTO `commune` VALUES (2,'Pornic','44210',1),(4,'test','99999',2);
/*!40000 ALTER TABLE `commune` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departement`
--

DROP TABLE IF EXISTS `departement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departement` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `NumeroDepartement` varchar(3) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departement`
--

LOCK TABLES `departement` WRITE;
/*!40000 ALTER TABLE `departement` DISABLE KEYS */;
INSERT INTO `departement` VALUES (1,'Loire-Atlantique','44'),(2,'test','461');
/*!40000 ALTER TABLE `departement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `etude`
--

DROP TABLE IF EXISTS `etude`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `etude` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `actif` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `etude`
--

LOCK TABLES `etude` WRITE;
/*!40000 ALTER TABLE `etude` DISABLE KEYS */;
INSERT INTO `etude` VALUES (1,'Etude Pornic',1),(2,'Etude de Pornic',1),(3,'test',1);
/*!40000 ALTER TABLE `etude` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personne`
--

DROP TABLE IF EXISTS `personne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `prenom` varchar(45) NOT NULL,
  `identifiant` varchar(45) NOT NULL,
  `motDePasse` varchar(1000) NOT NULL,
  `admin` tinyint(4) NOT NULL DEFAULT '0',
  `adresseMail` varchar(45) NOT NULL,
  `actif` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personne`
--

LOCK TABLES `personne` WRITE;
/*!40000 ALTER TABLE `personne` DISABLE KEYS */;
INSERT INTO `personne` VALUES (1,'grimault','romain','romain','romain',1,'romain@romain.Fr',1),(2,'test','test','test','test',0,'test@test.Fr',1);
/*!40000 ALTER TABLE `personne` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plage`
--

DROP TABLE IF EXISTS `plage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plage` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `idCommune` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Plage_Commune1_idx` (`idCommune`),
  CONSTRAINT `fk_Plage_Commune1` FOREIGN KEY (`idCommune`) REFERENCES `commune` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plage`
--

LOCK TABLES `plage` WRITE;
/*!40000 ALTER TABLE `plage` DISABLE KEYS */;
INSERT INTO `plage` VALUES (1,'Plages des sablons',2),(2,'Plage de la Birochère',2),(3,'test',4);
/*!40000 ALTER TABLE `plage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plagedeetude`
--

DROP TABLE IF EXISTS `plagedeetude`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plagedeetude` (
  `idEtude` int(11) NOT NULL,
  `idPlage` int(11) NOT NULL,
  `superficie` double DEFAULT NULL,
  PRIMARY KEY (`idEtude`,`idPlage`),
  KEY `fk_table1_Plage1_idx` (`idPlage`),
  CONSTRAINT `fk_table1_Etude1` FOREIGN KEY (`idEtude`) REFERENCES `etude` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_table1_Plage1` FOREIGN KEY (`idPlage`) REFERENCES `plage` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plagedeetude`
--

LOCK TABLES `plagedeetude` WRITE;
/*!40000 ALTER TABLE `plagedeetude` DISABLE KEYS */;
INSERT INTO `plagedeetude` VALUES (2,1,NULL),(3,2,NULL);
/*!40000 ALTER TABLE `plagedeetude` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zoneetude`
--

DROP TABLE IF EXISTS `zoneetude`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zoneetude` (
  `dateEtude` datetime NOT NULL,
  `LatitudeA` double NOT NULL,
  `LontitudeA` double NOT NULL,
  `LatitudeB` double NOT NULL,
  `LongitudeB` float NOT NULL,
  `LatitudeC` double NOT NULL,
  `LongitudeC` double NOT NULL,
  `LatitudeD` double NOT NULL,
  `LongitudeD` double NOT NULL,
  `SuperficieEtude` float NOT NULL,
  `idZoneEtude` int(11) NOT NULL,
  `IdPersonne` int(11) NOT NULL,
  `idEtude` int(11) NOT NULL,
  `idPlage` int(11) NOT NULL,
  PRIMARY KEY (`idZoneEtude`,`idEtude`,`idPlage`),
  KEY `fk_ZoneEtude_Personne1_idx` (`IdPersonne`),
  KEY `fk_ZoneEtude_table11_idx` (`idEtude`,`idPlage`),
  CONSTRAINT `fk_ZoneEtude_Personne1` FOREIGN KEY (`IdPersonne`) REFERENCES `personne` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ZoneEtude_table11` FOREIGN KEY (`idEtude`, `idPlage`) REFERENCES `plagedeetude` (`idEtude`, `idPlage`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zoneetude`
--

LOCK TABLES `zoneetude` WRITE;
/*!40000 ALTER TABLE `zoneetude` DISABLE KEYS */;
/*!40000 ALTER TABLE `zoneetude` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-18 18:06:56
