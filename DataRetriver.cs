using System;
using System.Threading.Tasks;
using API_Consume;

namespace API_Consume
{
    public class DataRetriever
    {
        private readonly ApiClient _apiClient;

        public DataRetriever()
        {
            _apiClient = new ApiClient();
        }

        public async Task GetUserAndPostsAsync()
        {
            var users = await _apiClient.GetApiResponseAsync<UserApiResponse[]>("https://jsonplaceholder.typicode.com/users");

            foreach (var user in users)
            {
                int id = user.Id;
                string name = user.Name;
                string username = user.Username;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{id} - username: {username} - name: {name}");
                Console.ResetColor();
            }

            int userId = GetUserInput("Enter a user id to get their posts: ", 10);
            if (userId != -1)
            {
                await GetPostsByUserId(userId);
            }
        }

        private async Task GetPostsByUserId(int userId)
        {
            var posts = await _apiClient.GetApiResponseAsync<PostApiResponse[]>($"https://jsonplaceholder.typicode.com/posts?userId={userId}");

            foreach (var post in posts)
            {
                int id = post.Id;
                string title = post.Title;
                string body = post.Body;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{id} - title: {title}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"body: {body}");
                Console.ResetColor();
            }

            int postId = GetUserInput("Enter a post id to get its comments: ", 100);
            if (postId != -1)
            {
                await GetCommentsByPostId(postId);
            }
        }

        private async Task GetCommentsByPostId(int postId)
        {
            var comments = await _apiClient.GetApiResponseAsync<CommentApiResponse[]>($"https://jsonplaceholder.typicode.com/comments?postId={postId}");

            foreach (var comment in comments)
            {
                int id = comment.Id;
                string name = comment.Name;
                string email = comment.Email;
                string body = comment.Body;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{id} - name: {name} - email: {email}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"body: {body}");
                Console.ResetColor();
            }
        }

        private int GetUserInput(string prompt, int maxId)
        {
            Console.Write(prompt);
            int userInput;
            if (int.TryParse(Console.ReadLine(), out userInput) && userInput >= 1 && userInput <= maxId)
            {
                return userInput;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid input, please enter a valid id between 1 and {maxId}.");
                Console.ResetColor();
                return -1;
            }
        }
    }
}
