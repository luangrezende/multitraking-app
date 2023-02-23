using Correios.App.Helpers;

namespace Correios.App.Extensions
{
    public static class TaskExtensions
    {
        public static void RunSync(this Task task)
        {
            AsyncHelpers.RunSync(() => task);
        }

        public static T RunSync<T>(this Task<T> task)
        {
            return AsyncHelpers.RunSync(() => task);
        }
    }
}
