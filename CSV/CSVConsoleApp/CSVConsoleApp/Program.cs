// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// テストデータ
var data = new List<List<string>>
            {
                new List<string> {"ID", "Name", "Description"},
                new List<string> {"1", "Taro", "Taro's description"},
                new List<string> {"2", "Hanako, with comma", "Hanako's \"description\" with quotes and a , comma."},
                new List<string> {"3", "Jiro\nwith newline", "Jiro's description with a \nnewline."},
                //テストパターンを追加
                new List<string> {"4", "Saburo", @"Saburo's \description\"},
                new List<string> {"5", "Shiro", "Shiro's \"description\""},
                new List<string> {"6", "Goro", "Goro's description"},
                new List<string> {"7", "Rokuro", "Rokuro's description"},
                new List<string> {"8", "Shichiro", "Shichiro's description"},
                new List<string> {"9", "Hachiro", "八郎の説明"},
            };

// CsvWriterのインスタンスを作成
CsvWriter csvWriter = new CsvWriter();

// CSVファイルを出力
csvWriter.WriteCsv(data, "output.csv");



// CSVファイルを読み込み
var records = CSVReader.ReadCSVFile("output.csv");

// 読み込んだデータを出力
foreach (var row in records)
{
    foreach (var field in row)
    {
        Console.Write($"{field} ");
    }
    Console.WriteLine();
}

