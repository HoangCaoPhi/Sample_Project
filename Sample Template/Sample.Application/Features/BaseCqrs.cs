namespace Sample.Application.Features
{
    public class BaseCqrs<TRepo>
    {
       protected readonly TRepo _repo;       

       public BaseCqrs(TRepo repo)
        {
            _repo = repo;
        }
    }
}
