**Verbeteringen graag in een eigen branch**

Basis web app.

HowTo:
Er staat een mapje HowTo in met wat info over zaken die telkens terugkeren als je een nieuw MVC project aanmaakt.

Database:
Er staan een paar connection strings in web.config die je kan gebruiken. Voor testen is LocalDb (versie onafhankelijk) erg handig.

Model:
Het model kan je configureren in mapje Models.

Mapping en migratie
In Models\IdentityModels.cs staat (op dit moment nog) de ApplicationDbContext, daar voeg je de klasse aan toe als je wilt dat deze ook via een migration in de database komt
Daarna volg je de stappen in HowTo\DBMigration.txt om ze daadwerkelijk in de database te krijgen
In "Configuration.cs" kan je in de Seed methode dingen doen die je bij een kale applicatie alvast ingevuld wil hebben.