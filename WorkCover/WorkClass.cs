using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCover;
using UsersCover;

namespace WorkCover
{
    public class WorkClass
    {
        DataClass objd = new DataClass();

        public string user { get; set; }
        public string pass { get; set; }

        public DataTable N_Login(UsersClass obje)
        {
            return objd.Dlogin(obje);
        }
        public DataTable N_UsersSearch (UsersClass obje)
        {
            return objd.D_UsersSearch(obje);
        }

        public DataTable N_UsersList(UsersClass obje)
        {
            return objd.D_UsersList(obje);
        }

        public string N_UsersProc(UsersClass obje)
        {
            return objd.D_UsersProc(obje);
        }

    }
}