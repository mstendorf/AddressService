# AddressService

## Kør appen
Den er skrevet i dotnet core, så naviger til projektet i en cli og skrive "dotnet run"
Derefter kan servicen testes via /swagger endpointet der stilles til rådighed.

Jeg vil tro den også kan køres via visual studio og den grønne play knap.

## Screenshot
![AddressService running](https://github.com/mstendorf/AddressService/blob/main/AddressService.jpg?raw=true)

## Disclaimers
Jeg har været lidt presset på tid, så jeg er sprunget over hvor gærdet er lavest ift. parsing af filen.
Det gav ikke mening for mig at bruge tiden på at parse alle detaljerne i filen korrekt ud, så jeg lavede en letvægtsudgave
der henter det mest essentielle.

Planen var egentlig at have en consol applikation der parsede data fra filen ind i en sqlite database og api'et
så hentede sine data derfra. Det ville have performet noget bedre, men jeg rendte i problemer med at sqlite NuGet pakken
ikke virkede på Mac og det havde jeg ikke lige tiden til at bøvle med.

Det er lidt en elendig løsning det her, men det virker :)
