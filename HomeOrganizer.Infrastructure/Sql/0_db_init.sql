DROP DATABASE IF EXISTS home_organizer;
CREATE DATABASE IF NOT EXISTS home_organizer;

USE home_organizer;

CREATE TABLE `user_account`
(
    `id`         varchar(36) PRIMARY KEY,
    `email`      varchar(50) NOT NULL,
    `firstname`  varchar(50) NOT NULL,
    `lastname`   varchar(50) NOT NULL,
    `created_at` char(14)    NOT NULL,
    `created_by` char(50)    NOT NULL,
    `updated_at` char(14)    NOT NULL,
    `updated_by` char(50)    NOT NULL
);

CREATE TABLE `home`
(
    `id`         varchar(36) PRIMARY KEY,
    `name`       varchar(50) NOT NULL,
    `created_at` char(14)    NOT NULL,
    `created_by` char(50)    NOT NULL,
    `updated_at` char(14)    NOT NULL,
    `updated_by` char(50)    NOT NULL
);

CREATE TABLE `user_account_home`
(
    `id`              varchar(36) PRIMARY KEY,
    `user_account_id` varchar(36) NOT NULL,
    `home_id`         varchar(36) NOT NULL,
    `role`            int         NOT NULL,
    `created_at`      char(14)    NOT NULL,
    `created_by`      char(50)    NOT NULL,
    `updated_at`      char(14)    NOT NULL,
    `updated_by`      char(50)    NOT NULL
);

CREATE TABLE `task`
(
    `id`          varchar(36) PRIMARY KEY,
    `home_id`    varchar(36) NOT NULL,
    `description` varchar(2024) NOT NULL,
    `due_dt`    char(8),
    `due_tm`   char(6),
    `task_status` int           NOT NULL,
    `created_at`  char(14)      NOT NULL,
    `created_by`  char(50)      NOT NULL,
    `updated_at`  char(14)      NOT NULL,
    `updated_by`  char(50)      NOT NULL
);

CREATE TABLE `task_user_account`
(
    `id`              varchar(36) PRIMARY KEY,
    `user_account_id` varchar(36) NOT NULL,
    `task_id`         varchar(36) NOT NULL,
    `created_at`      char(14)    NOT NULL,
    `created_by`      char(50)    NOT NULL,
    `updated_at`      char(14)    NOT NULL,
    `updated_by`      char(50)    NOT NULL
);

CREATE UNIQUE INDEX `U_user_account_home` ON `user_account_home` (`user_account_id`, `home_id`);

CREATE UNIQUE INDEX `U_task_user_account` ON `task_user_account` (`user_account_id`, `task_id`);

ALTER TABLE `user_account_home`
    ADD CONSTRAINT `FK_user_account_home_user_account` FOREIGN KEY (`user_account_id`) REFERENCES `user_account` (`id`);

ALTER TABLE `user_account_home`
    ADD CONSTRAINT `FK_user_account_home_home` FOREIGN KEY (`home_id`) REFERENCES `home` (`id`);

ALTER TABLE `task`
    ADD CONSTRAINT `FK_task_home` FOREIGN KEY (`home_id`) REFERENCES `home` (`id`);


ALTER TABLE `task_user_account`
    ADD CONSTRAINT `FK_task_user_account_user_account` FOREIGN KEY (`user_account_id`) REFERENCES `user_account` (`id`);

ALTER TABLE `task_user_account`
    ADD CONSTRAINT `FK_task_user_account_task` FOREIGN KEY (`task_id`) REFERENCES `task` (`id`);
