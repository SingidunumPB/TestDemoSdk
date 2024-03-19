using DemoSdk.Dto;
using Refit;

namespace DemoSdk;

public interface IDemoApi
{
    [Post("/api/Product/Create/create")]
    public Task<DemoProductCreateResponseDto> CreateProductAsync(DemoProductRequestDto request);
}
