using System;

namespace Models
{
    [Serializable]
    public class House
    {
        public int id;

        public string pagetitle;

        public string longtitle;

        public string introtext;

        public string description;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}

