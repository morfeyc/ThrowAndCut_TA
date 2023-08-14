﻿using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Services.Assets;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.LoadingCurtain
{
  public class LoadingCurtainService : ILoadingCurtainService
  {
    private readonly IGameFactory _gameFactory;

    private UI.Elements.LoadingCurtain _loadingCurtain;

    public LoadingCurtainService(IGameFactory gameFactory)
    {
      _gameFactory = gameFactory;
    }

    public async UniTask Initialize()
    {
      _loadingCurtain = await _gameFactory.InstantiateDIObject<UI.Elements.LoadingCurtain>(AssetAddress.LoadingCurtainKey);
    }

    public void Show() =>
      _loadingCurtain.Show();

    public void Hide() =>
      _loadingCurtain.Hide();
  }
}