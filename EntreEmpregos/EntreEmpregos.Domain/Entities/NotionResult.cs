using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace EntreEmpregos.Api.Entities;

    public class Annotations
    {
        [JsonProperty("bold")]
        [JsonPropertyName("bold")]
        public bool bold { get; set; }

        [JsonProperty("italic")]
        [JsonPropertyName("italic")]
        public bool italic { get; set; }

        [JsonProperty("strikethrough")]
        [JsonPropertyName("strikethrough")]
        public bool strikethrough { get; set; }

        [JsonProperty("underline")]
        [JsonPropertyName("underline")]
        public bool underline { get; set; }

        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public bool code { get; set; }

        [JsonProperty("color")]
        [JsonPropertyName("color")]
        public string color { get; set; }
    }

    public class CreatedBy
    {
        [JsonProperty("object")]
        [JsonPropertyName("object")]
        public string @object { get; set; }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }
    }

    public class ID
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonProperty("unique_id")]
        [JsonPropertyName("unique_id")]
        public UniqueId unique_id { get; set; }
    }

    public class LastEditedBy
    {
        [JsonProperty("object")]
        [JsonPropertyName("object")]
        public string @object { get; set; }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }
    }

    public class MultiSelect
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonProperty("color")]
        [JsonPropertyName("color")]
        public string color { get; set; }
    }

    public class Name
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonProperty("title")]
        [JsonPropertyName("title")]
        public List<Title> title { get; set; }
    }

    public class PageOrDatabase
    {
    }

    public class Parent
    {
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonProperty("database_id")]
        [JsonPropertyName("database_id")]
        public string database_id { get; set; }
    }

    public class Properties
    {
        [JsonProperty("Tags")]
        [JsonPropertyName("Tags")]
        public Tags Tags { get; set; }

        [JsonProperty("ID")]
        [JsonPropertyName("ID")]
        public ID ID { get; set; }

        [JsonProperty("Name")]
        [JsonPropertyName("Name")]
        public Name Name { get; set; }
    }

    public class Result
    {
        [JsonProperty("object")]
        [JsonPropertyName("object")]
        public string @object { get; set; }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonProperty("created_time")]
        [JsonPropertyName("created_time")]
        public DateTime created_time { get; set; }

        [JsonProperty("last_edited_time")]
        [JsonPropertyName("last_edited_time")]
        public DateTime last_edited_time { get; set; }

        [JsonProperty("created_by")]
        [JsonPropertyName("created_by")]
        public CreatedBy created_by { get; set; }

        [JsonProperty("last_edited_by")]
        [JsonPropertyName("last_edited_by")]
        public LastEditedBy last_edited_by { get; set; }

        [JsonProperty("cover")]
        [JsonPropertyName("cover")]
        public object cover { get; set; }

        [JsonProperty("icon")]
        [JsonPropertyName("icon")]
        public object icon { get; set; }

        [JsonProperty("parent")]
        [JsonPropertyName("parent")]
        public Parent parent { get; set; }

        [JsonProperty("archived")]
        [JsonPropertyName("archived")]
        public bool archived { get; set; }

        [JsonProperty("properties")]
        [JsonPropertyName("properties")]
        public Properties properties { get; set; }

        [JsonProperty("url")]
        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonProperty("public_url")]
        [JsonPropertyName("public_url")]
        public object public_url { get; set; }
    }

    public class Root
    {
        [JsonProperty("object")]
        [JsonPropertyName("object")]
        public string @object { get; set; }

        [JsonProperty("results")]
        [JsonPropertyName("results")]
        public List<Result> results { get; set; }

        [JsonProperty("next_cursor")]
        [JsonPropertyName("next_cursor")]
        public object next_cursor { get; set; }

        [JsonProperty("has_more")]
        [JsonPropertyName("has_more")]
        public bool has_more { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonProperty("page_or_database")]
        [JsonPropertyName("page_or_database")]
        public PageOrDatabase page_or_database { get; set; }

        [JsonProperty("developer_survey")]
        [JsonPropertyName("developer_survey")]
        public string developer_survey { get; set; }
    }

    public class Tags
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonProperty("multi_select")]
        [JsonPropertyName("multi_select")]
        public List<MultiSelect> multi_select { get; set; }
    }

    public class Text
    {
        [JsonProperty("content")]
        [JsonPropertyName("content")]
        public string content { get; set; }

        [JsonProperty("link")]
        [JsonPropertyName("link")]
        public object link { get; set; }
    }

    public class Title
    {
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonProperty("text")]
        [JsonPropertyName("text")]
        public Text text { get; set; }

        [JsonProperty("annotations")]
        [JsonPropertyName("annotations")]
        public Annotations annotations { get; set; }

        [JsonProperty("plain_text")]
        [JsonPropertyName("plain_text")]
        public string plain_text { get; set; }

        [JsonProperty("href")]
        [JsonPropertyName("href")]
        public object href { get; set; }
    }

    public class UniqueId
    {
        [JsonProperty("prefix")]
        [JsonPropertyName("prefix")]
        public object prefix { get; set; }

        [JsonProperty("number")]
        [JsonPropertyName("number")]
        public int number { get; set; }
    }

