CREATE TABLE UserProfile (
                             Id INTEGER PRIMARY KEY AUTOINCREMENT,
                             Name TEXT NOT NULL,
                             Email TEXT NOT NULL UNIQUE,
                             Username TEXT NOT NULL UNIQUE,
                             Nickname TEXT
);