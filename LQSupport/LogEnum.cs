using INOMSupport.Resources;
using System.Resources;

namespace LatamQuants.Support
{
    public enum EnumLogType
    {
        Error = 4,
        Information = 2
    };
    public static class LogError
    {
        public static string ReadErrorDescription(string codigo)
        {
            ResourceManager rm = new ResourceManager(typeof(ErrorCode));
            return rm.GetString(codigo);
        }
    }
}
