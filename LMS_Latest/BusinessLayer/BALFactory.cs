using BusinessLayer.Auth;
using BusinessLayer.Library;
namespace BusinessLayer
{
    public static class BALFactory
    {
        public static IAuthentication GetAuthenticationObject()
        {
            return new Authentication();
        }

        public static IBookModule GetBookModuleObject()
        {
            return new BookModule();
        }

        public static IUserModule GetUserModuleObject()
        {
            return new UserModule();
        }
    }
}
