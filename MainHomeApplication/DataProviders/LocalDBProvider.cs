using MainHomeApplication.Models;

namespace MainHomeApplication.DataProviders
{
    public class LocalDBProvider : IHomeDataProvider
    {
        ApplicationContext _context;
        public LocalDBProvider(ApplicationContext context)
        {
            _context = context;
        }
        Home IHomeDataProvider.createHome(Home home)
        {
            this._context.Homes.Add(home);
            this._context.SaveChanges();
            return home;
        }

        ServiceUser IHomeDataProvider.createUser(ServiceUser userochek)
        {
            this._context.ServiceUsers.Add(userochek);
            this._context.SaveChanges();
            return userochek;
        }

        void IHomeDataProvider.deleteHome(int homeId)
        {
            Home? dbHome =  this._context.Homes.Find(homeId);
            if (dbHome == null)
            {
                return;
            }
            this._context.Homes.Remove(dbHome);
            this._context.SaveChanges();
        }

        List<Home> IHomeDataProvider.getAllHomes()
        {
            return this._context.Homes.ToList();
        }

        Home? IHomeDataProvider.getHome(int id)
        {
            return this._context.Homes.Find(id);
        }

        Home? IHomeDataProvider.updateHome(Home home)
        {
            Home? dbHome = this._context.Homes.Find(home.Id);
            if (dbHome == null) {
                return null;
            }
            else
            {
                dbHome.address = home.address;
                dbHome.ownerName = home.ownerName;
                this._context.SaveChanges();
                return dbHome;
            }
        }
    }
}
