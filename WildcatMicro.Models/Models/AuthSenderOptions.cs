namespace WildcatMicro.Models
{
    public class AuthSenderOptions
    {
        private string user = "Michael L"; // The name you want to show up on your email
                                          // Make sure the string passed in below matches your API Key
        private string key = "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";
        public string SendGridUser { get { return user; } }
        public string SendGridKey { get { return key; } }
    }

}
