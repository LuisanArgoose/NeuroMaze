using System;

namespace DefaultNamespace
{
    [Serializable]
    public class Profile
    {
        public int GlobalId { get; set; }
        public int LocalId { get; set; }
        public string UserName { get; set; }
        public string EncryptPassword { get; set; }
        public Profile(){}
    }
}