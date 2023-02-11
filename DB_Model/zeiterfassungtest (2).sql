-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 11. Feb 2023 um 20:05
-- Server-Version: 10.4.27-MariaDB
-- PHP-Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `zeiterfassungtest`
--

DELIMITER $$
--
-- Prozeduren
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `arbeitsbegin` (IN `ma` VARCHAR(250))   BEGIN
	INSERT INTO arbeitszeit(benutzer_id, arbeitsbegin, arbeitstag_id)
    VALUES (ma, now(), (SELECT MAX(id) FROM `arbeitstag`));
UPDATE benutzer SET isWorking = true WHERE id = ma;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `arbeitsende` (IN `ma` VARCHAR(250))   BEGIN
	UPDATE arbeitszeit SET arbeitsende = now() WHERE benutzer_id = ma;
    UPDATE benutzer SET isWorking = false WHERE id = ma;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `arbeitstagBenutzer` (IN `id` INT, IN `datum` DATE)   Begin
SELECT
arbeitstag.Datum,
arbeitszeit.arbeitsbegin,
arbeitszeit.arbeitsende
FROM
arbeitstag
JOIN arbeitszeit ON arbeitstag.id = arbeitszeit.arbeitstag_id
WHERE arbeitszeit.benutzer_id = id AND arbeitstag.Datum = datum;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `neuerMitarbeiter` (`firstN` VARCHAR(250), `lastN` VARCHAR(250), `pw` VARCHAR(250), OUT `n` INT)   BEGIN
	INSERT INTO benutzer(firstname, lastname, PasswordHash, userpassword)
    VALUES(firstN, lastN, pw, pw);
    SELECT LAST_INSERT_ID() INTO n;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `arbeitstag`
--

