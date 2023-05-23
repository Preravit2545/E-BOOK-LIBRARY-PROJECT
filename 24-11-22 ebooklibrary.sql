-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 24, 2022 at 01:14 AM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ebooklibrary`
--

-- --------------------------------------------------------

--
-- Table structure for table `admintbl`
--

CREATE TABLE `admintbl` (
  `AdminID` int(10) NOT NULL COMMENT 'รหัสแอดมิน',
  `AdminUser` varchar(50) NOT NULL COMMENT 'รหัสผู้ใช้แอดมิน',
  `AdminPass` varchar(50) NOT NULL COMMENT 'รหัสผ่านแอดมิน',
  `AdminPicture` text NOT NULL COMMENT 'รูปภาพแอดมิน'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admintbl`
--

INSERT INTO `admintbl` (`AdminID`, `AdminUser`, `AdminPass`, `AdminPicture`) VALUES
(1, 'Preravit2545', '1234', '62638-20211029-105116-587920804.jpg'),
(2, 'Preravit2002', '12345', 'download.jpg'),
(3, 'Preravit4', '123455', '3.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `borrowtbl`
--

CREATE TABLE `borrowtbl` (
  `borrowID` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `ebook_id` int(11) NOT NULL,
  `Expired_Book` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `borrowtbl`
--

INSERT INTO `borrowtbl` (`borrowID`, `user_id`, `ebook_id`, `Expired_Book`) VALUES
(40, 1, 3, '2022-11-26'),
(41, 6, 2, '2022-11-26');

-- --------------------------------------------------------

--
-- Table structure for table `ebooktbl`
--

CREATE TABLE `ebooktbl` (
  `EbookID` int(10) NOT NULL COMMENT 'รหัสอีบุ๊ค',
  `EbookName` varchar(30) NOT NULL COMMENT 'ชื่ออีบุ๊ค',
  `EbookAuthor` varchar(30) NOT NULL COMMENT 'ชื่อผู้แต่งอีบุ๊ค',
  `EbookType` varchar(30) NOT NULL COMMENT 'ประเภทอีบุ๊ค',
  `EbookPicture` text NOT NULL,
  `EbookPDF` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ebooktbl`
--

INSERT INTO `ebooktbl` (`EbookID`, `EbookName`, `EbookAuthor`, `EbookType`, `EbookPicture`, `EbookPDF`) VALUES
(1, 'eb', 'a', 't', 'พีรวิชญ์.jpg', 'Living in the Light_ A guide to personal transformation ( PDFDrive ).pdf'),
(2, 'Blockchain', 'test', 'test', 'Blockchain-V2.jpg', 'Blockchain-V2.pdf'),
(3, 'AI GOVERNMENT FRAMEWORK', 'สำนักงานพัฒนารัฐบาลดิจิทัล', 'วิทยาศาสตร์', '2021-04-01_23-05-47.jpg', 'AI-Government-Framework.pdf'),
(4, 'THAILAND INTERNET', 'test', 'test', '2021-05-06_2-55-53.jpg', 'Blockchain-V2.pdf'),
(5, 'JAVA 101', 'Atiwong Suchato', 'คอมพิวเตอร์', '2021-03-13_17-22-35_1.jpg', 'java101.pdf');

-- --------------------------------------------------------

--
-- Table structure for table `usertbl`
--

CREATE TABLE `usertbl` (
  `User_ID` int(11) NOT NULL,
  `User_name` varchar(30) NOT NULL,
  `User_pass` varchar(30) NOT NULL,
  `User_type` varchar(30) NOT NULL,
  `User_picture` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `usertbl`
--

INSERT INTO `usertbl` (`User_ID`, `User_name`, `User_pass`, `User_type`, `User_picture`) VALUES
(1, 'Preravit2545', '12345', 'นักศึกษา', '62638-20211029-105116-587920804.jpg'),
(2, 'Preravit2', '12345', 'นักศึกษา', '62638-20211029-105116-587920804.jpg'),
(3, 'TEST', '1234', 'นักศึกษา', '62638-20211029-105116-587920804.jpg'),
(5, 'Preravit3', '12345', 'อาจารย์', 'download.jpg'),
(6, 'Preravit4', '12345', 'นักศึกษา', '5.jpg');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admintbl`
--
ALTER TABLE `admintbl`
  ADD PRIMARY KEY (`AdminID`);

--
-- Indexes for table `borrowtbl`
--
ALTER TABLE `borrowtbl`
  ADD PRIMARY KEY (`borrowID`),
  ADD KEY `user_id_fk` (`user_id`),
  ADD KEY `ebook_id_fk` (`ebook_id`);

--
-- Indexes for table `ebooktbl`
--
ALTER TABLE `ebooktbl`
  ADD PRIMARY KEY (`EbookID`);

--
-- Indexes for table `usertbl`
--
ALTER TABLE `usertbl`
  ADD PRIMARY KEY (`User_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admintbl`
--
ALTER TABLE `admintbl`
  MODIFY `AdminID` int(10) NOT NULL AUTO_INCREMENT COMMENT 'รหัสแอดมิน', AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `borrowtbl`
--
ALTER TABLE `borrowtbl`
  MODIFY `borrowID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=42;

--
-- AUTO_INCREMENT for table `usertbl`
--
ALTER TABLE `usertbl`
  MODIFY `User_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `borrowtbl`
--
ALTER TABLE `borrowtbl`
  ADD CONSTRAINT `ebook_id_fk` FOREIGN KEY (`ebook_id`) REFERENCES `ebooktbl` (`EbookID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_id_fk` FOREIGN KEY (`user_id`) REFERENCES `usertbl` (`User_ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
