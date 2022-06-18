using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Client.Services.Implementation;

public class NavigationService : INavigationService
{
    private readonly NavigationManager _navigationManager;
    private string _currentPage;

    private readonly IList<string> _pages = new List<string> { "", "aboutme", "resume", "contact" };

    public NavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;

        _currentPage = _navigationManager.Uri.Split('/').Last();
        _navigationManager.LocationChanged += _navigationManager_LocationChanged;
    }

    public Func<Task> AnimatePageRemovalAsync { get; set; }

    public async Task NavigateToAsync(string page)
    {
        if (_currentPage == page) return;

        await InvokeAnimatePageRemovalAsync();

        _navigationManager.NavigateTo(page);
    }

    public async Task NavigateToNextPageAsync()
    {
        var index = _pages.IndexOf(_currentPage);

        index++;

        if (index == _pages.Count)
            index = 0;

        await NavigateToAsync(_pages[index]);
    }

    public async Task NavigateToPreviousPageAsync()
    {
        var index = _pages.IndexOf(_currentPage);

        index--;

        if (index < 0)
            index = _pages.Count - 1;

        await NavigateToAsync(_pages[index]);
    }

    private async Task InvokeAnimatePageRemovalAsync()
    {
        if (AnimatePageRemovalAsync is null) return;

        await AnimatePageRemovalAsync.Invoke();

        AnimatePageRemovalAsync = null;
    }

    private void _navigationManager_LocationChanged(object sender, LocationChangedEventArgs e)
        => _currentPage = e.Location.Split('/').Last();

}