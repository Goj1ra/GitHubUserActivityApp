using GitHubUserActivityApp;

Console.Write("Write your username: ");
var username = Console.ReadLine();
if (username.Length == 0)
{
    Console.WriteLine("Usage: github-activity <username>");
    return;
}

GitHubApiWorker gitHubApiWorker = new GitHubApiWorker(username);
await gitHubApiWorker.UserDataReturnerAsync();
Console.ReadLine();

