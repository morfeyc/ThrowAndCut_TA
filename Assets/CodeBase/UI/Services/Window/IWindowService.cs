using CodeBase.UI.Windows;

namespace CodeBase.UI.Services.Window
{
  public interface IWindowService
  {
    void Open(WindowId id);
    void Close(WindowId id);
    void CleanUp();
  }
}