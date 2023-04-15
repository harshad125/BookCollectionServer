namespace MyCollection.Models
{
    public class Book
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; } 
        public string author { get; set; }
        public DateTime publishyear { get; set; }
        public string ISBNnumber { get; set; }
        public string price { get; set; }
        public string book_url { get; set; }
        public long userid { get; set; }
        

    }
}
