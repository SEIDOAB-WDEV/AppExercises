using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Linq;

using Configuration;

namespace Models
{
    public class csBogusLatin
    {
        public Guid QuoteId {get; set;} = Guid.NewGuid();
        public string Sentence { get; set;}

        #region Constructors
        public csBogusLatin() {}
        public csBogusLatin(csBogusLatin original)
        {
            QuoteId = original.QuoteId;
            Sentence = original.Sentence;
        }
        #endregion
    }
}