using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using CodeBase.UI.Windows;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace CodeBase.Services.StaticData
{
  public class StaticDataService : IStaticDataService, IInitializable
  {
    private const string DefaultFolder = "Static Data";

    private Dictionary<WindowId, AssetReference> _windowsData;
    private Dictionary<int, LevelData> _levels;

    public void Initialize()
    {
      _windowsData = Resources.LoadAll<WindowsStaticData>(DefaultFolder)
        .First()
        .WindowsData
        .ToDictionary(windowData => windowData.Id, windowData => windowData.AssetReference);
      
      _levels = Resources
        .LoadAll<LevelStaticData>(DefaultFolder)
        .First()
        .LevelsData
        .OrderBy(levelData => levelData.LevelNumber)
        .ToDictionary(x => x.LevelNumber, x => x);
    }

    public AssetReference ForWindow(WindowId id) =>
      _windowsData.TryGetValue(id, out AssetReference assetReference)
        ? assetReference
        : throw new KeyNotFoundException($"WindowId:{id.ToString()} not found");

    public LevelData ForLevel(int levelNumber) =>
      _levels.TryGetValue(levelNumber, out LevelData staticData)
        ? staticData
        : throw new KeyNotFoundException($"Level:{levelNumber} not found");
  }
}