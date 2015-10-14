# Jsoner

A JSON parser written as a single C# file. It converts JSON strings to dynamic objects.

## Usage

If you have some json like this:

```js
{
	"hello" : "world"
}
```

```c#
dynamic obj = Jsoner.Parser(jsonString);

Console.WriteLine(obj.hello); // "world"
```

Alternatively you could cast the results to a `IDictionary<string,object>` or `IList<object>`:

```c#
var list = Jsoner.Parser("[1, 2, 3, 4]") as IList<object>;

var dictionary = Jsoner.Parser("{ \"foo\" : 42 }") as IDictionary<string,object>;
```

## License

MIT