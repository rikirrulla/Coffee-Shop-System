-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 04, 2020 at 03:29 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `coffee_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `ordersID` int(11) NOT NULL,
  `order_date` date NOT NULL,
  `type` varchar(10) NOT NULL,
  `date_modified` date NOT NULL,
  `status` varchar(50) NOT NULL,
  `userID` int(11) NOT NULL,
  `productID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`ordersID`, `order_date`, `type`, `date_modified`, `status`, `userID`, `productID`) VALUES
(1, '0000-00-00', 'desktop', '0000-00-00', 'pranuar', 1, 3),
(2, '0000-00-00', 'desktop', '0000-00-00', 'pranuar', 1, 7),
(3, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 1),
(4, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 7),
(6, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 3),
(7, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 2),
(8, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 3),
(9, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 9),
(10, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 10),
(11, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 5),
(12, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 4),
(13, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 9),
(14, '2020-07-23', 'desktop', '2020-07-23', 'pranuar', 1, 8),
(15, '2020-07-24', 'desktop', '2020-07-24', 'pranuar', 1, 3),
(16, '2020-07-24', 'desktop', '2020-07-24', 'pranuar', 1, 7),
(17, '2020-07-24', 'desktop', '2020-07-24', 'pranuar', 1, 8),
(18, '2020-07-31', 'desktop', '2020-07-31', 'pranuar', 1, 4),
(19, '2020-08-01', 'desktop', '2020-08-01', 'pranuar', 1, 2),
(20, '2020-08-01', 'desktop', '2020-08-01', 'pranuar', 1, 8),
(21, '2020-08-02', 'desktop', '2020-08-02', 'pranuar', 1, 3),
(22, '2020-08-02', 'desktop', '2020-08-02', 'pranuar', 1, 7),
(23, '2020-08-02', 'desktop', '2020-08-02', 'pranuar', 1, 10),
(24, '2020-08-02', 'desktop', '2020-08-02', 'pranuar', 1, 9),
(25, '2020-08-02', 'desktop', '2020-08-02', 'pranuar', 1, 8),
(26, '2020-11-11', 'desktop', '2020-11-11', 'pranuar', 1, 3),
(27, '2020-11-11', 'desktop', '2020-11-11', 'pranuar', 1, 5),
(28, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 0),
(29, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 1),
(30, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 94),
(31, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 1),
(32, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 94),
(33, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 0),
(34, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 0),
(35, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 1),
(36, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 1),
(37, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 1),
(38, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 1),
(39, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 94),
(40, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 1),
(41, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 94),
(42, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 0),
(43, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 85),
(44, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 90),
(45, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 84),
(46, '2020-12-03', 'phone', '2020-12-03', 'kompletuar', 1, 1),
(47, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 107),
(48, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 1),
(49, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 107),
(50, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 1),
(51, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 108),
(52, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 108),
(53, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 90),
(54, '2020-12-03', 'phone', '2020-12-03', 'pranuar', 1, 112),
(55, '2020-12-04', 'desktop', '2020-12-04', 'rregullt', 1, 1),
(56, '2020-12-04', 'desktop', '2020-12-04', 'rregullt', 1, 107),
(57, '2020-12-04', 'phone', '2020-12-04', 'pranuar', 1, 84),
(58, '2020-12-04', 'phone', '2020-12-04', 'pranuar', 1, 87),
(59, '2020-12-04', 'desktop', '2020-12-04', 'rregullt', 1, 1),
(60, '2020-12-04', 'desktop', '2020-12-04', 'rregullt', 1, 108),
(61, '2020-12-04', 'desktop', '2020-12-04', 'rregullt', 1, 85),
(62, '2020-12-04', 'desktop', '2020-12-04', 'rregullt', 1, 88),
(63, '2020-12-04', 'phone', '2020-12-04', 'pranuar', 2, 84),
(64, '2020-12-04', 'phone', '2020-12-04', 'pranuar', 2, 107),
(65, '2020-12-04', 'phone', '2020-12-04', 'pranuar', 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `productID` int(11) NOT NULL,
  `product_name` varchar(50) NOT NULL,
  `unit_price` decimal(8,2) NOT NULL,
  `description` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `type` varchar(20) NOT NULL,
  `date_created` date NOT NULL,
  `date_modified` date NOT NULL,
  `image` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`productID`, `product_name`, `unit_price`, `description`, `category`, `type`, `date_created`, `date_modified`, `image`) VALUES
