-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 11. Feb 2023 um 15:51
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `neuerMitarbeiter` (`firstN` VARCHAR(250), `lastN` VARCHAR(250), `pw` VARCHAR(250), OUT `n` INT)   BEGIN
	INSERT INTO benutzer(firstname, lastname, PasswordHash, userpassword)
    VALUES(firstN, lastN, pw, pw);
    SELECT LAST_INSERT_ID() INTO n;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `anfangszeit`
--

CREATE TABLE `anfangszeit` (
  `benutzer_id` int(11) NOT NULL,
  `zeit` time NOT NULL,
  `arbeitstag_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `anfangszeit`
--

INSERT INTO `anfangszeit` (`benutzer_id`, `zeit`, `arbeitstag_id`) VALUES
(4711, '07:45:00', 3),
(4711, '07:45:00', 4),
(4711, '08:00:00', 1),
(4711, '08:15:00', 2),
(4711, '13:00:00', 1);

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
(4, '2023-01-23');

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
(1, 4711, '08:00:00', '12:00:00', 1),
(2, 4711, '13:00:00', '18:30:00', 1),
(3, 4711, '08:15:00', '12:30:00', 2),
(4, 4711, '07:45:00', '11:55:00', 3),
(5, 4711, '07:45:00', '12:00:00', 4),
(6, 4712, '08:00:00', '12:00:00', 1),
(7, 4712, '13:00:00', '18:30:00', 1),
(8, 4712, '08:15:00', '12:30:00', 2),
(9, 4712, '07:45:00', '11:55:00', 4),
(10, 4712, '13:45:00', '19:00:00', 4);

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
(4712, 'Monika', 'Musterfrau', 1, 0, 0x2a384436413633374633373935354442464345313232393230344444424544314345313145364634310000000000000000000000000000000000000000000000, 'master'),
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
-- Tabellenstruktur für Tabelle `endezeit`
--

CREATE TABLE `endezeit` (
  `benutzer_id` int(11) NOT NULL,
  `zeit` time NOT NULL,
  `arbeitstag_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `endezeit`
--

INSERT INTO `endezeit` (`benutzer_id`, `zeit`, `arbeitstag_id`) VALUES
(4711, '11:55:00', 3),
(4711, '12:00:00', 1),
(4711, '12:00:00', 4),
(4711, '12:30:00', 2),
(4711, '18:30:00', 1);

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
-- Indizes für die Tabelle `anfangszeit`
--
ALTER TABLE `anfangszeit`
  ADD PRIMARY KEY (`zeit`,`arbeitstag_id`),
  ADD KEY `benutzer_id` (`benutzer_id`),
  ADD KEY `arbeitstag_id` (`arbeitstag_id`);

--
-- Indizes für die Tabelle `arbeitstag`
--
ALTER TABLE `arbeitstag`
  ADD PRIMARY KEY (`id`);

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
-- Indizes für die Tabelle `endezeit`
--
ALTER TABLE `endezeit`
  ADD PRIMARY KEY (`zeit`,`arbeitstag_id`),
  ADD KEY `benutzer_id` (`benutzer_id`),
  ADD KEY `arbeitstag_id` (`arbeitstag_id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `arbeitstag`
--
ALTER TABLE `arbeitstag`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT für Tabelle `arbeitszeit`
--
ALTER TABLE `arbeitszeit`
  MODIFY `arbeitszeit_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT für Tabelle `benutzer`
--
ALTER TABLE `benutzer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4714;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `anfangszeit`
--
ALTER TABLE `anfangszeit`
  ADD CONSTRAINT `anfangszeit_ibfk_1` FOREIGN KEY (`benutzer_id`) REFERENCES `benutzer` (`id`),
  ADD CONSTRAINT `anfangszeit_ibfk_2` FOREIGN KEY (`arbeitstag_id`) REFERENCES `arbeitstag` (`id`);

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

--
-- Constraints der Tabelle `endezeit`
--
ALTER TABLE `endezeit`
  ADD CONSTRAINT `endezeit_ibfk_1` FOREIGN KEY (`benutzer_id`) REFERENCES `benutzer` (`id`),
  ADD CONSTRAINT `endezeit_ibfk_2` FOREIGN KEY (`arbeitstag_id`) REFERENCES `arbeitstag` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
