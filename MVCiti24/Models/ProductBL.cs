namespace MVCiti24.Models
{
    public class ProductBL
    {
        List<Product> products;

        public ProductBL()
        {
            products = new List<Product>();

            products.Add(new Product() {Id=1,Name= "WirelessEarbuds",Price=800,Description= "Compact, high-quality earbuds with noise-canceling technology. These wireless earbuds come with a rechargeable case, touch controls, and a comfortable",ImageUlr= "WirelessEarbuds.jpg" });
            products.Add(new Product() { Id = 2, Name = "SmartHomeSpeaker", Price = 200, Description = "A voice-activated smart speaker that connects to various devices in your home. It plays music, answers questions, controls smart home devices", ImageUlr = "SmartHomeSpeaker.jpg" });
            products.Add(new Product() { Id = 3, Name = "PortablePowerBank", Price = 900, Description = "Lightweight and high-capacity power bank capable of charging multiple devices on the go. Equipped with fast-charging ports", ImageUlr = "PortablePowerBank.jpg" });
            products.Add(new Product() { Id = 4, Name = "ElectricToothbrush", Price = 350, Description = "A rechargeable electric toothbrush with multiple brushing modes, a built-in timer, and soft, replaceable bristles. .", ImageUlr = "ElectricToothbrush.jpg" });
            products.Add(new Product() { Id = 5, Name = "FitnessTrackerWatch", Price = 500, Description = "A sleek, multi-functional fitness tracker with a heart rate monitor, sleep tracking, GPS, and waterproof design.", ImageUlr = "FitnessTrackerWatch.jpg" });
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetProductById(int Id)
        {
            return products.FirstOrDefault(p => p.Id == Id);
        }
    }
}
