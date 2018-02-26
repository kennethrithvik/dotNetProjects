using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        public String Names { get; set; }
        public int Cost { get; set; }
    }
}
