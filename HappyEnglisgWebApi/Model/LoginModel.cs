namespace HappyEnglisgWebApi.Model
{
    public class LoginModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    //-------------------



    public class AppSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        public string Warning { get; set; }

        public string Error { get; set; }
    }















    //----------------------










}
