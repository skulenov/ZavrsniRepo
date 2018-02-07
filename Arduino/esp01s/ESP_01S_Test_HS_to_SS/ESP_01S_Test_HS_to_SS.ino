/*
*	ESP-01S Test: Hardware Serial (PC over USB to Arduino) to Software Serial (Arduino to ESP-01S)
*/


#include <SoftwareSerial.h>

#define AT_TIMEOUT 5000 // ms
SoftwareSerial esp(4, 3); // RX, TX(Arduino) -> TX, RX(ESP-01S)

String readStr = "";
String writeStr = "";
char charData[] = { 204,0,25,85,15,185 };
byte byteData[] = { 204,0,25,85,15,185 };


void setup()
{
	Serial.begin(9600);
	esp.begin(9600);
	while (!Serial);	// wait until Hardware Serial is ready
	while (!esp);		// wait until Software Serial is ready
}

void loop()
{

	readStr = "";
	writeStr = "";

	if (Serial.available())
	{
		writeStr = Serial.readString();
	}
	if (writeStr.length() > 0)
	{
		if (writeStr.startsWith("dataChar"))
		{
			esp.write(charData, 6);
		}
		else if (writeStr.startsWith("byteData"))
		{
			esp.write(byteData, 6);
		}
		else
		{
			esp.println(writeStr);
		}
		esp.flush();
		Serial.println("TX: ");
		Serial.println(writeStr);
		Serial.flush();
	}
	while (esp.available() > 0)
	{
		readStr = esp.readString();
	}

	if (readStr.length() > 0)
	{
		Serial.println("RX: ");
		Serial.println(readStr);
		Serial.flush();
	}

}

byte fakeTemp()
{
	return ((micros() % 2) > 0) ? 25 : 30;
}

byte fakeHum()
{
	return ((micros() % 2) > 0) ? 50 : 90;
}

