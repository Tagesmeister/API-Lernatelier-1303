# Projekt-Dokumentation



Pascal Oestrich, Stefan Jesenko

| Datum | Version | Zusammenfassung                                              |
| ----- | ------- | ------------------------------------------------------------ |
|    19.01.2024   | 0.0.1   |               |
|    02.02.2024   | 0.0.2   |               |
|    26.01.2024   | 0.0.3   |              |
|    23.02.2024   | 0.0.4   |              |


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

✍️Fügen Sie hier ein Use Case-Diagramm mit mindestens 3 Anwendungsfällen ein; und eine Skizze davon, wie Ihre Netzseite aussehen sollte.

## 2 Planen

| AP-№ | Frist | Zuständig | Beschreibung | geplante Zeit |
| ---- | ----- | --------- | ------------ | ------------- |
| 1.A  |       |           |              |               |
| ...  |       |           |              |               |

Total: 

✍️ Die Nummer hat das Format `N.m`, wobei `N` die Nummer der User Story ist, auf die sich das Arbeitspaket bezieht, und `m` von `A` an nach oben buchstabiert. Beispiel: Das dritte Arbeitspaket, das die zweite User Story betrifft, hat also die Nummer `2.C`.

✍️ Ein Arbeitspaket sollte etwa 45' für eine Person in Anspruch nehmen. Die totale Anzahl Arbeitspakete sollte etwa Folgendem entsprechen: `Anzahl R-Sitzungen` ╳ `Anzahl Gruppenmitglieder` ╳ `4`. Wenn Sie also zu dritt an einem Projekt arbeiten, für welches zwei R-Sitzungen geplant sind, sollten Sie auf `2` ╳ `3` ╳`4` = `24` Arbeitspakete kommen. Sollten Sie merken, dass Sie hier nicht genügend Arbeitspakte haben, denken Sie sich weitere "Kann"-User Stories für Kapitel 1.2 aus.

## 3 Entscheiden

✍️ Dokumentieren Sie hier Ihre Entscheidungen und Annahmen, die Sie im Bezug auf Ihre User Stories und die Implementierung getroffen haben.

## 4 Realisieren

| AP-№ | Datum | Zuständig | geplante Zeit | tatsächliche Zeit |
| ---- | ----- | --------- | ------------- | ----------------- |
| 1.A  |       |           |               |                   |
| ...  |       |           |               |                   |

✍️ Tragen Sie jedes Mal, wenn Sie ein Arbeitspaket abschließen, hier ein, wie lang Sie effektiv dafür hatten.

## 5 Kontrollieren

| TC-№ | Datum | Resultat | Tester |
| ---- | ----- | -------- | ------ |
| 1.1  |       |          |        |
| ...  |       |          |        |

✍️ Vergessen Sie nicht, ein Fazit hinzuzufügen, welches das Test-Ergebnis einordnet.

## 6 Auswerten

✍️ Fügen Sie hier eine Verknüpfung zu Ihrem Lern-Bericht ein.
