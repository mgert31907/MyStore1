using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace Models
{
    public class UserDetailModel
    {
        public UserInformation GetUserInformation(string guId)
        {
            GarageDBEntities6 db = new GarageDBEntities6();
            var info = (from x in db.UserInformations
                        where x.GUID == guId
                        select x).FirstOrDefault();
            return info;
        }

        public void InsertUserDetail(UserInformation userDetail)
        {
            GarageDBEntities6 db = new GarageDBEntities6();
            db.UserInformations.Add(userDetail);
            db.SaveChanges();
        }
    }
}