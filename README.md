# Helper
![](https://img.shields.io/nuget/v/PESALEXMapper.Helper.svg)

## Features
PESALEXMapper.Helper is a [NuGet library](https://www.nuget.org/api/v2/package/PESALEXMapper.Helper) that you can mapper class with similar properties, get and set values by string name dynamically and more.

The following platforms are supported:
- .NET

## Getting started
The easiest way to get started is by [installing the available NuGet packages](https://www.nuget.org/packages/PESALEXMapper.Helper) and if you're not a NuGet fan then follow these steps:

Download the latest runtime library from: https://www.nuget.org/api/v2/package/PESALEXMapper.Helper;
Or install the latest package:
PM> **Install-Package PESALEXMapper.Helper**

## A Quick Example

### Mapping classes and properties
Take advantage of the mapping capabilities through the static class ```MapperUtil```.

> Ignore dependencies in mapping different ways:
```csharp
MapperUtil.MapIgnoreDependences(foo, fooDTO);
var barDTO = MapperUtil.MapIgnoreDependences<BarDTO>(bar);
bar = MapperUtil.MapIgnoreDependences<BarDTO, Bar>(barDTO);
```

------------

> ~~Keep dependencies in mapping different ways~~:
```csharp
MapperUtil.MapKeepDependencies(foo, fooDTO);
var barDTO = MapperUtil.MapKeepDependencies<BarDTO>(bar);
bar = MapperUtil.MapKeepDependencies<BarDTO, Bar>(barDTO);
```

------------

> Get value on property:
```csharp
var id = MapperUtil.GetValue(foo, "Id");
// id => 0;
```

------------

> Enter value on property:
```csharp
MapperUtil.SetValue(foo, "Id", 1);
// foo.Id => 1
```

------------

> Concatenate Parameters with Comma Separation:
```csharp
var result = MapperUtil.ConcatCSV(foo.Id, foo.Name);
// result => "1-bar"
```

------------

> Obtain the distinct properties dynamically (concatenated):
```csharp
dynamic dynamicBar = { Id = 1, Name = "Second", PID = "10"};
var result = MapperUtil.ConcatCSV(dynamicBar);
// result => "1-Second-10"
```

### Implementation helper
Take advantage of the mapping capabilities through the static class  ```ImplementationUtil```

> Verify that the interface is being implemented:
```csharp
var result = ImplementationUtil.ContainsInterface(typeof(Foo), "IBar");
// result => false
```

------------

> Checks if the property exists:
```csharp
var result = ImplementationUtil.ContainsProperty(typeof(Foo), "IBar");
// result => false
```

### Gadget of string
Take advantage of the mapping capabilities through the static class  ```StringUtil```

> Returns null or text without side spaces:
```csharp
using PESALEXMapper.Helper;
...
var result = " ".TrimNull();
// result => null
```

------------

> ~~Get description enum:~~
```csharp
var result = ImplementationUtil.GetDescriptionEnum("Foo", typeof(BarEnum)");
```

------------

> Remove spaces within the text and return in tiny:
```csharp
var result = ImplementationUtil.HandlerNormalized("Foo Bar TEST");
// result => "foobartest"
```

------------

> Removes parentheses from text:
```csharp
var result = ImplementationUtil.WithoutParentheses("Foo (bar)");
// result => "Foobar"
```

## Report Support
To report errors, questions and suggestions go to the [link](https://www.nuget.org/packages/PESALEXMapper.Helper/1.0.0/ReportMyPackage)
