-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: base
-- ------------------------------------------------------
-- Server version	5.7.11-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ic`
--

DROP TABLE IF EXISTS `ic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ic` (
  `id_ic` int(11) NOT NULL AUTO_INCREMENT,
  `nome` text NOT NULL,
  `descricao` text NOT NULL,
  `ranking` int(11) DEFAULT NULL,
  `imagem` varchar(255) NOT NULL,
  PRIMARY KEY (`id_ic`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ic`
--

LOCK TABLES `ic` WRITE;
/*!40000 ALTER TABLE `ic` DISABLE KEYS */;
INSERT INTO `ic` VALUES (20,'Carol','Rene',6,'Rafael'),(22,'Rafael','Filho',NULL,'Principe'),(25,'Teste','Novo Teste',NULL,'Rafael'),(26,'Mais um teste','Testando novamente o cadastro de itens',4,'Principe'),(27,'Rene Dourado','Carolina',2,'Principe'),(28,'Pin Pad','PIN Pad (acrônimo do termo em inglês - Personal Information Number - Peripheral Adapter Device) é a máquina utilizada para entrar com o número de identificação pessoal. Normalmente esse dispositivo é utilizado para informar a \"senha\", com no mínimo 4 números, de forma a identificar o demandante da operação financeira em sistemas computacionais. Esses dispositivos podem ser seguros e confiáveis quando utilizam assinaturas digitais. A forma desnormalizada é uma tabela na qual itens que aparecem mais de uma vez não foram removidos. Vimos que não se pode gerenciar bem dados usando este tipo de tabela em um banco de dados relacional. Consequentemente, é preciso dividir a tabela. A primeira forma normal refere-se a uma tabela simples, bidimensional, resultante da divisão da original desnormalizada. Pode ser considerada como uma tabela com um item em cada célula. A tabela é dividida para que nenhum item apareça mais de uma vez. A segunda forma normal refere-se a uma tabela na qual uma chave que pode identificar dados determina os valores de outras colunas. Aqui, é a chave primária que determina valores em outras colunas. Em um banco de dados relacional, um valor é chamado de funcionalmente dependente se ele determinar valores em outras colunas. Na segunda forma normal, a tabela é dividida para que valores em outras colunas sejam funcionalmente dependentes da chave primária. Na terceira forma normal, uma tabela é dividida para que um valor não seja determinado por nenhuma chave não-primária. Em um banco de dados relacional, um valor é chamado de transitivamente dependente se ele determinar valores em outras colunas indiretamente, o que é parte de uma operação funcionalmente dependente. Na terceira forma normal, a tabela é dividida para que valores transitivamente dependentes sejam removidos.',1,'PinPad'),(29,'Lourdes','A Lourdes é minha sogra. Ela é gente fina.',9,'Principe'),(32,'Jefferson Lima','O Jefferson é um dos melhores colaboradores que temos na CVC.',2,'Rafael');
/*!40000 ALTER TABLE `ic` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-03-25 19:52:44
