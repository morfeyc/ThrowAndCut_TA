using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress
{
  public interface ISavedProgress : ISavedProgressReader
  {
    void UpdateProgress(PlayerProgress progress);
  }
}