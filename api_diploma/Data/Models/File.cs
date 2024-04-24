using System.Reflection.Metadata;

namespace api_diploma.Data.Models
{
    public class File
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Passport { get; set; }
        public byte[] IndividualTaxNumber { get; set; }
        public byte[] MedicalCertificate { get; set; }
        public byte[] ResidencePermit { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
