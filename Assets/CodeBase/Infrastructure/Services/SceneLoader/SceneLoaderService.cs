using System;
using CodeBase.Infrastructure.Services.LoadingCurtain;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
  public class SceneLoaderService : ISceneLoaderService
  {
    private readonly ILoadingCurtainService _loadingCurtain;

    public SceneLoaderService(ILoadingCurtainService loadingCurtain)
    {
      _loadingCurtain = loadingCurtain;
    }

    public void Load(string sceneName, Action onLoaded = null) =>
      LoadAsync(sceneName, onLoaded).Forget();

    private async UniTaskVoid LoadAsync(string sceneName, Action onLoaded = null)
    {
      _loadingCurtain.Show();
      AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

      while (!loadSceneAsync.isDone)
        await UniTask.Yield();

      _loadingCurtain.Hide();
      onLoaded?.Invoke();
    }
  }
}