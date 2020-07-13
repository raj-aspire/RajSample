using System.ComponentModel;

namespace ContactApp.Models
{
    public class SchoolContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Mobile Number")]
        public string ContactMobileNumber { get; set; }
        [DisplayName("WhatsApp Number")]
        public string ContactWhatsAppNumber { get; set; }
        [DisplayName("Email")]
        public string EmailId { get; set; }
        [DisplayName("Your DOB")]
        public string YourBirthDay { get; set; }
        [DisplayName("Spouse DOB")]
        public string SpouseBirthDay { get; set; }
        [DisplayName("Kid(s) Name and Birthday")]
        public string KidsNameBirthDay { get; set; }
        [DisplayName("Current Location")]
        public string CurrentLocation { get; set; }
    }
}
