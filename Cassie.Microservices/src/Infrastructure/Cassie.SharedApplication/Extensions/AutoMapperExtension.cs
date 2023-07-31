using System;
using System.Reflection;
using AutoMapper;

namespace Cassie.SharedApplication.Extensions
{
	public static class AutoMapperExtension
	{
		public static IMappingExpression<TSource, TDestination> IgnoreNoneExistedProperties<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
		{
			var flags = BindingFlags.Public | BindingFlags.Instance;
			var sourceType = typeof(TSource);
			var destinationProperties = typeof(TDestination).GetProperties(flags);

			foreach (var property in destinationProperties)
			{
				var selectedProperty = sourceType.GetProperty(property.Name, flags);

                if (selectedProperty == null)
				{
					expression.ForMember(property.Name, opt => opt.Ignore());
				}
			}

			return expression;

        }
    }
}