CREATE TABLE `arbeitstag` (
  `id` int(11) NOT NULL,
  `Datum` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `arbeitstag`
--

INSERT INTO `arbeitstag` (`id`, `Datum`) VALUES
(1, '2023-01-20'),
(2, '2023-01-21'),
(3, '2023-01-22'),
(4, '2023-01-23'),
(5, '2023-02-05'),
(6, '2023-02-06'),
(8, '2023-02-11');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `arbeitszeit`
--

CREATE TABLE `arbeitszeit` (
  `arbeitszeit_id` int(11) NOT NULL,
  `benutzer_id` int(11) NOT NULL,
  `arbeitsbegin` time DEFAULT NULL,
  `arbeitsende` time DEFAULT NULL,
  `arbeitstag_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `arbeitszeit`
--

INSERT INTO `arbeitszeit` (`arbeitszeit_id`, `benutzer_id`, `arbeitsbegin`, `arbeitsende`, `arbeitstag_id`) VALUES
(1, 4711, '08:00:00', '18:26:03', 1),
(2, 4711, '13:00:00', '18:26:03', 1),
(3, 4711, '08:15:00', '18:26:03', 2),
(4, 4711, '07:45:00', '18:26:03', 3),
(5, 4711, '07:45:00', '18:26:03', 4),
(6, 4712, '08:00:00', '17:47:59', 1),
(7, 4712, '13:00:00', '17:47:59', 1),
(8, 4712, '08:15:00', '17:47:59', 2),
(9, 4712, '07:45:00', '17:47:59', 4),
(10, 4712, '13:45:00', '17:47:59', 4),
(11, 4711, '17:44:47', '18:26:03', 8),
(12, 4712, '17:47:43', '17:47:59', 8),
(13, 4711, '18:05:42', '18:26:03', 8),
(14, 4713, '18:20:10', '18:20:19', 8),
(15, 4711, '18:24:51', '18:26:03', 8),
(16, 4711, '18:25:34', '18:26:03', 8),
(17, 4711, '18:25:43', '18:26:03', 8);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `benutzer`
--

CREATE TABLE `benutzer` (
  `id` int(11) NOT NULL,
  `firstName` varchar(250) NOT NULL,
  `lastName` varchar(250) NOT NULL,
  `isAdmin` tinyint(1) NOT NULL DEFAULT 0,
  `isWorking` tinyint(1) NOT NULL DEFAULT 0,
  `PasswordHash` binary(64) NOT NULL,
  `userpassword` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `benutzer`
--

INSERT INTO `benutzer` (`id`, `firstName`, `lastName`, `isAdmin`, `isWorking`, `PasswordHash`, `userpassword`) VALUES
(4711, 'Max', 'Mustermann', 0, 0, 0x2a344143464533323032413546463543463436373839384643353841414231443631353032393434310000000000000000000000000000000000000000000000, 'admin'),
(4712, 'Monika', 'Musterfrau', 0, 0, 0x2a384436413633374633373935354442464345313232393230344444424544314345313145364634310000000000000000000000000000000000000000000000, 'master'),
(4713, 'Erik', 'Müller', 0, 0, 0x74657374707700000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 'testpw');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `benutzer_arbeitstag`
--

CREATE TABLE `benutzer_arbeitstag` (
  `benutzer_id` int(11) NOT NULL,
  `arbeitstag_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `benutzer_arbeitstag`
--

INSERT INTO `benutzer_arbeitstag` (`benutzer_id`, `arbeitstag_id`) VALUES
(4711, 1),
(4711, 2),
(4711, 3),
(4711, 4),
(4712, 1),
(4712, 4);

-- --------------------------------------------------------

--
-- Stellvertreter-Struktur des Views `zeigeallearbeitszeiten`
-- (Siehe unten für die tatsächliche Ansicht)
--
CREATE TABLE `zeigeallearbeitszeiten` (
`Mitarbeiternummer` int(11)
,`Vorname` varchar(250)
,`Nachname` varchar(250)
,`Arbeitstag` date
,`Arbeitsbegin` time
,`Arbeitsende` time
);

-- --------------------------------------------------------

--
-- Struktur des Views `zeigeallearbeitszeiten`
--
DROP TABLE IF EXISTS `zeigeallearbeitszeiten`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `zeigeallearbeitszeiten`  AS SELECT `benutzer`.`id` AS `Mitarbeiternummer`, `benutzer`.`firstName` AS `Vorname`, `benutzer`.`lastName` AS `Nachname`, `arbeitstag`.`Datum` AS `Arbeitstag`, `arbeitszeit`.`arbeitsbegin` AS `Arbeitsbegin`, `arbeitszeit`.`arbeitsende` AS `Arbeitsende` FROM ((`arbeitszeit` join `benutzer` on(`benutzer`.`id` = `arbeitszeit`.`benutzer_id`)) join `arbeitstag` on(`arbeitszeit`.`arbeitstag_id` = `arbeitstag`.`id`))  ;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `arbeitstag`
--
ALTER TABLE `arbeitstag`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Datum` (`Datum`);

--
-- Indizes für die Tabelle `arbeitszeit`
--
ALTER TABLE `arbeitszeit`
  ADD PRIMARY KEY (`arbeitszeit_id`),
  ADD KEY `benutzer_id` (`benutzer_id`),
  ADD KEY `arbeitstag_id` (`arbeitstag_id`);

--
-- Indizes für die Tabelle `benutzer`
--
ALTER TABLE `benutzer`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `benutzer_arbeitstag`
--
ALTER TABLE `benutzer_arbeitstag`
  ADD PRIMARY KEY (`benutzer_id`,`arbeitstag_id`),
  ADD KEY `arbeitstag_id` (`arbeitstag_id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `arbeitstag`
--
ALTER TABLE `arbeitstag`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT für Tabelle `arbeitszeit`
--
ALTER TABLE `arbeitszeit`
  MODIFY `arbeitszeit_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT für Tabelle `benutzer`
--
ALTER TABLE `benutzer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4714;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `arbeitszeit`
--
ALTER TABLE `arbeitszeit`
  ADD CONSTRAINT `arbeitszeit_ibfk_1` FOREIGN KEY (`benutzer_id`) REFERENCES `benutzer` (`id`),
  ADD CONSTRAINT `arbeitszeit_ibfk_2` FOREIGN KEY (`arbeitstag_id`) REFERENCES `arbeitstag` (`id`);

--
-- Constraints der Tabelle `benutzer_arbeitstag`
--
ALTER TABLE `benutzer_arbeitstag`
  ADD CONSTRAINT `benutzer_arbeitstag_ibfk_1` FOREIGN KEY (`benutzer_id`) REFERENCES `benutzer` (`id`),
  ADD CONSTRAINT `benutzer_arbeitstag_ibfk_2` FOREIGN KEY (`arbeitstag_id`) REFERENCES `arbeitstag` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
