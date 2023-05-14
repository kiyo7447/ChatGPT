using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class CsvWriter
{
    public void WriteCsv(List<List<string>> data, string filePath)
    {
        using (var streamWriter = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            foreach (var row in data)
            {
                var csvLine = string.Join(",", row.Select(field => EscapeCsvField(field)));
                streamWriter.WriteLine(csvLine);
            }
        }
    }

    private string EscapeCsvField(string field)
    {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            return "\"" + field.Replace("\"", "\"\"") + "\"";
        }
        return field;
    }
}

