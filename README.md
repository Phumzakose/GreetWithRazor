[![.NET](https://github.com/Phumzakose/GreetingsWithRazor/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Phumzakose/GreetingsWithRazor/actions/workflows/dotnet.yml)

# GreetingsWithRazor Deployment 
* Create a droplet on digital oceans
* After creating a droplet connect to the server
# Connecting to the server
* login to the server using root - ssh root@my ip address
* Once in the server go to the apps folder using the command - cd apps
* When you inside the apps folder clone the greet repository - git clone git@github.com:Phumzakose/GreetingsWithRazor.git
* Then change to the GreetingsWithRazor folder using the command- cd GreetingsWithRazor
# To restore all local dependencies run the commands inside GreetingsWithRazor folder
* dotnet restore
* dotnet build -c Release
* Change to the folder that will be running using the command - cd Razor
* Then in Razor folder run this command - dotnet bin/Release/net6.0/GreetWithRazor.dll --urls=http://localhost:6007/ 
* To run the Greetings app on the background use the command - nohup dotnet bin/Release/net6.0/GreetWithRazor.dll --urls=http://localhost:6007/ > vps.log 2>&1 &
* Check if your app is running at http://phumza.projectcodex.net
