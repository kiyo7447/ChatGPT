using System;
using System.IO;
using Microsoft.VisualStudio.TextTemplating;

namespace ReceiptFormatterT4
{
    class PersonModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {





            // テンプレートをファイルから読み込む
            var templateContent = File.ReadAllText("ReceiptTemplate.tt");

            // カスタム ホストを作成し、T4 エンジンを初期化する
            var customHost = new CustomTextTemplatingEngineHost("ReceiptTemplate.txt");
            var engine = new Engine();

            // テンプレートを処理し、出力内容を取得する
            var outputContent = engine.ProcessTemplate(templateContent, customHost);

            // 出力内容をファイルに書き込む
            File.WriteAllText("Output.txt", outputContent);

        }
    }
}

