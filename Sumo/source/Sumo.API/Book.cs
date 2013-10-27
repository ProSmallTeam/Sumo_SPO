using System.Collections.Generic;

namespace Sumo.API
{
    public class Book
    {
        public string Name;

        public string Md5Hash;

        //может быть пустое в случае передачи информации в SumoService
        public string PathToFile;

        public Dictionary<string, string> SecondaryFields;

    }
}