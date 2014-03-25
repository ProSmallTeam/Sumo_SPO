﻿using System.Runtime.Serialization;

namespace Sumo.Api
{
    [DataContract]
    public struct CategoryNode
    {
        [DataMember]
        public string Name;


        [DataMember]
        public int Count;


        [DataMember]
        public int Id;

    }
}