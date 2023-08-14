using CodeBase.UI.Windows;
using UnityEngine.AddressableAssets;

namespace CodeBase.Services.StaticData
{
  public interface IStaticDataService
  {
    AssetReference ForWindow(WindowId id);
  }
}