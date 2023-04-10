namespace Care.Models
{
    public class Medecine
    {
        //here we will write the property of our table columns here

        //for keeping required constrains we will user data antonations

        public string BatchId { get; set; }
        public string MedName { get; set; }
        public string Quantity { get; set;}
        public string Price { get; set; }
        public DateOnly Expire { get; set;}
    }
}
