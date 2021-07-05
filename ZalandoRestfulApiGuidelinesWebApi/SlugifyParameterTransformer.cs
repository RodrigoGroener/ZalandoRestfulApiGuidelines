using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace ZalandoRestfulApiGuidelinesWebApi
{
    // Source https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#use-a-parameter-transformer-to-customize-token-replacement
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            if (value == null) { return null; }

            return Regex.Replace(value.ToString(),
                "([a-z])([A-Z])",
                "$1-$2",
                RegexOptions.CultureInvariant,
                TimeSpan.FromMilliseconds(100)).ToLowerInvariant();
        }
    }
}