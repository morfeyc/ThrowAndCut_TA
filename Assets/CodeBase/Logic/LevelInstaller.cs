using System.Threading.Tasks;
using Cinemachine;
using CodeBase.Infrastructure.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace CodeBase.Logic
{
  public class LevelInstaller : MonoInstaller, IInitializable
  {
    [SerializeField] private CinemachineVirtualCamera _camera;
    [Space(15)]
    [SerializeField] private AssetReference _cardThrower;
    [SerializeField] private Transform _throwerStartPoint;
    [SerializeField] private Transform _throwerEndPoint;

    private IAssetProvider _assets;

    public override void InstallBindings()
    {
      Container
        .Bind<IInitializable>()
        .FromInstance(this);
    }

    public async void Initialize()
    {
      _assets = Container.Resolve<IAssetProvider>();

      await InstantiateCardThrower();
      _camera.Follow = _throwerStartPoint;
      _camera.LookAt = _throwerEndPoint;
    }

    private async UniTask InstantiateCardThrower()
    {
      GameObject cardThrowerObj = await _assets.Load<GameObject>(_cardThrower);
      Trajectory trajectory = Container.InstantiatePrefabForComponent<Trajectory>(cardThrowerObj);
      trajectory.Init(_throwerStartPoint.position, _throwerEndPoint.position);
    }
  }
}