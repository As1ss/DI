-- MySQL Script generated by MySQL Workbench
-- Sat Dec  9 22:23:54 2023
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema usuariologin
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `usuariologin` ;

-- -----------------------------------------------------
-- Schema usuariologin
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `usuariologin` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `usuariologin` ;

-- -----------------------------------------------------
-- Table `usuariologin`.`usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `usuariologin`.`usuario` ;

CREATE TABLE IF NOT EXISTS `usuariologin`.`usuario` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(20) NOT NULL,
  `contrasena` VARCHAR(40) NOT NULL,
  `tipo_usuario` VARCHAR(20) NOT NULL,
  `intentos_fallidos` INT NOT NULL DEFAULT 0,
  `bloqueado` TINYINT(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `usuariologin`.`intentos_login`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `usuariologin`.`intentos_login` ;

CREATE TABLE IF NOT EXISTS `usuariologin`.`intentos_login` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `id_usuario` INT NOT NULL,
  `resultado` TINYINT(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  INDEX `id_usuario` (`id_usuario` ASC) VISIBLE,
  CONSTRAINT `intentos_login_ibfk_1`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `usuariologin`.`usuario` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
