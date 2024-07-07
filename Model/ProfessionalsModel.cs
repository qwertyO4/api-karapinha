namespace minhaprimeiraapi.Model
{
    public class ProfessionalModel
    {
        public int professionalsId { get; set; }
        public string fullName { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string bi { get; set; }
        public byte[] photo { get; set; }
        public string workingHours { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}