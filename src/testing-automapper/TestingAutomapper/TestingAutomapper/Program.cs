// See https://aka.ms/new-console-template for more information
using AutoMapper;
using System.Collections.Generic;
using System.Diagnostics;
using TestingAutomapper.Models;

var config = new MapperConfiguration(cfg => {
    cfg.CreateMap<Source, Target>();
});

var mapper = config.CreateMapper();
mapper.ConfigurationProvider.AssertConfigurationIsValid();

var source = new Source() { Active = true, Id = 99, Name = "TestName", Numbers = new List<int>() { 1, 8, 88, 987 }, Property = "TestProperty" };
int iterations = 200000;

Stopwatch sw = new Stopwatch();

sw.Start();
for (int i = 0; i < iterations; i++)
{
    var target = ManualMap(source);
}
sw.Stop();
Console.WriteLine("Manual mapping time: " + sw.ElapsedMilliseconds + "ms");

sw.Restart();
for (int i = 0; i < iterations; i++)
{
    var target = AutoMap(source);
}

Console.WriteLine("Auto-map time: " + sw.ElapsedMilliseconds + "ms");
sw.Restart();
var sourceList = new List<Source>();
for (int i = 0; i < iterations; i++)
{
    sourceList.Add(source);    
}
var mappedList = AutoMapList(sourceList);
sw.Stop();
Console.WriteLine("Auto-map list time: " + sw.ElapsedMilliseconds + "ms");
Console.ReadLine();


Target ManualMap(Source item)
{
    return new Target()
    {
        Active = item.Active,
        Id = item.Id,
        Name = item.Name,
        Numbers = item.Numbers,
        Property = item.Property
    };
}

Target AutoMap(Source item)
{    
    return mapper.Map<Target>(item);    
}

List<Target> AutoMapList(List<Source> items)
{
    return mapper.Map<List<Target>>(items);
}
