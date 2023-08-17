//using CookBlog.Api.Core.Entities;
//using CookBlog.Api.Core.Repositories;
//using CookBlog.Api.Core.ValuesObjects;
//using Microsoft.Extensions.Caching.Distributed;
//using Newtonsoft.Json;

//namespace CookBlog.Api.Infrastructure.DAL.Repositories;

//internal sealed class CacheTagRepository : ITagRepository
//{
//    private readonly ITagRepository _decorated;
//    private readonly IDistributedCache _distributedCache;

//    public CacheTagRepository(ITagRepository decorated, IDistributedCache distributedCache)
//    {
//        _decorated = decorated;
//        _distributedCache = distributedCache;
//    }

//    public async Task<Tag?> GetAsync(TagId id)
//    {
//        string key = $"tag-{id}";

//        string? cacheTag = await _distributedCache.GetStringAsync(key);

//        Tag? tag;
//        if (string.IsNullOrEmpty(cacheTag))
//        {
//            tag = await _decorated.GetAsync(id);
            
//            if (tag is null)
//            {
//                return tag;
//            }

//            await _distributedCache.SetStringAsync(
//                key,
//                JsonConvert.SerializeObject(tag));

//            return tag;
//        }

//        tag = JsonConvert.DeserializeObject<Tag>(
//            cacheTag,
//            new JsonSerializerSettings
//            {
//                ConstructorHandling =
//                    ConstructorHandling.AllowNonPublicDefaultConstructor
//            });

//        return tag;
//    }

//    public Task AddAsync(Tag tag) => _decorated.AddAsync(tag);

//    public void DeleteAsync(Tag tag) => _decorated.DeleteAsync(tag);

//    public async Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> ids) => await _decorated.GetTags(ids);
//}
