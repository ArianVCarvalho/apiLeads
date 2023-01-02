using System.Net;
using System.Net.Http.Json;
using api.test.commom;
using FluentAssertions;

namespace api.test;

public class Tests
{
    private TestWebApp _app;
    private HttpClient _client;
    protected HttpClient Client => _client ?? throw new Exception("Setup was not run.");
    [SetUp]
    public void Setup()
    {
        _app = new TestWebApp();
        _client = _app.CreateClient();
        
    }
    
    [TearDown]
    public virtual async Task TearDown()
    {
        using (_client)
        {
            
        }

        await using (_app)
        {
        }
    }
    
    [Test]
    public async Task Test1()

    {
        var res = await SendAsync(HttpMethod.Get, "/","");
        res.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    protected async Task<HttpResponseMessage> SendAsync(HttpMethod method, string uri, string storeId,
        object? payload = null)
    {
        var jsonContent = JsonContent.Create(payload);
        var jsonString = await jsonContent.ReadAsStringAsync();
        var res = await Client.SendAsync(new HttpRequestMessage(method, uri)
        {
            Headers = { { "x-store-id", storeId } },
            Content = payload is not null ? jsonContent : null
        });
        await res.Dump();
        return res;
    }
}