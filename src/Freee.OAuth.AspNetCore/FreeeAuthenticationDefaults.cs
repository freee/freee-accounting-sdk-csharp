namespace Freee.OAuth.AspNetCore
{
    public static class FreeeAuthenticationDefaults
    {
        public const string AuthenticationScheme = "Freee";

        public const string DisplayName = "Freee";

        public const string Issuer = "Freee";

        public const string CallbackPath = "/signin-freee";

        public const string AuthorizationEndpoint = "https://accounts.secure.freee.co.jp/public_api/authorize";

        public const string TokenEndpoint = "https://accounts.secure.freee.co.jp/public_api/token";

        public const string UserInformationEndpoint = "https://api.freee.co.jp/api/1/users/me";
    }
}
