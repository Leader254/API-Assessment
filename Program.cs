using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        string apiUrl = "https://jsonplaceholder.typicode.com/users";

        HttpResponseMessage response = await client.GetAsync(apiUrl);
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<UserApiResponse[]>(responseBody);

            foreach (var user in users)
            {
                int id = user.Id;
                string name = user.Name;
                string username = user.Username;
                Console.WriteLine($"{id}- username: {username} - name: {name}");
            }
        }
        else
        {
            Console.WriteLine($"API request failed with status code: {response.StatusCode}");
        }
        Console.WriteLine("Enter a user id to get their posts: ");
        int userId = Convert.ToInt32(Console.ReadLine());
        await GetPostsByUserId(userId);

        async Task GetPostsByUserId(int userId)
        {
            HttpClient client = new HttpClient();
            string apiUrl = $"https://jsonplaceholder.typicode.com/posts?userId={userId}";

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<PostApiResponse[]>(responseBody);

                foreach (var post in posts)
                {
                    int id = post.Id;
                    string title = post.Title;
                    string body = post.Body;
                    Console.WriteLine($"{id}- title: {title}");
                    Console.WriteLine($"body: {body}");
                }
            }
            else
            {
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter a post id to get its comments: ");
            Console.ResetColor();
            int postId = Convert.ToInt32(Console.ReadLine());
            await GetCommentsByPostId(postId);

            async Task GetCommentsByPostId(int postId)
            {
                HttpClient client = new HttpClient();
                string apiUrl = $"https://jsonplaceholder.typicode.com/comments?postId={postId}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var comments = JsonConvert.DeserializeObject<CommentApiResponse[]>(responseBody);

                    foreach (var comment in comments)
                    {
                        int id = comment.Id;
                        string name = comment.Name;
                        string email = comment.Email;
                        string body = comment.Body;
                        Console.WriteLine($"{id}- name: {name} - email: {email} - body: {body}");
                    }
                }
                else
                {
                    Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                }
            }
        }
    }
}

public class UserApiResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

// public class Address
// {
//     public string Street { get; set; } = string.Empty;
//     public string Suite { get; set; } = string.Empty;
//     public string City { get; set; } = string.Empty;
//     public string Zipcode { get; set; } = string.Empty;
//     public Geo Geo { get; set; } = new Geo();
// }

// public class Geo
// {
//     public string Lat { get; set; } = string.Empty;
//     public string Lng { get; set; } = string.Empty;
// }

public class PostApiResponse
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}

public class CommentApiResponse
{
    public int PostId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}