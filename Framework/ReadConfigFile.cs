using System;
using System.Xml; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class ReadConfigFile
    {
        //  Framework Project - Read Config File

        public string ReadData(string Name)
        {
            var Data = "";
            XmlTextReader xmlReader = new XmlTextReader("..\\XMLFile.xml");
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xmlReader.Name == Name)
                        {
                            Data = xmlReader.ReadString().ToString();
                        }
                        break;
                }
                if (Data != "")
                    break;
            }
            return Data;
        }
    }
}  
