using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sumo.API
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Name;

        [DataMember]
        public string Md5Hash;

        [DataMember]
        // путь к файлу, зависящий от пользователя
        public string Path;

        [DataMember]
        public Dictionary<string, List<string>> SecondaryFields;
    }
}