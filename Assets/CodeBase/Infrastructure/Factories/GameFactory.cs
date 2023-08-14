using CodeBase.Infrastructure.Assets;
using CodeBase.Services.Progress;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
  public class GameFactory : IGameFactory, IInitializable
  {
    private readonly DiContainer _diContainer;
    private readonly IAssetProvider _assets;

    public GameFactory(DiContainer diContainer, IAssetProvider assets)
    {
      _diContainer = diContainer;
      _assets = assets;
    }

    public void Initialize()
    {
      _assets.Load<GameObject>(AssetAddress.LoadingCurtainKey);
    }

    public async UniTask<T> InstantiateDIObject<T>(string assetKey) where T : MonoBehaviour
    {
      GameObject objectToInstantiate = await _assets.Load<GameObject>(AssetAddress.LoadingCurtainKey);
      T component = _diContainer.InstantiatePrefabForComponent<T>(objectToInstantiate, parentTransform: null);
      return component;
    }
    
    public async UniTask<T> InstantiateDIObjectRegistered<T>(string assetKey) where T : MonoBehaviour
    {
      T component = await InstantiateDIObject<T>(assetKey);
      RegisterProgressWatchers(component.gameObject);
      return component;
    }
    
    private void RegisterProgressWatchers(GameObject gameObject)
    {
      foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
        Register(progressReader);
    }
    
    private void Register(ISavedProgressReader progressReader)
    {
      if (progressReader is ISavedProgress progressWriter)
        _diContainer
          .Bind<ISavedProgress>()
          .FromInstance(progressWriter)
          .NonLazy();

      _diContainer
        .Bind<ISavedProgressReader>()
        .FromInstance(progressReader)
        .NonLazy();
    }

    public void Cleanup()
    {
    }
  }
}