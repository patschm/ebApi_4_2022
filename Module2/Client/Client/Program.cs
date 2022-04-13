for(int i = 0; i < 5000; i++)
{
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("https://localhost:7282/test/");

    var response = await client.GetAsync("34/hoi");
    if(response.IsSuccessStatusCode)
    {
        System.Console.WriteLine(response.Content.Headers.ContentType);
        var data = await response.Content.ReadAsStringAsync();
        System.Console.WriteLine(   data);
    }
    client.Dispose();
}
Console.ReadLine();