using AutoMapper;
using System.Collections;

namespace Sample.Application.Common.Utils
{
    public class ConvertUtils
    {
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true; // Cho phép ánh xạ các thuộc tính mảng/collection có thể là null
                cfg.AllowNullDestinationValues = true; // Cho phép các giá trị đích có thể là null
                cfg.CreateMap<TSource, TDestination>();
            });

            var mapper = config.CreateMapper();

            return mapper.Map<TSource, TDestination>(source);
        }

        public static IEnumerable<TDestination> MapListObject<TDestination>(IEnumerable source)
        {
            var type = source.GetType().GetGenericArguments()[0];

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(type, typeof(TDestination));
            });

            return config.CreateMapper().Map<IEnumerable<TDestination>>(source);
        }
    }
}
