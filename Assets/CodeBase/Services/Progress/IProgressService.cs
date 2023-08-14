using CodeBase.Data;

namespace CodeBase.Services.Progress
{
  public interface IProgressService
  {
    PlayerProgress Progress { get; set; }
  }
}