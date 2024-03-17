using AddressApi.Map;
using Microsoft.AspNetCore.Mvc;

namespace AddressApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StreetController : ControllerBase
{
    private readonly ILogger<StreetController> _logger;
    private IAddressMap addresss_map;

    public StreetController(ILogger<StreetController> logger, IAddressMap addressMap)
    {
        _logger = logger;
        addresss_map = addressMap;
    }

    [HttpGet("street")]
    public Dictionary<string, string> Get(int communal_code, int street_code)
    {
        return addresss_map.Get(communal_code, street_code);
    }

    [HttpGet("street/search")]
    public IEnumerable<Dictionary<string, string>> Search(string query)
    {
        var result = addresss_map.Search(query);
        return addresss_map.Search(query);
    }
}
