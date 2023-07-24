using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using EntreEmpregos.Api.Entities;


namespace EntreEmpregos.Controllers;

[ApiController]
[Route("[controller]")]
public class NotionController : ControllerBase
{
    private readonly HttpClient _client = new HttpClient();

    private static readonly string token =
        "secret_=";

    // Definindo o ID do banco de dados do Notion
    private static readonly string databaseId =
        "b9d833f326df4b65870c6a94b2245f18";

    [HttpGet]
    public async Task<IActionResult> GetDatabase()
    {
        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
        _client.DefaultRequestHeaders.Add("Notion-Version", "2022-02-22");
        
        HttpContent contentBody = new StringContent(
            "",
            Encoding.UTF8,
            "application/json"
        );
        var response =
            await _client.PostAsync($"https://api.notion.com/v1/databases/{databaseId}/query",contentBody);
            
        if (response.IsSuccessStatusCode == false)
            return BadRequest(response.Content.ReadAsStringAsync());

        var content = response.Content.ReadAsStringAsync();

        var responseJson = JsonSerializer.Deserialize<Root>(content.Result);
        
        List<string> JobTitle = new List<string>();

        foreach (var item in responseJson.results)
        {
            JobTitle.Add(item.properties.Name.title[0].plain_text);
        }

        return Ok(JobTitle);
    }
}