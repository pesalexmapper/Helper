# PESALEXMapper Helper
![](https://img.shields.io/nuget/v/PESALEXMapper.Helper.svg)

## Features
PESALEXMapper.Helper is a [NuGet library](https://www.nuget.org/api/v2/package/PESALEXMapper.Helper) that you can have a framework to functionality improvements.

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
MapperUtil.IgnoreDependences(foo, fooDTO);
var barDTO = MapperUtil.IgnoreDependences<BarDTO>(bar);
bar = MapperUtil.IgnoreDependences<BarDTO, Bar>(barDTO);
```

------------

> Keep dependencies in mapping different ways:
```csharp
MapperUtil.KeepDependencies(foo, fooDTO);
var barDTO = MapperUtil.KeepDependencies<BarDTO>(bar);
bar = MapperUtil.KeepDependencies<BarDTO, Bar>(barDTO);
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

### Gadget of string (this is a extension)
Take advantage of the mapping capabilities through the static class  ```StringUtil```

> Returns null or text without side spaces:
```csharp
using PESALEXMapper.Helper;
...
var result = " ".TrimNull();
var result2 = " any ".TrimNull();
// result => null
// result2 => "any"
```

------------

> Remove spaces within the text and return in tiny:
```csharp
var result = ImplementationUtil.Tyne("Foo Bar TEST");
// result => "foobartest"
```

------------

> ~~Removes parentheses from text:~~
[Obsolete] use RemoveSpecialChars
```csharp
var result = ImplementationUtil.WithoutParentheses("Foo (bar)");
// result => "Foo bar"
```

------------

> Remove special char from text:
```csharp
var arrange = "Foo (bar)";
var result = arrange.RemoveSpecialChars("(", ")");
// result => "Foo bar"
```

------------

> Remove all special characters of string:
```csharp
var result = ImplementationUtil.Alphanumeric("#@$a123$% 4567890A@#$@#$");
// result => "a1234567890A"
```

------------

> Return only letters:
```csharp
var result = ImplementationUtil.Alphabetic("34a097A2424 ");
// result => "aA"
```

------------

> Returns only numerics:
```csharp
var result = ImplementationUtil.Numerics("1A2s3#4%5¨6¨&7*8(9@0T");
// result => "1234567890"
```

------------

> Capitalize sentence:
```csharp
var result = ImplementationUtil.Capitalize("capitalize sentence");
// result => "Capitalize Sentence"
```

------------

> Capitalize first letter in text:
```csharp
var result = ImplementationUtil.CapitalizeFirst("capitalize first letter");
// result => "Capitalize first letter"
```

### Gadget of Enum
Take advantage of the mapping capabilities through the static class  ```EnumUtil```

#### Example of Enum
```csharp
    [Description("Values")]
    public enum EnumValue
    {
        [Description("1ª name")]
        Foo,
        [Description("2ª name")]
        Bar,
        [Description("3ª name")]
        FooBar,
        [Description("4ª name")]
        BarFoo
    }
```

------------

> Obtain the description of the member of an enum:
```csharp
var result = EnumUtil.DescriptionList<EnumValue>();
// result.Count => 4
```

------------

> Obtain the description of an enum:
```csharp
var result = EnumUtil.GetDescriptionOfType<EnumValue>();
// result => "Values"
```

------------

> Obtain the description list of all members:
```csharp
var result = EnumUtil.GetDescription<EnumValue>(EnumValue.FooBar.ToString());
// result =>"3ª name"
```

## Report Support
To report errors, questions and suggestions go to the [link](https://www.nuget.org/packages/PESALEXMapper.Helper/1.0.0/ReportMyPackage)
