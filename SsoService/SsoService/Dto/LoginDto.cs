using System.Runtime.Serialization;

namespace SsoService.Dto
{
    [DataContract]
    public class LoginDto
    {
        [DataMember]
        public bool Status { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}