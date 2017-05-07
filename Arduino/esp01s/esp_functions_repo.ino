//bool findResponse(const String pattern)
//{
//	return (((String)respChars).indexOf(pattern) > -1);
//}
//
//char respChars[64];				// Buffer for response from Esp Serial
//bool gotResp = false;			// Flag for signaling that response has been received
//
//void getEspResponse()
//{
//	static byte index = 0;
//	char inChar;
//
//	while (!gotResp && EspSerial.available())
//	{
//		if (index <= 63)
//		{
//			inChar = EspSerial.read();
//			if (inChar == '\n')
//			{
//				gotResp = true;
//				respChars[index] = '\0';
//				index = 0;
//			}
//			else respChars[index++] = inChar;
//		}
//		else
//		{
//			gotResp = true;
//			index = 0;
//		}
//	}
//}