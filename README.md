# GeckoBoard Push
A typesafe library for easy access to the GeckoBoard Push API using C#.

It is actually very easy to fail when using the geckoboard api. The documentation is not completely clear on how some parameters should be used and also exposes disambiguos data structures. This repository aims to fix this. By using C#, we can force you inte creating correct requests by type-safeness, or in worst case, early throws of exceptions.

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

## Contribute
It is a hell of a task to create widget implementations for all the Gecko Board widget types. Grab one and help out? 

###WIDGET TYPES
Custom Widget Types  
Bar Chart  
Bullet Graph  
Funnel  
~~Geck-o-Meter~~  
Highcharts  
Leaderboard  
Line Chart  
List  
Map  
Monitoring  
Number and Secondary Stat  
~~Pie Chart~~  
~~RAG~~  
~~Text~~  
