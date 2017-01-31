namespace Project1ToDo.Models
{
    public class Categorization
    {
        public int Id { get; set; }

        public int listID { get; set; }
        public List List { get; set; }

        public int categoryID { get; set; }
        public Category Category { get; set; }
    }
    //To navigate, use a Select:
    //// product.Categories
    //var categories = product.Categorizations.Select(c => c.Category);
}