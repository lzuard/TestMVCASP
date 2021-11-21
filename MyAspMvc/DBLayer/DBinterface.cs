using MyAspMvc.Models;

namespace MyAspMvc.DBInterface
{
    public static class DBinterface
    {
        public static void SetData(IOptEntity entity)
        {
            string entityType = entity.ToString();

            switch (entityType)
            {
                case "User":
                    SetUserData((UserData)entity);
                    break;
                default:
                    //ToDo exception here
                    break;
                    
            }
        }


        private static void SetUserData(UserData user)
        {
            user.SetData("Rick",18);
        }
    }
}