-- MySQL Script generated by MySQL Workbench
-- Thu Feb  9 11:16:29 2023
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema trello
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema trello
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `trello` DEFAULT CHARACTER SET utf8mb4 ;
USE `trello` ;

-- -----------------------------------------------------
-- Table `trello`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trello`.`users` (
  `users_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(70) NOT NULL,
  `email` VARCHAR(70) NOT NULL,
  `password` VARCHAR(255) NOT NULL,
  `signup_date` DATE NOT NULL,
  PRIMARY KEY (`users_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `trello`.`projects`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trello`.`projects` (
  `project_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `description` TEXT NOT NULL,
  `creation_date` DATE NOT NULL,
  PRIMARY KEY (`project_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `trello`.`users_has_projects`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trello`.`users_has_projects` (
  `users_users_id` INT NOT NULL,
  `projects_project_id` INT NOT NULL,
  PRIMARY KEY (`users_users_id`, `projects_project_id`),
  INDEX `fk_users_has_projects_projects1_idx` (`projects_project_id` ASC) VISIBLE,
  INDEX `fk_users_has_projects_users_idx` (`users_users_id` ASC) VISIBLE,
  CONSTRAINT `fk_users_has_projects_users`
    FOREIGN KEY (`users_users_id`)
    REFERENCES `trello`.`users` (`users_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_users_has_projects_projects1`
    FOREIGN KEY (`projects_project_id`)
    REFERENCES `trello`.`projects` (`project_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `trello`.`lists`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trello`.`lists` (
  `list_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(60) NOT NULL,
  `projects_project_id` INT NOT NULL,
  PRIMARY KEY (`list_id`, `projects_project_id`),
  INDEX `fk_list_projects1_idx` (`projects_project_id` ASC) VISIBLE,
  CONSTRAINT `fk_list_projects1`
    FOREIGN KEY (`projects_project_id`)
    REFERENCES `trello`.`projects` (`project_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `trello`.`cards`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trello`.`cards` (
  `card_id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(45) NOT NULL,
  `description` TEXT NOT NULL,
  `creation_date` DATE NOT NULL,
  `lists_list_id` INT NOT NULL,
  PRIMARY KEY (`card_id`, `lists_list_id`),
  INDEX `fk_cards_lists1_idx` (`lists_list_id` ASC) VISIBLE,
  CONSTRAINT `fk_cards_lists1`
    FOREIGN KEY (`lists_list_id`)
    REFERENCES `trello`.`lists` (`list_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `trello`.`tags`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trello`.`tags` (
  `tag_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `color` VARCHAR(45) NOT NULL,
  `cards_card_id` INT NOT NULL,
  PRIMARY KEY (`tag_id`, `cards_card_id`),
  INDEX `fk_tags_cards1_idx` (`cards_card_id` ASC) VISIBLE,
  CONSTRAINT `fk_tags_cards1`
    FOREIGN KEY (`cards_card_id`)
    REFERENCES `trello`.`cards` (`card_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `trello`.`comments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trello`.`comments` (
  `comment_id` INT NOT NULL AUTO_INCREMENT,
  `content` TEXT NOT NULL,
  `creation_date` DATE NOT NULL,
  `cards_card_id` INT NOT NULL,
  `users_users_id` INT NOT NULL,
  PRIMARY KEY (`comment_id`, `cards_card_id`, `users_users_id`),
  INDEX `fk_comments_cards1_idx` (`cards_card_id` ASC) VISIBLE,
  INDEX `fk_comments_users1_idx` (`users_users_id` ASC) VISIBLE,
  CONSTRAINT `fk_comments_cards1`
    FOREIGN KEY (`cards_card_id`)
    REFERENCES `trello`.`cards` (`card_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_comments_users1`
    FOREIGN KEY (`users_users_id`)
    REFERENCES `trello`.`users` (`users_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
