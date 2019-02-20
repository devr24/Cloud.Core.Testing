namespace Cloud.Core.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit.Abstractions;
    using Xunit.Sdk;
    using JetBrains.Annotations;

    /// <summary>
    /// Decorates a test as a Unit Test, so that it runs in Continuous Integration builds.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IsUnitAttribute : CloudCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsUnitAttribute"/>
        /// </summary>
        public IsUnitAttribute() : base("Unit") { }
    }

    /// <summary>
    /// Decorates a test as an Integration Test, so that it runs in Continuous Integration builds.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IsIntegrationAttribute : CloudCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsIntegrationAttribute"/>
        /// </summary>
        public IsIntegrationAttribute() : base("Integration") { }
    }

    /// <summary>
    /// Decorates a test as a Read Only Integration Test, so that it runs in Continuous Integration builds and can also run in Production.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IsIntegrationReadOnlyAttribute : CloudCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsIntegrationReadOnlyAttribute"/>
        /// </summary>
        public IsIntegrationReadOnlyAttribute() : base("Integration", "ReadOnly") { }
    }

    /// <summary>
    /// Decorates a test as a Read Only Integration Test, so that it runs in Continuous Integration builds and can also run in Production.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IsPerformanceAttribute : CloudCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsIntegrationReadOnlyAttribute"/>
        /// </summary>
        public IsPerformanceAttribute() : base("Performance") { }
    }

    /// <summary>
    /// Decorates a test as a development entry point.
    /// This test never runs on any automated build, is purely a development facility.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IsDevAttribute : CloudCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsDevAttribute"/>
        /// </summary>
        public IsDevAttribute() : base("Dev") { }
    }

    /// <summary>
    /// Base class for all the category model attributes. Contains a list of all the attribute categories
    /// and supports multiple categories.
    /// </summary>
    [TraitDiscoverer(CloudCategoryDiscoverer.FullyQualifiedName, CloudCategoryDiscoverer.Namespace)]
    public abstract class CloudCategoryAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CloudCategoryAttribute"/>.
        /// </summary>
        /// <param name="categories">The trait categories present in the attribute.</param>
        protected CloudCategoryAttribute(params string[] categories)
        {
            Categories = categories;
        }

        /// <summary>
        /// Gets the list of categories in the test that the attribute is decorating.
        /// Exposed as public because xUnit needs to reflect the getter to get to it.
        /// </summary>
        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public IEnumerable<string> Categories { get; }
    }

    /// <summary>
    /// Discoverer that provides trait values to xUnit tests.
    /// </summary>
    public class CloudCategoryDiscoverer : ITraitDiscoverer
    {
        internal const string Namespace = nameof(Cloud) + "." + nameof(Core) + "." + nameof(Testing);
        internal const string FullyQualifiedName = Namespace + "." + nameof(CloudCategoryDiscoverer);

        /// <summary>Gets the trait values from the trait attribute.</summary>
        /// <param name="traitAttribute">The trait attribute containing the trait values.</param>
        /// <returns>The trait values.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var categories = traitAttribute.GetNamedArgument<IEnumerable<string>>(nameof(CloudCategoryAttribute.Categories));
            return categories.Select(c => new KeyValuePair<string, string>("Category", c));
        }
    }

}
