
using Microsoft.AspNetCore.Mvc;
using NsiDemo.Sdk;
using NsiDemo.Sdk.Dto;
using Refit;

namespace TestSdk.Controllers;

public class ProductController() : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(DemoProductCreateDto product)
    {
        var test = new NsiDemoSdkClient();
        var myApi = RestService.For<IDemoApi>("http://localhost:5026");
        var result = await myApi.CreateProductAsync(new DemoProductRequestDto(product));
        return Ok(result);
    }
}