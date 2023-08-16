using CodeBase.UI.Windows;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.Factory
{
  public interface IUIFactory
  {
    UniTask CreateUIRoot();
    UniTask<WindowBase> CreateWindow(WindowId id);
  }
}