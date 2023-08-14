using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress
{
  public interface ISavedProgressReader
  {
    void LoadProgress(PlayerProgress progress);
  }
}