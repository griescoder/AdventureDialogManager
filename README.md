@'
# Adventure Dialog Manager

## Projektbeschreibung

Der Adventure Dialog Manager ist eine CRUD-Anwendung zur Verwaltung von Dialogen für ein kleines Adventure-Spiel.

## Technologien

- Unity 6
- C#
- SQLite
- Unity UI und TextMeshPro

## Funktionen

- Dialoge erstellen (Create)
- Dialoge anzeigen (Read)
- Dialoge bearbeiten (Update)
- Dialoge löschen (Delete)
- Dialoge dauerhaft in einer SQLite-Datenbank speichern
- Gespeicherte Dialoge in der Spielszene anzeigen

## Architektur

Die Anwendung ist nach einem Schichtenmodell aufgebaut:

- **DialogManagerUI:** Benutzeroberfläche und Eingaben
- **DialogService:** Vermittlung der Anwendungslogik
- **DialogRepository:** Datenbankzugriff
- **DialogEntry:** Datenmodell für einen Dialogeintrag

## Datenbank

Die Anwendung verwendet SQLite. Die Tabelle `DialogEntries` enthält die Felder `Id`, `CharacterName`, `Text` und `Condition`.

Die Laufzeitdatenbank wird unter `Application.persistentDataPath` gespeichert. Eine Beispieldatenbank liegt im Projekt unter `Database/dialogs.db`.

## Projekt starten

1. Das Repository klonen.
2. Das Projekt im Unity Hub öffnen.
3. Eine kompatible Unity-Version verwenden.
4. Die Szene `MainMenu` starten.

## Testen

1. Einen Dialog hinzufügen.
2. Die Liste aktualisieren und den Eintrag prüfen.
3. Den Dialog anhand seiner ID bearbeiten.
4. Die Änderung überprüfen.
5. Einen Testdialog löschen.

## Projektziel

Ziel war die Entwicklung einer funktionsfähigen CRUD-Anwendung mit SQLite und einer Trennung der Verantwortlichkeiten.

## UML-Klassendiagramm

Das folgende Klassendiagramm veranschaulicht die Struktur des AdventureDialogManager-Projekts und die Beziehungen zwischen den Klassen.

'@ | Set-Content -Encoding utf8 README.md

