﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace _13._14.XslTransform
{
    class XslTransform
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../cat.xslt");
            xslt.Transform("../../catalogue.xml", "../../catalogue.html");
        }
    }
}
