﻿using ConsoleApp4.Repositories;
using Microsoft.Extensions.Configuration;

//TODO: add logging and error handling
var config = GetConfiguration();
var sourceFilePath = config["SourceRoutesFilePath"] ?? throw new Exception("Cannot load configuration file path.");

//TODO:use relative path instead of global
var service = new FastestPathService(new RoutesCsvRepository(sourceFilePath));

var fastest = service.FindFastestPaths(new City("0"));

Console.WriteLine(string.Join(',', fastest.Select(x => $"{x.Point.Name}: {x.MinDuration.TotalDays}")));

static IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    IConfiguration config = builder.Build();
    return config;
}