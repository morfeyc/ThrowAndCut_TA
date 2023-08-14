using System.Collections.Generic;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Windows;

namespace CodeBase.UI.Services.Window
{
  public class WindowService : IWindowService
  {
    private readonly IUIFactory _uiFactory;

    private readonly Dictionary<WindowId, WindowBase> _cachedWindows = new();

    public WindowService(IUIFactory uiFactory)
    {
      _uiFactory = uiFactory;
    }

    public async void Open(WindowId id)
    {
      if (TryGetFromCache(id, out WindowBase cachedWindow))
      {
        cachedWindow.Open();
        return;
      }

      WindowBase window = await _uiFactory.CreateWindow(id);
      window.Open();
      _cachedWindows[id] = window;
    }

    public void Close(WindowId id)
    {
      if (TryGetFromCache(id, out WindowBase cachedWindow)) 
        cachedWindow.Close();
    }

    public void CleanUp()
    {
      foreach (WindowBase window in _cachedWindows.Values)
        window.Destroy();

      _cachedWindows.Clear();
    }

    private bool TryGetFromCache(WindowId id, out WindowBase window)
    {
      if (!_cachedWindows.TryGetValue(id, out WindowBase cachedWindow))
      {
        window = null;
        return false;
      }

      window = cachedWindow;
      return true;
    }
  }
}