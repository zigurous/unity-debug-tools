# Logging

The Debug Tools package provides a static class with more robust logging functions compared to `UnityEngine.Debug`. The [Log](xref:Zigurous.Debug.Log) class can log messages, warnings, and errors to the console. One primary difference is you can log multiple messages through a single function call.

```csharp
Log.Message(a, b, c);
Log.Warning(a, b, c);
Log.Error(a, b, c);
```

You can also provide a custom prefix to display for the message as well as a given context.

```csharp
Log.Message(foo, "[Zigurous]:");
Log.Warning(foo, "[Zigurous]:");
Log.Error(foo, "[Zigurous]:");

Log.Message(foo, context);
Log.Warning(foo, context);
Log.Error(foo, context);
```

### Customization

You can customize the delimiter used when logging multiple messages, and you can set a global prefix that is displayed before each message in order to separate them from others.

```csharp
Log.delimiter = ",";
Log.prefix = "[Zigurous]:";
```

The class also handles null checking to not cause any errors if you log an invalid object. You can even set the string that is displayed when a null reference is logged.

```csharp
Log.nullReference = "Null";
```
