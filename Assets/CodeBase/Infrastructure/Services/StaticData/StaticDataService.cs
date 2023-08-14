using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Windows;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace CodeBase.Infrastructure.Services.StaticData
{
  public class StaticDataService : IStaticDataService, IInitializable
  {
    private const string DefaultFolder = "Static Data";

    private Dictionary<WindowId, AssetReference> _windowsData;

    public void Initialize()
    {
      _windowsData = Resources.LoadAll<WindowsStaticData>(DefaultFolder)
        .First()
        .WindowsData
        .ToDictionary(windowData => windowData.Id, windowData => windowData.AssetReference);
    }

    public AssetReference ForWindow(WindowId id) =>
      _windowsData.TryGetValue(id, out AssetReference assetReference)
        ? assetReference
        : throw new KeyNotFoundException($"WindowId:{id.ToString()} not found");
  }
}