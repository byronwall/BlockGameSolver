using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BlockGameSolver.Utility.ResourceUtilities
{
    public class ResourceToStream
    {
        public static Stream LoadResource(string name, Assembly assembly)
        {
            Stream stream = assembly.GetManifestResourceStream(name);
            if (stream == null)
            {
                string errorString = string.Format("Cannot find the following resource \"{0}\" in assembly: <{1}>\n" + "The followingwere found:\n", name, assembly.FullName);

                string[] sl = assembly.GetManifestResourceNames();

                foreach (string s in sl)
                {
                    errorString += string.Format("\"{0}\"\n", s);
                }

                throw new ApplicationException(errorString);
            }
            return stream;
        }

        public static Stream LoadResource(string name)
        {
            return LoadResource(name, Assembly.GetCallingAssembly());
        }

        public static string LoadResourceAsString(string name)
        {
            Stream s = LoadResource(name, Assembly.GetCallingAssembly());

            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int) s.Length);

            return Encoding.ASCII.GetString(b, 0, b.Length);
        }

        public static XDocument LoadXDocument(string name)
        {
            using (Stream stream = LoadResource(name))
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    return XDocument.Load(reader);
                }
            }
        }
    }

}