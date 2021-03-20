USE commandapi;
-- ----------------------------------------------------------------------------------
-- Create initial cmd info table
-- ----------------------------------------------------------------------------------
CREATE TABLE commands
(
	id INT NOT NULL AUTO_INCREMENT,
	description VARCHAR(255) NOT NULL,
	platform VARCHAR(50) NOT NULL,
	command_line VARCHAR(50) NOT NULL,
    
    CONSTRAINT pk_cmd PRIMARY KEY (id)
);