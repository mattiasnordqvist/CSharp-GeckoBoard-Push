# GeckoBoard Push
Some code for easy access of the GeckoBoard Push API using C#.

## Install

To install Web Anchor, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)
<p><code>PM&gt; Install-Package CSharpGeckoBoardPush</code></p>

## Use

So you are displaying a Pie Chart showing browser usage statistics on your Gecko Board? Let's create class for it.

```csharp
// this code is not up to date. Should create new examples
public class BrowserUsagePieChart : PieChart
{
    public BrowserUsagePieChart(Dictionary<string, double> browserUsages) : base("my-pie-chart-widget-key")
    {
        foreach (var browserUsage in browserUsages)
        {
            Data.Item.Add(new Item(browserUsage.Key,browserUsage.Value));
        }
    }
}
```

Replace the `my-pie-chart-widget-key` with the widget key tied to your specific widget.

Note that it is not necessary to define your own subclasses like this. Your could use the PieChart class as it is.

Let's pretend this data came from somewhere.

```csharp
var data = new Dictionary<string, double>
{
    { "Chrome", 63.7 },
    { "IE", 7.7 },
    { "Firefox", 22.1 },
    { "Safari",  3.9 },
    { "Opera",  1.5 },                   
};
```

Feed it to your Gecko Board!
```csharp
var api = new GeckoApiFactory().Create("your-api-key");

api.Push(new BrowserUsagePieChart(data));
```
