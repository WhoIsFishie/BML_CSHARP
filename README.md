# BML_CSHARP
If you want something done right. you have to do it yourself

# What is this?
this is a c# library im that im making so it would be easier for devs to make apps that communicate with the bml api
the api is made to be fully asyncronus and communicate with the bml api
the code contains easy to undustand method names and comments to make it easy for anyone to pick up and start working with the library 
the code is written in a way any dev can pick it up and forget about the backend and server communication when it comes to the api and start working with the ui straight out of the box

# Lib_BML vs BML_MOCK_APP
Lib bml is where all the code lives
it containts the methods to call for when making a ui for a bml app

bml mock app is a test ground i made so i can test parts of the library to make sure its communicating with the bml app well and make it easier for me to see the output
IN NO WAY SHAPE OR FORM IS THE BML MOCK APP TO BE USED AS A BML CLIENT AS IT DOES NOT SECURE ANY OF THE LOGIN DETAILS OR ANYTHING. ITS JUST A TESTING GROUND FOR THE LIBRARY




# how to use
bool result = await Lib_BML.Login.DoLogin(username, password);

https://write.mv/fishie-posting/making-my-own-bml-app
