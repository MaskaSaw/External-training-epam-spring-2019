using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace URLDataParser
{
    public class URLParser
    {
        #region private fields
        private string logPath = Directory.GetCurrentDirectory() + "ErrorsFile.log";
        private string resultPath = Directory.GetCurrentDirectory() + "ResultFile.xml";

        private Regex urlAddressPattern = new Regex(@"^http[s]{0,1}:\/\/([^?\/]+(\/)?){1,}((?<=\/)[^\?\/\=\&]+\?([^\?\/\=\&]+=[^\?\/\=\&]+(&[^\?\/\=]+=[^\?\/\=\&]+){0,}){0,1}[\/]{0,1}){0,1}$");
        private Regex partWithoutParamsPattern = new Regex(@"(?<=\/).+?(?=\/|$)");
        private Regex partWithParamsPattern = new Regex(@"(.+)(\?)(.+)(?=\/|$)");
        private Regex extraParamsPattern = new Regex(@"([^=&]+)(=)([^=&]+)");

        XmlElement param;
        XmlElement uri;
        XmlElement urlAddress;
        XmlElement urlAddresses;
        XmlDocument document;
        #endregion

        #region constructor
        public URLParser()
        {
            document = new XmlDocument();
            urlAddresses = document.CreateElement("urlAddresses");
        }
        #endregion

        #region exporting and serializing functions
        public void ExportDataFromFile(string filename)
        {
            string fileString = "";

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    fileString = sr.ReadLine();

                    if (urlAddressPattern.IsMatch(fileString))
                    {
                        urlAddress = document.CreateElement("urlAddress");
                        bool first = true;
                        bool firstParameters = true;
                        bool firstUri = true;

                        foreach (Match partWithoutParams in partWithoutParamsPattern.Matches(fileString))
                        {
                            if (first)
                            {
                                CreateHost(partWithoutParams.ToString(), ref first);
                            }
                            else
                            {
                                if (!partWithParamsPattern.IsMatch(partWithoutParams.ToString()))
                                {
                                    CreateSegment(partWithoutParams.ToString(), ref firstUri);
                                }
                                else
                                {
                                    foreach (Match partsWithParams in partWithParamsPattern.Matches(partWithoutParams.ToString()))
                                    {
                                        CreateSegment(partsWithParams.Groups[1].ToString(), ref firstUri);
                                        foreach (Match foundExtraParams in extraParamsPattern.Matches(partsWithParams.Groups[3].Value))
                                        {
                                            CreateParam(foundExtraParams.Groups[1].ToString(), foundExtraParams.Groups[3].ToString(), ref firstParameters);
                                        }
                                    }
                                }
                            }
                        }

                        urlAddresses.AppendChild(urlAddress);
                    }
                    else
                    {
                        Log(fileString);
                    }
                }

                document.AppendChild(urlAddresses);
                WriteToFile(document);
            }
            catch (IOException)
            {
                throw new IOException("File error!");
            }
        }

        private void CreateHost(string hostValue, ref bool firstTime)
        {
            XmlElement host = document.CreateElement("host");
            hostValue = hostValue.Remove(0, 1);
            host.SetAttribute("name", hostValue);
            urlAddress.AppendChild(host);
            firstTime = false;
        }

        private void CreateSegment(string segmentValue, ref bool firstUri)
        {
            if (firstUri)
            {
                uri = document.CreateElement("uri");
                firstUri = false;
            }

            XmlElement segment = document.CreateElement("segment");
            segment.InnerText = segmentValue;
            uri.AppendChild(segment);
            urlAddress.AppendChild(uri);
        }

        private void CreateParam(string paramKey, string paramValue, ref bool firstParameters)
        {
            if (firstParameters)
            {
                param = document.CreateElement("parameters");
                firstParameters = false;
            }

            XmlElement parametr = document.CreateElement("parametr");
            parametr.SetAttribute("key", paramKey);
            parametr.SetAttribute("value", paramValue);
            param.AppendChild(parametr);
            urlAddress.AppendChild(param);
        }

        private void WriteToFile(XmlDocument document)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlElement));

            try
            {
                using (TextWriter tw = new StreamWriter(resultPath))
                {
                    xmlSerializer.Serialize(tw, document);
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }
        #endregion

        private void Log(string str)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Open(logPath, FileMode.Append)))
                {
                    sw.WriteLine($"Error: Couldn't wrong data export from string {str}");
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }
    }
}
