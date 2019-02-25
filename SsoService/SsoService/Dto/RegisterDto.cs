using System.Runtime.Serialization;

namespace SsoService.Dto
{
    [DataContract]
    public class RegisterDto
    {
        [DataMember]
        public bool Status { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}