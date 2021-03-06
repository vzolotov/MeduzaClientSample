﻿using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeduzaClient.Models
{
    public class EntityBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class Image
    {
        public bool show { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
        public string path { get; set; }
        public bool show { get; set; }
    }

    public class Ads
    {
        public bool show { get; set; }
    }

    public class Reactions
    {
        public bool show { get; set; }
    }

    public class Elements
    {
        public Image image { get; set; }
        public Tag tag { get; set; }
        public Ads ads { get; set; }
        public Reactions reactions { get; set; }
    }

    public class Inner
    {
        public string layout { get; set; }
        public Elements elements { get; set; }
    }

    public class Image2
    {
        public bool show { get; set; }
    }

    public class Tag2
    {
        public string name { get; set; }
        public string path { get; set; }
        public bool show { get; set; }
    }

    public class Elements2
    {
        public Image2 image { get; set; }
        public Tag2 tag { get; set; }
    }

    public class Outer
    {
        public string layout { get; set; }
        public Elements2 elements { get; set; }
    }

    public class Prefs
    {
        public Inner inner { get; set; }
        public Outer outer { get; set; }
    }

    public class Source
    {
        public string url { get; set; }
        public int trust { get; set; }
        public string name { get; set; }
        public string quote { get; set; }
    }

    public class Tag3
    {
        public string name { get; set; }
        public string path { get; set; }
    }

    public class Footer
    {
        public object caption { get; set; }
        public object credit { get; set; }
    }

    public class Document: EntityBase
    {
        public string document_type { get; set; }
        public Prefs prefs { get; set; }
        public Source source { get; set; }
        public int version { get; set; }

        private string _title;
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public string url { get; set; }
        public int modified_at { get; set; }
        public int published_at { get; set; }
        public string pub_date { get; set; }
        public Tag3 tag { get; set; }
        public Footer footer { get; set; }
        public bool full { get; set; }
    }
}
