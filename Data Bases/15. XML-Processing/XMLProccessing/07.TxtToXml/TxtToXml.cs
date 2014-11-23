using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _07.TxtToXml
{
    class TxtToXml
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("..\\..\\Person.txt");

            var person = new XElement("person");
 
            using (reader)
            {
                string line = reader.ReadLine();
                int counter = 1;

                while (line != null)
                {
                    switch (counter % 3)
                    {
                        case 1:
                            {
                                var nameElement = new XElement("name", line);
                                person.Add(nameElement);
                            }
                            break;
                        case 2:
                            {
                                var addressElement = new XElement("address", line);
                                person.Add(addressElement);
                            }
                            break;
                        case 0:
                            {
                                var phoneElement = new XElement("phoneNumber", line);
                                person.Add(phoneElement);
                            }
                            break;
                        default:
                            break;
                    }

                    line = reader.ReadLine();
                    counter++;
                }
            }
            
            person.Save("..\\..\\person.xml");
        }
    }
}
