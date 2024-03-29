# Places api

> Simple NET6 places rest api

## Basic functionalities of places rest api:

```bash
Has the following apis:
User
1. [POST]   /api/User/register -> to create a new user
2. [POST]   /api/User//login -> to authenticate a user

Place - a place can have a country id
1. [POST]   /api/Places -> create a new place                       [requires jwt]
2. [GET]    /api/Places/GetAll -> get a list of all places          [requires jwt]
3. [GET]    /api/Places/ -> get a list of all places with paging    [requires jwt]
4. [GET]    /api/Places/:id  -> to get a place by id                [requires jwt]
5. [PUT]    /api/Places/:id  -> To update a place by id             [requires jwt]
6. [DELETE] /api/Places/:id  -> To delete a place by id             [requires jwt][only admin role can execute]

Country
1. [POST]   /api/v1/Countries -> create a new country                  [requires jwt]
2. [GET]    /api/v1/Countries/GetAll -> get a list of all Countries
3. [GET]    /api/v1/Countries/ -> get a list of all Countries with paging
4. [GET]    /api/v1/Countries/:id  -> to get a country by id. Has a places field showing places in the country
5. [PUT]    /api/v1/Countries/:id  -> To update a country by id        [requires jwt]
6. [DELETE] /api/v1/Countries/:id  -> To delete a country by id        [requires jwt][only admin role can execute]

Country v2
1. [POST]   /api/v2/Countries -> create a new country                  [requires jwt]
2. [GET]    /api/v2/Countries -> get a list of all Countries with OData
E.g.:
    GET: api/v2/Countries?$select=name,natCode
    GET: api/v2/Countries?$filter=name eq 'Singapore'
    GET: api/v2/Countries?$orderby=name
    GET: api/v2/Countries?$select=name,natCode&$filter=name eq 'Singapore'&$orderby=name

3. [GET]    /api/v2/Countries/Paged -> get a list of all Countries with paging
4. [GET]    /api/v2/Countries/:id  -> to get a country by id. Has a places field showing places in the country
5. [PUT]    /api/v2/Countries/:id  -> To update a country by id        [requires jwt]
6. [DELETE] /api/v2/Countries/:id  -> To delete a country by id        [requires jwt][only admin role can execute]

```

## Running the project locally:

```bash
1. Download and unzip project.<br>
   Open the project in Visual Studio.<br>
   Requires NET to be setup on Visual Studio.

2. Requires Postman
import placeListing.postman_collection.json into your postman to test the endpoints

3. Using microsoft sql, which can be viewed via sql explorer on Visual Studio.
To ensure data is seeded into microsoft sql, run these commands in Package Manager Console:

dotnet tool install --global dotnet-ef
*** Go into the root directory of the project first before running the next command ***
cd .\PlaceListing.API.Core
dotnet ef
add-migration InitialMigration
update-database


4. To start the app, press the play button on Visual Studio
(Remember step 3 before starting the app to ensure it works the way it should)

The Swagger UI page would appear on https://localhost:7086/swagger/index.html
a sample of how it would look like can be seen on Swagger_UI.pdf in the root directory
```
