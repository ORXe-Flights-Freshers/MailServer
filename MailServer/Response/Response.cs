namespace MailServer.Services
{
   public class Response
    {
        private Status  _success;

        public Response(Status success)
        {
           _success = success;
        }
    }
}