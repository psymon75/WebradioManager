-- Creator:       MySQL Workbench 6.0.7/ExportSQLite plugin 2009.12.02
-- Author:        MENETREYS_INFO
-- Caption:       New Model
-- Project:       Name of the project
-- Changed:       2014-04-07 10:39
-- Created:       2014-04-01 15:36
PRAGMA foreign_keys = OFF;

-- Schema: webradiomanager
BEGIN;
CREATE TABLE "twebradio"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(255)
);
CREATE TABLE "tcalendar"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "filename" TEXT,
  "webradioid" INTEGER NOT NULL,
  CONSTRAINT "fk_tcalendar_twebradio1"
    FOREIGN KEY("webradioid")
    REFERENCES "twebradio"("id")
);
CREATE INDEX "tcalendar.fk_tcalendar_twebradio1_idx" ON "tcalendar"("webradioid");
CREATE TABLE "tgender"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(45)
);
CREATE TABLE "taudiotype"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(45)
);
CREATE TABLE "tstreamtype"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(10)
);
CREATE TABLE "tserver"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "webradioid" INTEGER NOT NULL,
  "port" INTEGER,
  "logfilename" TEXT,
  "configfilename" TEXT,
  "password" VARCHAR(255),
  "adminpassword" VARCHAR(255),
  CONSTRAINT "fk_tserver_twebradio1"
    FOREIGN KEY("webradioid")
    REFERENCES "twebradio"("id")
);
CREATE INDEX "tserver.fk_tserver_twebradio1_idx" ON "tserver"("webradioid");
CREATE TABLE "tmusic"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "filename" TEXT,
  "title" VARCHAR(255),
  "artist" VARCHAR(255),
  "album" VARCHAR(255),
  "year" YEAR,
  "label" VARCHAR(45),
  "duration" TIME,
  "genderid" INTEGER NOT NULL,
  "typeid" INTEGER NOT NULL,
  CONSTRAINT "fk_tmusic_tgender1"
    FOREIGN KEY("genderid")
    REFERENCES "tgender"("id"),
  CONSTRAINT "fk_tmusic_ttype1"
    FOREIGN KEY("typeid")
    REFERENCES "taudiotype"("id")
);
CREATE INDEX "tmusic.fk_tmusic_tgender1_idx" ON "tmusic"("genderid");
CREATE INDEX "tmusic.fk_tmusic_ttype1_idx" ON "tmusic"("typeid");
CREATE TABLE "tplaylist"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(255),
  "filename" TEXT,
  "webradioid" INTEGER NOT NULL,
  "typeid" INTEGER NOT NULL,
  CONSTRAINT "fk_tplaylist_twebradio1"
    FOREIGN KEY("webradioid")
    REFERENCES "twebradio"("id"),
  CONSTRAINT "fk_tplaylist_tplaylisttype1"
    FOREIGN KEY("typeid")
    REFERENCES "taudiotype"("id")
);
CREATE INDEX "tplaylist.fk_tplaylist_twebradio1_idx" ON "tplaylist"("webradioid");
CREATE INDEX "tplaylist.fk_tplaylist_tplaylisttype1_idx" ON "tplaylist"("typeid");
CREATE TABLE "tplaylist_has_music"(
  "playlistid" INTEGER NOT NULL,
  "musicid" INTEGER NOT NULL,
  CONSTRAINT "fk_tplaylist_has_music_tplaylist"
    FOREIGN KEY("playlistid")
    REFERENCES "tplaylist"("id"),
  CONSTRAINT "fk_tplaylist_has_music_tmusic1"
    FOREIGN KEY("musicid")
    REFERENCES "tmusic"("id")
);
CREATE INDEX "tplaylist_has_music.fk_tplaylist_has_music_tplaylist_idx" ON "tplaylist_has_music"("playlistid");
CREATE INDEX "tplaylist_has_music.fk_tplaylist_has_music_tmusic1_idx" ON "tplaylist_has_music"("musicid");
CREATE TABLE "tcalendarevent"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(45),
  "starttime" VARCHAR(45),
  "duration" VARCHAR(45),
  "repeat" INTEGER,
  "priority" INTEGER,
  "shuffle" BOOL,
  "loopatend" BOOL,
  "calendarid" INTEGER NOT NULL,
  "playlistid" INTEGER NOT NULL,
  CONSTRAINT "fk_tcalendarevent_tcalendar1"
    FOREIGN KEY("calendarid")
    REFERENCES "tcalendar"("id"),
  CONSTRAINT "fk_tcalendarevent_tplaylist1"
    FOREIGN KEY("playlistid")
    REFERENCES "tplaylist"("id")
);
CREATE INDEX "tcalendarevent.fk_tcalendarevent_tcalendar1_idx" ON "tcalendarevent"("calendarid");
CREATE INDEX "tcalendarevent.fk_tcalendarevent_tplaylist1_idx" ON "tcalendarevent"("playlistid");
CREATE TABLE "ttranscoder"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "webradioid" INTEGER NOT NULL,
  "streamtypeid" INTEGER NOT NULL,
  "bitrate" INTEGER,
  "samplerate" INTEGER,
  "name" VARCHAR(255),
  "url" TEXT,
  "ip" VARCHAR(45),
  "port" INTEGER,
  "password" VARCHAR(255),
  "configfilename" TEXT,
  "logfilename" TEXT,
  CONSTRAINT "fk_ttranscoder_twebradio1"
    FOREIGN KEY("webradioid")
    REFERENCES "twebradio"("id"),
  CONSTRAINT "fk_ttranscoder_tstreamtype1"
    FOREIGN KEY("streamtypeid")
    REFERENCES "tstreamtype"("id")
);
CREATE INDEX "ttranscoder.fk_ttranscoder_twebradio1_idx" ON "ttranscoder"("webradioid");
CREATE INDEX "ttranscoder.fk_ttranscoder_tstreamtype1_idx" ON "ttranscoder"("streamtypeid");
CREATE TABLE "thistory"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "date" DATE,
  "musicid" INTEGER NOT NULL,
  "transcoderid" INTEGER NOT NULL,
  CONSTRAINT "fk_thistory_tmusic1"
    FOREIGN KEY("musicid")
    REFERENCES "tmusic"("id"),
  CONSTRAINT "fk_thistory_ttranscoder1"
    FOREIGN KEY("transcoderid")
    REFERENCES "ttranscoder"("id")
);
CREATE INDEX "thistory.fk_thistory_tmusic1_idx" ON "thistory"("musicid");
CREATE INDEX "thistory.fk_thistory_ttranscoder1_idx" ON "thistory"("transcoderid");
COMMIT;
