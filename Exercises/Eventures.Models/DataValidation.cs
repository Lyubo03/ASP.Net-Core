namespace Eventures.Models
{
    public class DataValidation 
    {
        public static class User
        {
            public const int UsernameMinLength = 3;
            public const int UCNMaxLength = 10;
            public const int UCNMinLength = 10;
            public const int Password = 5;
        }
        public static class Event
        {
            public const int EventNameMaxLength = 10;
        }
    }
}