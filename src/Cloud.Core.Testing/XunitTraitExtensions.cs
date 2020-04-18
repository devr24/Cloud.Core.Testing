namespace Cloud.Core.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    /// Decorates a test as a Unit Test, so that it runs in Continuous Integration builds.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IsUnitAttribute : CloudCoreCategoryAttribute
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
    public sealed class IsIntegrationAttribute : CloudCoreCategoryAttribute
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
    public sealed class IsIntegrationReadOnlyAttribute : CloudCoreCategoryAttribute
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
    public sealed class IsPerformanceAttribute : CloudCoreCategoryAttribute
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
    public sealed class IsDevAttribute : CloudCoreCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsDevAttribute"/>
        /// </summary>
        public IsDevAttribute() : base("Dev") { }
    }

    /// <summary>
    /// Decorates a test as a smoke test entry point.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IsSmokeAttribute : CloudCoreCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IsDevAttribute"/>
        /// </summary>
        public IsSmokeAttribute() : base("Smoke") { }
    }

    /// <summary>
    /// Base class for all the category model attributes. Contains a list of all the attribute categories
    /// and supports multiple categories.
    /// </summary>
    [TraitDiscoverer(CloudCoreCategoryDiscoverer.FullyQualifiedName, CloudCoreCategoryDiscoverer.Namespace)]
    // ReSharper disable once InconsistentNaming
    public abstract class CloudCoreCategoryAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CloudCoreCategoryAttribute"/>.
        /// </summary>
        /// <param name="categories">The trait categories present in the attribute.</param>
        protected CloudCoreCategoryAttribute(params string[] categories)
        {
            Categories = categories;
        }

        /// <summary>
        /// Gets the list of categories in the test that the attribute is decorating.
        /// Exposed as public because xUnit needs to reflect the getter to get to it.
        /// </summary>
        public IEnumerable<string> Categories { get; }
    }

    /// <summary>
    /// Discoverer that provides Cloud core trait values to xUnit tests.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class CloudCoreCategoryDiscoverer : ITraitDiscoverer
    {
        internal const string Namespace = nameof(Cloud) + "." + nameof(Core) + "." + nameof(Testing);
        internal const string FullyQualifiedName = Namespace + "." + nameof(CloudCoreCategoryDiscoverer);

        /// <summary>Gets the trait values from the trait attribute.</summary>
        /// <param name="traitAttribute">The trait attribute containing the trait values.</param>
        /// <returns>The trait values.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var categories = traitAttribute.GetNamedArgument<IEnumerable<string>>(nameof(CloudCoreCategoryAttribute.Categories));
            return categories.Select(c => new KeyValuePair<string, string>("Category", c));
        }
    }

}
