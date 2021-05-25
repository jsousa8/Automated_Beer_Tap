# Beer_Tap
This is my project to have Alexa to Operate a beer tap using Arduino MKR 1010 Wifi

This project is not complete at the time I wrote this document.
The code at this point can enable Alexa to control a light which then turns on a servo motor. I have currently a linear actuator on the way that I will be attaching to the beer tap handle. 

How I connected Arduino MKR 1010 Wifi to Alexa:
You first need to have a Arduino Create Account and add a "New Thing" from here (https://create.arduino.cc/iot/things).
Follow the directions inorder to add your arduino board. When prompted for device type, scroll down to Smart Home and choose "Dimmed Light"

For the coding aspect I followed the directions from (https://blog.arduino.cc/2019/11/12/create-a-voice-controlled-device-with-alexa-and-arduino-iot-cloud-in-7-minutes/) and added code inorder to control a servo.

I will be updating this document with a parts list once I have the motor recieved and have a working proto type that I can record.

Under the issues tab you will find pictures and will be posting more.

Here is a video for what I have currently working: https://youtu.be/Dsof3aiYZY4

Let me know if you have any questions

Thanks!

UPDATE(06/11/2020): 
After looking at how I currently have the arduino connecting to Alexa I decided that I want my setup designed differently. What I have works but there is no flexibility to say "Hey Alexa, pour me a 12 or 16 oz beer". That is why I am implementing an AWS Lambda function and Linux Instance running in AWS. The lambda function is for talking between Alexa and my AWS linux instance. Running on the linux service is a .NET CORE API where I store 2 variables, Pour(True/False) and a ounces. From there I will have my Arduino Rev2 Wifi to make Http requests to get the data from the Linux instance inorder to to control the servos and other processes. I have currently the .NET CORE API service running in a free AWS Instance where I am able to connect to it from the outside world, you can see that code under the beerService directory. I have running on the AWS instance Apache as a reverse proxy to link the port that the request is coming from to where the .NET CORE service is actually running. Next I am working on is connecting my arduino to make those Http requests to the Linux service to get those updated values. I will update this once I get it working. Thanks!
