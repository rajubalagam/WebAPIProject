
Code Challenge:
http://agl-developer-test.azurewebsites.net/

Asp Net Core Version: 2.1
Visual studio 2017

The solution uses ASP.NET Core Web Application with "API" template with solution name "APICodeProject". 

The solution contains Unit test project "APICodeProject.Tests"

The client to consume the Web API is a plain static html file which is hosted on Web API project with name /wwwroot/PetDetails.html.

Build the entire solution.

Run the APICodeProject to see the json output format under localhost url: https://localhost:44345/api/pets
[{"gender":"Male","names":["Garfield","Jim","Max","Tom"]},{"gender":"Female","names":["Garfield","Simba","Tabby"]}]

Open new tab and access the url: https://localhost:44345/petdetails.html

Cats By Owner Gender
	Male
	Garfield
	Jim
	Max
	Tom
Female
	Garfield
	Simba
	Tabby

Run the test project to see the unit test cases success. 
