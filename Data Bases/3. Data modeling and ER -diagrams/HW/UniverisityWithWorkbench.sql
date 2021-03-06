-- MySQL Script generated by MySQL Workbench
-- 08/23/14 18:13:09
-- Model: New Model    Version: 1.0
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Faculties` (
  `idFaculties` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`idFaculties`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Students` (
  `id` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  `FacultyID` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_Students_Faculty_idx` (`FacultyID` ASC),
  CONSTRAINT `FK_Students_Faculty`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `mydb`.`Faculties` (`idFaculties`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Departments` (
  `idDepartments` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  `FacultyID` INT NULL,
  PRIMARY KEY (`idDepartments`),
  INDEX `FK_Departments_Faculty_idx` (`FacultyID` ASC),
  CONSTRAINT `FK_Departments_Faculty`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `mydb`.`Faculties` (`idFaculties`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Professors` (
  `idProfessors` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  `DepartmentID` INT NULL,
  PRIMARY KEY (`idProfessors`),
  INDEX `FK_Professors_Department_idx` (`DepartmentID` ASC),
  CONSTRAINT `FK_Professors_Department`
    FOREIGN KEY (`DepartmentID`)
    REFERENCES `mydb`.`Departments` (`idDepartments`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Courses` (
  `idCourses` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  `ProfessorID` INT NULL,
  PRIMARY KEY (`idCourses`),
  INDEX `FK_Courses_Professor_idx` (`ProfessorID` ASC),
  CONSTRAINT `FK_Courses_Professor`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `mydb`.`Professors` (`idProfessors`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`MappingStudents/Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`MappingStudents/Courses` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `StudentID` INT NULL,
  `CourseID` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_MappingStudents/Courses_Students_idx` (`StudentID` ASC),
  INDEX `FK_MappingStudents/Courses_Courses_idx` (`CourseID` ASC),
  CONSTRAINT `FK_MappingStudents/Courses_Students`
    FOREIGN KEY (`StudentID`)
    REFERENCES `mydb`.`Students` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_MappingStudents/Courses_Courses`
    FOREIGN KEY (`CourseID`)
    REFERENCES `mydb`.`Courses` (`idCourses`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Titles` (
  `idTitles` INT NOT NULL AUTO_INCREMENT,
  `TitleName` VARCHAR(45) NULL,
  PRIMARY KEY (`idTitles`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Professors/Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Professors/Titles` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `ProfessorID` INT NULL,
  `TitleID` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_Professors/Titles_Professors_idx` (`ProfessorID` ASC),
  INDEX `FK_Professors/Titles_Titles_idx` (`TitleID` ASC),
  CONSTRAINT `FK_Professors/Titles_Professors`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `mydb`.`Professors` (`idProfessors`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Professors/Titles_Titles`
    FOREIGN KEY (`TitleID`)
    REFERENCES `mydb`.`Titles` (`idTitles`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
