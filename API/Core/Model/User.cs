using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;

namespace FlyMateAPI.Core.Model
{
    public class User : MongoUser<string>
    {
        public UserAddress Address { get; set; } = null!;
    }
}
