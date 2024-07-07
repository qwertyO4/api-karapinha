namespace minhaprimeiraapi.Model
{
    public class EmailsModel
    {
        public int emailId { get; set; }
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public DateTime dateSent { get; set; }
        public string statusEmail { get; set; }
    }
}