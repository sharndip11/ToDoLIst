using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todolist.Models
{
    public class Item
    {
		[JsonProperty(PropertyName = "id")]
		public string id { get; set; }

		[JsonProperty(PropertyName = "text")]
		public string text { get; set; }

		[JsonProperty(PropertyName = "createdDate")]
		public string createdDate { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string description { get; set; }

		[JsonProperty(PropertyName = "isDone")]
		public bool isDone { get; set; }

		[JsonProperty(PropertyName = "doneDate")]
		public string doneDate { get; set; }

		[JsonProperty(PropertyName = "priority")]
		public string priority { get; set; }
	}
}
