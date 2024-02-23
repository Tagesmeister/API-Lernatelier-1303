# Projekt-Dokumentation



Pascal Oestrich, Stefan Jesenko

| Datum | Version | Zusammenfassung                                              |
| ----- | ------- | ------------------------------------------------------------ |
|    19.01.2024   | 0.0.1   |   Registrierung und SQLlight-Datenbank aufgesetzt            |
|    02.02.2024   | 0.0.2   |     Login und CRUD-Manipulationen realisiert          |
|    26.01.2024   | 0.0.3   |     Datenbank in C# im Programm implementiert und CRUD für Datenmanipulation modifiziert        |
|    23.02.2024   | 1.0.0   |    Gedebugged und Codebereinigt, das Programm getestet          |


## 1 Informieren

### 1.1 Ihr Projekt

Wir machen eine API auf der man Personen speichern kann. die Daten werden in einer Sqlite DB gespeichert.

Wir möchten eine API machen in der man Benutzer speichern kann, die Daten der Benutzer sollen Passwort geschützt sein.
Man kann Vor- und Nachname, Alter, Email und Passwort eingeben. Das Passwort wird Verschlüsselt und als Hashcode abgelegt.
Man kann sich mit der Email und dem Passwort anmelden um die anderen Daten zu erhalten. 

### 1.2 User Stories

| US-№ | Verbindlichkeit | Typ  | Beschreibung                       |
| ---- | --------------- | ---- | ---------------------------------- |
| 1    |Muss|Funktional|Als User möchte ich einen neue Person hinzufügen können, damit ich die API verwenden kann um meine Personen liste zu kreieren.|
| 2    |Muss|Funktional|Als User möchte ich einen User Updaten können, damit die Daten akutell bleiben.|
| 3    |Muss|Funktional|Als User möchte ich einen User Löschen können, damit ich User die es nicht mehr braucht entfernen kann.|
| 4    |Muss|Funktional|Als User möchte ich das Daten aus der Datenbank ausgegeben werden, damit ich sehen kann welche User in meiner Datenbank sind.|
| 5    |Muss|Funktional|Als User möchte ich, dass man sich einloggen muss um Daten auszugeben, damit nicht jeder einfach die privaten Daten einsehen kann.|
| 6    |Muss|Funktional|Als User möchte ich, dass man sich einloggen muss um Daten zu bearbeiten, damit keiner Daten manipulieren kann der nicht die berechtigung dafür hat.|
| 7    |Muss|Funktional|Als User möchte ich, dass man sich einloggen muss um Daten zu Löschen, damit keiner Daten manipulieren kann der nicht die berechtigung dafür hat.|



### 1.3 Testfälle

| TC-№ | Ausgangslage | Eingabe | Erwartete Ausgabe |
| ---- | ------------ | ------- | ----------------- |
| 1.1  |API wurde gestartet|register Request({"FirstName": "Hans","SecondName": "Peter","EMail": "Hans.Peter@gmail.com","Age": 45,"Password": "123","UserName": "SuperHans"}|200 OK({"id":0,"firstName":"Hans","secondName":"Peter","eMail":"Hans.Peter@gmail.com","age":45,"password":"123","userName":"SuperHans"}))|
| 2.1  |User wurde der API hinzugefügt|{"FirstName": "Hans","SecondName": "Müller","EMail": "Hans.Müller@gmail.com","Age": 45,"Password": "123","UserName": "SuperHans"}|200 OK({"id":0,"firstName":"Hans","secondName":"Müller","eMail":"Hans.Müller@gmail.com","age":45,"password":"123","userName":"SuperHans"})|
| 3.1  |User wurde der API hinzugefügt|{"id":1}| 201 OK ({"id":1,"firstName":"Hans","secondName":"Peter","eMail":"Hans.Peter@gmail.com","age":45, "password":"123","userName":"SuperHans"}))|
| 4.1 | API wurde gestartet, User ist angemeldet | GETall-Request | 200 OK ({"id":1,"firstName":"Olaf","secondName":"Scholz","eMail":"Olaf.Scholz@gmail.com","age":26,"password":"Olfaf","userName":"Bundeskanzler"}({"id":2,"firstName":"Hans","secondName":"Peter","eMail":"Hans.Peter@gmail.com","age":45,"password":"123","userName":"SuperHans"})) |
| 5.1 | API gestartet ohne anmeldung | GETall-Request | 401 Badrequest |
| 5.2 | API gestartet angemeldet | GETall-Request | 200 OK ({"id":1,"firstName":"Olaf","secondName":"Scholz","eMail":"Olaf.Scholz@gmail.com","age":26,"password":"Olfaf","userName":"Bundeskanzler"}({"id":2,"firstName":"Hans","secondName":"Peter","eMail":"Hans.Peter@gmail.com","age":45,"password":"123","userName":"SuperHans"}))|
| 6.1 | API gestartet ohne anmeldung | PUT-Request ({"id":1,"firstName":"Olaf","secondName":"Brieder","eMail":"Olaf.Brieder@gmail.com","age":30,"password":"Olfaf","userName":"Bundeskanzler"}) | 401 Badrequest |
| 6.2 | API gestartet angemeldet | PUT-Request ({"id":1,"firstName":"Olaf","secondName":"Brieder","eMail":"Olaf.Brieder@gmail.com","age":30,"password":"Olfaf","userName":"Bundeskanzler"}) | 200 OK |
| 7.1 |API gestartet ohne anmledung |Delete-Request {"id":1} | 401 Badrequest |
| 7.2 |API gestartet angemeldet |Delete-Request {"id":1} | 200 OK |


