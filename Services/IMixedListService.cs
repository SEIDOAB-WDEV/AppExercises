using System;
using Models;

namespace Services
{
    public interface IMixedListService
    {
        public List<csBogusLatin> Latin {get;}
        public List<csFriend> Friends {get;}
        public List<csAddress> Addresses {get;}
        public List<csPet> Pets {get;}
        public List<csFamousQuote> Quotes {get;}
    }
}