using CodeBase.UI.Services.Window;
using CodeBase.UI.Windows;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Services.StaticData
{
  public interface IStaticDataService
  {
    AssetReference ForWindow(WindowId id);
  }
}