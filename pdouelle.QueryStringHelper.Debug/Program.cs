using System;

namespace pdouelle.QueryStringHelper.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            var guidsArray = new Guid[] {new("41c481b8-0312-44dc-9aa5-08d9109443d3"), new("70d4171f-b04a-471a-9aa6-08d9109443d3")};

            var test = new Class1() {IncludeBlobs = true, NotificationTemplateIds = guidsArray};

            var result = test.GetQueryString();
        }
    }
}