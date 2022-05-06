using BasicRealm.Model;

namespace BasicRealm.Services;

public interface IOrgService
{
    public Task<bool> CreateOrg(Organisation org);
    public Task<IEnumerable<Organisation>> GetOrgs();
    public Task<bool> CreateContact(Contact contact);
    public Task<IEnumerable<Contact>> GetContacts(string orgName = "");
    public Task<Organisation> FindOrg(string orgName);
}