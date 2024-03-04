DROP TABLE IF EXISTS Usage;
DROP TABLE IF EXISTS Message;
DROP TABLE IF EXISTS Choice;
DROP TABLE IF EXISTS FilterResult;
DROP TABLE IF EXISTS ContentFilterResults;
DROP TABLE IF EXISTS PromptFilterResult;
DROP TABLE IF EXISTS ChatCompletion;

CREATE TABLE ChatCompletion (
                                Id TEXT PRIMARY KEY,
                                Object TEXT NOT NULL,
                                Created BIGINT NOT NULL,
                                Model TEXT NOT NULL,
                                SystemFingerprint TEXT
                            );

CREATE TABLE PromptFilterResult (
                                    ChatCompletionId TEXT,
                                    PromptIndex INTEGER NOT NULL,
                                    Id TEXT PRIMARY KEY -- Add this line,
);

CREATE TABLE ContentFilterResults (
                                      PromptFilterResultId TEXT REFERENCES PromptFilterResult(Id) PRIMARY KEY, -- Modify this line
                                      HateFilterResultId INTEGER NOT NULL REFERENCES FilterResult(Id),
                                      SelfHarmFilterResultId INTEGER NOT NULL REFERENCES FilterResult(Id),
                                      SexualFilterResultId INTEGER NOT NULL REFERENCES FilterResult(Id),
                                      ViolenceFilterResultId INTEGER NOT NULL REFERENCES FilterResult(Id)
);

CREATE TABLE FilterResult (
                              Id INTEGER PRIMARY KEY AUTOINCREMENT,
                              Filtered BOOLEAN NOT NULL,
                              Severity TEXT NOT NULL
                           );

CREATE TABLE Choice (
                        ChatCompletionId TEXT REFERENCES ChatCompletion(Id) PRIMARY KEY,
                        FinishReason TEXT,
                        MessageId INTEGER REFERENCES Message(Id)
                    );

CREATE TABLE Message (
                         Id INTEGER PRIMARY KEY AUTOINCREMENT,
                         Role TEXT NOT NULL,
                         Content TEXT NOT NULL
                     );

CREATE TABLE Usage (
                       ChatCompletionId TEXT REFERENCES ChatCompletion(Id) PRIMARY KEY,
                       PromptTokens INTEGER NOT NULL,
                       CompletionTokens INTEGER NOT NULL,
                       TotalTokens INTEGER NOT NULL
                   );