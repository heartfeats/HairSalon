# _Hair Salon Manager_

#### By _**John Murray**_

## Description

_An app to manage hair salon stylists and clients_


## Setup/Installation Requirements

* _Install MAMP_
* _Make sure ports are set to default_
* _Start server_
* _Go to phpMyAdmin and import the john_murray.sql file_
* _dotnet restore then dotnet run_
* _Navigate to (http://localhost:5000)_

## Technologies Used
* _C#_
* _.NET_
* _HTML and CSS_
* _SQL_
* _MAMP_

## Creating Database
* _CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));_
* _CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);_
* _Change the collation to utf8_general_ci_


### License

*{MIT License}*

Copyright (c) 2017 **_{John Murray}_**
