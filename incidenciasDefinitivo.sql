-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.7.26 - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para incidencias
DROP DATABASE IF EXISTS `incidencias`;
CREATE DATABASE IF NOT EXISTS `incidencias` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_spanish_ci */;
USE `incidencias`;

-- Volcando estructura para evento incidencias.borrarTicketsSinValorar
DROP EVENT IF EXISTS `borrarTicketsSinValorar`;
DELIMITER //
CREATE DEFINER=`tienda`@`localhost` EVENT `borrarTicketsSinValorar` ON SCHEDULE EVERY 1 MINUTE STARTS '2019-01-02 11:03:29' ENDS '2029-04-26 15:39:52' ON COMPLETION PRESERVE ENABLE DO BEGIN
      DELETE FROM ticketencurso WHERE NOW() > DATE_ADD(fechaFinalizacion,INTERVAL 4 DAY);     
END//
DELIMITER ;

-- Volcando estructura para tabla incidencias.equipo
DROP TABLE IF EXISTS `equipo`;
CREATE TABLE IF NOT EXISTS `equipo` (
  `serviceTag` varchar(7) COLLATE latin1_spanish_ci NOT NULL,
  `marca` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  `modelo` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  `finGarantia` datetime NOT NULL,
  `idTipo` int(11) NOT NULL,
  `numOficina` int(11) NOT NULL,
  `numSerie` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  PRIMARY KEY (`serviceTag`),
  UNIQUE KEY `numSerie` (`numSerie`),
  KEY `FK_equipo_tipo` (`idTipo`),
  KEY `FK_equipo_sede` (`numOficina`),
  CONSTRAINT `FK_equipo_sede` FOREIGN KEY (`numOficina`) REFERENCES `sede` (`numOficina`) ON UPDATE CASCADE,
  CONSTRAINT `FK_equipo_tipo` FOREIGN KEY (`idTipo`) REFERENCES `tipo` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.equipo: ~40 rows (aproximadamente)
DELETE FROM `equipo`;
/*!40000 ALTER TABLE `equipo` DISABLE KEYS */;
INSERT INTO `equipo` (`serviceTag`, `marca`, `modelo`, `finGarantia`, `idTipo`, `numOficina`, `numSerie`) VALUES
	('A20200', 'HP', 'smart 980', '2020-03-21 00:00:00', 1, 1, 'HU265BM18V'),
	('A20201', 'Dell', 'optiplex 960 uff', '2021-11-20 00:00:00', 1, 1, 'YY201N'),
	('A20202', 'Lenovo', 'thinkcenter 400', '2022-03-11 00:00:00', 1, 1, 'LN2800A'),
	('A20203', 'Lexkmark', 'mx711', '2021-04-10 00:00:00', 4, 1, 'LE44550'),
	('A40204', 'Dell', 'Latitud e5430', '2020-03-15 00:00:00', 2, 1, 'FW208K'),
	('A40205', 'Samsung', 's4900032f', '2020-11-21 00:00:00', 5, 1, 'SA43201'),
	('A40206', 'HP', 'w500', '2022-03-12 00:00:00', 4, 1, 'HU265BM21S'),
	('A40207', 'HP', 'Pavilion 2020', '2021-10-16 00:00:00', 1, 1, 'HU265BM16V'),
	('A40208', 'HP', '3005', '2021-07-17 00:00:00', 3, 1, 'HU265BM15V'),
	('A40209', 'Lenovo', 'Idea400', '2020-09-17 00:00:00', 1, 1, 'LN3400B'),
	('A40504', 'HP', 'pavilion 400', '2029-07-20 00:00:00', 1, 1, 'a2045389c'),
	('B30250', 'Dell', 'Optiples380 gx', '2022-03-04 09:13:04', 1, 3, 'DM202L'),
	('B30251', 'Hp', 'pavilion x10', '2020-05-04 09:14:22', 1, 3, 'HU265BM14V'),
	('B30252', 'Dell', 'Optiplex 380', '2019-03-04 09:16:06', 1, 3, 'DN302K'),
	('B30253', 'Dell', 'Optiplex', '2020-01-04 09:16:49', 1, 3, 'ZW981M'),
	('B30254', 'Dell', 'Optiplex', '2020-03-04 09:17:19', 1, 3, 'KH201N'),
	('B30255', 'HP', 'xfera 3010', '2020-03-25 00:00:00', 1, 3, 'HU265BM13V'),
	('B30256', 'Lenovo', 'idea 3100', '2021-05-13 00:00:00', 2, 3, 'LN4001Z'),
	('B30257', 'Lenovo', 'idea x2010', '2019-12-10 00:00:00', 2, 3, 'LN4002R'),
	('B30258', 'Canon', 'wi500', '2020-08-20 00:00:00', 3, 3, 'CA20102'),
	('B30259', 'lexkmark', 'x711', '2022-10-14 00:00:00', 4, 3, 'LE20310'),
	('C10201', 'HP', '3005', '2021-10-15 00:00:00', 3, 2, 'HU265BM12V'),
	('C10202', 'Ricoh', '5430', '2018-05-14 00:00:00', 3, 2, 'LE20201'),
	('C10203', 'HP', 'W500', '2021-08-11 00:00:00', 4, 2, 'HU265BM17D'),
	('C10204', 'HP', 'w500', '2022-03-12 00:00:00', 4, 2, 'HU265BM11V'),
	('C10205', 'Samsung', 's4900032f', '2018-10-09 00:00:00', 5, 2, 'LE20301'),
	('C20201', 'Dell', 'Latitud e5430', '2019-07-22 00:00:00', 2, 2, 'DE30211'),
	('C20202', 'Lenovo', 'thinkcenter 500', '2021-05-21 00:00:00', 1, 2, 'LN4400T'),
	('C20203', 'Lenovo', 'thinkcenter 400', '2020-08-19 00:00:00', 1, 2, 'LN4500T'),
	('C20204', 'Dell', 'optiplex 960 uff', '2021-07-13 00:00:00', 1, 2, 'TS201N'),
	('C20205', 'HP', 'smart 980', '2020-03-18 00:00:00', 1, 2, 'HU365BM11V'),
	('D40200', 'HP', 'Sf500', '2020-03-26 00:00:00', 1, 4, 'HU465BM11V'),
	('D40201', 'Dell', 'Optiplex 540', '2021-07-24 00:00:00', 1, 4, 'WE201N'),
	('D40202', 'Lenovo', 'thinkcenter 400', '2021-09-18 00:00:00', 1, 4, 'LN3029T'),
	('D40203', 'Lenovo', 'thinkcenter 500', '2020-03-25 00:00:00', 1, 4, 'LN3032C'),
	('D40204', 'Dell', 'Optiplex MT9000', '2020-03-13 00:00:00', 1, 4, 'KH654N'),
	('D40205', 'Samsung', 'GalaxyTab3', '2020-06-20 00:00:00', 2, 4, 'SA4987A'),
	('D40206', 'HP', 'Pavilion m300', '2021-05-22 00:00:00', 2, 4, 'HU565BM11V'),
	('D40207', 'HP', 'Pavilion 5090', '2019-11-11 00:00:00', 2, 4, 'HU665BM11V'),
	('D40208', 'Lexkmark', 'Mx711', '2021-06-19 00:00:00', 4, 4, 'LE4032A'),
	('D40209', 'Lexkmark', 'Mx711', '2021-07-17 00:00:00', 3, 4, 'LE3502A'),
	('D50300', 'HP', 'M500', '2021-06-19 00:00:00', 3, 3, 'HPJ209093V'),
	('D50301', 'Dell', 'OptipleX 380 gx', '2019-11-11 00:00:00', 4, 3, 'AB430WW');
/*!40000 ALTER TABLE `equipo` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.estado
DROP TABLE IF EXISTS `estado`;
CREATE TABLE IF NOT EXISTS `estado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.estado: ~5 rows (aproximadamente)
DELETE FROM `estado`;
/*!40000 ALTER TABLE `estado` DISABLE KEYS */;
INSERT INTO `estado` (`id`, `descripcion`) VALUES
	(1, 'creada'),
	(2, 'asignada'),
	(3, 'en curso'),
	(4, 'finalizada'),
	(5, 'pendiente');
/*!40000 ALTER TABLE `estado` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.estadoconexion
DROP TABLE IF EXISTS `estadoconexion`;
CREATE TABLE IF NOT EXISTS `estadoconexion` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) COLLATE latin1_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.estadoconexion: ~2 rows (aproximadamente)
DELETE FROM `estadoconexion`;
/*!40000 ALTER TABLE `estadoconexion` DISABLE KEYS */;
INSERT INTO `estadoconexion` (`id`, `descripcion`) VALUES
	(1, 'activo'),
	(2, 'inactivo');
/*!40000 ALTER TABLE `estadoconexion` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.estadousuario
DROP TABLE IF EXISTS `estadousuario`;
CREATE TABLE IF NOT EXISTS `estadousuario` (
  `idUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `idConexion` int(11) DEFAULT NULL,
  `fechaUltimaRevision` datetime DEFAULT NULL,
  PRIMARY KEY (`idUsuario`),
  KEY `FK_estadousuario_estadoconexion` (`idConexion`),
  CONSTRAINT `FK_estadousuario_estadoconexion` FOREIGN KEY (`idConexion`) REFERENCES `estadoconexion` (`id`),
  CONSTRAINT `FK_estadousuario_usuario` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`UsuarioID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.estadousuario: ~21 rows (aproximadamente)
DELETE FROM `estadousuario`;
/*!40000 ALTER TABLE `estadousuario` DISABLE KEYS */;
INSERT INTO `estadousuario` (`idUsuario`, `idConexion`, `fechaUltimaRevision`) VALUES
	(5, 1, '2020-06-04 18:41:23'),
	(6, 1, '2020-05-27 10:06:38'),
	(7, 1, '2020-04-11 11:51:03'),
	(8, 1, '2020-06-02 22:33:33'),
	(9, 2, '2020-03-23 10:53:57'),
	(10, 1, '2020-04-26 21:19:34'),
	(11, 1, '2020-06-04 18:44:31'),
	(12, 2, '2020-03-23 10:54:29'),
	(13, 2, '2020-03-23 10:54:39'),
	(14, 2, '2020-03-23 10:54:47'),
	(15, 1, '2020-06-03 18:00:14'),
	(17, 1, '2020-06-03 18:01:40'),
	(18, 2, '2020-03-23 10:55:20'),
	(20, 2, '2020-03-23 10:55:09'),
	(21, 1, '2020-04-26 15:39:35'),
	(22, 1, '2020-04-08 15:45:41'),
	(34, 1, '2020-05-29 21:51:51'),
	(40, 2, '2020-04-15 22:59:59'),
	(45, 2, '2020-04-13 19:53:38'),
	(46, 1, '2020-06-02 22:40:33'),
	(47, 2, '2020-04-13 22:55:47'),
	(68, 2, '2020-05-09 11:55:43'),
	(70, 2, '2020-06-01 12:33:56'),
	(73, 2, '2020-06-01 12:40:01'),
	(74, 2, '2020-06-01 12:40:01');
/*!40000 ALTER TABLE `estadousuario` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.localidad
DROP TABLE IF EXISTS `localidad`;
CREATE TABLE IF NOT EXISTS `localidad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) COLLATE latin1_spanish_ci NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.localidad: ~12 rows (aproximadamente)
DELETE FROM `localidad`;
/*!40000 ALTER TABLE `localidad` DISABLE KEYS */;
INSERT INTO `localidad` (`id`, `nombre`) VALUES
	(4, 'Alcoy'),
	(1, 'Alicante'),
	(12, 'Badajoz'),
	(9, 'Barcelona'),
	(3, 'Benidorm'),
	(6, 'Granada'),
	(10, 'Huelva'),
	(8, 'Madrid'),
	(11, 'Malaga'),
	(2, 'San Juan'),
	(7, 'Toledo'),
	(5, 'Torrevieja');
/*!40000 ALTER TABLE `localidad` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.rol
DROP TABLE IF EXISTS `rol`;
CREATE TABLE IF NOT EXISTS `rol` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(15) COLLATE latin1_spanish_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.rol: ~4 rows (aproximadamente)
DELETE FROM `rol`;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` (`id`, `nombre`) VALUES
	(4, 'Administrador'),
	(1, 'Cliente'),
	(3, 'Gerente'),
	(2, 'Técnico');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.sede
DROP TABLE IF EXISTS `sede`;
CREATE TABLE IF NOT EXISTS `sede` (
  `numOficina` int(11) NOT NULL AUTO_INCREMENT,
  `calle` varchar(90) COLLATE latin1_spanish_ci NOT NULL DEFAULT '0',
  `codigoPostal` varchar(5) COLLATE latin1_spanish_ci NOT NULL DEFAULT '0',
  `planta` tinyint(2) NOT NULL DEFAULT '0',
  `localidad` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`numOficina`),
  KEY `localidad` (`localidad`),
  CONSTRAINT `sede_ibfk_1` FOREIGN KEY (`localidad`) REFERENCES `localidad` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.sede: ~4 rows (aproximadamente)
DELETE FROM `sede`;
/*!40000 ALTER TABLE `sede` DISABLE KEYS */;
INSERT INTO `sede` (`numOficina`, `calle`, `codigoPostal`, `planta`, `localidad`) VALUES
	(1, 'Avenida Oscar Esplá 58', '03006', 25, 1),
	(2, 'Avinguda País Valencià 32', '03642', 1, 4),
	(3, 'Avenida Europa 3', '04356', 7, 3),
	(4, 'Calle Britania 40', '02056', 0, 2),
	(5, 'Avenida del Cid', '04023', 23, 1);
/*!40000 ALTER TABLE `sede` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.tecnico
DROP TABLE IF EXISTS `tecnico`;
CREATE TABLE IF NOT EXISTS `tecnico` (
  `idUsuario` int(11) NOT NULL,
  `idTecnico` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`idUsuario`),
  UNIQUE KEY `idTecnico` (`idTecnico`),
  CONSTRAINT `FK__usuario` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`UsuarioID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=89 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.tecnico: ~11 rows (aproximadamente)
DELETE FROM `tecnico`;
/*!40000 ALTER TABLE `tecnico` DISABLE KEYS */;
INSERT INTO `tecnico` (`idUsuario`, `idTecnico`) VALUES
	(6, 1),
	(10, 2),
	(15, 3),
	(21, 4),
	(22, 5),
	(17, 6),
	(34, 24),
	(45, 26),
	(46, 86),
	(47, 87),
	(40, 88);
/*!40000 ALTER TABLE `tecnico` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.ticket
DROP TABLE IF EXISTS `ticket`;
CREATE TABLE IF NOT EXISTS `ticket` (
  `numTicket` int(11) NOT NULL AUTO_INCREMENT,
  `idEquipo` varchar(50) COLLATE latin1_spanish_ci DEFAULT '',
  `idUsuario` int(11) NOT NULL,
  `fechaEntrada` datetime NOT NULL,
  `fechaResolucion` datetime DEFAULT NULL,
  `descripcion` varchar(200) COLLATE latin1_spanish_ci NOT NULL DEFAULT '',
  `resolucion` varchar(200) COLLATE latin1_spanish_ci DEFAULT '',
  `estado` int(11) DEFAULT '1',
  `categoria` int(11) DEFAULT NULL,
  `tecnicoAsignado` int(11) DEFAULT NULL,
  `notasTecnico` varchar(100) COLLATE latin1_spanish_ci DEFAULT NULL,
  `valoracion` int(11) DEFAULT NULL,
  `textoValoracion` varchar(100) COLLATE latin1_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`numTicket`),
  KEY `FK_ticket_equipo` (`idEquipo`),
  KEY `FK_ticket_usuario` (`idUsuario`),
  KEY `FK_ticket_estado` (`estado`),
  KEY `FK_ticket_tecnico` (`tecnicoAsignado`),
  KEY `FK_ticket_tipo` (`categoria`),
  CONSTRAINT `FK_ticket_equipo` FOREIGN KEY (`idEquipo`) REFERENCES `equipo` (`serviceTag`) ON UPDATE CASCADE,
  CONSTRAINT `FK_ticket_estado` FOREIGN KEY (`estado`) REFERENCES `estado` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `FK_ticket_tecnico` FOREIGN KEY (`tecnicoAsignado`) REFERENCES `tecnico` (`idTecnico`) ON UPDATE CASCADE,
  CONSTRAINT `FK_ticket_tipo` FOREIGN KEY (`categoria`) REFERENCES `tipo` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `FK_ticket_usuario` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`UsuarioID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=137 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.ticket: ~128 rows (aproximadamente)
DELETE FROM `ticket`;
/*!40000 ALTER TABLE `ticket` DISABLE KEYS */;
INSERT INTO `ticket` (`numTicket`, `idEquipo`, `idUsuario`, `fechaEntrada`, `fechaResolucion`, `descripcion`, `resolucion`, `estado`, `categoria`, `tecnicoAsignado`, `notasTecnico`, `valoracion`, `textoValoracion`) VALUES
	(1, 'B30252', 15, '2020-03-15 13:01:56', '2020-03-20 21:04:06', 'FALLA EL RATÓN', 'Cambio de ratón, pruebas ok.', 4, NULL, NULL, 'Pendiente recibir material.', 1, 'ok'),
	(2, 'B30252', 7, '2020-03-16 20:38:02', '2020-03-20 21:04:07', 'falla el teclado', 'Reincio del pc.', 4, NULL, NULL, NULL, 5, 'Excelente asistencia, muchas gracias.'),
	(4, 'C20201', 7, '2020-03-17 14:55:33', '2020-03-20 21:04:08', 'No puedo conectarme a internet', 'Reinicio del pc.', 4, NULL, NULL, NULL, 1, ''),
	(6, 'C20204', 7, '2020-03-18 15:52:28', '2020-03-20 21:04:09', 'La batería no carga', 'Cambio de batería.', 4, NULL, NULL, 'Pendiente recibir batería.', 2, 'El técnico ha sido muy lento'),
	(8, 'A20200', 7, '2020-03-17 16:04:38', '2020-03-20 21:04:10', 'Monitor se ve mal.', 'Cambio de cable dvi.', 4, NULL, NULL, 'Visita acordada lunes a primera hora.', 1, ''),
	(9, 'C20204', 7, '2020-03-17 16:33:08', '2020-03-20 21:03:41', 'Sistema va muy lento.', 'Cambio de teclado', 4, NULL, NULL, NULL, 1, 'Fue Julio, lo dejó todo roto.'),
	(10, 'D40204', 7, '2020-03-17 19:14:59', '2020-03-19 21:03:43', 'No se oyen los auriculares', 'Revisión de conector', 4, NULL, NULL, 'Hora prevista de asistencia 10:30h', 1, ''),
	(11, 'D40204', 7, '2020-03-18 12:00:00', '2020-03-19 21:03:44', 'Teclado sin pilas.', 'Cambio de pilas,pruebas ok.', 4, NULL, NULL, NULL, 5, ''),
	(12, 'B30254', 7, '2020-03-18 12:07:35', '2020-03-19 21:03:45', 'El ordenador se reincia constantemente.', 'Revisión de memoría ram.', 4, NULL, NULL, NULL, 1, 'Tras el cambio de disco duro funciona ok.'),
	(14, 'B30252', 7, '2020-03-18 12:19:20', '2020-03-19 21:03:45', 'He perdido el cargador', 'Cambio de cargador.', 4, NULL, NULL, NULL, NULL, NULL),
	(15, 'B30253', 7, '2020-03-18 12:22:56', '2020-03-19 21:03:46', 'La impresora mancha las hojas.', 'Revisión del fotoconductor.', 4, NULL, NULL, NULL, NULL, NULL),
	(16, 'A40204', 7, '2020-03-18 12:28:15', '2020-03-20 21:03:47', 'El escáner atasca los documentos.', 'Limpieza de rodillos pickup.', 4, NULL, NULL, NULL, 1, ''),
	(17, 'B30253', 7, '2020-03-18 13:03:50', '2020-03-20 21:03:47', 'El ordenador se bloquea y reinicia sólo', 'Cambio de placa base, pruebas ok.', 4, NULL, NULL, NULL, 1, ''),
	(18, 'B30254', 7, '2020-03-18 13:12:04', '2020-03-18 21:03:48', 'Pantalla rota.', 'Cambio de pantalla.', 4, NULL, NULL, NULL, 5, 'excelente!'),
	(19, 'B30250', 7, '2020-03-18 13:22:08', '2020-03-18 21:03:49', 'No puedo abrir documentos excel.', 'Borramos perfil de usuario.', 4, NULL, NULL, NULL, NULL, NULL),
	(20, 'B30254', 7, '2020-03-18 13:25:42', '2020-03-20 21:03:49', 'No funciona el wifi .', 'Reseteamos el router inalámbrico.', 4, NULL, NULL, NULL, 1, ''),
	(21, 'B30253', 7, '2020-03-18 13:29:07', '2020-03-20 21:03:52', 'El ratón se mueve erraticamente por el escritorio.', 'Cambio de ratón', 4, NULL, NULL, NULL, 1, ''),
	(22, 'C20204', 7, '2020-03-18 13:32:42', '2020-03-19 21:03:51', 'Impresora hace ruido.', 'Cambio de fusor. Pruebas ok', 4, NULL, NULL, NULL, 1, ''),
	(23, 'B30254', 7, '2020-03-18 13:44:06', '2020-03-20 21:03:52', 'El ordenador va lento.', 'Reinstalamos sistema operativo.', 4, NULL, NULL, NULL, 2, ''),
	(24, 'A40204', 7, '2020-03-18 15:09:08', '2020-03-20 21:03:53', 'El ordenador no enciende', 'Cambio de fuente de alimentación.', 4, NULL, NULL, NULL, 2, ''),
	(25, 'D40200', 7, '2020-03-18 15:19:04', '2020-03-20 21:03:54', 'Falla el cargador.', 'Revisión del punto de luz.', 4, NULL, NULL, NULL, 3, ''),
	(26, 'A40206', 7, '2020-03-18 15:23:57', '2020-03-20 21:03:55', 'No va el teléfono ip', 'Configuración de centralita.', 4, NULL, NULL, NULL, 1, ''),
	(27, 'D40206', 7, '2020-03-18 15:29:59', '2020-03-20 21:03:56', 'Falta un teclado de viaje para mi tablet.', 'Instalación de teclado de viaje.', 4, NULL, 5, NULL, 1, ''),
	(28, 'D40207', 7, '2020-03-18 15:42:34', '2020-03-20 21:03:56', 'Pc huele a quemado.', 'Cambio de fuente de alimentación.', 4, NULL, 3, NULL, 3, ''),
	(29, 'D40207', 7, '2020-03-18 15:57:41', '2020-03-20 21:03:57', 'Se ha caido una tecla del teclado.', 'Cambio de teclado.', 4, NULL, 4, NULL, 2, ''),
	(30, 'D40207', 7, '2020-03-18 17:01:22', '2020-03-20 21:03:58', 'El sonido no se oye.', 'Conectamos cable jack.', 4, NULL, 2, NULL, 5, ''),
	(31, 'B30253', 7, '2020-03-18 17:17:32', '2020-03-20 21:03:58', 'Se ve mal la pantalla.', 'Ajustamos cable dvi.', 4, NULL, 1, NULL, 2, ''),
	(32, 'B30252', 7, '2020-03-18 18:40:00', '2020-03-20 21:04:02', 'el auricular se escucha mal.', 'Cambio de auricular', 4, NULL, 2, NULL, 3, ''),
	(33, 'B30254', 7, '2020-03-18 22:41:27', '2020-03-20 21:04:01', 'No puedo seleccionar impresora.', 'Reinstalamos impresora.', 4, NULL, 5, NULL, 3, 'El ratón nuevo no funciona muy bien.'),
	(34, NULL, 7, '2020-03-18 23:13:45', '2020-03-20 21:04:02', 'El botón derecho del ratón no funciona.', 'Cambio de ratón.', 4, NULL, 4, '', 1, 'El servicio ha sido rápido y eficiente.'),
	(35, 'B30254', 7, '2020-03-19 12:47:39', '2020-03-20 21:04:03', 'La impresora saca el papel arrugado.', 'Engrasamos fusor.', 4, NULL, 3, NULL, 5, ''),
	(38, 'B30252', 7, '2020-03-19 18:58:44', '2020-03-20 21:04:04', 'Problemas de conexión a internet.', 'Reinstalamos driver de forma remota.', 4, NULL, 4, NULL, 1, ''),
	(39, 'B30252', 7, '2020-03-19 19:29:09', '2020-03-20 21:04:05', 'El equipo no responde', 'Cambio de placa base.', 4, NULL, 4, '', NULL, ''),
	(40, 'A40204', 7, '2020-03-19 20:51:24', '2020-03-20 21:04:05', 'La impresora huele a quemado.', 'Cambio de fuente de alta tensión.', 4, NULL, 1, '', NULL, ''),
	(41, 'A40204', 11, '2020-03-20 19:58:58', '2020-03-30 16:52:09', 'No me llegan notificaciones de los e-mails.', 'Activamos el sonido de Windows.', 4, NULL, 2, NULL, NULL, NULL),
	(42, 'D40206', 12, '2020-03-20 20:10:22', '2020-04-01 20:25:04', 'El altavoz izquierdo no funciona.', 'Sustituimos altavoz.', 4, NULL, 1, NULL, NULL, NULL),
	(43, 'B30253', 7, '2020-03-21 12:28:46', '2020-03-21 13:17:33', 'No funciona el mando del televisor de la sala de reuniones.', 'Cambio de pilas.', 4, NULL, 1, NULL, NULL, NULL),
	(44, 'B30252', 5, '2020-03-22 22:42:41', '2020-04-01 20:26:13', 'ordenador atascado', 'Los ordenadores no se atascan.', 4, NULL, 5, NULL, 1, 'Por fin tengo arreglado el problema, gracias.'),
	(45, 'A20201', 5, '2020-03-22 22:52:03', '2020-03-23 10:25:20', 'teclado roto9', 'Reiniciamos pc.', 4, NULL, 4, NULL, 3, ''),
	(46, 'B30254', 5, '2020-03-24 23:29:16', '2020-03-25 19:54:10', 'No me funciona el word, no se abren los documentos.', 'Eliminamos perfil de usuario Windows.', 4, NULL, 1, NULL, 5, 'Una asistencia genial.'),
	(47, 'B30254', 5, '2020-03-25 17:21:11', '2020-03-25 19:54:12', 'El ordenador se queda bloquedo cada dos por tres.', 'Reinstalamos sistema operativo.', 4, NULL, 2, NULL, 1, 'Me sigue sin funcionar.'),
	(48, 'B30254', 5, '2020-03-25 17:34:45', '2020-03-25 19:54:09', 'Ordenador obsoleto, va muy lento ', 'Ampliamos memoria ram.', 4, NULL, 3, NULL, 3, 'Servicio muy lento'),
	(49, 'B30254', 5, '2020-03-25 20:01:35', '2020-03-26 19:54:08', 'El sistema de sonido de la sal de reuniones no funciona.', 'Conectamos conector de altavoz a torrre.', 4, NULL, 4, NULL, NULL, NULL),
	(50, NULL, 5, '2020-03-29 10:00:00', NULL, 'El teclado tiene rota la tecla del 8. Solicitamos cambio urgente.', 'Revisión del teclado.', 4, NULL, 5, 'Pendiente servicio técnico', NULL, ''),
	(51, NULL, 5, '2020-03-29 10:00:10', '2020-05-25 12:15:33', 'El teclado tiene rota la tecla del 8. Solicitamos cambio urgente.', 'Cambio de telcado.', 4, 1, 6, 'Pendiente servicio técnico, equipo en garantía.', NULL, ''),
	(52, NULL, 5, '2020-03-29 10:00:31', '2020-03-30 17:03:28', 'El teclado tiene rota la tecla del 8. Solicitamos cambio urgente.', 'Cambio de teclado.', 4, NULL, 4, '', NULL, ''),
	(53, 'B30254', 5, '2020-03-29 10:23:37', '2020-03-30 17:00:31', 'La impresora saca hojas en blanco.', 'Cambio de rodillos pickup por parte del  servicio técnico, pruebas ok.', 4, NULL, 4, 'Equipo en garantía, esperando a servicio técnico.', 2, 'La impresora no funciona bien del todo.'),
	(54, NULL, 5, '2020-03-29 10:59:05', '2020-03-30 16:42:25', 'El ordenador hace ruido y huele a quemado.', 'Cambio de fuente de alimentación.', 4, NULL, 3, 'Pendiente recibir fuente de alimentación.', NULL, ''),
	(55, 'B30254', 5, '2020-03-30 17:58:16', '2020-03-30 18:22:33', 'No funciona un puerto usb y no puedo conectar nada.', 'Cambio de placa base, pruebas ok.', 4, NULL, 1, NULL, 1, 'Excelente! el técnico ha sido muy rápido, muchas gracias!'),
	(56, 'B30254', 5, '2020-03-30 18:12:53', '2020-03-30 19:10:23', 'Cuando abro el internet explorer sale un error.', 'Reinstalamos sistema operativo, pruebas ok.', 4, NULL, 1, 'Técnico de baja, ', NULL, ''),
	(57, 'B30254', 5, '2020-03-30 19:00:19', '2020-03-30 19:10:44', 'Muestra una pantalla azul al iniciar, no funciona nada, es urgente.', 'Cambio de memoria ram, pruebas ok.', 4, NULL, 2, 'Incidencia gestionada por servicio técnico.', NULL, ''),
	(58, 'A20200', 5, '2020-03-31 22:51:30', '2020-03-31 22:57:17', 'La batería me dura una hora.', 'Cambio de batería, pruebas ok.', 4, NULL, 2, NULL, 5, 'Con la batería nueva, me durá tres horas! estupendo!!'),
	(59, 'B30254', 5, '2020-04-01 20:31:18', '2020-04-02 10:07:48', 'He perdido el cargador del portátil, solicito uno.', 'Entregamos cargador nuevo a usuario, gestionamos facturación.', 4, NULL, 4, '', NULL, ''),
	(60, 'A40205', 5, '2020-04-01 22:10:13', '2020-04-02 10:07:06', 'El ordenador a veces cuando escribo se borra lo que hay delante.', 'Dar formación a usuario, al pulsar insert se soluciona el problema.', 4, NULL, 2, 'Pendiente contactar con  usuario, posible problema de mala praxis', NULL, ''),
	(61, 'B30254', 5, '2020-04-02 12:21:00', '2020-04-02 12:49:08', 'No abre el gestor de inventario, no puedo trabajar.', 'Recargamos políticas remotamente, el  software ya funciona.', 4, NULL, 4, '', 4, 'Todo perfecto.'),
	(62, 'B30254', 5, '2020-04-02 13:41:48', '2020-04-02 13:55:44', 'El ordenador se bloquea y tarda mucho en reaccionar, solicitamos revisión.', 'Cambio de disco duro, hacemos backup de información e instalamos disco SSD para mejorar rendimiento, pruebas ok todo ok.', 4, NULL, 4, NULL, 2, 'El técnico tardó mucho en llegar y no ha resuelto la avería, sigue fallando.'),
	(63, 'B30254', 5, '2020-04-02 16:54:36', '2020-04-03 15:42:12', 'El portátil hace mucho ruido.', 'Añadimos pasta térmica al procesador y limpiamos ventilador.', 4, NULL, 4, '', 2, 'Sigue haciendo mucho ruido, ordenador obsoleto.'),
	(64, 'B30252', 7, '2020-04-06 22:48:22', '2020-04-22 13:33:29', 'hace ruido', 'Cambio de ventilador. pruebas ok.', 4, NULL, 3, 'Pendiente garantía', 2, 'Sigue haciendo mucho ruido, parece que en cualquier momento se va a romper.'),
	(65, 'C10202', 17, '2020-04-07 09:25:25', '2020-04-08 15:47:41', 'La impresora deja manchas de tinta e el papel. Solicitamos revisión.', 'Cambio de tóner, pruebas ok todo ok.', 4, NULL, 2, NULL, 0, NULL),
	(66, NULL, 11, '2020-04-08 15:50:20', '2020-04-12 16:14:01', 'El equipo me va muy lento, solicito revisión, tarda más de 10 minutos en iniciar.', 'Se acuerda con usuario cambio de equipo.', 4, 2, 6, '', 5, 'Genial!'),
	(67, 'A40207', 7, '2020-04-08 16:00:33', '2020-04-11 11:45:14', 'No funciona el táctil de mi tablet', 'Cambio de lcd, pruebas ok.', 4, 3, 1, NULL, 1, 'Ahora va muy bien!!!'),
	(68, 'B30253', 17, '2020-04-11 16:07:39', '2020-04-12 16:26:10', 'El ordenador hace tiempo que va muy muy lento.', 'Ampliación de memoria, pruebas ok.', 4, 1, 6, 'Solicitamos ampliación de memoría ram. Pendiente autorización del departamento.', 0, NULL),
	(70, 'B30254', 17, '2020-04-11 16:08:48', '2020-04-12 18:51:51', 'No se escuchan los auriculares, el usuario es Antonio Resines, el equipo no está catalogado, poner etiqueta.', 'Generamos etiqueta y revisamos cableado, pruebas ok.', 4, 1, 1, '', 0, NULL),
	(71, 'B30252', 17, '2020-04-11 20:33:57', '2020-04-12 16:05:08', 'Falla el teclado, solicitamos cambio', 'Reinicio remoto soluciona problema.', 4, 1, 6, '', 0, NULL),
	(72, 'B30253', 5, '2020-04-12 16:41:25', '2020-04-12 17:25:14', 'El ratón no funciona', 'Cambio de ratón, pruebas ok', 4, 1, 3, 'El ratón necesita ser sustituido y no hay en stock. Se ha procedido a solicitar uno nuevo.', 5, ''),
	(73, 'B30254', 5, '2020-04-12 18:05:26', '2020-04-12 20:14:07', 'El ordenador no enciende, es urgente.', 'El ordenador va bien', 4, 1, 1, '', 1, ''),
	(74, 'C10202', 8, '2020-04-12 18:46:33', '2020-04-12 20:38:16', 'La impresora  saca las hojas arrugadas.', 'Sustituimos impresora por otra nueva.', 4, 3, 6, 'Pendiente recibir fusor para cambio.', 2, 'La impresora nueva va muy lento.'),
	(75, 'B30252', 5, '2020-04-12 20:56:37', '2020-04-13 23:03:09', 'No puedo unirme a las links, hay algún tipo de problema, el programa se cierra', 'Reinstalamos microsoft link, pruebas ok todo ok.', 4, 6, 4, NULL, 5, ''),
	(76, 'B30254', 5, '2020-04-13 23:26:45', '2020-04-16 12:07:22', 'El ordenador hace mucho ruido.', 'Cambio de ventilador, pruebas ok.', 4, 1, 4, NULL, 1, ''),
	(77, NULL, 5, '2020-04-15 23:31:05', '2020-04-22 13:35:59', 'No puedo abrir el navegador, me sale un pantallazo azul.', 'Reinstalmaos máquina virtual.', 4, 1, 6, '', NULL, ''),
	(78, 'B30251', 8, '2020-04-15 23:33:14', '2020-04-22 12:56:07', 'El ordenador va muy lento, solicitamos revisión.', 'Cambiamos disco duro, por disco de estado sólido.', 4, 1, 1, NULL, 3, ''),
	(80, 'C10202', 17, '2020-04-22 11:57:15', '2020-04-22 13:22:03', 'Se requiere instalar equipo nuevo en oficina, el usuario es Andrea Botero Rigoberto', 'Pc instaldo con éxito.', 4, 1, 1, NULL, 0, NULL),
	(81, 'C10203', 17, '2020-04-22 12:28:43', '2020-04-22 13:19:31', 'Revisión de impresora, hace ruido. ', 'Cambio de engranajes del fusor, pruebas ok.', 4, 3, 86, 'Pendiente Recibir fusor.', 0, NULL),
	(82, 'C20201', 8, '2020-04-22 12:39:30', '2020-04-22 12:57:46', 'Necesito unos auriculares para las links. Solicito envío.', 'Envío de auriculares a usuario por valija.', 4, 2, 1, '', 1, ''),
	(83, 'A20201', 20, '2020-04-22 12:41:23', '2020-04-26 15:00:23', 'Neciso revisión de mi ordenador, va fatal.', 'Reinstalamos sistema operativo, pruebas ok.', 4, 1, 4, NULL, NULL, NULL),
	(84, 'A20200', 11, '2020-04-22 12:43:13', '2020-04-26 16:02:24', 'Algunas teclas del teclado no me funcionan nada bien, solicito cambio.', 'Cambio de teclado, pruebas ok todo ok.', 4, 1, 3, '', NULL, ''),
	(85, NULL, 5, '2020-04-22 12:44:20', '2020-04-22 13:34:57', 'La impresora imprime el papel arrugado a veces se atasca.', 'Se gestionará cambio de impresora', 4, 4, 6, '', NULL, ''),
	(86, 'D40204', 8, '2020-04-26 16:08:08', '2020-04-26 20:47:03', 'Cuando hago fotocopias salen dos líneas vertícales en las hojas. Solicito cambio.', 'Limpieza del cristal, pruebas ok.', 4, 4, 86, NULL, NULL, NULL),
	(87, 'd40205', 8, '2020-04-26 16:08:51', '2020-04-26 21:17:35', 'La tablet se me ha caido y tiene rota la pantalla.', 'Cambio de pantalla pruebas ok.', 4, 2, 1, NULL, NULL, NULL),
	(88, 'D40200', 20, '2020-04-26 16:14:42', '2020-05-07 17:15:39', 'La impresora del despacho arruga las hojoas, solicito revisión.', 'Reemplazaremos por impresora de préstamos hasta disponibilidad de fusor.', 4, 3, 6, '', NULL, NULL),
	(89, 'A20203', 20, '2020-04-26 16:15:02', '2020-05-07 17:27:00', 'Mis auriculares no funcionan bien, solicito sustitución.', 'Cambio de auriculares, pruebas ok', 4, 2, 6, 'Pendiente recibir auriculares.', NULL, ''),
	(90, 'C10202', 12, '2020-04-26 16:16:08', '2020-04-26 21:31:02', 'No podemos acceder a los documentos del servidor, necesitamos reparación urgente.', 'Revisamos políticas del usuario, pruebas ok.', 4, 6, 6, '', NULL, NULL),
	(91, 'B30250', 12, '2020-04-26 16:16:48', '2020-04-26 21:20:25', 'Se han roto algunas teclas del portátil, no puedo trabjar.', 'Cambio de teclado pruebas ok.', 4, 2, 2, NULL, NULL, NULL),
	(92, 'A40204', 13, '2020-04-26 16:20:49', '2020-04-26 21:17:12', 'El ordenador va muy lento y a aveces se apaga solo.', 'Ampliación de memoría ram, pruebas ok.', 4, 1, 1, NULL, NULL, NULL),
	(93, 'A20201', 13, '2020-04-26 16:21:20', '2020-04-26 21:16:35', 'Necesitamos la instalación de un equipo en la oficina para un compañero nuevo.', 'Petición a gerencia de equipo nuevo.', 4, 1, 1, '', NULL, ''),
	(94, 'D40200', 8, '2020-04-26 17:02:32', '2020-04-26 21:14:53', 'La tele de la sala de conferencias no enciende', 'Revisión del cableado, pruebas ok.', 4, 5, 1, NULL, NULL, NULL),
	(95, 'D40200', 8, '2020-04-26 17:04:45', '2020-04-26 21:15:49', 'Los altavoces fallan', 'Sustitución de altavoces.', 4, 1, 1, NULL, NULL, NULL),
	(96, 'A20200', 8, '2020-04-26 19:22:39', '2020-04-26 21:15:23', 'Prueba técnico 24, usuario 34', 'Prueba satisfactoria.', 4, 1, 1, NULL, NULL, NULL),
	(97, 'A20201', 8, '2020-04-26 20:14:09', '2020-04-26 20:47:59', 'Fallo de sonido, prueba técnico 34-24', 'Reinstalamos driver, pruebas ok.', 4, 1, 24, NULL, NULL, NULL),
	(98, NULL, 8, '2020-04-26 21:38:25', NULL, 'La batería del portátil dura muy poco', 'Envíamos batería a usuario.', 4, 2, 6, '', NULL, ''),
	(99, 'C10202', 5, '2020-04-26 21:39:52', '2020-05-07 17:18:48', 'La impresora no funciona bien', 'Error de software de usuario, solucionado remotamente.', 4, 3, 6, '', NULL, NULL),
	(100, NULL, 5, '2020-04-26 21:40:11', '2020-05-07 17:18:09', 'Necesito una mochila para mi portátil', 'Comprar y pasar como gasto.', 4, 2, 6, '', 3, 'No estamos contento con la reparación realizada.'),
	(101, 'A20202', 12, '2020-04-26 21:41:52', '2020-05-07 17:17:39', 'El explorador de windows no funciona bien.', 'Reinstalación remota de explorer', 4, 6, 6, '', NULL, NULL),
	(102, 'B30254', 5, '2020-05-08 19:21:42', '2020-05-09 12:54:07', 'El navegador no abre ninguna ventana.', 'Reinstalamos internet explorer de forma remota.', 4, 1, 6, '', NULL, NULL),
	(103, 'B30254', 5, '2020-05-25 11:09:23', '2020-05-25 11:11:47', 'El equipo funciona lento, solicitamos revisión.', 'Cambio de disco duro, pruebas ok.', 4, 1, 3, NULL, 1, ''),
	(104, 'B30253', 5, '2020-05-25 19:37:16', '2020-05-27 16:36:10', 'Necesito un cargador para el portátil', 'Habilitamos cargador al portátil.', 4, 2, 3, NULL, 3, 'El cargador que me han entregado, no funciona.'),
	(105, 'D40209', 5, '2020-05-26 12:07:34', '2020-05-27 16:21:47', 'La impresora láser del despacho no funciona bien.', 'Revisión de fusor, pruebas ok.', 4, 4, 24, '', 1, 'Muy buen servicio'),
	(106, 'C10204', 8, '2020-05-26 12:41:53', '2020-05-27 10:06:30', 'El teclado no funciona correctamente.', 'Cambio de teclado, pruebas ok todo ok.', 4, 2, 1, NULL, NULL, NULL),
	(107, 'B30253', 5, '2020-05-29 10:48:42', '2020-05-29 11:30:02', 'El ordenador hace mucho ruido.', 'Cambio de ventilador del procesador, pruebas ok.', 4, 1, 3, NULL, 5, 'Excelente reparación, el ordenador parece como nuevo.'),
	(108, 'D40202', 5, '2020-05-29 13:11:45', '2020-05-29 21:52:10', 'prueba', 'ASFDS', 4, 1, 24, '', 1, ''),
	(109, 'D40205', 5, '2020-05-29 13:15:18', '2020-05-29 21:51:54', 'prueba2', 'DSAF', 4, 1, 24, '', 5, ''),
	(110, 'D40204', 5, '2020-05-29 13:15:50', '2020-05-29 21:51:23', 'prueba3', 'TODO OK', 4, 6, 24, '', 1, ''),
	(111, 'D40202', 5, '2020-05-29 14:02:38', '2020-05-29 21:50:44', 'prueba4', 'TODO OK', 4, 1, 24, '', 1, ''),
	(112, 'D40201', 5, '2020-05-29 14:02:57', '2020-05-29 21:50:09', 'prueba5', 'Todo ok.', 4, 1, 24, '', 1, ''),
	(113, 'B30254', 17, '2020-05-31 19:26:49', '2020-06-01 20:21:12', 'Cambio de pc requerido', 'cambio de pc.', 4, 4, 6, '', 0, NULL),
	(114, 'B30253', 11, '2020-05-31 20:01:03', '2020-05-31 20:06:21', 'El tecaldo no me funciona bien', 'Cambio de teclado, pruebas ok.', 4, 1, 3, NULL, 3, 'El técnico ha sido muy eficiente'),
	(115, 'B30253', 11, '2020-05-31 21:38:42', '2020-05-31 21:40:16', 'El teclado no funciona correctamente.', 'Le mandaremos un teclado el lunes.', 4, 1, 6, '', 2, 'No me gusta nada el teclado nuevo.'),
	(116, 'B30251', 11, '2020-05-31 23:29:31', '2020-06-01 20:20:24', 'Los altavoces del equipo funcionan mal.', 'REvisión de altavoces. pruebas ok.', 4, 2, 6, '', 1, ''),
	(117, 'B30252', 11, '2020-05-31 23:32:37', '2020-05-31 23:41:18', 'La impresora se queda atascada', 'Cambio de tóner.', 4, 4, 3, NULL, 1, ''),
	(118, 'B30253', 11, '2020-06-01 15:39:21', '2020-06-01 16:10:31', 'Necesito un cargador para mi Laptop', 'Instalamos cargador al usario.', 4, 1, 3, '', 3, 'El cargador no funciona bien del todo.'),
	(119, 'C10203', 5, '2020-06-01 15:45:09', '2020-06-01 20:18:53', 'El ordenador va muy lento y no abre documentos pdf. Solicito revisión.', 'Cambio de memoria ram, pruebas ok.', 4, 1, 6, '', 1, 'Excelente!'),
	(120, NULL, 8, '2020-06-01 15:46:10', '2020-06-01 20:05:57', 'Se me ha roto la pantalla de mi tablet, solicito cambio o reparación de la misma.', 'Recibirá una nueva tablet en los próximos días.', 4, 1, 6, '', NULL, ''),
	(121, NULL, 17, '2020-06-01 20:03:40', '2020-06-01 20:19:48', 'Se requiere cambio de altavoz.', 'cambio de altavoz.', 4, 1, 6, '', 0, NULL),
	(122, 'B30254', 5, '2020-06-02 19:54:05', '2020-06-02 23:20:27', 'El teclado no funciona', 'Cambio de teclado, pruebas ok.', 4, 1, 3, NULL, 1, ''),
	(123, 'B30251', 11, '2020-06-02 22:32:05', '2020-06-02 23:26:34', 'La impresora atasca constantemente.', 'Cambio de fusor, pruebas ok.', 4, 4, 3, NULL, NULL, NULL),
	(124, 'C20201', 8, '2020-06-02 22:33:26', '2020-06-02 23:28:03', 'El ordenador no enciende, necesito ayuda urgente!!', 'Cambio de memoria ram, pruebas ok.', 4, 1, 6, '', NULL, NULL),
	(125, 'C20202', 5, '2020-06-02 22:35:55', '2020-06-02 23:27:39', 'El portátil hace mucho ruido, no se puede trabajar así.', 'Revisión de ventilador, pruebas ok.', 4, 4, 6, '', 1, ''),
	(126, NULL, 5, '2020-06-02 23:47:51', '2020-06-03 22:56:41', 'el equipo no enciende', 'Cambio de fuente de alimentación, pruebas ok.', 4, 1, 6, '', NULL, ''),
	(127, 'C20203', 17, '2020-06-03 12:07:08', '2020-06-03 17:59:51', 'El altavoz derecho de mi portátil no se escucha bien.', 'CAmbio de altavoz.', 4, 1, 3, NULL, 0, NULL),
	(128, 'D50301', 5, '2020-06-03 12:42:01', '2020-06-03 22:55:42', 'No abre el explorador y se bloquea.', 'Instalación remota de internet explorer, pruebas ok.', 4, 6, 6, '', 1, ''),
	(129, 'A40204', 8, '2020-06-03 12:42:50', '2020-06-03 22:55:09', 'La impresora hace mucho ruido, parece que en cualquier momento vaya a romperse.', 'Cambio de engranajes del fusor, pruebas ok.', 4, 4, 6, '', NULL, NULL),
	(130, 'C20204', 11, '2020-06-03 12:43:53', '2020-06-03 22:54:34', 'He perdido el cargador de la tablet.', 'Instalamos cargador, pruebas ok.', 4, 2, 6, '', 1, ''),
	(131, 'A40205', 73, '2020-06-03 12:49:28', '2020-06-03 22:54:04', 'La destructora de papel no enciende.', 'Revisión del motor, pruebas ok.', 4, 5, 6, '', NULL, NULL),
	(132, 'A20201', 5, '2020-06-04 18:43:27', NULL, 'Fallan arias telas del telado, solicito ambio.', '', 3, NULL, 3, '', NULL, ''),
	(133, 'C20201', 11, '2020-06-04 18:51:12', NULL, 'El portátil se caliente mucho y va muy lento.', NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(134, 'A20200', 68, '2020-06-04 18:52:14', NULL, 'La impresora imprime borroso, puede venir alguien a revisarla?', NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(135, 'B30258', 70, '2020-06-04 18:53:11', NULL, 'He perdido el cargador de la tablet, como puedo conseguir otro?', NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(136, 'D50301', 73, '2020-06-04 18:54:14', NULL, 'El proyector se apaga de vez en cuando, necesitamos que lo revisen.', NULL, 2, NULL, 3, NULL, NULL, NULL);
/*!40000 ALTER TABLE `ticket` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.ticketencurso
DROP TABLE IF EXISTS `ticketencurso`;
CREATE TABLE IF NOT EXISTS `ticketencurso` (
  `id` int(11) NOT NULL DEFAULT '0',
  `idUsuario` int(11) NOT NULL,
  `idTecnico` int(11) DEFAULT NULL,
  `fechaFinalizacion` datetime DEFAULT NULL,
  `fechaCreacion` datetime DEFAULT NULL,
  `fechaEnCurso` datetime DEFAULT NULL,
  `fechaAsignacion` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_ticketencurso_usuario` (`idUsuario`),
  KEY `FK_ticketencurso_ticket` (`idTecnico`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.ticketencurso: ~14 rows (aproximadamente)
DELETE FROM `ticketencurso`;
/*!40000 ALTER TABLE `ticketencurso` DISABLE KEYS */;
INSERT INTO `ticketencurso` (`id`, `idUsuario`, `idTecnico`, `fechaFinalizacion`, `fechaCreacion`, `fechaEnCurso`, `fechaAsignacion`) VALUES
	(113, 17, 88, '2020-06-01 20:21:12', '2020-05-31 19:26:49', '2020-06-01 20:21:12', '2020-05-31 19:29:58'),
	(120, 8, 86, '2020-06-01 20:05:57', '2020-06-01 15:46:10', '2020-06-01 20:05:57', '2020-06-01 19:17:22'),
	(121, 17, 3, '2020-06-01 20:19:48', '2020-06-01 20:03:40', '2020-06-01 20:19:48', '2020-06-01 20:03:40'),
	(123, 11, 3, '2020-06-02 23:26:34', '2020-06-02 22:32:05', '2020-06-02 23:26:15', '2020-06-02 23:18:43'),
	(124, 8, 1, '2020-06-02 23:28:03', '2020-06-02 22:33:26', '2020-06-02 23:28:03', '2020-06-02 23:27:07'),
	(126, 5, 3, '2020-06-03 22:56:41', '2020-06-02 23:47:51', '2020-06-03 22:56:41', '2020-06-03 10:58:02'),
	(127, 17, 3, '2020-06-03 17:59:51', '2020-06-03 12:07:08', '2020-06-03 12:07:25', '2020-06-03 12:07:08'),
	(129, 8, 24, '2020-06-03 22:55:09', '2020-06-03 12:42:50', '2020-06-03 22:55:09', '2020-06-03 17:39:23'),
	(131, 73, 26, '2020-06-03 22:54:04', '2020-06-03 12:49:28', '2020-06-03 22:54:04', '2020-06-03 22:51:51'),
	(132, 5, 3, NULL, '2020-06-04 18:43:26', '2020-06-04 18:56:50', '2020-06-04 18:56:24'),
	(133, 11, NULL, NULL, '2020-06-04 18:51:12', NULL, NULL),
	(134, 68, NULL, NULL, '2020-06-04 18:52:13', NULL, NULL),
	(135, 70, NULL, NULL, '2020-06-04 18:53:11', NULL, NULL),
	(136, 73, 3, NULL, '2020-06-04 18:54:13', NULL, '2020-06-04 18:55:07');
/*!40000 ALTER TABLE `ticketencurso` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.tipo
DROP TABLE IF EXISTS `tipo`;
CREATE TABLE IF NOT EXISTS `tipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) COLLATE latin1_spanish_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.tipo: ~6 rows (aproximadamente)
DELETE FROM `tipo`;
/*!40000 ALTER TABLE `tipo` DISABLE KEYS */;
INSERT INTO `tipo` (`id`, `nombre`) VALUES
	(3, 'Impresora'),
	(4, 'Multifunción'),
	(1, 'PC'),
	(2, 'Portátil'),
	(6, 'Software'),
	(5, 'TV');
/*!40000 ALTER TABLE `tipo` ENABLE KEYS */;

-- Volcando estructura para tabla incidencias.usuario
DROP TABLE IF EXISTS `usuario`;
CREATE TABLE IF NOT EXISTS `usuario` (
  `UsuarioID` int(11) NOT NULL AUTO_INCREMENT,
  `password` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  `nombre` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  `apellidos` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  `extension` int(11) DEFAULT NULL,
  `mail` varchar(90) COLLATE latin1_spanish_ci DEFAULT NULL,
  `numOficina` int(11) NOT NULL,
  `rolUsuario` int(11) NOT NULL,
  PRIMARY KEY (`UsuarioID`),
  UNIQUE KEY `mail` (`mail`),
  UNIQUE KEY `extension` (`extension`),
  KEY `FK_usuario_sede` (`numOficina`),
  KEY `FK_usuario_rol` (`rolUsuario`),
  CONSTRAINT `FK_usuario_rol` FOREIGN KEY (`rolUsuario`) REFERENCES `rol` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `FK_usuario_sede` FOREIGN KEY (`numOficina`) REFERENCES `sede` (`numOficina`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla incidencias.usuario: ~20 rows (aproximadamente)
DELETE FROM `usuario`;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`UsuarioID`, `password`, `nombre`, `apellidos`, `extension`, `mail`, `numOficina`, `rolUsuario`) VALUES
	(5, 'b59c67bf196a4758191e42f76670ceba', 'Alberto', 'Moreno fernández', 3068, 'alberto.moreno@alitec.es', 1, 1),
	(6, 'b59c67bf196a4758191e42f76670ceba', 'alejandra', 'González López', 3808, 'alejandra.gonzalez@alitec.es', 2, 2),
	(7, 'b59c67bf196a4758191e42f76670ceba', 'Antonio', 'Resines Sanz', 3007, 'antonio.resines@alitec.es', 2, 1),
	(8, 'b59c67bf196a4758191e42f76670ceba', 'Sara', 'Martínez Valero', 3909, 'sara.martinez@alitec.es', 2, 1),
	(9, 'b59c67bf196a4758191e42f76670ceba', 'Juan Ramón', 'Berenguer Hernández', 3010, 'juan.berenguer@alitec.es', 2, 3),
	(10, 'b59c67bf196a4758191e42f76670ceba', 'Luisa', 'Colomer LLorens', 3011, 'luisa.colomer@alitec.es', 1, 2),
	(11, 'b59c67bf196a4758191e42f76670ceba', 'David', 'Sangrá Llopis', 3052, 'david.sangra@alitec.es', 3, 1),
	(12, 'b59c67bf196a4758191e42f76670ceba', 'Monica', 'Sanz Roncero', 3013, 'monica.sanz@alitec.es', 1, 1),
	(13, 'b59c67bf196a4758191e42f76670ceba', 'Fran', 'Vera Torrent', 3014, 'fran.vera@alitec.es', 2, 1),
	(14, 'b59c67bf196a4758191e42f76670ceba', 'Dario', 'Gimenez Pardo', 3015, 'dario.gimenez@alitec.es', 1, 1),
	(15, 'b59c67bf196a4758191e42f76670ceba', 'Juan', 'Perez Martinez', 3009, 'juan.perez@alitec.es', 3, 2),
	(17, 'b59c67bf196a4758191e42f76670ceba', 'Ramón', 'López Lorca', 3005, 'ramon.lopez@alitec.es', 1, 4),
	(18, 'b59c67bf196a4758191e42f76670ceba', 'Antonia', 'Femenia Hernández', 3008, 'antonia.femenia@alitec.es', 3, 3),
	(20, 'b59c67bf196a4758191e42f76670ceba', 'Rafael', 'Sanchis Heredia', 3006, 'rafael.sanchis@alitec.es', 1, 1),
	(21, 'b59c67bf196a4758191e42f76670ceba', 'Dario', 'Hernández Jimenez', 3192, 'dario.hernandez@alitec.es', 1, 2),
	(22, 'b59c67bf196a4758191e42f76670ceba', 'Vanesa', 'Romero Legastro', 3104, 'vanesa.romero@alitec.es', 2, 2),
	(34, 'b59c67bf196a4758191e42f76670ceba', 'Alejandra', 'González López', 3079, 'alejandra.lopez@alitec.es', 1, 2),
	(40, 'b59c67bf196a4758191e42f76670ceba', 'Fran', 'García LLorens', 3088, 'fran.garcia@alitec.es', 1, 2),
	(45, 'b59c67bf196a4758191e42f76670ceba', 'Isabel ', 'Moya Lastre', 3090, 'isabel.moya@alitec.es', 1, 2),
	(46, 'b59c67bf196a4758191e42f76670ceba', 'Andrea', 'Botero Rigoberto', 3060, 'andrea.botero@alitec.es', 2, 2),
	(47, 'b59c67bf196a4758191e42f76670ceba', 'Susana', 'Gómez Muñoz', 3064, 'susana.gomez@alitec.es', 1, 2),
	(68, 'b59c67bf196a4758191e42f76670ceba', 'Andrés', 'Cervantes Hidalgo', 3070, 'andres.cervantes@alitec.es', 4, 1),
	(70, 'b59c67bf196a4758191e42f76670ceba', 'Irene', 'Lucas Silva', 3820, 'irene.lucas@alitec.es', 3, 1),
	(73, 'b59c67bf196a4758191e42f76670ceba', 'Tom', 'Smith Jefferson', 3370, 'tom.smith@alitec.es', 2, 1),
	(74, 'b59c67bf196a4758191e42f76670ceba', 'Ángel', 'Montero Pelayo', 2999, 'angel.montero@alitec.es', 3, 1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;

-- Volcando estructura para disparador incidencias.actualizarTicket
DROP TRIGGER IF EXISTS `actualizarTicket`;
SET @OLDTMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER';
DELIMITER //
CREATE TRIGGER `actualizarTicket` BEFORE UPDATE ON `ticket` FOR EACH ROW BEGIN
/*Cuando un ticket pasa al estado asignado actualizamos la fecha de asignación y el técnico asiganado en ticket de curso*/
    IF (old.estado=1 AND new.estado=2) THEN
    	UPDATE ticketencurso SET idTecnico=new.tecnicoAsignado, fechaAsignacion=now() WHERE id=old.numTicket;
    	
    END IF;


 /*Cuando un ticket pasa al estado enCurso desde asignado actualizamos la fecha en curso de ticket en curso*/   
      IF (old.estado=2 AND new.estado=3 ) THEN
    	UPDATE ticketencurso SET fechaEnCurso=now() WHERE id=old.numTicket;
    	
    END IF;
 
 /*Cuando un ticket está asignado y se lo asignamos a otro técnico, actualizamos la fecha de asignación del ticket en curso*/
     IF (old.estado=2 AND new.estado=2 AND old.tecnicoAsignado<>new.tecnicoAsignado) THEN
    	UPDATE ticketencurso SET idTecnico=new.tecnicoAsignado, fechaAsignacion=now() WHERE id=old.numTicket;
    	
    END IF;
    
/*Cuando un ticket está asignado y lo cerramos(admnistrador) actualizamos la fechaFinalizacion el técnico y la fecha de en Curso.*/
     IF (old.estado=2 AND new.estado=4 ) THEN
    	UPDATE ticketencurso SET fechaFinalizacion=now(),fechaEnCurso=now() WHERE id=old.numTicket;
    	SET new.fechaResolucion=now();
    END IF;   

  
 /*Cuando un ticket pasa al estado finalizada desde encurso actualizamos la fechaDeFinalización.*/  
    IF (old.estado=3 AND new.estado=4 AND old.tecnicoAsignado=new.tecnicoAsignado ) THEN
    	UPDATE ticketencurso SET fechaFinalizacion=now() WHERE id=old.numTicket;
    	SET new.fechaResolucion=now();
    END IF;
  /*Cuando un ticket pasa al estado finalizada desde encurso (administrador) actualizamos la fechaDeFinalización.*/  
    IF (old.estado=3 AND new.estado=4 AND old.tecnicoAsignado<>new.tecnicoAsignado ) THEN
    	UPDATE ticketencurso SET fechaFinalizacion=now(),idTecnico=new.tecnicoAsignado WHERE id=old.numTicket;
    	SET new.fechaResolucion=now();
    END IF;
    
 /*Cuando un ticket pasa al estado ASIGNADA desde encurso (administrador) actualizamos la fechaEnCurso.*/  
    IF (old.estado=3 AND new.estado=2 AND old.tecnicoAsignado<>new.tecnicoAsignado ) THEN
    	UPDATE ticketencurso SET fechaEnCurso=null,idTecnico=new.tecnicoAsignado WHERE id=old.numTicket;
    END IF;
    
 /*Cuando un ticket está pendiente y lo cerramos(admnistrador) cambiando el técnico asignado,actualizamos la fechaFinalizacion, el técnico.*/
     IF (old.estado=5 AND new.estado=4 AND old.tecnicoAsignado<>new.tecnicoAsignado) THEN
    	UPDATE ticketencurso SET idTecnico=new.tecnicoAsignado, fechaFinalizacion=now() WHERE id=old.numTicket;
    	
    END IF;   
    
/*Cuando un ticket está pendiente y lo asignamos(admnistrador) cambiando el técnico asignado,actualizamos la fechaEnCurso a null y el técnico.*/
     IF (old.estado=5 AND new.estado=2 AND old.tecnicoAsignado<>new.tecnicoAsignado) THEN
    	UPDATE ticketencurso SET idTecnico=new.tecnicoAsignado, fechaEnCurso=null,fechaAsignacion=now() WHERE id=old.numTicket;
    	
    END IF;   
    
/*Cuando un ticket pasa al estado enCurso desde pendiente  actualizamos la fecha en curso de un ticket en curso.*/        
    IF (old.estado=5 AND new.estado=3 ) THEN
    	UPDATE ticketencurso SET fechaEnCurso=now() WHERE id=old.numTicket;
    	
    END IF;
/*Cuando un ticket pasa al estado finalizado desde pendiente  actualizamos la fecha de finalización de un ticket en curso.*/        
    IF (old.estado=5 AND new.estado=4 AND old.tecnicoAsignado=new.tecnicoAsignado ) THEN
    	UPDATE ticketencurso SET fechaFinalizacion=now() WHERE id=old.numTicket;
      SET new.fechaResolucion=now();
    END IF;	
/*Cuando un ticket pasa al estado finalizado desde pendiente  actualizamos la fecha de finalización de un ticket en curso.*/        
    IF (old.estado=5 AND new.estado=4 AND old.tecnicoAsignado<>new.tecnicoAsignado) THEN
    	UPDATE ticketencurso SET fechaFinalizacion=now(),fechaEnCurso=now() WHERE id=old.numTicket;
    	SET new.fechaResolucion=now();
    END IF;	
    
END//
DELIMITER ;
SET SQL_MODE=@OLDTMP_SQL_MODE;

-- Volcando estructura para disparador incidencias.crearTecnico
DROP TRIGGER IF EXISTS `crearTecnico`;
SET @OLDTMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER';
DELIMITER //
CREATE TRIGGER `crearTecnico` AFTER UPDATE ON `usuario` FOR EACH ROW BEGIN
  IF new.rolUsuario = 2 and old.rolUsuario<>2
    THEN
      INSERT INTO tecnico (idUsuario) VALUES (new.UsuarioID);
  END IF;
END//
DELIMITER ;
SET SQL_MODE=@OLDTMP_SQL_MODE;

-- Volcando estructura para disparador incidencias.crearUsuarioTecnico
DROP TRIGGER IF EXISTS `crearUsuarioTecnico`;
SET @OLDTMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER';
DELIMITER //
CREATE TRIGGER `crearUsuarioTecnico` AFTER INSERT ON `usuario` FOR EACH ROW BEGIN
  IF new.rolUsuario = 2
    THEN
      INSERT INTO tecnico (idUsuario) VALUES (new.UsuarioID);
  END IF;
END//
DELIMITER ;
SET SQL_MODE=@OLDTMP_SQL_MODE;

-- Volcando estructura para disparador incidencias.inicializarEstadoUsuario
DROP TRIGGER IF EXISTS `inicializarEstadoUsuario`;
SET @OLDTMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER';
DELIMITER //
CREATE TRIGGER `inicializarEstadoUsuario` AFTER INSERT ON `usuario` FOR EACH ROW BEGIN
	INSERT INTO estadousuario VALUES (new.UsuarioID,2,now());
END//
DELIMITER ;
SET SQL_MODE=@OLDTMP_SQL_MODE;

-- Volcando estructura para disparador incidencias.ticketEnCurso
DROP TRIGGER IF EXISTS `ticketEnCurso`;
SET @OLDTMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER';
DELIMITER //
CREATE TRIGGER `ticketEnCurso` AFTER INSERT ON `ticket` FOR EACH ROW BEGIN
		IF (new.Estado=1) THEN 
				INSERT INTO ticketencurso(id,fechaCreacion,idUsuario) VALUES (new.numTicket,NOW(),new.idUsuario);
		ELSE 
			INSERT INTO ticketencurso(id,fechaCreacion,idUsuario,fechaAsignacion,idTecnico) VALUES (new.numTicket,NOW(),new.idUsuario,NOW(),new.tecnicoAsignado);
		END IF;
	
END//
DELIMITER ;
SET SQL_MODE=@OLDTMP_SQL_MODE;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
