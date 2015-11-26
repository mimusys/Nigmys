-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 19, 2015 at 10:09 AM
-- Server version: 10.1.8-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `users`
--
DROP DATABASE IF EXISTS `mimusys_users_dev`;
CREATE DATABASE IF NOT EXISTS `mimusys_users_dev` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `mimusys_users_dev`;

DROP DATABASE IF EXISTS `users`;
-- --------------------------------------------------------

--
-- Table structure for table `passwordinformation`
--

DROP TABLE IF EXISTS `passwordinformation`;
CREATE TABLE `passwordinformation` (
  `passwordID` int(11) NOT NULL,
  `passwordHash` varchar(300) NOT NULL,
  `salt` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `passwordinformation`
--

INSERT INTO `passwordinformation` (`passwordID`, `passwordHash`, `salt`) VALUES
(1, '55f8d19cbb291b70b2fcdd06c6dcfed537184ab8c2e19ab98bfe3cd49e23a9ca', '1111');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `customerID` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `passwordID` int(11) NOT NULL,
  `address` tinytext NOT NULL,
  `zip` varchar(10) NOT NULL,
  `email` varchar(50) NOT NULL,
  `birthDate` date NOT NULL,
  `companyName` varchar(50) NOT NULL,
  `pictureURL` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`customerID`, `username`, `firstName`, `lastName`, `passwordID`, `address`, `zip`, `email`, `birthDate`, `companyName`, `pictureURL`) VALUES
(1, 'username1', 'fakeFirst', 'fakeLast', 1, '123 fake st.', '11111', 'fake@fake.com', '2015-11-18', 'fake LTD', 'www.google.com');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `passwordinformation`
--
ALTER TABLE `passwordinformation`
  ADD PRIMARY KEY (`passwordID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`customerID`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`),
  ADD KEY `passwordID` (`passwordID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `passwordinformation`
--
ALTER TABLE `passwordinformation`
  MODIFY `passwordID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `customerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`passwordID`) REFERENCES `passwordinformation` (`passwordID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
