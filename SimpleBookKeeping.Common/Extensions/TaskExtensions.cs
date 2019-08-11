using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SimpleBookKeeping.Common.Extensions
{
    public static class TaskExtensions
    {
        public static Task<TReturn> Convert<T, TReturn>(this Task<T> task, IMapper mapper)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var tcs = new TaskCompletionSource<TReturn>();

            task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith(t =>
            {
                tcs.TrySetResult(mapper.Map<T, TReturn>(t.Result));
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => tcs.TrySetException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);

            return tcs.Task;
        }


        public static Task<IList<TReturn>> ConvertEach<T, TReturn>(this Task<List<T>> task, IMapper mapper)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var tcs = new TaskCompletionSource<IList<TReturn>>();

            task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith(t =>
            {
                tcs.TrySetResult(t.Result.Select(mapper.Map<T, TReturn>).ToList());
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => tcs.TrySetException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);

            return tcs.Task;
        }
    }
}
