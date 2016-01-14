# GeckoBoard Push
Some code for easy access of the GeckoBoard Push API using C#.

## Install

To install  GeckoBoard Push, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)
<p><code>PM&gt; Install-Package PushApi</code></p> or maybe <p><code>PM&gt; Install-Package CSharpGeckoBoardPush</code></p>

Right now I'm not sure which one is correct... will look into it anytime soon.

## Use

```csharp

var geckoboard = new Geckoboard("your-api-key");
var myWidget = geckoboard.GetWidget("widget-key");

// Number and secondary stat. See geckoboard documentation for alternatives 
var data = new
{
    item = new object[]{
        new {
          value = 5723,
          text = "Total paying customers"
        }
      }
};

await myWidget.Push(data);

```

Geckoboard custom widgets documentation: https://developer.geckoboard.com/
