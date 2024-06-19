namespace dierentuinn.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Dieren> Dierens { get; set; }
    }
}
