using System.Collections.Generic;
using Cinemachine;
using CodeBase.Data;
using CodeBase.Infrastructure.Assets;
using CodeBase.Logic.PlayingCard;
using CodeBase.Logic.Slicing;
using CodeBase.Services.Progress;
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
    [Space(15)] 
    [SerializeField] private List<SliceableObject> _objectsToSlice;

    private IAssetProvider _assets;
    private IProgressService _progressService;

    public override void InstallBindings()
    {
      Container
        .Bind<IInitializable>()
        .FromInstance(this);
    }

    public async void Initialize()
    {
      _assets = Container.Resolve<IAssetProvider>();
      _progressService = Container.Resolve<IProgressService>();
      _progressService.Progress.LevelTask = new LevelTask(_objectsToSlice.Count);

      await InstantiateCardThrower();
    }

    private async UniTask InstantiateCardThrower()
    {
      GameObject cardThrowerObj = await _assets.Load<GameObject>(_cardThrower);
      CardThrower cardThrower = Container.InstantiatePrefabForComponent<CardThrower>(cardThrowerObj);
      
      cardThrower.Init(_throwerStartPoint.position, _throwerEndPoint.position);
    }
  }
}