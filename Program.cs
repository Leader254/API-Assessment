namespace API_Consume
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dataRetriever = new DataRetriever();
            await dataRetriever.GetUserAndPostsAsync();
        }
    }
}
