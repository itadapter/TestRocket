using System.Threading;
using System.Threading.Tasks;

namespace RocketConsole
{
  public interface IWorker
  {
    Task ExecuteAsync(CancellationToken stoppingToken);
  }
}