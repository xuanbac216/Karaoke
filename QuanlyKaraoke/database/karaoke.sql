-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.10-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win32
-- HeidiSQL Version:             9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping database structure for karaoke
CREATE DATABASE IF NOT EXISTS `karaoke` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `karaoke`;
karaokedichvu

-- Dumping structure for table karaoke.dichvu
CREATE TABLE IF NOT EXISTS `dichvu` (
  `madv` int(11) NOT NULL,
  `tendv` varchar(30) NOT NULL,
  `loaidichvu` varchar(20) NOT NULL,
  `soluong` int(11) NOT NULL,
  `dongia` char(10) NOT NULL,
  `dvt` varchar(20) NOT NULL,
  PRIMARY KEY (`madv`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table karaoke.hoadon
CREATE TABLE IF NOT EXISTS `hoadon` (
  `sohd` int(11) NOT NULL AUTO_INCREMENT,
  `maphong` int(11) NOT NULL,
  `khachhang` varchar(50) DEFAULT NULL,
  `diachi` varchar(50) DEFAULT NULL,
  `giovao` datetime NOT NULL,
  `giora` datetime DEFAULT NULL,
  `trangthai` int(11) NOT NULL,
  PRIMARY KEY (`sohd`),
  KEY `FK_hoadon_phong` (`maphong`),
  CONSTRAINT `FK_hoadon_phong` FOREIGN KEY (`maphong`) REFERENCES `phong` (`maphong`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table karaoke.hoadon_dichvu
CREATE TABLE IF NOT EXISTS `hoadon_dichvu` (
  `sohd` int(11) NOT NULL,
  `madv` int(11) NOT NULL,
  `soluong` int(11) NOT NULL,
  PRIMARY KEY (`sohd`,`madv`),
  KEY `FK_hoadon_dichvu_dichvu` (`madv`),
  CONSTRAINT `FK_hoadon_dichvu_dichvu` FOREIGN KEY (`madv`) REFERENCES `dichvu` (`madv`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_hoadon_dichvu_hoadon` FOREIGN KEY (`sohd`) REFERENCES `hoadon` (`sohd`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table karaoke.phieudatphong
CREATE TABLE IF NOT EXISTS `phieudatphong` (
  `sophieu` int(11) NOT NULL,
  `tenkh` varchar(50) DEFAULT NULL,
  `loaiphong` char(10) DEFAULT NULL,
  `tiendatcoc` char(10) NOT NULL,
  `giovao` datetime NOT NULL,
  `ghichu` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`sophieu`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table karaoke.phong
CREATE TABLE IF NOT EXISTS `phong` (
  `maphong` int(11) NOT NULL,
  `tenphong` varchar(50) NOT NULL,
  `giaphong` char(10) NOT NULL,
  `trangthai` int(2) NOT NULL,
  `mota` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`maphong`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table karaoke.taikhoan
CREATE TABLE IF NOT EXISTS `taikhoan` (
  `id` char(20) NOT NULL,
  `password` char(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
