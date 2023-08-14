using CodeBase.Data;

namespace CodeBase.Services.Progress
{
  public interface ISavedProgress : ISavedProgressReader
  {
    void UpdateProgress(PlayerProgress progress);
  }
}