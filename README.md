# E-Commerce Back End API

## Table of Contents
1. [Introduction](#introduction)
2. [Getting Started](#getting-started)
3. [How to use](#how-to-use)
    - [Get all users](#get-all-users)
    - [Get user by ID](#get-user-bv-id)
    - [Post new user](#post-new-user)
    - [Get all items](#get-all-items)
    - [Get item by ID](#get-item-by-id)
    - [Post new item](#post-new-item)
    - [Delete item](#delete-item)
4. [Final Thoughts](#final-thoughts)

## Introduction
This API was created as my final project for my into to API's class. This API project is a barebones representation of what the backend for an E-Commerce site should look like. This project is done completely in C# using the ASP.NET Core Framework and Entity Framework. I was inspired to make this type of backend because E-Commerce sites are very popular and I figured it would be good practice to build something similar.

## Getting Started

This Getting Started Section assumes you have `MySQL`, `MySQLServer`, `Visual Studio` with .NET installed and running.

First start up your local MySql Server and run the SQL script provided in the repo. This will automatically create the database and populate it with some data.

Run the MyAPI solution in visual studio to get the API running.

Tips For Running:
Be sure to have all of the following NuGet packages installed:

    - Newtonsoft.Json
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.InMemory
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
    - Pomelo.EntityFrameworkCore.MySql
    - Swashbuckle.AspNetCore

Be sure to add this connection string to your `appsettings.json` as follows. Remember to substitute for your username and password.
```json
"ConnectionStrings": {
"CustomerDataService": "Server=127.0.0.1;Port=3306;Database=ecommerce;User=USER;Password=PASSWORD"
 }
```
## How to use
**Routes:**
- [Get all users](#get-all-users)
- [Get user by ID](#get-user-bv-id)
- [Post new user](#post-new-user)
- [Get all items](#get-all-items)
- [Get item by ID](#get-item-by-id)
- [Post new item](#post-new-item)
- [Delete item](#delete-item)

Below will be documentation on every API route possible. You may also reference the Postman collection provided [here](https://www.getpostman.com/collections/e964784505cb326d3ce6) to eliminate the need of typing out all the routes yourself.
Just copy the the link then in Postman select Import -> Link -> Paste Link Provided -> Done. This will give you access to easy postman testing.

You can expect all responses to come out in the following format:
```json
{
    "statusCode": ,
    "statusDescription": ,
    "response": {
   
    }
}
```
`StatusCode`: Will return a 1xx 2xx 3xx 4xx 5xx int code reflecting the response.

`statusDescription`: Will be a string describing the status code previously mentioned. Assuming there was an error the description will tell the client what went wrong

`response`: Will return a list or object based on whatever route was called.

### GET All users

>      url:  https://localhost:7266/api/user/

**Description**
This route will return information on all Users within the database.

**Sample Response**
```json
{
    "statusCode": 200,
    "statusDescription": "Sucessful Response.",
    "response": [
        {
            "userId": 1,
            "username": "cooluser1",
            "pass": "abc123",
            "email": "coolemail@email.com",
            "balance": 400.45
        },
        {
            "userId": 2,
            "username": "applelover",
            "pass": "supersecure",
            "email": "email@email.com",
            "balance": 20.76
        }
    ]
}
```

### GET User by ID

>      url:  https://localhost:7266/api/user/{id}

**Description**
This route will return information on a specific user based on the ID passed.

**Sample Response**
```json
{
    "statusCode": 200,
    "statusDescription": "Successful Response. User Found.",
    "response": {
        "userId": 1,
        "username": "cooluser1",
        "pass": "abc123",
        "email": "coolemail@email.com",
        "balance": 400.45
    }
}
```

### POST New User

>      url:  https://localhost:7266/api/user/

**Description**
This route will create a new user and add it to the databse.

**Sample Request Body**
```json
{
    "username": "coolusername11",
    "pass": "securepassword",
    "email": "johndoe@email.com"
}
```

**Sample Response**
```json
{
    "statusCode": 201,
    "statusDescription": "Sucessful Response. User created",
    "response": {
        "userId": 5,
        "username": "coolusername111",
        "pass": "securesecure",
        "email": "johndoe@email.com",
        "balance": 0
    }
}
```
### GET All Items

>      url:  https://localhost:7266/api/items/

**Description**
This route will return information on all Items within the database.

**Sample Response**
```json
{
    "statusCode": 200,
    "statusDescription": "Sucessful Response.",
    "response": [
        {
            "itemId": 1,
            "userId": 1,
            "title": "COOL CHAIR",
            "price": 25.99,
            "descrip": "totally cool and comfortable chair"
        },
        {
            "itemId": 4,
            "userId": 1,
            "title": "Super Cool Card",
            "price": 4356.25,
            "descrip": "This item is the best and is cool. Please buy."
        }
    ]
}
```

### GET Item by ID

>      url:  https://localhost:7266/api/item/{id}

**Description**
This route will return information on a specific item within the database based on the ID passed.

**Sample Response**
```json
{
    "statusCode": 200,
    "statusDescription": "Successful Response. User found.",
    "response": {
        "itemId": 1,
        "userId": 1,
        "title": "COOL CHAIR",
        "price": 25.99,
        "descrip": "totally cool and comfortable chair"
    }
}
```

### POST New Item

>      url:  https://localhost:7266/api/item/

**Description**
This route will create a new item based on the request body and add it to the database.

**Sample Request**
```json
{
    "UserId": 1,
    "title": "Super Cool Card",
    "price": 4356.25,
    "descrip": "This item is the best and is cool. Please buy."
}
```
**Sample Response**
```json
{
    "statusCode": 201,
    "statusDescription": "Sucessful Response. Item created",
    "response": {
        "itemId": 5,
        "userId": 1,
        "title": "Super Cool Card",
        "price": 4356.25,
        "descrip": "This item is the best and is cool. Please buy."
    }
}
```

### DELETE Item

>      url:  https://localhost:7266/api/item/{id}

**Description**
This route will delete all the information on a specific item from the database.

**Sample Response**
```json
{
    "statusCode": 200,
    "statusDescription": "Sucessful Response. Item Deleted",
    "response": {
        "itemId": 4,
        "userId": 1,
        "title": "Super Cool Card",
        "price": 4356.25,
        "descrip": "This item is the best and is cool. Please buy."
    }
}
```

## Final Thoughts

This project was fun to work on. It was a stressful time learning the intricacies of Entity Framework. Most of my struggle came from constructing the models in a way such that I would be able to cleanly delete with now primary/foreign key exceptions. After looking at documentation and getting help from my course instructor I was able to get the API functioning as intended.
Any resonable person may be looking at my API with a questioning face wondering why the client is able to extract sensitive information such as passwords and credit card details with ease. I understand and acknowledge these flaws within the API and plan to add some type of encryption soon. For now this project just illustrates some of my knowledge wtih backends, specifically SQL and the .NET and Entity Framework.