### 1.4 Diagramme

![image](https://github.com/Tagesmeister/API-Lernatelier-1303/assets/110892258/db81583c-daac-4d88-b5bb-020fecd19616)


## 2 Planen

| AP-№ | Frist | Zuständig | Beschreibung | geplante Zeit |
| ---- | ----- | --------- | ------------ | ------------- |
| 1.A  |  19.01.2024     |     Oestrich      |     Registrieren realisieren         |      2         |
| 2.A  |   19.01.2024    |    Jesenko       |     SQLLightdatenbank aufsetzten         |        1.5       |
| 3.A  |  02.02.2024   |  Oestrich   |     Login        |      2        |
| 4.A  |   02.02.2024  |  Jesenko   |       CRUD-Manipulationen      |     1.5        |
| 5.A  |  26.02.2024   |   Oestrich  |       Datenbank in C# im Programm implementieren      |       3       |
| 6.A  |   26.02.2024  |  Jesenko  |   CRUD für Datenmanipulation modifizieren         |       3       |
| 7.A  |  23.02.2024    |   Jesenko  |  Debuggen           |        1      |
| 7.B  |  23.02.2024   |   Oestrich  |    Code berreinigung         |      1        |

Total: 15 * 45 min = 675 min --> 11.25 h

## 3 Entscheiden

Wir werden nach Planung vorgehen, je nach Know-how wird es von der Planung abweichen.

## 4 Realisieren

| AP-№ | Datum | Zuständig | geplante Zeit | tatsächliche Zeit |
| ---- | ----- | --------- | ------------- | ----------------- |
| 1.A  |   19.01.2024   |      Oestrich     |       2 |  2   |
| 2.A  |   19.01.2024    |    Jesenko       |     1.5 |  1.8   |
| 3.A  |   02.02.2024    |     Oestrich      |      2 |  2   |
| 4.A  |   02.02.2024    |      Jesenko     |     1.5 |   1.75  |
| 5.A  |   26.02.2024    |      Oestrich     |      3 |   4  |
| 6.A  |   26.02.2024    |     Jesenko      |       3 |   3  |
| 7.A  |   23.02.2024    |      Jesenko     |       1 |   1  |
| 7.B  |   23.02.2024   |       Oestrich    |       1 |   1  |


## 5 Kontrollieren

| TC-№ | Datum | Resultat | Tester |
| ---- | ----- | -------- | ------ |
| 1.1  |   23.02.2024    |    OK      |    Jesenko    |
| 2.1  |   23.02.2024    |      OK    |    Jesenko    |
|  3.1 |   23.02.2024    |        OK  |    Jesenko    |
| 4.1  |   23.02.2024    |     OK     |   Jesenko     |
| 5.1  |   23.02.2024    |      OK    |    Jesenko    |
| 5.2  |  23.02.2024     |        OK  |    Jesenko    |
|  6.1 |   23.02.2024    |      OK    |   Jesenko     |
|  6.2 |  23.02.2024     |        OK  |    Jesenko    |
|  7.1 |   23.02.2024    |       OK   |    Jesenko    |
| 7.1  |   23.02.2024    |         OK |    Jesenko    |

Alle Tesfälle hatten ein psotives Ergebniss, die API läuft und ist fertiggestellt.

## 6 Mahara Links

Pascal Oestrich:

Stefan Jesenko:
