using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonNoSQL.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
}