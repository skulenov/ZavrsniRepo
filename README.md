# ZavrsniRepo
Repozitorij Zavrsnog rada

ArduinoUno vanjska jedinica sa senzorom za temperaturu i vlagu DHT11 za registriranje istih, te ESP01-S WiFi modul za komunikaciju sa serverskom aplikacijom putem TCP/IP protokola radi prijenosa očitanih vrijednosti na serversku aplikaciju.

Serverska aplikacija (BaseApp) pisana je u C# jeziku, a upravljački program na Arduinu pisan je u Arduino optimiziranoj inačici C++ jezika.

Arduino upravljački program još nije prilagođen da pakira podatke sa senzora po "protokolu" po kojem ih serverska aplikacija očekuje ali je funkcionalan u smislu da je moguće pročitati te iste podatke na http adresi ESP01-S modula (IP adresa na kojoj se prijavljuje na WiFi router odnosno lokalnu mrežu).
Ovo je moguće zato što upravljački program na HTTP GET request odgovara sa stringom koji sadrži http stranicu koja sadrži XML prikaz očitanih podataka.
Ova funkcionalnost ugrađena je u fazi testiranja radi lakšeg praćenja ponašanja upravljačkog programa i pojedinih njegovih funkcionlanosti.

Serverska aplikacija (BaseApp) ima ugrađenu funkcionalnost generiranja "dummy" datoteka sa sadržajem podataka u obliku u kojem ih aplikacija može parsirati i prikazati u obliku grafa vrijednosti iznosa očitanih veličina u vremenu (FGenForm - Files Generator).

Oblik zapisa podataka u kojem ih aplikacija prima je niz bajtova dužine 6 sa definiranim značenjem svake pozicije u nizu:
===================================================
poz 0 = data start check byte, value = (byte)204
poz 1 = id byte, value = (byte)'@'
poz 2 = temperature, value min,max = (byte)(0,255)
poz 3 = humidity, value min,max = (byte)(0,255)
poz 4 = light, value min,max = (byte)(0,255)
poz 5 = data end check byte, value = (byte)185
===================================================

Upravljački program će periodički ostvarivati TCP/IP konekciju na serversku aplikaciju, poslati paket podataka i odspojiti se.

Serverska aplikacija neprestano osluškuje na dolazne konekcije i po uspješnom ostvarenju iste, prima podatke, provjerava integritet istih i ukoliko su ispravni zapisuje ih na disk sa informacijom o trenutnom vremenu (na serveru).

Osim logiranja podataka, serverska aplikacija ima funkcionalnost za prikaz prethodno spremljenih ili generiranih datoteka sa podacima u obliku grafova u vremenu.

Pojedini graf se može spremiti kao slikovna datoteka u *.PNG formatu.

Projekt je još u fazi izrade.


Autor: Sead Kulenović
