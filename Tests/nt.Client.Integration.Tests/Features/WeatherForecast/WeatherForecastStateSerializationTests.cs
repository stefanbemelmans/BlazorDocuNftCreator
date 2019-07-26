﻿namespace nt.Client.Integration.Tests.Features.WeatherForecast
{
  using System;
  using Shouldly;
  using nt.Shared.Features.WeatherForecast;
  using System.Text.Json.Serialization;

  internal class WeatherForecastStateSerializationTests
  {

    public class Person
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime? BirthDay { get; set; }
    }

    public void ShouldSerializeAndParseSample()
    {
      var jsonSerializerOptions = new JsonSerializerOptions();
      var person = new Person { FirstName = "Steve", LastName = "Cramer", BirthDay = new DateTime(1967, 09, 27) };
      string json = JsonSerializer.ToString(person, jsonSerializerOptions);
      Person parsed = JsonSerializer.Parse<Person>(json, jsonSerializerOptions);
      parsed.BirthDay.ShouldBe(person.BirthDay);
      parsed.FirstName.ShouldBe(person.FirstName);
      parsed.LastName.ShouldBe(person.LastName);
    }

    public void ShouldSerializeAndParse()
    {
      //Arrange
      var jsonSerializerOptions = new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
      var weatherForecastDto = new WeatherForecastDto
      (
        aDate: DateTime.MinValue.ToUniversalTime(), 
        aSummary: "Summary 1",
        aTemperatureC: 24
      );

      string json = JsonSerializer.ToString(weatherForecastDto, jsonSerializerOptions);

      //Act
      WeatherForecastDto parsed = JsonSerializer.Parse<WeatherForecastDto>(json, jsonSerializerOptions);

      //Assert
      weatherForecastDto.TemperatureC.ShouldBe(parsed.TemperatureC);
      weatherForecastDto.Summary.ShouldBe(parsed.Summary);
      weatherForecastDto.Date.ShouldBe(parsed.Date);
    }
  }
}
