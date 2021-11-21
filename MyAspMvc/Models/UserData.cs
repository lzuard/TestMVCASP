using System;

namespace MyAspMvc.Models
{
    public class UserData: IOptEntity
    {
        private int id { get; set; } = -1;
        public string name { get; private set; } = "Unrecognized";
        public int age { get; private set; }  = 0;


        public void Initialize(int id)
        {
            this.id = id;
            DBInterface.DBinterface.SetData(this);
        }

        public void SetData(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        
        public new string ToString()
        {
            return "User";
        }

        public void SetData()
        {
            throw new NotImplementedException();
        }
    }
}