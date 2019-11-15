namespace MailServer.Response
{
   public class EmailResponse
    {
        public Status  _success;

        public EmailResponse(Status success)
        {
           _success = success;
        }
    }
}