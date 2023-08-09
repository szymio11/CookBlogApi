using CookBlog.Api.Core.Abstractions;

namespace CookBlog.Api.Infrastructure.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.Now;
}
