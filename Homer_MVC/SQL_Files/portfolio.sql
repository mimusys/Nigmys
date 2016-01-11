-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 11, 2016 at 03:19 AM
-- Server version: 10.1.8-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mimusys_portfolio_dev`
--
CREATE DATABASE IF NOT EXISTS `mimusys_portfolio_dev` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `mimusys_portfolio_dev`;

-- --------------------------------------------------------

--
-- Table structure for table `currentstatements`
--

DROP TABLE IF EXISTS `currentstatements`;
CREATE TABLE `currentstatements` (
  `statementID` int(11) NOT NULL,
  `portfolioID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `historicalstatements`
--

DROP TABLE IF EXISTS `historicalstatements`;
CREATE TABLE `historicalstatements` (
  `statementID` int(11) NOT NULL,
  `portfolioID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `portfolio`
--

DROP TABLE IF EXISTS `portfolio`;
CREATE TABLE `portfolio` (
  `portfolioID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `portfolio`
--

INSERT INTO `portfolio` (`portfolioID`) VALUES
(1);

-- --------------------------------------------------------

--
-- Table structure for table `portfolioinvestmentinformation`
--

DROP TABLE IF EXISTS `portfolioinvestmentinformation`;
CREATE TABLE `portfolioinvestmentinformation` (
  `investmentInformationID` int(11) NOT NULL,
  `portfolioID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `currentstatements`
--
ALTER TABLE `currentstatements`
  ADD PRIMARY KEY (`statementID`),
  ADD KEY `portfolioID` (`portfolioID`);

--
-- Indexes for table `historicalstatements`
--
ALTER TABLE `historicalstatements`
  ADD PRIMARY KEY (`statementID`),
  ADD KEY `portfolioID` (`portfolioID`);

--
-- Indexes for table `portfolio`
--
ALTER TABLE `portfolio`
  ADD PRIMARY KEY (`portfolioID`);

--
-- Indexes for table `portfolioinvestmentinformation`
--
ALTER TABLE `portfolioinvestmentinformation`
  ADD PRIMARY KEY (`investmentInformationID`),
  ADD KEY `portfolioID` (`portfolioID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `currentstatements`
--
ALTER TABLE `currentstatements`
  MODIFY `statementID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `historicalstatements`
--
ALTER TABLE `historicalstatements`
  MODIFY `statementID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `portfolio`
--
ALTER TABLE `portfolio`
  MODIFY `portfolioID` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `currentstatements`
--
ALTER TABLE `currentstatements`
  ADD CONSTRAINT `currentstatements_ibfk_1` FOREIGN KEY (`portfolioID`) REFERENCES `portfolio` (`portfolioID`);

--
-- Constraints for table `historicalstatements`
--
ALTER TABLE `historicalstatements`
  ADD CONSTRAINT `historicalstatements_ibfk_1` FOREIGN KEY (`portfolioID`) REFERENCES `portfolio` (`portfolioID`);

--
-- Constraints for table `portfolioinvestmentinformation`
--
ALTER TABLE `portfolioinvestmentinformation`
  ADD CONSTRAINT `portfolioinvestmentinformation_ibfk_1` FOREIGN KEY (`portfolioID`) REFERENCES `portfolio` (`portfolioID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
