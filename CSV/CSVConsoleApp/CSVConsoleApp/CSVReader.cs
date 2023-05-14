using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class CSVReader
{
    public static List<List<string>> ReadCSVFile(string filePath)
    {
        List<List<string>> records = new List<List<string>>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                List<string> fields = ParseCSVLine(line);
                records.Add(fields);
            }
        }

        return records;
    }

    private static List<string> ParseCSVLine(string line)
    {
        List<string> fields = new List<string>();
        string pattern = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        Regex regex = new Regex(pattern);
        string[] splitLine = regex.Split(line);

        foreach (string field in splitLine)
        {
            string unescapedField = field.Replace("\"\"", "\"");
            if (unescapedField.StartsWith("\"") && unescapedField.EndsWith("\""))
            {
                unescapedField = unescapedField.Substring(1, unescapedField.Length - 2);
            }
            fields.Add(unescapedField);
        }

        return fields;
    }
}
