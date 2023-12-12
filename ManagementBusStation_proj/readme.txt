
                                                                                                                                     PROJECT "MANAGEMENT OF BUS STATION"

Projekat "Management of Bus Station" ili "Upravljanje autobuskom stanicom" je projekat baziran na .NET programskom jeziku C#.
Namjena ovog projekta je predviđena za pravilno funkcionisanje sistema upravljanja autobuskom stanicom.
On je zasnovan na MVC patternu.
Definisane tabele baze podataka "Management Bus Station" su:
     1. Table TicketSales (Tabela prodaje autobuskih karti)
     2. Table EmployeeTypes (Tabela tipova zaposlenika)
     3. Table Employees (Tabela zaposlenika autobuske stanice)
     4. Table Buses (Tabela autobusa)
     5. Table BusLines (Tabela autobuskih linija)
     6. Table TicketSalesByBusLines (Tabela prodaje autobuskih karti po autobuskim linijama)
Sve ove tabele (objekti) baze podataka su mapirane u njima odgovarajuće klase entitetskog modela podataka tako da te klase nose naziv po tipu modela podataka enitetske klase.


                                                                                                                SPECIFIČNOSTI PROJEKTA "UPRAVLJANJE AUTOBUSKOM STANICOM"

C# projekat "Upravljanje autobuskom stanicom" posjeduje formu za prijavu (logovanje) zaposlenika autobuske stanice.
Nakon uspješnog logovanja zaposlenika tipa administrator automatski se otvara stranica za prikaz forme čija je svrha rezervacija autobuskih karti.
Nakon uspješnog logovanja zaposlenika tipa korisnik automatski se otvara stranica za prikaz forme koja izvršava rezervaciju autobuskih linija.
Prilikom prijave administratora u navigacionom dijelu stranice dostupni su mu sljedeći linkovi:
     1. Link za prikazivanje liste zaposlenika autobuske stanice 
     2. Link za prikazivaje liste autobusa
     3. Link za prikazivanje liste autobuskih linija
     4. Link za obavještavanje polazaka autobusa
     5. Link za obavještavanje dolazaka autobusa
     6. Link za odjavu na stranicu za prijavu (logovanje) zaposlenika autobuske stanice 
Prilikom prijave korisnika u navigacionom dijelu stranice dostupni su mu sljedeći linkovi:
     1. Link za prikazivanje liste autobusa
     2. Link za prikazivanje liste autobuskih linija
     3. Link za obavještavanje polazaka autobusa
     4. Link za obavještavanje dolazaka autobusa
     5. Link za odjavu na stranicu za prijavu (logovanje) zaposlenika autobuske stanice 
Dodatno, u navigacionom dijelu stranice na lijevoj strani nalazi se naziv ulogovanog zaposlenika (administrator ili korisnik) koji se pojavljuje na navedenom mjestu nakon uspješne prijave zaposlenika.
Ovaj C# projekat pored stranice za prikaz liste zaposlenika autobuske stanice sadrži sljedeće stranice:
     1. Stranicu za prikaz forme koja izvršava registraciju zaposlenika
     2. Stranicu za prikaz forme koja izvršava ažuriranje novih (promjenu) zaposlenika
     3. Stranicu za prikaz forme koja izvršava uklanjanje postojećih zaposlenika
Projekat pored stranice za prikaz liste autobusa sadrži i dodatne stranice:
     1. Stranicu za prikaz forme koja izvršava rezervaciju autobusa
     2. Stranicu za prikaz forme čija je svrha ažuriranje novih (promjena) autobusa
     3. Stranicu za prikaz forme čija je svrha uklanjanje postojećih autobusa
Za uredno funkcionisanje autobuskih linija projekat pored stranice za prikaz liste autobuskih linija sadrži i dodatne stranice:
     1. Stranicu za prikaz forme koja izvršava rezervaciju autobuskih linija
     2. Stranicu za prikaz forme čija je svrha ažuriranje novih (promjena) autobuskih linija
     3. Stranicu za prikaz forme čija je svrha uklanjanje postojećih autobuskih linija
On je baziran na definisanju sprječavanja (prevencije) pristupa svim stranicama bez prethodne prijave (logovanja) zaposlenika (administrator ili korisnik) tj. pristup ovim stranicama je strogo uvjetovan (ispravnom) prijavom na stranici za logovanje zaposlenika.
Posjeduje i definisanu enkripciju šifri (passwords) svih zaposlenika autobuske stanice u bazi podataka u cilju zaštite povjerljivosti podataka. 
 
 









 