﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace MDStudio
{
    [XmlRoot("Root")]
    public class Config
    {
        [XmlElement("ASM68KPath")]
        public string Asm68kPath { get; set; }

        public Config()
        {

        }

        public void Read()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\mdstudio";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                if (File.Exists(path + @"\config.xml"))
                {
                    StreamReader sr = new StreamReader(path + @"\config.xml");
                    try
                    {
                        Config config;

                        config = (Config)xs.Deserialize(sr);

                        Asm68kPath = config.Asm68kPath;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

        }
        public void Save()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\mdstudio";

            StreamWriter sw = new StreamWriter(path + @"\config.xml");

            try
            {
                xs.Serialize(sw, this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
