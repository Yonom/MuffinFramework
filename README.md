**MuffinFramework** is a library that assists you in creating automated applications. These can be bots but MuffinFramework can also be used to add Plugin functionality to an existing program, as Plugins are automated as well and do not require any direct interaction from other parts of your software.

[![Build status](https://ci.appveyor.com/api/projects/status/tlnfswmv92rul6aj)](https://ci.appveyor.com/project/Yonom/muffinframework)

MuffinFramework requires Microsoft Visual Studio 2010 or higher and supports the following frameworks:

- .NET Framework 4 and higher
- Silverlight 5

Programs using MuffinFramework will have their code split in three different "Layers". The Platform layer is the lowest one, then there is the Services layer and finally there comes the Muffin layer. MuffinFramework will take care of loading your classes so you don't have to write a lot of code to "glue" these parts together. 

This allows you to spend more time writing the actual code and results in a much cleaner code base.

## Quick Start guide
To start using MuffinFramework, create a new console application and add ```MuffinFramework.dll``` as a resource in visual studio.
Now edit your ```Program.cs``` so it looks like this.

```csharp
using System;
using MuffinFramework;

class Program
{
    static void Main()
    {
        var client = new MuffinClient();
        client.Start();

        Console.ReadLine();
        
        client.Dispose();
    }
}
```
From here, the created client will take care of detecting, loading and executing your Platforms, Services and Muffins. Of course you can also use MuffinFramework in all kinds of .NET Applications or add other functionality to your ```Program.cs```.

Now you can continue by adding three folders to your project:

- Platforms
- Services
- Muffins

These will hold their  ```Layer ``` classes respectively.

An example of this setup can be found in the samples section of the Framework (```SampleApplication1```).

You will find it easier to start coding by first creating a Muffin and adding Platforms/Services as the need arrives later. Below you will find templates needed to create a  ```Layer ``` class.

## Layers
In MuffinFramework, you split your code in three layers. These layers each have their own purpose. Once a class inherits one of the three basic Layer classes, it will be automatically detected using MEF and there is no need to reference it anywhere in your code. By default, only the assembly calling ```MuffinClient```'s constructor will be searched for classes to load. MuffinFramework can also search through multiple assemblies. This will be explained in another section of the readme.


### Muffins
Muffins are the part of your program that do the actual work and they usually don't provide functions for other classes to use as they control their actions themselves. MuffinFramework's pattern is suitable for bots because it is bots that do automated actions and are not given tasks from a user. Muffins are loaded after all other layers and can access both Services and Platforms. 

**Template:**
```csharp
using MuffinFramework.Muffin;

public class Muffin1 : Muffin
{
    protected override void Enable()
    {
        // Your code here...
    }
}
```

### Services
Services function as a communication layer between Muffins and Platforms. They almost always depend on one or more platforms and enhance their functionality. Services are loaded after all Platforms are.

**Template:**
```csharp
using MuffinFramework.Service;

public class Service1 : Service
{
    protected override void Enable()
    {
        // Your code here...
    }
}
```

### Platforms
Platforms communicate with other external systems. This can be the console output, an IRC connection to a server or any kind of web API. Platforms establish and maintain these connections. They are the first group of classes to be loaded.

**Template:**
```csharp
using MuffinFramework.Platform;

public class Platform1 : Platform
{
    protected override void Enable()
    {
        // Your code here...
    }
}
```

## Accessing other layers
To consume a ```Platform```/```Service```, you must first retrieve the loaded instance from its ```Loader```.
```csharp
Platform1 platform = this.PlatformLoader.Get<Platform1>();
```

An example of this in action can be found in ```SampleApplication2```.

 ```LayerLoader<,>.Get<TType>``` returns the loaded instance of the given ```TType```. If no  ```Layer ``` can be cast to ```TType```, a ```KeyNotFoundException``` is thrown.

LayerLoaders of higher layers are not available to lower ones. (Ex. you can not access ```MuffinLoader``` from a ```Service```)

Be careful when querying for classes in the same layer: there is no guarantee that a  ```Layer ``` will load before another and the loading order of layers might change from time to time. Therefore you must wait for all classes in a layer to load before querying a class. ```LayerLoader<,>.EnableComplete``` event can be useful in these situations. (See ```SampleApplication3```)

## Parts
Not every ```Muffin```/```Service```/```Protocol``` has basic tasks to do, some of them might need to be split in smaller separate parts that work together. Parts are there for this exact purpose. Instead of having to use multiple Muffins where the process of accessing other Muffins is complicated, you can use MuffinParts. MuffinParts are activated by a Muffin or another ```MuffinPart```.
They require a ```TProtocol``` class or interface, this can be your main class or any other object and is provided by the creator of the ```MuffinPart```. This object will then be stored in the ```MuffinPart.Host``` property.

To create a part, inherit from ```MuffinPart<TProtocol>```/```ServicePart<TProtocol>```/```PlatformPart<TProtocol>``` instead of  the base classes. As the type parameter  ```TProtocol ```, you can use your main  ```Layer ``` class (e.g. ```MuffinPart<Muffin1>```). Everything else will be the same as working with normal  ```Layer ``` classes.

Parts are not initialized by MuffinFramework automatically and must be "Enabled" by another class. This class can be a  ```Layer ``` or even another  ```LayerPart ```.

The following syntax can be used for this purpose:
```csharp
LayerPart<,>.EnablePart<TPart, TProtocol>(TProtocol host);
```

Because in the following example the the class calling ```EnablePart<,>(TProtocol host)``` is used as the ```TProtocol```, you can omit the host parameter. MuffinFramework will try to cast ```this``` to the given ```TProtocol```.
```csharp
// These are equivalent
MuffinPart1 part1 = this.EnablePart<MuffinPart1, Muffin1>(this);
MuffinPart1 part2 = this.EnablePart<MuffinPart1, Muffin1>();
```

If you want to avoid having to specify ```TProtocol``` every time you enable a part, change your main class so it inherits from ```Muffin<TProtocol>```/```Service<TProtocol>```/```Platform<TProtocol>```. 

```csharp
public class Muffin1 : Muffin<Muffin1>
```
Now you can omit the second type parameter for ```EnablePart```.

```csharp
// These are equivalent as well
MuffinPart1 part1 = this.EnablePart<MuffinPart1>(this);
MuffinPart1 part2 = this.EnablePart<MuffinPart1>();
```
For more help, take a look at ```SampleApplication4``` which contains some usage examples.

## IDisposable support
All three base classes ```Muffin```, ```Service``` and ```Platform``` and also the three part classes ```MuffinPart```, ```ServicePart``` and ```PlatformPart``` implement ```IDisposable```. 
```MuffinClient.Dispose()``` will dispose all  ```Layer ``` classes loaded by MuffinFramework in the following order: Muffins, then Services and finally the Platforms. It is recommended to call this function before exiting so that  ```Layer ``` classes can rely on  ```Dispose() ``` for doing tasks such as saving user data, gracefully closing TCP connections etc.

## Managed Extensibility Framework
To load classes not located in the current assembly, you must edit ```MuffinClient.Catalog``` to add or remove catalogs. For loading classes, MuffinFramework uses MEF and you will need to reference ```System.ComponentModel.Composite``` to edit the catalog. More help for MEF catalogs can be found [here][1]. 

You can also take a look at ```SampleApplication6``` which contains a separate library for its ```Muffin``` classes.
  [1]: https://mef.codeplex.com/wikipage?title=Using%20Catalogs 
