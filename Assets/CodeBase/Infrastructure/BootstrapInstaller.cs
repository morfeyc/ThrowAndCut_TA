using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.GameStateMachine;
using CodeBase.Infrastructure.GameStateMachine.Provider;
using CodeBase.Infrastructure.GameStateMachine.States;
using CodeBase.Infrastructure.Services.Assets;
using CodeBase.Infrastructure.Services.Inputs;
using CodeBase.Infrastructure.Services.LoadingCurtain;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Window;
using Zenject;

namespace CodeBase.Infrastructure
{
  public class BootstrapInstaller : MonoInstaller, IInitializable, IDisposable
  {
    public override void InstallBindings()
    {
      BindInputs();
      BindAssets();
      BindSceneLoader();
      BindLoadingCurtain();
      BindStaticData();
      BindServices();
      BindFactories();
      BindUIServices();
      BindGameStateMachine();
      BindSelf();
    }

    public void Initialize()
    {
      IGameStateMachine gameStateMachine = Container.Resolve<IGameStateMachine>();
      Container.Resolve<IGameStateMachineProvider>().Value = gameStateMachine;
      gameStateMachine.Enter<BootstrapState>();
    }

    private void BindInputs()
    {
      Container
        .BindInterfacesTo<InputService>()
        .AsSingle()
        .NonLazy();
    }

    private void BindAssets()
    {
      Container
        .BindInterfacesTo<AssetProvider>()
        .AsSingle()
        .NonLazy();
    }

    private void BindSceneLoader()
    {
      Container
        .BindInterfacesTo<SceneLoaderService>()
        .AsSingle()
        .NonLazy();
    }

    private void BindLoadingCurtain()
    {
      Container
        .BindInterfacesTo<LoadingCurtainService>()
        .AsSingle()
        .NonLazy();
    }

    private void BindStaticData()
    {
      Container
        .BindInterfacesTo<StaticDataService>()
        .AsSingle()
        .NonLazy();
    }


    private void BindServices()
    {
      Container
        .BindInterfacesTo<ProgressService>()
        .AsSingle()
        .NonLazy();

      Container
        .BindInterfacesTo<SaveLoadService>()
        .AsSingle()
        .NonLazy();
    }

    private void BindFactories()
    {
      Container
        .BindInterfacesTo<GameFactory>()
        .AsSingle()
        .NonLazy();
    }

    private void BindUIServices()
    {
      Container
        .BindInterfacesTo<UIFactory>()
        .AsSingle()
        .NonLazy();

      Container
        .BindInterfacesTo<WindowService>()
        .AsSingle()
        .NonLazy();
    }

    private void BindGameStateMachine()
    {
      Container
        .BindInterfacesTo<GameStateMachineProvider>()
        .AsSingle()
        .NonLazy();

      BindGameStateMachineStates();

      Container
        .BindInterfacesTo<GameStateMachine.GameStateMachine>()
        .AsSingle()
        .NonLazy();
    }

    private void BindGameStateMachineStates()
    {
      Container
        .BindInterfacesTo<BootstrapState>()
        .AsSingle()
        .NonLazy();

      Container
        .BindInterfacesTo<LoadProgressState>()
        .AsSingle()
        .NonLazy();

      Container
        .BindInterfacesTo<LoadLevelState>()
        .AsSingle()
        .NonLazy();

      Container
        .BindInterfacesTo<GameLoopState>()
        .AsSingle()
        .NonLazy();
    }

    private void BindSelf()
    {
      Container
        .Bind<IInitializable>()
        .FromInstance(this);
    }

    public void Dispose()
    {
      List<IDisposable> disposables = Container
        .ResolveAll<IDisposable>();

      foreach (IDisposable disposable in disposables)
        disposable.Dispose();
    }
  }
}