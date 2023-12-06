using System;
using Models;

namespace Services
{
    public class csMixedListService : IMixedListService
    {
        public List<csFamousQuote> Quotes {get;}
        public List<csBogusLatin> Latin {get;}
        public List<csFriend> Friends {get;}
        public List<csAddress> Addresses {get;}
        public List<csPet> Pets {get;}

        public csMixedListService()
        {
            var rnd = new csSeedGenerator();
            Quotes = rnd.AllQuotes.Select(q => new csFamousQuote(){Author = q.Author, Quote = q.Quote}).ToList();

            Latin = rnd.LatinSentences(50).Select(q => new csBogusLatin(){Sentence = q}).ToList();

            Friends = rnd.ItemsToList<csFriend>(50);

            Addresses = rnd.ItemsToList<csAddress>(50);

            Pets = rnd.ItemsToList<csPet>(50);
        }
    }
}