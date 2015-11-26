# GeckoBoard Push
Some code for easy access of the GeckoBoard Push API using C#.

## Install

To install Web Anchor, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)
<p><code>PM&gt; Install-Package PushApi</code></p>

## Use

```csharp

var api = new GeckoApiFactory().Create("your-api-key");

api.Push(new Widget("widgey-key", new { /* data, see doc */ }));
```

Geckoboard custom widgets documentation: https://developer.geckoboard.com/
