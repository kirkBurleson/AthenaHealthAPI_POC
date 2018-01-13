namespace Interfaces
{
    public interface IAthenaService
    {
        IServiceResult Create(IServiceInput input);
        IServiceResult Search(IServiceInput input);
        IServiceResult Update(IServiceInput input);
    }
}
