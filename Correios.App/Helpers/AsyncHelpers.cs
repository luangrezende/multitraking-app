using System.Globalization;

namespace Correios.App.Helpers
{
    public static class AsyncHelpers
    {
        private static readonly TaskFactory _myTaskFactory =
            new(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> task)
        {
            return _myTaskFactory.StartNew(() =>
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;
                return task();
            }).Unwrap().GetAwaiter().GetResult();
        }

        public static void RunSync(Func<Task> task)
        {
            _myTaskFactory.StartNew(() =>
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;
                return task();
            }).Unwrap().GetAwaiter().GetResult();
        }
    }
}
