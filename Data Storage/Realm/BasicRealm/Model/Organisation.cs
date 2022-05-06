using MongoDB.Bson;
using Realms;

namespace BasicRealm.Model;

public class Organisation : RealmObject
{
    [PrimaryKey]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [Required]
    public string OrgName { get; set; }
    
    [Backlink(nameof(Contact.Employer))]
    public IQueryable<Contact> Contacts { get; }
}