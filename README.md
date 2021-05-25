# Alexa Beer Tap Control

## Introduction
    This is my project to have Alexa operate a kegorator. I wanted to automate the at home bar experience to not only build something that is unique, but to also ensure a quality beer pour. 

## Technologies Used
1. .NET API
1. Docker
1. Raspberry PI
1. Arduino MKR 1010 Wifi
1. Linear Servo
1. Python
1. C++
    
## Flow Chart Diagram    
![diagram](./beerdiagram.png)

## How To Build
       
### Custom Alexa Skill Kit
1. Visit [Alexa Developer Console](https://developer.amazon.com/alexa/console/ask) and Click on Create skill
    
1.  Then enter in a Skill Name. This should be something related to the action. For example I called mine "pour me a beer". Then choose the Custom option and your preferred language, I went with the Alexa-hosted (Python) option.
    
1. Choose Start from Scratch, unless you want to choose a premade template.
    
1. Once the page finishes building your skill, you will have bunch of options on your left. The first one of these options that we will edit is Invocation. This is what you ask Alexa inorder for it to realize that you want to use this specific skill. For me I choose "The bar" so that I can first ask "Alexa, open the bar" so that it knows that I am referencing this specific skill.
    
1. Next, we have intents. For this example we are going to add 2 intents one for if the user asks for a specific sized beer and the other if the user decides on a custom size. 

    * For the first intent call it StandardSize. and click on custom intent. We need to enter in some sample utterances. These are to train the Alexa skill on what a user might say to invoke this intent. For this example, I used "I want a beer" and "pour me a beer" since these two utterances don't have the option to enter in a custom beer size.
    * The next intent we will need is a SelectSize intent. This is the intent where we will be able to specificy a certain size of beer that we want. In the sample utterances section enter phrases such as "I want a {size} ounce beer", or "pour me a {size} ounce beer". The {size} variable tells Alexa to listen to a number. In the Intent slots is where you will specify what size is. In the name section enter in the name of your variable, so in our example it will be called "size". Next in the slot type this is where we will specify what kind of variable "size" is. So we will specify a AMAZON.NUMBER type since we will want a number to be saved. 
1. Under Assets we will need to add a slot type. This is for the Alexa Skill to understand how phrases/utterances are recognized and what kinda of data is being interpreted. First click on the Add Slot Type Button. Then choose the "Use an existing slot type from Alexa's built-in library" option since all we are using is a AMAZON.NUMBER for the size variable we will also be using that type here as well.
1. Next we need to build the endpoint for the Alexa Skill which will be a AWS Lambda funciton but we will need to come back to this page once we are done with that.

### AWS Lambda Function
    The AWS Lambda Function is similar to a full vm but is very cost effective. This is because AWS will only partition resources to it when it gets called so it is not always running. 

1. First visit [AWS Console](https://aws.amazon.com/console/) and if you don't already make an account
1. Then click on the Lambda link and create a lambda function.
    * We will be authoring from scratch for this function.
    * Then in the runtime option choose python, since this is what I decided to write this project in. 
1. Once finished click on Create Funciton, which will bring you to the function overview page.
1. On the left side of the screen there will be a add trigger button. This is where we will tell the lambda function that it will be triggered by the alexa skill we just created. Click the add trigger button.
1. In the select trigger drop down choose the Alexa Skills Kit option.
1. In order to get our skill kit id we will need to go back to the alexa developer console and click back onto the endpoint tab. There you will need to copy the skill id and paste back into the aws console page for the trigger. Then click add.
1. On the function overview page copy the Function ARN id and paste it back to the Alexa Skill Default region area on the endpoint tab. This will establish the link between your aws lambda function and your skills kit. 
1. Now back to the lamnda function overview page. If you scroll down towards the bottom of the page you will see the IDE where the actual code for the function lives. You will find a empty lambda_function.py file there. In this repository you will find a lambda_function.py file under a AWS directory. Copy this file into the empty lambda_function.py we discussed earlier. Inorder for this python script to work you will need to replace the URL variable value with the ip address of the machine that is running your .net api. The .net api will be explained later on.
1. Save your function and that should be it for the api.
1. I got a lot of help from this [repo](https://github.com/KeithGalli/Alexa-Python/blob/master/basic_template.py) and he also has a youtube channel so definetly check him out if you want a deeper dive into the explination.

### .NET API

    My .NET Service was based from the Visual Studio IDE .Net service templates dor ASP.Net API. It orginally was designed for a weather forecast api but I implemented it in such a way that I only use two variables, a pour status and a beer size. The status is to signify when the robot should pour the beer and the beer size is to signify the amount to pour. 

### Docker File
    I wanted to used Docker because it makes it easier to run my code on most platforms without having to worry about it running on Windows vs Liunux. I have a docker-compose.yaml file set up because I eventually plan on running in conjunction with this first docker file another docker file like you can see in the above diagram to handle more of the backend for communication between my .net service and my arduino/servos. 

## How to Run

### Running the docker file

#### On Windows/ MacOS
1. In order to run the docker file we will need to first create a self signed certificate to run the service since it is set up to communicate over https. Check out [Microsoft's article](https://docs.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-5.0) about running ASP .NET Core images over https using docker. They provide a great explination on how to create self signed certificates on either Windows or Mac. 

#### On Linux
1. On Linux based machines such as Ubuntu, Debian or Raspbian OS you will need to take a different approach on it. We will be using the openssl command for this. Check out [Rich Stokoe's](http://richstokoe.com/2017/12/10/running-asp-net-core-raspbian-linux-raspberry-pi-https/) page, specifically the https section where he goes over how to run the commands for openssl. 
1. Then once you have the certificate with go to the Microsoft article link above. Use the MacOS/Liunux command for docker run and paste where their .pfx certificate is located with the one you created in the previous step.

    Now depending onyour router's security settings you will need to add port forwarding for your service's ip addresses and what ports you are running the service on. Make sure you match it with the same ports as what your docker container is bounded to in the run command.

### Next Steps
So now I need to complete the second docker image that will act as the middle person between my arduino and my initial docker image. That is why you will see a docker-compose.yaml file. These are good to use when managing multiple docker images at once and it is easier to have the containers communicate with each other. 

### Sources 
I have linked these already throught this document but I want to give credit again because they were great sources for me and maybe for you with any of your projects.

* [Alexa Repo](https://github.com/KeithGalli/Alexa-Python/blob/master/basic_template.py) He also has a youtube channel so check that out as well.
* [Rich Stokoe's](http://richstokoe.com/2017/12/10/running-asp-net-core-raspbian-linux-raspberry-pi-https/) article on how to use openssl on linux. 