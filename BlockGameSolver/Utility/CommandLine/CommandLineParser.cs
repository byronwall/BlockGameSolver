using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BlockGameSolver.Utility.CommandLine
{
    public class CommandLineParser
    {
        private string[] arguments;
        private Dictionary<string, string> switchValue = new Dictionary<string, string>();


        public CommandLineParser(string[] arguments)
        {
            this.arguments = arguments;

            Regex splitter = new Regex(@"^-{1,2}|^/|=|:", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string[] parts;

            foreach (string s in arguments)
            {
                parts = splitter.Split(s);

                if (parts.Length == 3)
                {
//We have a match
                    string param = parts[1];
                    string value = parts[2];
                    if (!switchValue.ContainsKey(param))
                    {
                        switchValue.Add(param, value);
                    }
                    else
                    {
                        throw new ArgumentException("Threre was a repeat in command line parameters.");

                    }
                }
                else
                {
                    throw new ArgumentException("The command line parameters do not meet the expected format.");
                }
            }
        }
        public string this[string index]
        {
            get
            {
                if (switchValue.ContainsKey(index))
                {
                    return switchValue[index];

                }
                return null;
            }
        }
    }
}