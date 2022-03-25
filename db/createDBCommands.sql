CREATE TABLE users ( user_id serial PRIMARY KEY );
CREATE TABLE IF NOT EXISTS relationships (user_id INT NOT NULL, assignee_id INT NOT NULL, closeness INT NOT NULL, PRIMARY KEY (user_id, assignee_id), FOREIGN KEY (user_id) REFERENCES users (user_id), FOREIGN KEY (assignee_id) REFERENCES users (user_id));
