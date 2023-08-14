using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress
{
  public interface IProgressService
  {
    PlayerProgress Progress { get; set; }
  }
}