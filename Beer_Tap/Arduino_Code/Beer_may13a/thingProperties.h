#include <ArduinoIoTCloud.h>
#include <Arduino_ConnectionHandler.h>


const char THING_ID[] = "7da751ca-bad4-4124-962c-cc0886c157f7";

const char SSID[]     = SECRET_SSID;    // Network SSID (name)
const char PASS[]     = SECRET_PASS;    // Network password (use for WPA, or use as key for WEP)

void onBeerChange();

CloudDimmedLight beer;

void initProperties(){

  ArduinoCloud.setThingId(THING_ID);
  ArduinoCloud.addProperty(beer, READWRITE, ON_CHANGE, onBeerChange);

}

WiFiConnectionHandler ArduinoIoTPreferredConnection(SSID, PASS);
