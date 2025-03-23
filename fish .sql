-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 02 2025 г., 18:22
-- Версия сервера: 8.0.30
-- Версия PHP: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `fish`
--

-- --------------------------------------------------------

--
-- Структура таблицы `environmentalquality`
--

CREATE TABLE `environmentalquality` (
  `quality_id` int NOT NULL,
  `region_id` int DEFAULT NULL,
  `pollution_level` varchar(50) DEFAULT NULL,
  `pollutants` text,
  `assessment_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `environmentalquality`
--

INSERT INTO `environmentalquality` (`quality_id`, `region_id`, `pollution_level`, `pollutants`, `assessment_date`) VALUES
(1, 1, 'Low', 'Pollutants: CO2, NO2', '2023-12-01'),
(2, 1, 'string', 'string', '2025-03-02');

-- --------------------------------------------------------

--
-- Структура таблицы `product`
--

CREATE TABLE `product` (
  `product_id` int NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `origin_region_id` int DEFAULT NULL,
  `Selection_date` date DEFAULT NULL,
  `Weight_product` float DEFAULT NULL,
  `Expiration_date` int DEFAULT NULL,
  `Length_TL` float DEFAULT NULL,
  `Lenth_Sl` float DEFAULT NULL,
  `Lenth_Fl` float DEFAULT NULL,
  `K` float DEFAULT NULL,
  `Mn_ug_kg` float DEFAULT NULL,
  `Mn_ug_kg_sy` float DEFAULT NULL,
  `Co_ug_kg` float DEFAULT NULL,
  `Co_ug_kg_sy` float DEFAULT NULL,
  `Ni_ug_kg` float DEFAULT NULL,
  `Ni_ug_kg_sy` float DEFAULT NULL,
  `Cu_mg_kg` float DEFAULT NULL,
  `Cu_mg_kg_sy` float DEFAULT NULL,
  `Zn_mg_kg` float DEFAULT NULL,
  `Zn_mg_kg_sy` float DEFAULT NULL,
  `As_mg_kg` float DEFAULT NULL,
  `As_mg_kg_sy` float DEFAULT NULL,
  `Se_ug_kg` float DEFAULT NULL,
  `Se_ug_kg_sy` float DEFAULT NULL,
  `Cd_ug_kg` float DEFAULT NULL,
  `Cd_ug_kg_sy` float DEFAULT NULL,
  `Hg_ug_kg` float DEFAULT NULL,
  `Hg_ug_kg_sy` float DEFAULT NULL,
  `Pb_ug_kg` float DEFAULT NULL,
  `Pb_ug_kg_sy` float DEFAULT NULL,
  `safety_score` float DEFAULT NULL,
  `origin_info` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `product`
--

INSERT INTO `product` (`product_id`, `name`, `origin_region_id`, `Selection_date`, `Weight_product`, `Expiration_date`, `Length_TL`, `Lenth_Sl`, `Lenth_Fl`, `K`, `Mn_ug_kg`, `Mn_ug_kg_sy`, `Co_ug_kg`, `Co_ug_kg_sy`, `Ni_ug_kg`, `Ni_ug_kg_sy`, `Cu_mg_kg`, `Cu_mg_kg_sy`, `Zn_mg_kg`, `Zn_mg_kg_sy`, `As_mg_kg`, `As_mg_kg_sy`, `Se_ug_kg`, `Se_ug_kg_sy`, `Cd_ug_kg`, `Cd_ug_kg_sy`, `Hg_ug_kg`, `Hg_ug_kg_sy`, `Pb_ug_kg`, `Pb_ug_kg_sy`, `safety_score`, `origin_info`) VALUES
(1, 'Product 1', 1, '2023-12-01', 1.5, 10, 20.5, 18, 19.5, 0.85, 0.5, 0.6, 0.3, 0.4, 0.7, 0.8, 0.2, 0.3, 0.4, 0.5, 0.02, 0.03, 0.1, 0.12, 0.005, 0.006, 0.007, 0.008, 0.02, 0.03, 85.5, 'gavno'),
(2, 'Product 2', 2, '2023-12-02', 2, 12, 22, 20, 21.5, 0.9, 0.6, 0.7, 0.4, 0.5, 0.8, 0.9, 0.3, 0.4, 0.5, 0.6, 0.03, 0.04, 0.13, 0.14, 0.006, 0.007, 0.009, 0.01, 0.03, 0.04, 90, 'net');

-- --------------------------------------------------------

--
-- Структура таблицы `region`
--

CREATE TABLE `region` (
  `region_id` int NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `Area` varchar(255) DEFAULT NULL,
  `City` varchar(255) DEFAULT NULL,
  `latitude` float DEFAULT NULL,
  `longitude` float DEFAULT NULL,
  `habitat_info` text,
  `environmental_quality_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `region`
--

INSERT INTO `region` (`region_id`, `name`, `Area`, `City`, `latitude`, `longitude`, `habitat_info`, `environmental_quality_id`) VALUES
(1, 'Region A', 'Area 1', 'City X', 55.7558, 37.6173, 'Habitat info for Region A', NULL),
(2, 'string', 'string', 'string', 0, 0, 'string', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `sales_point`
--

CREATE TABLE `sales_point` (
  `sales_point_id` int NOT NULL,
  `region_id` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `working_hours` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `sales_point`
--

INSERT INTO `sales_point` (`sales_point_id`, `region_id`, `name`, `address`, `working_hours`) VALUES
(1, 1, 'Store 1', '123 Main St, City A', 'Mon-Fri: 9:00 AM - 6:00 PM'),
(2, 1, 'Store 2', '456 Oak St, City A', 'Mon-Fri: 10:00 AM - 5:00 PM'),
(3, 2, 'Store 3', '789 Pine St, City B', 'Mon-Fri: 8:00 AM - 7:00 PM'),
(4, 2, 'Store 4', '101 Maple St, City B', 'Mon-Fri: 9:00 AM - 6:00 PM'),
(5, 1, 'Store 5', '202 Birch St, City C', 'Mon-Fri: 9:00 AM - 6:00 PM');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `environmentalquality`
--
ALTER TABLE `environmentalquality`
  ADD PRIMARY KEY (`quality_id`),
  ADD KEY `fk_region_id` (`region_id`);

--
-- Индексы таблицы `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `origin_region_id` (`origin_region_id`);

--
-- Индексы таблицы `region`
--
ALTER TABLE `region`
  ADD PRIMARY KEY (`region_id`),
  ADD KEY `environmental_quality_id` (`environmental_quality_id`);

--
-- Индексы таблицы `sales_point`
--
ALTER TABLE `sales_point`
  ADD PRIMARY KEY (`sales_point_id`),
  ADD KEY `region_id` (`region_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `environmentalquality`
--
ALTER TABLE `environmentalquality`
  MODIFY `quality_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `product`
--
ALTER TABLE `product`
  MODIFY `product_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `region`
--
ALTER TABLE `region`
  MODIFY `region_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `sales_point`
--
ALTER TABLE `sales_point`
  MODIFY `sales_point_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `environmentalquality`
--
ALTER TABLE `environmentalquality`
  ADD CONSTRAINT `fk_region_id` FOREIGN KEY (`region_id`) REFERENCES `region` (`region_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`origin_region_id`) REFERENCES `region` (`region_id`);

--
-- Ограничения внешнего ключа таблицы `region`
--
ALTER TABLE `region`
  ADD CONSTRAINT `region_ibfk_1` FOREIGN KEY (`environmental_quality_id`) REFERENCES `environmentalquality` (`quality_id`);

--
-- Ограничения внешнего ключа таблицы `sales_point`
--
ALTER TABLE `sales_point`
  ADD CONSTRAINT `sales_point_ibfk_1` FOREIGN KEY (`region_id`) REFERENCES `region` (`region_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
