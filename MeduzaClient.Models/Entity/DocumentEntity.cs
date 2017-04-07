using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeduzaClient.Models.Entity
{

    public class DocumentEntity: DbEntityBase
    {
        public string document_type { get; set; }
        public int version { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public int modified_at { get; set; }
        public int published_at { get; set; }
        public string pub_date { get; set; }
        public bool full { get; set; }
    }
}
