-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2019. Már 31. 01:17
-- Kiszolgáló verziója: 10.1.37-MariaDB
-- PHP verzió: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `lab3d`
--

-- --------------------------------------------------------
CREATE DATABASE lab3d CHARACTER SET utf8 COLLATE utf8_hungarian_ci;

--
-- Tábla szerkezet ehhez a táblához `accountok`
--

CREATE TABLE `accountok` (
  `felhNev` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `jelszo` varchar(28) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `email_cim` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `jog` varchar(20) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `szint` int(11) NOT NULL,
  `regio_az` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `accountok`
--

INSERT INTO `accountok` (`felhNev`, `jelszo`, `email_cim`, `jog`, `szint`, `regio_az`) VALUES
('gycsaba', 'gycsaba', 'gyuris.csaba@vasvari.hu', 'felhasználó', 1, 3),
('baro', 'baro123', 'balint.robert@vasvari.hu', 'felhasználó', 1, 3),
('user', 'user', 'username@gmail.com', 'felhasználó', 1, 3);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `helyszin`
--

CREATE TABLE `helyszin` (
  `azon` int(11) NOT NULL,
  `kontinens` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `orszag` varchar(80) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `szel_kor` varchar(18) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `hossz_fok` varchar(18) COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jatek`
--

CREATE TABLE `jatek` (
  `szAzon` int(11) DEFAULT NULL,
  `jAzon` int(11) NOT NULL,
  `palyaAz` int(11) DEFAULT NULL,
  `elhX` int(11) DEFAULT NULL,
  `elhY` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `palyak`
--

CREATE TABLE `palyak` (
  `palyaAz` int(11) NOT NULL,
  `szintKov` int(11) DEFAULT NULL,
  `nehezseg` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szerverek`
--

CREATE TABLE `szerverek` (
  `szAzon` int(11) DEFAULT NULL,
  `ip_cim` int(15) DEFAULT NULL,
  `alh_maszk` int(15) DEFAULT NULL,
  `helyszinAzon` int(11) DEFAULT NULL,
  `hardver_erof` text COLLATE utf8_hungarian_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `accountok`
--
ALTER TABLE `accountok`
  ADD PRIMARY KEY (`felhNev`);

--
-- A tábla indexei `helyszin`
--
ALTER TABLE `helyszin`
  ADD PRIMARY KEY (`azon`);

--
-- A tábla indexei `jatek`
--
ALTER TABLE `jatek`
  ADD PRIMARY KEY (`jAzon`),
  ADD KEY `FK_szerverPalya` (`palyaAz`);

--
-- A tábla indexei `palyak`
--
ALTER TABLE `palyak`
  ADD PRIMARY KEY (`palyaAz`);

--
-- A tábla indexei `szerverek`
--
ALTER TABLE `szerverek`
  ADD KEY `szerverek` (`helyszinAzon`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `helyszin`
--
ALTER TABLE `helyszin`
  MODIFY `azon` int(11) NOT NULL AUTO_INCREMENT;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `jatek`
--
ALTER TABLE `jatek`
  ADD CONSTRAINT `FK_szerverPalya` FOREIGN KEY (`palyaAz`) REFERENCES `palyak` (`palyaAz`);

--
-- Megkötések a táblához `szerverek`
--
ALTER TABLE `szerverek`
  ADD CONSTRAINT `szerverek` FOREIGN KEY (`helyszinAzon`) REFERENCES `helyszin` (`azon`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
