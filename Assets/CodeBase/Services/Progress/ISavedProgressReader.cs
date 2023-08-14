using CodeBase.Data;

namespace CodeBase.Services.Progress
{
  public interface ISavedProgressReader
  {
    void LoadProgress(PlayerProgress progress);
  }
}