# Configure ASP.NET Core 5.0 to conform to the Zalando’s RESTful API Guidelines

Zalando’s RESTful API Guidelines describes in detail how they design RESTful APIs. This sample app  demonstrates how configure ASP.NET Core 5.0 Web APIs to conform to three specific rules regarding path and JSON body formatting. For that propose I modified the sample application “Weather Forecast” starter template.


## MUST use lowercase separate words with hyphens for path segments [#129](https://opensource.zalando.com/restful-api-guidelines/#129)
use of an `RouteTokenTransformerConvention` to conform to this rule.
```csharp
services.AddControllers(options =>
  {
      options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
  })
```

## MUST property names must be ASCII snake_case (and never camelCase): `^[a-z_][a-z_0-9]*$` [#118](https://opensource.zalando.com/restful-api-guidelines/#118)
use of `SnakeCaseNamingStrategy` for JSON Bodys from Newtonsoft.Json
```csharp
  .AddNewtonsoftJson(options =>
  {
      options.SerializerSettings.ContractResolver = new DefaultContractResolver
      {
          NamingStrategy = new SnakeCaseNamingStrategy()
      };

      options.SerializerSettings.Converters.Add(new StringEnumConverter());
  });

services.AddSwaggerGenNewtonsoftSupport();
```


## MUST use snake_case (never camelCase) for query parameters [#130](https://opensource.zalando.com/restful-api-guidelines/#130)
use of `FromQueryAttribute`
```csharp
 [HttpGet]
  public IEnumerable<WeatherForecast> Search(
      [FromQuery(Name = "q")] string query,
      [FromQuery(Name = "created_before")] string createdBefore)
  {...}
```
