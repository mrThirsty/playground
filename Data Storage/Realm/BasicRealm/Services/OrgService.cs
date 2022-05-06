using BasicRealm.Model;
using Realms;

namespace BasicRealm.Services;

public class OrgService : IOrgService
{
    public OrgService()
    {
        _realmInstance = Realm.GetInstance();
    }

    private readonly Realm _realmInstance;
    
    public async Task<bool> CreateOrg(Organisation org)
    {
        await _realmInstance.WriteAsync(access =>
        {
            access.Add(org);
        });

        return true;
    }

    public async Task<IEnumerable<Organisation>> GetOrgs()
    {
        return _realmInstance.All<Organisation>();
    }

    public async Task<bool> CreateContact(Contact contact)
    {
        await _realmInstance.WriteAsync(access =>
        {
            access.Add(contact);
        });

        return true;
    }

    public async Task<IEnumerable<Contact>> GetContacts(string orgName = "")
    {
        if (string.IsNullOrWhiteSpace(orgName))
        {
            return _realmInstance.All<Contact>();
        }

        return _realmInstance.All<Contact>().Where(c => c.Employer.OrgName == orgName);
    }

    public async Task<Organisation?> FindOrg(string orgName)
    {
        if (string.IsNullOrWhiteSpace(orgName)) throw new ArgumentNullException(nameof(orgName));

        var org = _realmInstance.All<Organisation>().Where(o => o.OrgName == orgName)
            .FirstOrDefault();

        return org;
    }
}