# ISTSignalR

This project has three main parts 

1.Notification Service
2.UserMangment which contains APi using Identity and UserMangment MVC project
3.Shared kernal for any thing shared across the solution

to add database from package manager console set the Default project to IST.SQLContext
and start up build project to UserManagment API at UsersManagment.Services at UserManagment.Presentation
then update-database

to test please open 2 different browsers
add 2 users and no validation needed 
login with 2 users frow the 2 browsers 
from one of them navigate to add task 
set task data and the needed username to receive 
check the second user recevied the task 