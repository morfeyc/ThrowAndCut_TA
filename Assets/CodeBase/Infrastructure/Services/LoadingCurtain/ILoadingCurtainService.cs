using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.LoadingCurtain
{
  public interface ILoadingCurtainService
  {
    UniTask Initialize();
    void Show();
    void Hide();
  }
}