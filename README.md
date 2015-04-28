# CSharp GeckoBoard Push
A typesafe library for easy access to the GeckoBoard Push API using C#

## Install

To install Web Anchor, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)
<p><code>PM&gt; Install-Package CSharpGeckoBoardPush</code></p>

## Use

So you are displaying a Pie Chart showing browser usage statistics on your Gecko Board? Let's create class for it.

```csharp
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

## Contribute
It is a hell of a task to create widget implementations for all the Gecko Board widget types. Grab one and help out? 
