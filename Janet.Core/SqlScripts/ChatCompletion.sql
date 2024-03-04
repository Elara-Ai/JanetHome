CREATE TABLE ChatCompletion (
                                Id TEXT PRIMARY KEY,
                                Object TEXT NOT NULL,
                                Created BIGINT NOT NULL,
                                Model TEXT NOT NULL,
                                SystemFingerprint TEXT
);

CREATE TABLE PromptFilterResult (
                                    ChatCompletionId TEXT REFERENCES ChatCompletion(Id) PRIMARY KEY,
                                    PromptIndex INTEGER NOT NULL
);

CREATE TABLE ContentFilterResults (
                                      PromptFilterResultId TEXT REFERENCES PromptFilterResult(ChatCompletionId, PromptIndex) PRIMARY KEY,
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
                        Index INTEGER NOT NULL,
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