namespace minhaprimeiraapi.Model
{
    public class ServiceModel
    {
        public int serviceId { get; set; }

        public string category { get; set; }   

        public string serviceName { get; set; }

        public decimal price { get; set; }

        public string serviceDescription { get; set; }

        public DateTime dateCreated { get; set; }

        public DateTime dateModified { get; set; }
    }
}
