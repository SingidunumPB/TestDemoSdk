
using Microsoft.AspNetCore.Mvc;
using NsiDemo.Sdk;
using NsiDemo.Sdk.Application.Client;
using NsiDemo.Sdk.Application.Models;
using NsiDemo.Sdk.Dto;
using Refit;

namespace TestSdk.Controllers;

public class ProductController() : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(DemoProductCreateDto product)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5026"),
        };

        var api = RestService.For<IDemoApi>(httpClient);
        var client = new NsiDemoSdkClient(api);
        
        var headers = new Dictionary<string, string> 
        {
            {"X-De-Username", "petar_bisevacc"},
            {"X-De-Password", "test123"}
        };
        
        var result = await client.CreateProductAsync(new DemoProductRequestModel(product.CompanyId, product.Name, "http://localhost:5026", headers));
        return Ok(result);
    }
}