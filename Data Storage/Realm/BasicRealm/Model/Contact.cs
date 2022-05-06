using MongoDB.Bson;
using Realms;

namespace BasicRealm.Model;

public class Contact : RealmObject
{
    [PrimaryKey] 
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    
    [Required]
    public string Firstname { get; set; }
    
    [Required]
    public string Lastname { get; set; }
    
    public Organisation Employer { get; set; }
}