![NuGet Version](https://img.shields.io/nuget/v/PartialSourceGen.Attributes)

# What is this

This is a library containing the marker attributes used in `PartialSourceGen` library. In the normal use case, this library is not necessary, so this should not be needed to install!

It is needed, if you need to enable `InternalsVisibleTo` and you will get an error of `CS0436`.

# Why
The source generator generates the attributes used as markers into your project with an `internal` scope.

When enabling `InternalsVisibleTo` all projects that reference each other will generate their own version of the same attribute markers, which normally is not visible to other projects.

# Installation

Run `dotnet add package PartialSourceGen.Attributes` to add the marker attributes.

Then in your csproj file enable `PARTIALSOURCEGEN_EXCLUDE_ATTRIBUTES` constant:

```xml
 <!-- File: myproject.csproj ... omitted rest of file content -->
 <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <!-- Add MS build constant -->
        <DefineConstants>PARTIALSOURCEGEN_EXCLUDE_ATTRIBUTES</DefineConstants>
    </PropertyGroup>
 </Project>
```

# Contains

No logic only attributes.  
The marker attributes can be found in the `PartialSourceGen` namespace:

- `Partial`
- `IncludeInitializer`
- `ExcludePartial`
- `ForceNull`
- `PartialReference`

The `PartialReference` comes in 2 variants, the newer dotnet 7.0, generic attribute variant and the traditional non-generic attribute variant.

# Alternative solution
You can write your own attributes and put them in the `PartialSourceGen` namespace. The attributes do not contain logic, and are only markers for the source generator.

# Versioning
The versioning of this library does not follow the source generator versioning.

# References
The main `PartialSourceGen` project can be found here: https://github.com/Newex/PartialSourceGen