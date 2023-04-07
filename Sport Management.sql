create database SportsManagement;


CREATE TABLE Sports (
  sport_id INT IDENTITY (1,1) PRIMARY KEY,
  sport_name VARCHAR(255) NOT NULL,
  
);

CREATE TABLE Tournament (
  tournament_id INT IDENTITY (1,1) PRIMARY KEY,
  tournament_name VARCHAR(255) NOT NULL,
);

CREATE TABLE Tournament_Sport (
  id INT IDENTITY (1,1) PRIMARY KEY,
  tournament_id INT,
  sport_id INT,
  FOREIGN KEY (tournament_id) REFERENCES Tournament(tournament_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  FOREIGN KEY (sport_id) REFERENCES Sports(sport_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);


SELECT t.tournament_name, s.sport_name 
FROM Tournament_Sport ts
JOIN Tournament t ON ts.tournament_id = t.tournament_id
JOIN Sports s ON ts.sport_id = s.sport_id;

CREATE TABLE Scoreboard (
  scoreboard_id INT IDENTITY (1,1) PRIMARY KEY,
  tournament_sport_id INT,
  team1_name varchar(30),
  team2_name varchar(30),
  team1_score INT DEFAULT 0,
  team2_score INT DEFAULT 0, 
  result varchar (30),
  FOREIGN KEY (tournament_sport_id) REFERENCES Tournament_Sport(id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
);

  DROP TABLE Scoreboard;


alter table Scoreboard add  Result varchar(30);

INSERT INTO Sports (sport_name) VALUES 
('Football'),
('Basketball');

INSERT INTO Tournament (tournament_name) VALUES 
('Intra-College Football Tournament'),
('Inter-University Basketball Tournament');


INSERT INTO Tournament_Sport (tournament_id, sport_id) VALUES 
(1, 1),
(2, 2);

select * from Sports;
select * from Tournament;
select * from Tournament_Sport;
select * from Scoreboard;

select * from team;
select * from Player;
/*
delete from Tournament where tournament_id = 3;
delete from Tournament where tournament_id = 4;
delete from Tournament where tournament_id = 5;
delete from Tournament where tournament_id = 6;
delete from Tournament where tournament_id = 7;
delete from Tournament where tournament_id = 8;
delete from Tournament where tournament_id = 9;
delete from Tournament where tournament_id = 13;
*/

SELECT sb.scoreboard_id, t.tournament_name, s.sport_name, sb.team1_name, sb.team1_score, sb.team2_name, sb.team2_score, sb.result 
FROM Scoreboard sb
JOIN Tournament_Sport ts ON sb.tournament_sport_id = ts.id
JOIN Tournament t ON ts.tournament_id = t.tournament_id
JOIN Sports s ON ts.sport_id = s.sport_id;

CREATE TABLE Player (
  player_id INT IDENTITY (1,1) PRIMARY KEY,
  player_name VARCHAR(50) NOT NULL,
  player_email VARCHAR(50) NOT NULL,
  player_phone VARCHAR(20) NOT NULL,
  player_college VARCHAR(50) NOT NULL
);


CREATE TABLE Team (
  team_id INT IDENTITY (1,1) PRIMARY KEY,
  team_name VARCHAR(50) NOT NULL,
  Tournament_Sport_id INT NOT NULL,
  player_id INT NOT NULL,
  FOREIGN KEY (Tournament_Sport_id) REFERENCES Tournament_Sport(id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  FOREIGN KEY (player_id) REFERENCES Player(player_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);


INSERT INTO Player (player_name, player_email, player_phone, player_college)
VALUES
  ('John Doe', 'johndoe@example.com', '555-1234', 'ABC College'),
  ('Jane Smith', 'janesmith@example.com', '555-5678', 'XYZ University'),
  ('Mike Johnson', 'mikejohnson@example.com', '555-9876', 'LMN College');

  INSERT INTO Player (player_name, player_email, player_phone, player_college)
VALUES
('Sara Smith', 'sara.smith@example.com', '123-456-7890', 'ABC College'),
('John Doe', 'john.doe@example.com', '987-654-3210', 'XYZ University'),
('Jessica Lee', 'jessica.lee@example.com', '555-123-4567', 'DEF College'),
('David Kim', 'david.kim@example.com', '111-222-3333', 'GHI University'),
('Emily Chang', 'emily.chang@example.com', '444-555-6666', 'JKL College'),
('Michael Brown', 'michael.brown@example.com', '777-888-9999', 'MNO University');

  INSERT INTO Tournament_Sport_player ( Tournament_Sport_id, player_id)
VALUES
( 1, 1),
( 1, 2),
( 1, 3),
( 1, 4),
(2, 5),
( 2, 6),
( 2, 7),
( 1, 8);

CREATE TABLE Tournament_Sport_player (
  team_id INT IDENTITY (1,1) PRIMARY KEY,
  Tournament_Sport_id INT NOT NULL,
  player_id INT NOT NULL,
  FOREIGN KEY (Tournament_Sport_id) REFERENCES Tournament_Sport(id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  FOREIGN KEY (player_id) REFERENCES Player(player_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

select * from Tournament_Sport_player;
