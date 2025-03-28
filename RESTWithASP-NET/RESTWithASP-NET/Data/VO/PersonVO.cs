﻿using RESTWithASP_NET.Hypermedia;
using RESTWithASP_NET.Hypermedia.Abstract;
using RESTWithASP_NET.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTWithASP_NET.Data.VO
{

    public class PersonVO : ISupportsHyperMedia
    {
        public long Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? Gender { get; set; }

        public bool Enabled { get; set; }

        public List<HyperMediaLink> Links { get ; set ; } = new List<HyperMediaLink>();
    }
}
