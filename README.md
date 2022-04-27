# E-Commerce Back End API

## Table of Contents
1. [Introduction](#introduction)
2. [Getting Started](#gs-id)
3. [How to use](#htu-id)
    - [Get all users](#get-u-id)
    - [Get user by ID](#get-u-id-id)
    - [Post new user](#post-u-id)
    - [Get all items](#get-i-id)
    - [Get item by ID](#get-i-id-id)
    - [Post new item](#post-i-id)
    - [Delete item](#delete-i-id)

## Introduction
This API was created as my final project for my into to API's class. This API project is a barebones representation of what the backend for an E-Commerce site should look like. This project is done completely in C# using the ASP.NET Core Framework. I was inspired to make this type of backend because E-Commerce sites are very popular and I figured it would be good practice to build something similar.

## Getting Started{#gs-id}
First start up your local MySql Server and run the SQL script provided. This will automatically create the database and populate it with some data.

Run the MyAPI solution to get the API running.

Tips For Running:
Be sure to have all of the following NuGet packages installed:
    - `Newtonsoft.Json`
    - `Microsoft.EntityFrameworkCore`
    - `Microsoft.EntityFrameworkCore.InMemory`
    - `Microsoft.EntityFrameworkCore.SqlServer`
    - `Microsoft.EntityFrameworkCore.Tools`
    - `Pomelo.EntityFrameworkCore.MySql`
    - `Swashbuckle.AspNetCore`
    
## How to use {#htu-id}
**Routes:**
 - [Get all users](#get-u-id)
- [Get user by ID](#get-u-id-id)
- [Post new user](#post-u-id)
- [Get all items](#get-i-id)
- [Get item by ID](#get-i-id-id)
- [Post new item](#post-i-id)
- [Delete item](#delete-i-id)

Below will be documentation on every API route possible. You may also reference the Postman collection provided in the Repo to eliminate the need of typing out all the routes yourself.

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

### GET All users {#get-u-id}

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

### GET User by ID {#get-u-id-id}

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

### POST New User {#post-u-id}

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
### GET All Items {#get-i-id}

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

### GET Item by ID {#get-i-id-id}

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

### POST New Item {#post-i-id}

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

### DELETE Item {#delete-i-id}

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

