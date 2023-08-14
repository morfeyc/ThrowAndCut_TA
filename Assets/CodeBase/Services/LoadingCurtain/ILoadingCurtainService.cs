using Cysharp.Threading.Tasks;

namespace CodeBase.Services.LoadingCurtain
{
  public interface ILoadingCurtainService
  {
    UniTask Initialize();
    void Show();
    void Hide();
  }
}