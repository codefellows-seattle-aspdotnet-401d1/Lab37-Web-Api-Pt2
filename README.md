![cf](http://i.imgur.com/7v5ASc8.png) Lab37-WebAPI-Pt2
=====================================

## To Submit this Assignment
- fork this repository
- write all of your code in a directory named `lab-#`; + `<your name>` **e.g.** `lab36-amanda`
- push to your repository
- submit a pull request to this repository
- submit a link to your PR in canvas

## Directions 
- Building off of Lab 36, 
  - Add a PUT, POST, & DELETE action to your main controller.
  - Whenever you are updating or adding data to your database, make sure the ModelState is valid. if it is not, return a bad request
  - Create a GET action that "gets all" of the values you have saved
  - Incorporate content Negotiation into your application, require that one of your controllers produces XML, restrict another to only use JSON.(*hint - don't forget about the services you have to add to the Startup.cs class*)
  
-  COMMENT your code. Clearly. Identify the above requirements within your code. It is important that ALL The code written in this project is yours and you comment exaclty what/why everything is going on. 
- Use Postman to test your API.

## ReadMe
- Your readme should include the following information:
	- How long did it take you to complete this assignment? 1.5 hours
	- What did you struggle with? Why? How did you solve? I struggled with getting my Put action to work properly. It will replace an existing item but will not create an item if nothing exists at a certain ID.
	- What did you learn during this assignment? I learned which of my actions require an int to be passed in and why that's necessary.
    - What resources did you utilize for this assingment? the notes I took during yesterday's lecture

## Rubric
- 4pts: 5 actions (Get (all), Get(id), Post, Put, Delete) properly implemented and working
- 2pts: Content Negotiation present and working. ModelState present and working
- 2pts: Code is clearly commented.
- 2pt: Readme included with answers to questions
