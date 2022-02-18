using System.ComponentModel;

namespace ALUXION.Domain
{
    public enum ProviderType
    {
        [Description("Google")]
        Google,

        [Description("Facebook")]
        Facebook,

        [Description("Local")]
        Local
    }
}
