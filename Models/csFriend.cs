using System.Collections.Generic;
using Configuration;

//DbModels namespace is the layer which contains all the C# models of
//the database tables Select queries as well as results from a call to a View,
//Stored procedure, or Function.

//C# classes corresponds to table structure (no suffix) or
//specific search results (DTO suffix)
namespace Models;

public class csFriend : ISeed<csFriend>
{
    public virtual Guid FriendId { get; set; } = Guid.NewGuid();

    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }

    public virtual string Email { get; set; }
    public DateTime? Birthday { get; set; } = null;

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString()
    {
        var sRet = $"{FullName} [{FriendId}]";
        return sRet;
    }

    #region contructors
    public csFriend() { }

    public csFriend(csFriend org)
    {
        this.Seeded = org.Seeded;

        this.FriendId = org.FriendId;
        this.FirstName = org.FirstName;
        this.LastName = org.LastName;
        this.Email = org.Email;
    }
    #endregion

    #region randomly seed this instance
    public bool Seeded { get; set; } = false;

    public virtual csFriend Seed(csSeedGenerator sgen)
    {
        Seeded = true;
        FriendId = Guid.NewGuid();
        FirstName = sgen.FirstName;
        LastName = sgen.LastName;
        Email = sgen.Email(FirstName, LastName);
        Birthday = (sgen.Bool) ? sgen.DateAndTime(1970, 2000) : null;

        return this;
    }
    #endregion
}

