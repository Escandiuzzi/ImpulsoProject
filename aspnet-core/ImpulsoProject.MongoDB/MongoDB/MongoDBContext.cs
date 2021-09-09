using ImpulsoProject.Authorization.Users;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ImpulsoProject.MongoDB
{
    [ConnectionStringName("MongoDB")]
    public class MongoDBContext : AbpMongoDbContext
    {
        [MongoCollection("Users")] //Sets the collection name
        public IMongoCollection<User> Users => Collection<User>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            //Customize the configuration for your collections.
            /*modelBuilder.Entity<User>(b =>
            {
                b.CollectionName = "Users"; //Sets the collection name
                b.BsonMap.UnmapProperty(x => x.MyProperty); //Ignores 'MyProperty'
            });*/
        }
    }
}
