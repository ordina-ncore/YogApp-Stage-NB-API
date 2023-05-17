# YogApp API

## Technologieën

Zoals reeds vermeld maken we voor de backend gebruik van de volgende technologieën.


- .NET7 (C#)
- EntityFramework7
- HotChocolate 13 (GraphQL)
- PostgreSQL DB
- Docker
- Azure AD (Identity & User management)

## Domain Driven Design
Er wordt voor de backend gebruik gemaakt van Domain Driven Design (DDD).

Domain-Driven Design (DDD) is een ontwerpbenadering die zich richt op het modelleren van de onderliggende domeinlogica van een systeem. Het begrijpt en vertegenwoordigt de complexiteit van bedrijfsprocessen en regels in software op een manier die de zakelijke vereisten nauwkeurig weerspiegelt.

Neem bijvoorbeeld de klasse Room:


```
public class RoomEntity: EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
```
deze RoomEntity maakt wordt gebruikt in de RoomDomain klasse:

 
```
public class RoomDomain
    {
        public RoomEntity entity { get; }
        private RoomDomain(Guid id, string name, string address, int capacity, string description, bool isDeleted)
        {
            entity = new RoomEntity()
            {
                Id = id,
                Name = name,
                Address = address,
                Capacity = capacity,
                Description = description,
                IsDeleted = isDeleted
            };
        }
        private RoomDomain(RoomEntity entity) => this.entity = entity;

        public static RoomDomain Create(RoomEntity entity)
        {
            return new RoomDomain(entity);
        }
        public static RoomDomain Create(string name, string address, int capacity, string description)
        {
            return new RoomDomain(
                Guid.NewGuid(),
                name,
                address,
                capacity,
                description,
                false
                );
        }
        public RoomEntity Edit(string name, string address, int capacity, string description)
        {
            this.entity.Name = name;
            this.entity.Address = address;
            this.entity.Capacity = capacity;
            this.entity.Description = description;

            return this.entity;
        }

    }
```

Alle methoden die de properties van de RoomEntity wijzigen, horen in de RoomDomain te zitten.

Daarnaast wordt er, zoals reeds vermeld, gebruik gemaakt van een GrapghQL API, de backend library die hiervoor wordt gebruikt is hotchocolate 13.

## GraphQL
Er wordt een onderscheid gemaakt tussen Mutations en Queries.
Mutations zijn in GraphQL wat POST, PUT en DELETE zijn voor REST API's. Queries zijn dan weer de "GET" requests.

Om het project gestructureerd te houden, scheiden we de mutations en de queries in verschillende klassen.

```
[QueryType]
public static class SessionQueries
{

    [UsePaging]
    [UseSorting]
    [UseFiltering]
    [Authorize(Roles = new[] { "User", "Teacher" })]
    public static List<SessionEntity> GetSessions([Service] ISessionRepository repo, [Service] IAzureService azureService)
    {
        return repo.GetAll();
    }
    [Authorize(Roles = new[] { "User", "Teacher" })]
    public static SessionEntity? GetSession([Service] ISessionRepository repo, Guid id)
    {
        return repo.GetById(id);
    }
}
```
boven de klasse wordt de tag **[QueryType]** gebruikt om aan te geven dat de methoden in deze klassen QUERY endpoints zijn.

**[UsePaging]**,**[UseSorting]** en **[UseFiltering]** tags zijn er zodat je vanuit de call de paging, sorting en filtering features kan gebruiken.

**[Authorize]** tags zijn zodat je de endpoints kan beveiligen, alleen de personen die over de rol beschikken, kunnen deze call maken.

Services die gebruikt worden in de call worden geinjecteerd in de properties van de methode aan de hand van de **[Service]** tag.

## Appsettings
hieronder een kort overzicht van de appsettings, en waar elke secret voor dient:

```
 "AzureAdConfiguration": {
    "Instance": "",
    "TenantId": "", 
    "Domain": "",
    "ClientId": "",
    "TokenValidationParameters": {
      "ValidateIssuer": true,
      "ValidIssuer": "",
      "ValidateAudience": true,
      "ValidAudiences": [ "" ]
    }
  },
  "MsGraphConfiguration": {
    "TenantId": "",
    "ClientId": "",
    "ClientSecret": ""
  }
```

**Instance**: Dit is de Azure AD-instantie waarmee uw applicatie communiceert (meestal login.microsoftonline.com).

**TenantId**: Dit identificeert de specifieke Azure AD tenant (uw organisatie in Azure) waarmee uw applicatie zal communiceren.

**Domain**: Dit is het domein van uw Azure AD tenant.

**ClientId**: Dit is de ID die aan uw applicatie is toegewezen bij registratie bij Azure AD. Het identificeert uniek uw applicatie.

**TokenValidationParameters** 

 **ValidateIssuer**: Dit is een boolean om aan te geven of de uitgever (Azure AD) van het token moet worden gevalideerd.

 **ValidIssuer**: Dit is de geldige uitgever die overeen moet komen met de uitgeverclaim in het token.

 **ValidateAudience**: Dit is een boolean om aan te geven of het publiek van het token moet worden gevalideerd.

 **ValidAudiences**: Dit is een lijst met geldige publieken die overeen moeten komen met de publieksclaim in het token.

**MsGraphConfiguration** 
 **TenantId**: Dit is de ID van uw Azure AD tenant voor de Microsoft Graph API.

 **ClientId**: Dit is de ID die aan uw applicatie is toegewezen door Azure AD voor de Microsoft Graph API.

 **ClientSecret**: Dit is de geheime sleutel die voor uw applicatie in Azure AD is gegenereerd voor authenticatie bij de Microsoft Graph API.