(1, 'Amerikane', '0.50', '', 'Kafe', 'Kafe', '2020-08-12', '2020-07-16', ''),
(84, 'Ice Tea', '1.00', '', 'Pije jo alkoolike', 'Pije', '2020-07-15', '2020-07-16', ''),
(85, 'Sprite', '1.00', '', 'Pije jo alkoolike', 'Pije', '2020-07-15', '2020-07-16', ''),
(86, 'Ujë Natyral', '1.00', '', 'Pije jo alkoolike', 'Pije', '2020-07-15', '2020-07-16', ''),
(87, 'Coca Cola Zero', '1.00', '', 'Pije jo alkoolike', 'Pije', '2020-07-15', '2020-07-16', ''),
(88, 'Ujë pa Gaz (0.50 lt)', '0.50', '', 'Pije jo alkoolike', 'Pije', '2020-07-15', '2020-07-16', ''),
(89, 'Ujë me Gaz (0.50 lt)', '0.50', '', 'Pije jo alkoolike', 'Pije', '2020-07-15', '2020-07-16', ''),
(90, 'Birra Peja', '1.00', '', 'Pije alkoolike', 'Pije', '2020-07-15', '2020-07-16', ''),
(94, 'Ice Tea', '1.00', 'Pije', 'Pije jo alkoolike', 'Pije', '2020-10-25', '2020-10-25', ''),
(107, 'E Madhe', '0.50', 'Kafe', 'Kafe', 'Kafe', '2020-12-03', '2020-12-03', ''),
(108, 'E vogel', '0.50', 'Kafe', 'Kafe', 'Kafe', '2020-12-03', '2020-12-03', ''),
(109, 'Karamel', '1.00', 'Akullore me karamel', 'Akullore', 'Akullore', '2020-12-03', '2020-12-03', ''),
(110, 'Snaker', '1.00', 'Snaker', 'Akullore', 'Akullore', '2020-12-03', '2020-12-03', ''),
(111, 'Rafaelo', '1.00', 'Rafaelo', 'Akullore', 'Akullore', '2020-12-03', '2020-12-03', ''),
(112, 'Birra e Shkupit', '1.00', 'Birre', 'Pije alkoolike', 'Pije alkoolike', '2020-12-03', '2020-12-03', '');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `pin_code` varchar(4) NOT NULL,
  `password_hash` varchar(50) NOT NULL,
  `telephone_number` varchar(50) NOT NULL,
  `type` varchar(10) NOT NULL,
  `date_created` date NOT NULL,
  `date_modified` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `first_name`, `last_name`, `username`, `pin_code`, `password_hash`, `telephone_number`, `type`, `date_created`, `date_modified`) VALUES
(1, 'Vedat', 'Muriqi', 'vedat', '0000', 'ad1dfc86b73f84818958fcd41dfc9ce3', '+38343900360', 'admin', '2020-07-15', '2020-12-04'),
(2, 'Milot', 'Rashica', 'milot', '0000', '0dcc8ab67dbbc624db759ef321089603', '+38343900350', 'admin', '2020-07-15', '2020-12-04'),
(3, 'Edon', 'Zhegrova', 'edon', '0000', '098f6bcd4621d373cade4e832627b4f6', '+38343900350', 'admin', '0000-00-00', '2020-12-04'),
(4, 'test', 'test', 'test', '0000', '098f6bcd4621d373cade4e832627b4f6', 'test', 'user', '2020-12-04', '2020-12-04');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`ordersID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`productID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `ordersID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `productID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=114;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
