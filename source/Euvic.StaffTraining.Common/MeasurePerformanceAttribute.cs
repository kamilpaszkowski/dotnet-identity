using System;
using System.Reflection;
using MediatR;

namespace Euvic.StaffTraining.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MeasurePerformanceAttribute : Attribute
    {
    }

    public static partial class Extensions
    {
        public static bool RequirePerformanceCheck<TResponse>(this IRequest<TResponse> request) =>
          request.GetType().GetCustomAttribute(typeof(MeasurePerformanceAttribute)) is MeasurePerformanceAttribute attribute;
    }
}
