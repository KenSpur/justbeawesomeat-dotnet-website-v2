namespace Client.Services;

public interface INavigationService
{
    public Func<Task> AnimatePageRemovalAsync { get; set; }

    Task NavigateToAsync(string page);
    Task NavigateToNextPageAsync();
    Task NavigateToPreviousPageAsync();
}