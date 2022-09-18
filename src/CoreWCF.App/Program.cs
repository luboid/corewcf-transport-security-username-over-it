namespace CoreWCF.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var theService = new ServiceReference1.TheServiceClient();
                theService.ClientCredentials.UserName.UserName = "the-user";
                theService.ClientCredentials.UserName.Password = "P@ssw0rd";

                var result = theService.CheckSomeThing(new ServiceReference1.TheServiceRequestType
                {
                    BoolValue = true,
                    StringValue = "call"
                });

                var theServiceAsync = new ServiceReference2.TheServiceAsyncClient();
                theServiceAsync.ClientCredentials.UserName.UserName = "the-user";
                theServiceAsync.ClientCredentials.UserName.Password = "P@ssw0rd";

                var resultAsync = theServiceAsync.CheckSomeThingAsync(new ServiceReference2.TheServiceRequestType
                {
                    BoolValue = true,
                    StringValue = "call"
                }).GetAwaiter().GetResult();

                Console.WriteLine("All went well ...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }
}