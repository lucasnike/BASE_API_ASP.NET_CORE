namespace Infra.Data.Repositories.Interfaces;


public interface ISummaryRepository : IRepository
{
    IEnumerable<string> Get();
}
