import serial
import time

arduino = serial.Serial(port='/dev/ttyACM0',baudrate=9600,timeout=.1)

time.sleep(5)
serialcmd = "HELLO MOTO"

arduino.write(serialcmd.encode())
#try:
 #   while True:
  #      response = arduino.readline()
   #     print(response.decode())
#except KeyboardInterrupt:
 #   arduino.close()
    