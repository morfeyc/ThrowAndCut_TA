using CodeBase.Infrastructure.Assets;
using CodeBase.Services.StaticData;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Windows;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Services.Factory
{
  public class UIFactory : IUIFactory
  {
    private readonly DiContainer _diContainer;
    private readonly IAssetProvider _assets;
    private readonly IStaticDataService _staticData;

    private Transform _uiRoot;

    public UIFactory(DiContainer diContainer, IAssetProvider assets, IStaticDataService staticData)
    {
      _diContainer = diContainer;
      _assets = assets;
      _staticData = staticData;
    }

    public async UniTask CreateUIRoot()
    {
      GameObject uiRootPrefab = await _assets.Load<GameObject>(AssetAddress.UIRootKey);
      GameObject uiRootObj = _diContainer.InstantiatePrefab(uiRootPrefab);
      _uiRoot = uiRootObj.transform;
    }

    public async UniTask<WindowBase> CreateWindow(WindowId id)
    {
      GameObject windowObj = await _assets.Load<GameObject>(_staticData.ForWindow(id));
      WindowBase window = _diContainer.InstantiatePrefabForComponent<WindowBase>(windowObj, _uiRoot);

      window.Close();
      return window;
    }
  }
}