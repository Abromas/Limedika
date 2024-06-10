# Web aplikacija klientų tvarkymui [LT]
## Užduoties aprašymas
### Duotą JSON tekstą išsisaugokite į failą `klientai.json`:

```json
[
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 2","Address":"Liepų al. 3-1B, Panevėžys","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 3","Address":"Varnių g. 39-9, Kaunas","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 5","Address":"Švenčionių g. 36-2, Nemenčinė, Vilniaus r. sav.","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 7","Address":"Vilniaus g. 220, Šiauliai","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 10","Address":"Baltų pr. 7A-1, Kaunas","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 9","Address":"Vytenio g. 16, Prienai","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 11","Address":"Livonijos g. 5, Joniškis","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 16","Address":"Šiltnamių g. 29, Vilnius","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 18","Address":"Kniaudiškių g. 6, Panevėžys","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 20","Address":"Nemuno g. 70, Panevėžys","PostCode":""}
]
```
### Sukurkite WEB aplikaciją su funkcijomis `Importuoti klientus`, `Atnaujinti pašto indeksus`, `Klientų sąrašas`.
`„Importuoti klientus“` - iš duoto JSON failo reikia į MSSQL duomenų bazę išsaugoti klientų sąrašą (vengti duomenų sudubliavimo).
`„Atnaujinti pašto indeksus“` - iš postit.lt puslapio pagal kliento adresą surasti pašto indeksą ir išsaugoti duomenų bazėje. 

Postit.lt užklausos pavyzdys:
https://api.postit.lt/?term=Savanorių+12,+Vilnius&key=postit.lt-examplekey

Naudojimo instrukcija adresu https://postit.lt/API/

`„Klientų sąrašas“` – atidaro langą, kuriame rodome klientų sąrašą (iš duomenų bazės).

### Duomenų bazėje padaryti log lentą
kurioje matytųsi atliktų veiksmų istorija – kada sukurtas kliento įrašas, kada atnaujintas pašto indeksas ir t.t.
 
Prisijungimas prie duomenų bazės, postit užklausos adresas, postit key turi būti valdomi per konfigūraciją.

### Darbo rezultatas
programos kodo failai ir duomenų bazės struktūros skriptas.

# Web Application for Managing Clients [EN]

## Task Description

### Save the given JSON text into a file named `clients.json`:

```json
[
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 2","Address":"Liepų al. 3-1B, Panevėžys","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 3","Address":"Varnių g. 39-9, Kaunas","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 5","Address":"Švenčionių g. 36-2, Nemenčinė, Vilniaus r. sav.","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 7","Address":"Vilniaus g. 220, Šiauliai","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 10","Address":"Baltų pr. 7A-1, Kaunas","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 9","Address":"Vytenio g. 16, Prienai","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 11","Address":"Livonijos g. 5, Joniškis","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 16","Address":"Šiltnamių g. 29, Vilnius","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 18","Address":"Kniaudiškių g. 6, Panevėžys","PostCode":""},
    {"Name":"UAB \"Gintarinė vaistinė\" fil. nr. 20","Address":"Nemuno g. 70, Panevėžys","PostCode":""}
]
```
## Create a web application with the following functionalities:

`Import Clients`: Save the client list from the given JSON file into an MSSQL database (avoid data duplication).

`Update Postal Codes`: Fetch the postal code from postit.lt based on the client's address and save it into the database.

Example request:
https://api.postit.lt/?term=Savanorių+12,+Vilnius&key=postit.lt-examplekey

Usage instructions available at: postit.lt API

`Client List`: Open a window displaying the list of clients (from the database).

### Database Requirements:

Implement a log table to record the history of actions performed:
When a client record is created
When a postal code is updated
Etc.

### Configuration:

Database connection
Postit request URL
Postit key

These should be managed through configuration.

### Deliverables:

Program code files
Database structure script


# Project `Prerequisites`
*`VS 2022`
*`.SQL Server (2019)`
*`.Net 8`
*`NodeJS`

## Steps to run locally

#### #1 Copy Repo
#### #2 Restore Nugets
#### #3 Using PS/CMD navigate to `wwwroot\npmJS` and run 
  `npm install`
  `npm run build` 
#### #4 Set your credentials in AppSettings/AzureKeyVault
#### #5 `dotnet ef database update` to create and apply DB migrations

# Application Screens

`/Home`
![image](https://github.com/Abromas/Limedika/assets/37139146/bf7c7620-7c09-4d43-a294-8c0e23ef633d)

`/clients`
![image](https://github.com/Abromas/Limedika/assets/37139146/382c0985-43ab-49e4-8b5c-c882ca6b1449)
![image](https://github.com/Abromas/Limedika/assets/37139146/21e5a86f-0063-40ee-95c2-6683d7efd331)
![image](https://github.com/Abromas/Limedika/assets/37139146/67e8e5b3-b851-4e24-a870-d36a141c9954)
![image](https://github.com/Abromas/Limedika/assets/37139146/187e5fd6-c3c0-4ab8-9e65-0ff1b67a1d44)
![image](https://github.com/Abromas/Limedika/assets/37139146/362eb373-4439-4bf7-a16c-48177cc69bcb)
![image](https://github.com/Abromas/Limedika/assets/37139146/384ce053-4263-4256-9b68-0e84ef6bf982)
![image](https://github.com/Abromas/Limedika/assets/37139146/962b8694-160b-4fbe-9bad-40ad1fc25a7a)
![image](https://github.com/Abromas/Limedika/assets/37139146/76bdb5cb-396d-4cc8-bf3b-613c692cf910)
`/logs`
![image](https://github.com/Abromas/Limedika/assets/37139146/53b08182-fed3-4f7f-ac93-523dd3574755)

# Other info
### As task was just saying it needs to be Web app, I chose to try something new `~Blazor with .Net 8.`
  #### Development experience: 8/10 
#### Personal comment:
  I've had a great time working with Blazor .NET 8 recently, and here’s why:
  
  Easy Transition: Moving from ASP.NET to Blazor was smooth. It fits right into the .NET world we're used to.
  
  Performance Boost: Apps load faster and feel snappier, thanks to the performance improvements.
  
  Productive Workflow: Hot reload is a game-changer. We can see changes instantly without restarting the app, saving a ton of time.
  
  Component Magic: Building with components makes code clean and reusable. Plus, we can mix server-side and client-side easily.
  
  Top-Notch Security: Blazor's built-in security features make it easy to secure apps without extra hassle.
  
  Great Community: Lots of resources and support from both the community and Microsoft. It's easy to find help when we need it.
  
  In short, Blazor .NET 8 has made web development faster, more secure, and overall more enjoyable. Loving it!






