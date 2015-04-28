# CSharp-GeckoBoard-Push
A typesafe library for easy access to the GeckoBoard Push API using C#

So you are displaying a Pie Chart showing browser usage statistics on your Gecko Board? Let's create class for it.

```csharp
public class BrowserUsagePieChart : PieChart
{
    public BrowserUsagePieChart(Dictionary<string, int> browserUsages) : base("my-pie-chart-widget-key")
    {
        foreach (var browserUsage in browserUsages)
        {
            Data.Item.Add(new Item { Label = browserUsage.Key, Value = browserUsage.Value });
        }
    }
}
```

Replace the `my-pie-chart-widget-key` with the widget key tied to your specific widget.

Let's pretend this data came from somewhere.

```csharp
var data = new Dictionary<string, int>
{
    { "Chrome", 637 },
    { "IE", 77 },
    { "Firefox", 221 },
    { "Safari",  39 },
    { "Opera",  15 },                   
};
```

Feed it to your Gecko Board!
```csharp
var api = new GeckoApiFactory().Create("your-api-key");

api.Push(new BrowserUsagePieChart(data));
```
