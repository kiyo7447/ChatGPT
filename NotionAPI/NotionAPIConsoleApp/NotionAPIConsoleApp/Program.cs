using Notion.Client;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

class Program
{
    // 環境変数からAPIキーを取得
    private static readonly string apiKey = Environment.GetEnvironmentVariable("NOTION_API_KEY");
    private static readonly string databaseId = "411351af0c1f438ea8d521c11e57eb8b";

    static async Task Main()
    {
        var client = NotionClientFactory.Create(new ClientOptions
        {
            AuthToken = apiKey
        });


        var user = await client.Users.MeAsync();

        await QueryAsync(client);

    }
    static async Task QueryAsync(NotionClient client)
    {

        var databasesQueryParams = new DatabasesQueryParameters
        {
            Filter = new CompoundFilter
            {
                Or = new List<Filter>
                {
                    new CheckboxFilter(
                        "In stock",
                        true
                    ),
                    new NumberFilter(
                        "Cost of next trip",
                        greaterThanOrEqualTo: 2
                    )
                }
            },
            Sorts = new List<Sort>
            {
                new()
                {
                    Property = "Last ordered",
                    Direction = Direction.Ascending
                }
            }
        };

        var pagesPaginatedList = await client.Databases.QueryAsync(databaseId, databasesQueryParams);
        Console.WriteLine($"該当件数＝{pagesPaginatedList.Results.Count}");

        foreach (var page in pagesPaginatedList.Results)
        {
            Console.WriteLine($"メモ＝{GetText(page.Properties["メモ"])}");
            Console.WriteLine($"メモ＝{((NumberPropertyValue)page.Properties["Cost of next trip"]).Number}");
            Console.WriteLine($"メモ＝{((LastEditedTimePropertyValue)page.Properties["Last ordered"]).LastEditedTime}");

        }
    }

    static string GetText(Object prop)
    {
        var retText = new StringBuilder();
        if (prop is RichTextPropertyValue rtv)
        {
            rtv.RichText.Any(t =>
            {
                retText.AppendLine(t.PlainText);
                return true;
            });
            return retText.ToString();
        }
        else
        {
            throw new NotImplementedException($"このタイプは実装していません。{prop.GetType().FullName}");
        }
    }
}
