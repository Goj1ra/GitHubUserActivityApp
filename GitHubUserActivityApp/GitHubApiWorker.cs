
using Newtonsoft.Json.Linq;

namespace GitHubUserActivityApp
{
    public class GitHubApiWorker
    {
        public string Username { get; set; }
        private string apiUrl { get; set; }
        public GitHubApiWorker(string username)
        {
            Username = username;
            apiUrl = $"https://api.github.com/users/{username}";
        }

        public async Task<string> UserDataReturnerAsync()
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "GitHubUserActivityApp");

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();
                JObject user = JObject.Parse(responseData);
                Console.WriteLine($"User: {user["login"]}");
                Console.WriteLine($"Name: {user["name"]}");
                Console.WriteLine($"Bio: {user["bio"]}");
                Console.WriteLine($"Location: {user["location"]}");
                Console.WriteLine($"Public Repos: {user["public_repos"]}");
                Console.WriteLine($"Followers: {user["followers"]}");
                Console.WriteLine($"Following: {user["following"]}");
                return " ";

            }
            catch (HttpRequestException e)
            {
                return $"Request error: {e.Message}";
            }
        }
    }
}
