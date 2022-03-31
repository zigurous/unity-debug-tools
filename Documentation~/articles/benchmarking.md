---
slug: "/manual/benchmarking"
---

# Benchmarking

The **Debug Tools** package comes with a static class to perform function benchmark tests. The [Benchmark](/api/Zigurous.Debug/Benchmark) class can be used to measure the execution time of a single function or the comparison between multiple functions.

```csharp
// Measures the execution time of Foo over 1000 iterations.
float time = Benchmark.Measure(Foo, 1000);

// Compares the difference in execution time between Foo and Bar over 1000 iterations.
float difference = Benchmark.Compare(Foo, Bar, 1000);

// Performs a benchmark the executes each function 1000 times.
// The time of each function will be logged individually.
// You can pass as many functions as you want.
Benchmark.Run(1000, Foo, Bar, Baz);
```

<hr/>

## 🎏 Compare Equality

Alternatively, sometimes it is useful to test if the results of two functions are equal. The **Debug Tools** package comes with another static class [Compare](/api/Zigurous.Debug/Compare-1) to handle these tests. The class uses generics to know the type of value you are looking to compare, and it returns the percentage of results that are equal.

```csharp
Compare<bool>.Test(Foo, Bar, 1000);
Compare<float>.Test(Foo, Bar, 1000);
```
