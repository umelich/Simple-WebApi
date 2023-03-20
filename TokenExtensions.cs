//public static class TokenExtensions
//{
//    public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
//    {
//        return builder.UseMiddleware<TokenMiddleware>();
//    }
//}
//-------------------------------------------------------------------------------
public static class TokenExtensions
{
    public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
    {
        return builder.UseMiddleware<TokenMiddleware>(pattern);
    }
}