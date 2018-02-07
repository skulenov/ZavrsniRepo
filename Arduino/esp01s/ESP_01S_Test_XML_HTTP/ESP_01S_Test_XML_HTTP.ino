
#include <SoftwareSerial.h>

SoftwareSerial EspSerial(4, 3); // RX, TX

#define stamode "CWMODE=1"		//0//	0 = AP, 1 = STA, 2 = Both
#define ipmac	"CIFSR"			//1//	Get IP address & MAC
#define	mulconn	"CIPMUX=1"		//2//	0 = Single, 1 = Multiple Connections
#define	server	"CIPSERVER"		//3//	1,<port_num> = Start, 0 = Stop
#define	ipsend	"CIPSEND"		//5//	<ch_num>,<data_length> = Start sending data/Open channel
#define	ipclose	"CIPCLOSE"		//6//	<ch_num> = Stop sending data/Close channel

void setup()
{
	Serial.begin(9600);
	EspSerial.begin(9600);
	while (!Serial);
	Serial.println("#Base Ready#");
	while (!EspSerial);
	Serial.println("#Esp Serial Ready#");
	initializeEsp();
}

void loop()
{
	if (EspSerial.available() > 0)
	{
		String request = printToTerminal(readEspSerial());
		if (request.indexOf("GET / HTTP/1.1") > -1)
		{
			int index = request.indexOf("+IPD,") + 5;
			String channel = request.substring(index, index + 1);
			sendEspData(buildHTTPResponse(buildXML()),channel);
		}
	}
	if (Serial.available() > 0)
	{
		String sendStr =  Serial.readString();
		
		if (sendStr.length() > 0)
		{
			if (sendStr.indexOf("<~XML>") > -1)
			{
				String channel = sendStr.substring(6, 7);
				sendEspData(buildXML(),channel);
			}
			else if (sendStr.indexOf("<#CMD>") > -1)
			{
				String cmdStr = sendStr.substring(sendStr.lastIndexOf("<#CMD>")+6);
				sendEspCommand(cmdStr);
			}
			else if (sendStr.indexOf("<#DAT>") > -1)
			{
				String channel = sendStr.substring(6, 7);
				String dataStr = sendStr.substring(sendStr.lastIndexOf("<#DAT>") + 8);
				sendEspData(dataStr, channel);
			}
			else if (sendStr.indexOf("<~RAW>") > -1)
			{
				String rawStr = sendStr.substring(sendStr.indexOf("<~RAW>") + 6);
				EspSerial.println(rawStr);
				EspSerial.flush();
				Serial.println("<SEND>\n" + rawStr);
				Serial.flush();
			}

		}
	}
}

void initializeEsp()
{
	Serial.println("#Initialize#");
	
	sendEspCommand(stamode);
	printToTerminal(readEspSerial());
	
	sendEspCommand(ipmac);
	printToTerminal(readEspSerial());

	sendEspCommand(mulconn);
	printToTerminal(readEspSerial());
	
	String start_nPort = "=1,8266";
	sendEspCommand(server + start_nPort);
	printToTerminal(readEspSerial());
}

void sendEspData(String data,String channel)
{
	String ch_dLen = ipsend;
	ch_dLen += "=";
	ch_dLen += channel;
	ch_dLen += ",";
	ch_dLen += data.length();
	sendEspCommand(ch_dLen);

	while (!EspSerial.available());
	printToTerminal(readEspSerial());
	EspSerial.println(data);
	EspSerial.flush();
	printToTerminal(data);
	printToTerminal(readEspSerial());

	ch_dLen = ipclose;
	ch_dLen += "=";
	ch_dLen += channel;
	sendEspCommand(ch_dLen);
	printToTerminal(readEspSerial());
}

void sendEspCommand(String command)
{
	if (command && command != "")
	{
		EspSerial.println("AT+" + command);
		EspSerial.flush();
		Serial.println("<SEND>");
		Serial.flush();
		Serial.println("AT+" + command);
		Serial.flush();
	}
}

String readEspSerial()
{
	String respStr = "";

	while (EspSerial.available() > 0)
	{
		respStr = EspSerial.readString();
	}

	return respStr;
}

String printToTerminal(String respStr)
{
		Serial.println("<PRINT>\n"+respStr);
		Serial.flush();
		
		return respStr;
}

uint8_t emulateTemperature()
{
	return ((micros() % 2) > 0) ? 25 : 30;
}

uint8_t emulateHumidity()
{
	return ((micros() % 2) > 0) ? 35 : 15;
}

String buildXML()
{
	String xml = "<?xml version='1.0' encoding='UTF-8'?>";
	xml += "<Sensors><Sensor1><Temp>";
	xml += emulateTemperature();
	xml += "</Temp><Humid>";
	xml += emulateHumidity();
	xml += "</Humid></Sensor1><Sensor2><Temp>";
	xml += emulateTemperature();
	xml += "</Temp><Humid>";
	xml += emulateHumidity();
	xml += "</Humid></Sensor2></Sensors>";
	return xml;
}

String buildHTTPResponse(String data)
{
	String http = "HTTP/1.1 200 OK\r\nContent - Type: text / xml\r\nConnection : close\r\n\r\n" + data + "\r\n";
	
	return http;
}