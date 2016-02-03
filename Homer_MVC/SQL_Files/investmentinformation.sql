-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 11, 2016 at 03:16 AM
-- Server version: 10.1.8-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mimusys_investmentinformation_dev`
--
CREATE DATABASE IF NOT EXISTS `mimusys_investmentinformation_dev` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `mimusys_investmentinformation_dev`;

-- --------------------------------------------------------

--
-- Table structure for table `costitems`
--

DROP TABLE IF EXISTS `costitems`;
CREATE TABLE `costitems` (
  `costItemID` int(11) NOT NULL,
  `investmentInformationID` int(11) NOT NULL,
  `costItemName` varchar(100) NOT NULL,
  `costItemValue` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `debtpartners`
--

DROP TABLE IF EXISTS `debtpartners`;
CREATE TABLE `debtpartners` (
  `debtPartnerID` int(11) NOT NULL,
  `investmentInformationID` int(11) NOT NULL,
  `loanAmount` decimal(12,2) NOT NULL,
  `term` int(11) NOT NULL,
  `annualPercentageRate` decimal(12,2) NOT NULL,
  `lenderName` varchar(100) NOT NULL,
  `loanStartDate` date NOT NULL,
  `payment` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `depreciationitems`
--

DROP TABLE IF EXISTS `depreciationitems`;
CREATE TABLE `depreciationitems` (
  `depreciationItemID` int(11) NOT NULL,
  `investmentInformationID` int(11) NOT NULL,
  `depreciationItemName` varchar(100) NOT NULL,
  `depreciationItemValue` decimal(12,2) NOT NULL,
  `depreciationItemTimeDuration` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `equitypartners`
--

DROP TABLE IF EXISTS `equitypartners`;
CREATE TABLE `equitypartners` (
  `equityPartnerID` int(11) NOT NULL,
  `investmentInformationID` int(11) NOT NULL,
  `equityPartnerName` varchar(100) NOT NULL,
  `cashFlowPercent` decimal(12,2) NOT NULL,
  `appreciationPercent` decimal(12,2) NOT NULL,
  `principalPaydownPercent` decimal(12,2) NOT NULL,
  `taxDeductionPercent` decimal(12,2) NOT NULL,
  `equityInvestment` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `investmentinformation`
--

DROP TABLE IF EXISTS `investmentinformation`;
CREATE TABLE `investmentinformation` (
  `investmentInformationID` int(11) NOT NULL,
  `statementID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `potentialreturninformation`
--

