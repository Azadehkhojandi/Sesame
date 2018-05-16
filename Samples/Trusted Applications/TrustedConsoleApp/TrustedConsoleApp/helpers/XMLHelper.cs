﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace TrustedConsoleApp.helpers
{
    public static class XmlHelper
    {
        public static void FromXmlString(this RSA rsa, string xmlString)
        {
            var parameters = new RSAParameters();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            if (xmlDoc.DocumentElement.Name.Equals("RSAKeyValue"))
            {
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "Modulus":
                            parameters.Modulus = Convert.FromBase64String(node.InnerText);
                            break;
                        case "Exponent":
                            parameters.Exponent = Convert.FromBase64String(node.InnerText);
                            break;
                        case "P":
                            parameters.P = Convert.FromBase64String(node.InnerText);
                            break;
                        case "Q":
                            parameters.Q = Convert.FromBase64String(node.InnerText);
                            break;
                        case "DP":
                            parameters.DP = Convert.FromBase64String(node.InnerText);
                            break;
                        case "DQ":
                            parameters.DQ = Convert.FromBase64String(node.InnerText);
                            break;
                        case "InverseQ":
                            parameters.InverseQ = Convert.FromBase64String(node.InnerText);
                            break;
                        case "D":
                            parameters.D = Convert.FromBase64String(node.InnerText);
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("Invalid XML RSA key.");
            }

            rsa.ImportParameters(parameters);
        }
    }
}
