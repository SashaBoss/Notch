namespace Notch.Bootstrap
{
    using System;
    using System.Collections.Generic;
    using Notch.Infrastructure.Request;
    using Unity.Builder;
    using Unity.Injection;
    using Unity.Policy;
    using Unity.Resolution;

    internal class ServiceProviderParametersResolver : ResolverOverride
    {
        private readonly Queue<InjectionParameterValue> _parameterValues;

        public ServiceProviderParametersResolver(IRequestContext requestContext, IEnumerable<object> values, bool useContext = false)
        {
            _parameterValues = new Queue<InjectionParameterValue>();

            if (useContext)
            {
                _parameterValues.Enqueue(InjectionParameterValue.ToParameter(requestContext));
            }

            if (values != null)
            {
                foreach (var parameterValue in values)
                    _parameterValues.Enqueue(InjectionParameterValue.ToParameter(parameterValue));
            }
        }

        public override IDependencyResolverPolicy GetResolver(IBuilderContext context, Type dependencyType)
        {
            if (_parameterValues.Count < 1)
                return null;

            var value = _parameterValues.Dequeue();
            return value.GetResolverPolicy(dependencyType);
        }
    }
}