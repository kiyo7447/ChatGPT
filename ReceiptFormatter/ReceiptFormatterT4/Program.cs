using System;
using System.IO;
using Mono.TextTemplating;

namespace ReceiptFormatterT4
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Program
    {


        static async Task Main(string[] args)
        {
            var templateFilename = "ReceiptTemplate.tt";
            var outputFilename = "OutputReceipt.txt";
            {
                //パラメータなし
                var generator = new TemplateGenerator();
                bool success = await generator.ProcessTemplateAsync(templateFilename, outputFilename);

                Console.WriteLine(success);

                if (generator.Errors.HasErrors)
                {
                    var consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (var error in generator.Errors)
                        Console.WriteLine(error);
                    Console.ForegroundColor = consoleColor;
                }
            }


            {
                //パラメータあり(int)
                var generator = new TemplateGenerator();
                generator.GetOrCreateSession()["p1"] = 32;

                bool success = await generator.ProcessTemplateAsync(templateFilename, outputFilename);

                Console.WriteLine(success);
            }

            templateFilename = "ReceiptTemplate2.tt";
            outputFilename = "OutputReceipt2.txt";


            {
                //パラメータあり(List<Person>)


                var generator = new TemplateGenerator();
                generator.GetOrCreateSession()["Person"] = new List<Person> {
                    new Person { FirstName = "ho", LastName = "ge" },
                    new Person { FirstName = "ho", LastName = "ge" }
                };


                bool success = await generator.ProcessTemplateAsync(templateFilename, outputFilename);

                Console.WriteLine(success);

                if (generator.Errors.HasErrors)
                {
                    var consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (var error in generator.Errors)
                        Console.WriteLine(error);
                    Console.ForegroundColor = consoleColor;
                }
            }


            {
                string templateContent = File.ReadAllText(templateFilename);

                var generator = new TemplateGenerator();
                ParsedTemplate parsed = generator.ParseTemplate(templateFilename, templateContent);
                TemplateSettings settings = TemplatingEngine.GetSettings(generator, parsed);

                settings.CompilerOptions = "-nullable:enable";

                (string generatedFilename, string generatedContent) = await generator.ProcessTemplateAsync(
                    parsed, templateFilename, templateContent, outputFilename, settings
                );

                File.WriteAllText(generatedFilename, generatedContent);
                Console.WriteLine(generatedContent);
            }

            Console.ReadKey();

        }


    }
}

