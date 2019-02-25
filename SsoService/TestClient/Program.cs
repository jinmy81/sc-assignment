using System;
using TestClient.SsoService;

namespace TestClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestRegisterUser();

            var ssoClient = new SsoServiceClient();
            var ret = ssoClient.Login("test", "1234");
        }

        private static void TestRegisterUser()
        {
            var ssoClient = new SsoServiceClient();
            RegisterDto ret = ssoClient.Register("tester", "1234");
            if (ret.Status)
            {
                Console.WriteLine("Successfully registered.");
            }
            else
            {
                Console.WriteLine($"Fail to register {ret.Message}");
            }
        }
    }
}