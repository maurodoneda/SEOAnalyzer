# 

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
SEO Analyzer - This is a small project I created to analyze the SEO results of a search term in google. 
The project is devide in two, server app(backend) and client app(front-end). on The backend project I used C# and .Net to create a Domain Driven Architecture, where the ceneter of the aplication is the Entities. 

![Software Architecture](image.png)


-- Data Layer --

This was coded in a code-first approach levereging EntitiFramwork as a ORM ad usign its Migrations to create and update the Database. 
The data base initialy contains only two entities: Searches and Results in 1 to 1 relationship.

-- Logic Layer --

In the Logic layer of the Architecture I'm using a Services classes where I define the Interfaces that will be consumed by the API and that will be able to make make changes to the database context. This way the software is very safe, scalabe and easy to mantain beacause its possible to add and remove services and just allow their Interfaces to be consumed. At the moment there is only one Service to make the google search and get back the position based on the search term and the url the user is willing to analyze.

-- API -- 
Although its a simple application I decided to code a API to receive and send requests. This api endpoints then can be called by any kind of Client Application, making the system completely flexible and with separation of concerns. Here I decide to use a React application and making calls to this API to send and receive data.

-- React App --

The front-End application is very simple at this point in time. I decide to use React instead of a simple .NetCore WebApp exactly to make the system more separate.
I havente used React in a whiel so given more time this can app can grow. Because of the structure behind this system is very scalable, every search and result is receive from the web is saved on the database, it allows to make analisys in top of those results with simple Axios calls. Used Axios to Call my API, from the API the Service on the Logic layer is called.



## Technologies
Project is created with:
* C# / .Net5 / EntityFramework for the back-end.
* React.js for the front-end.



## Setup
To run this project, install it locally using npm - you will need npm installed to run the client-app
* On a terminal window clone the repo into your directory with this command: git clone https://github.com/maurodoneda/SEOAnalyzer.git
* Open the solution file on VisuaStudio or VScode 
* On appsetting.json you need to set your local machine on the conectionstring, just change the data source to your local machine name and add any name to Initial Catalog:
```diff
 "ConnectionStrings": {
-    "Default": "Data Source=MAURO-PC\\SQLEXPRESS;Initial Catalog=SEOAnalyzer2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }

```
- The system is configured to create a new DataBase if you dont have one when you run it first time.


* Run the API (note you should change to run the api instead of the IIS on visualStudio). This will lunch the API on on your $local port: localhost:5001
* With the API running now cd or open a terminal into the client-app folder where the React App is located
* On the terminal type the command: npm start
* Now it will luch the app in your localhost:3000 and you should see the initial screen and be able to type your search term and url to analyze. After it runs you give you a back a string with the position if it appear on the first 100 pages.

Given more time this app can grow in complexity and in features, there is a lot to work on still, speacially on the fron-end where I didn't have much time to work on. But the way is paved for it!

Best Regards,

Mauro Doneda
Software Engineer
```
