using System.Threading.Tasks;

namespace LocalAdmin.V2.Core;

internal static class Program
{
    public const string SYNC_PLUGIN_DATA_MESSAGE = "SYNC_PLUGIN_DATA::";
    public const string LA_INTEGRATION_STATUS = "LAI_STATUS::";
    public const string IOEXCEPTION_SHARING_VIOLATION = "IOException: Sharing violation on path";
    public const string SERVER_STARTUP_MSG = "Starting server...";
    public const string UNITY_FASTMENU_SCENE_LOADED = "Scene Manager: Loaded scene 'FastMenu' [Assets/_Scenes/FastMenu.unity]";

    private static async Task Main(string[] args)
    {
        Utf8Json.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
            Utf8Json.Resolvers.GeneratedResolver.Instance,
            Utf8Json.Resolvers.BuiltinResolver.Instance
        );

        while (true)
        {
            using var la = new LocalAdmin();
            await la.Start(StartupArgManager.MergeStartupArgs(args));
        }
        // ReSharper disable once FunctionNeverReturns
    }
}