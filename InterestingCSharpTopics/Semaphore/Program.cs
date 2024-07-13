HttpClient _client = new()
{
    Timeout = TimeSpan.FromSeconds(5)
};
SemaphoreSlim _gate = new(10);

Task.WaitAll(CreateCalls().ToArray());

IEnumerable<Task> CreateCalls()
{
    for (int i = 0; i < 500; i++)
    {
        yield return CallGoogleAsync();
    }
}
 async Task CallGoogleAsync()
{
    try
    {
        await _gate.WaitAsync();
        var response = await _client.GetAsync("https://google.com");
        _gate.Release();
        Console.WriteLine(response.StatusCode);
    }
    catch (Exception e)
    {

         Console.WriteLine(e.Message);
    }
}
    


