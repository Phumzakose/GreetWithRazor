using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace GreetFunction
{
  public class Friends
  {
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("first_name")]
    public string? FirstName { get; set; }

    [BsonElement("count")]
    public int Counter { get; set; }
    public Friends()
    {
      Id = ObjectId.GenerateNewId();
    }

  }


}