DROP TABLE IF EXISTS `potentialreturninformation`;
CREATE TABLE `potentialreturninformation` (
  `potentialReturnID` int(11) NOT NULL,
  `investmentInformationID` int(11) NOT NULL,
  `annualAppreciationRate` decimal(4,0) NOT NULL,
  `salesCommission` decimal(4,0) NOT NULL,
  `capitalGainsTax` decimal(4,0) NOT NULL,
  `incomeTaxRate` decimal(4,0) NOT NULL,
  `discountRate` decimal(4,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `propertyinformation`
--

DROP TABLE IF EXISTS `propertyinformation`;
CREATE TABLE `propertyinformation` (
  `propertyInformationID` int(11) NOT NULL,
  `investmentInformationID` int(11) NOT NULL,
  `address` varchar(200) NOT NULL,
  `city` varchar(30) NOT NULL,
  `state` varchar(15) NOT NULL,
  `bedrooms` int(11) NOT NULL,
  `baths` int(11) NOT NULL,
  `squareFootage` int(11) NOT NULL,
  `pricePerSquareFoot` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `purchaseinformation`
--

DROP TABLE IF EXISTS `purchaseinformation`;
CREATE TABLE `purchaseinformation` (
  `purchaseInformationID` int(11) NOT NULL,
  `investmentInformationID` int(11) NOT NULL,
  `purchasePrice` decimal(12,2) NOT NULL,
  `purchaseDate` date NOT NULL,
  `marketPrice` decimal(12,2) NOT NULL,
  `downPayment` decimal(12,2) NOT NULL,
  `totalInvestmentCost` decimal(12,2) NOT NULL,
  `landValue` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `costitems`
--
ALTER TABLE `costitems`
  ADD PRIMARY KEY (`costItemID`),
  ADD KEY `investmentInformationID` (`investmentInformationID`);

--
-- Indexes for table `debtpartners`
--
ALTER TABLE `debtpartners`
  ADD PRIMARY KEY (`debtPartnerID`),
  ADD KEY `investmentInformationID` (`investmentInformationID`);

--
-- Indexes for table `depreciationitems`
--
ALTER TABLE `depreciationitems`
  ADD PRIMARY KEY (`depreciationItemID`),
  ADD KEY `investmentInformationID` (`investmentInformationID`);

--
-- Indexes for table `equitypartners`
--
ALTER TABLE `equitypartners`
  ADD PRIMARY KEY (`equityPartnerID`),
  ADD KEY `investmentInformationID` (`investmentInformationID`);

--
-- Indexes for table `investmentinformation`
--
ALTER TABLE `investmentinformation`
  ADD PRIMARY KEY (`investmentInformationID`),
  ADD KEY `statementID` (`statementID`);

--
-- Indexes for table `potentialreturninformation`
--
ALTER TABLE `potentialreturninformation`
  ADD PRIMARY KEY (`potentialReturnID`),
  ADD KEY `investmentInformationID` (`investmentInformationID`);

--
-- Indexes for table `propertyinformation`
--
ALTER TABLE `propertyinformation`
  ADD PRIMARY KEY (`propertyInformationID`),
  ADD KEY `investmentInformationID` (`investmentInformationID`);

--
-- Indexes for table `purchaseinformation`
--
ALTER TABLE `purchaseinformation`
  ADD PRIMARY KEY (`purchaseInformationID`),
  ADD KEY `investmentInformationID` (`investmentInformationID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `costitems`
--
ALTER TABLE `costitems`
  MODIFY `costItemID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `debtpartners`
--
ALTER TABLE `debtpartners`
  MODIFY `debtPartnerID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `depreciationitems`
--
ALTER TABLE `depreciationitems`
  MODIFY `depreciationItemID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `equitypartners`
--
ALTER TABLE `equitypartners`
  MODIFY `equityPartnerID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `investmentinformation`
--
ALTER TABLE `investmentinformation`
  MODIFY `investmentInformationID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `potentialreturninformation`
--
ALTER TABLE `potentialreturninformation`
  MODIFY `potentialReturnID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `propertyinformation`
--
ALTER TABLE `propertyinformation`
  MODIFY `propertyInformationID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `purchaseinformation`
--
ALTER TABLE `purchaseinformation`
  MODIFY `purchaseInformationID` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `costitems`
--
ALTER TABLE `costitems`
  ADD CONSTRAINT `costitems_ibfk_1` FOREIGN KEY (`investmentInformationID`) REFERENCES `investmentinformation` (`investmentInformationID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `debtpartners`
--
ALTER TABLE `debtpartners`
  ADD CONSTRAINT `debtpartners_ibfk_1` FOREIGN KEY (`investmentInformationID`) REFERENCES `investmentinformation` (`investmentInformationID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `depreciationitems`
--
ALTER TABLE `depreciationitems`
  ADD CONSTRAINT `depreciationitems_ibfk_1` FOREIGN KEY (`investmentInformationID`) REFERENCES `investmentinformation` (`investmentInformationID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `equitypartners`
--
ALTER TABLE `equitypartners`
  ADD CONSTRAINT `equitypartners_ibfk_1` FOREIGN KEY (`investmentInformationID`) REFERENCES `investmentinformation` (`investmentInformationID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `potentialreturninformation`
--
ALTER TABLE `potentialreturninformation`
  ADD CONSTRAINT `potentialreturninformation_ibfk_1` FOREIGN KEY (`investmentInformationID`) REFERENCES `investmentinformation` (`investmentInformationID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `propertyinformation`
--
ALTER TABLE `propertyinformation`
  ADD CONSTRAINT `propertyinformation_ibfk_1` FOREIGN KEY (`investmentInformationID`) REFERENCES `investmentinformation` (`investmentInformationID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `purchaseinformation`
--
ALTER TABLE `purchaseinformation`
  ADD CONSTRAINT `purchaseinformation_ibfk_1` FOREIGN KEY (`investmentInformationID`) REFERENCES `investmentinformation` (`investmentInformationID`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
