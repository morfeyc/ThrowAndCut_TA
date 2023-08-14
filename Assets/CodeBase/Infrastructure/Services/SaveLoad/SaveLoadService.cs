using CodeBase.Data;
using CodeBase.Infrastructure.Services.Progress;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "Progress";
    private readonly IProgressService _progressService;

    public SaveLoadService(IProgressService progressService)
    {
      _progressService = progressService;
    }

    public void SaveProgress() =>
      PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());

    public PlayerProgress LoadProgress() =>
      PlayerPrefs.GetString(ProgressKey)?
        .ToDeserialized<PlayerProgress>();
  }
}