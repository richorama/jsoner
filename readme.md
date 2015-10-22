# Jsoner

A JSON parser written as a single C# file. It converts JSON strings to dynamic objects.

## Usage

If you have some json like this:

```js
{
	"hello" : "world"
}
```

You can parse it like this:

```c#
dynamic obj = Json.Parse(jsonString);

Console.WriteLine(obj.hello); // "world"
```

Alternatively you could cast the results to a `IDictionary<string,object>` or `IList<object>`:

```c#
var list = Json.Parse("[1, 2, 3, 4]") as IList<object>;

var dictionary = Json.Parse("{ \"foo\" : 42 }") as IDictionary<string,object>;
```

Likewise you can convert an object to a json string:

```c#
string json = Json.Stringify(new { hello = "world" });
Console.WriteLine(json); // {"hello":"world"}
``` 

## License

MIT


