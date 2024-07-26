using System;

namespace PartialSourceGen;

/// <summary>
/// Generate partial optional properties of this class/struct.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
internal sealed class PartialAttribute : Attribute
{
    /// <summary>
    /// The optional summary for the partial entity. If not given
    /// the original summary will be used.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// If true, required properties will maintain their required modifier.
    /// If false, the partial entity will remove the required modifier.
    /// </summary>
    public bool IncludeRequiredProperties { get; set; }

    /// <summary>
    /// The optional class name for the partial entity.
    /// If not specified, the naming convection will be Partial[ClassName]
    /// </summary>
    public string? PartialClassName { get; set; }

    /// <summary>
    /// If true, any attribute on properties will be included in the partial
    /// entity. Default false.
    /// </summary>
    public bool IncludeExtraAttributes { get; set; }
}

/// <summary>
/// Include the initializer for this property in the partial entity.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal sealed class IncludeInitializerAttribute : Attribute
{
}

#if NET7_0_OR_GREATER
/// <summary>
/// Replace a type with a partial reference
/// </summary>
/// <typeparam name="TOriginal">The original type</typeparam>
/// <typeparam name="TPartial">The partial type</typeparam>
/// <remarks>
/// Instantiate a partial reference attribute
/// </remarks>
/// <param name="name">The partial property name to generate</param>
[AttributeUsage(AttributeTargets.Property)]
internal sealed class PartialReferenceAttribute<TOriginal, TPartial>(string? name = null) : Attribute
{
    private readonly string? name = name;
}
#endif
/// <summary>
/// Replace a type with a partial reference
/// </summary>
/// <remarks>
/// Instantiate a partial reference attribute
/// </remarks>
/// <param name="original">The original type</param>
/// <param name="partial">The partial type</param>
/// <param name="name">The partial property name to generate</param>
[AttributeUsage(AttributeTargets.Property)]
internal sealed class PartialReferenceAttribute(Type original, Type partial, string? name = null) : Attribute
{
    private readonly Type original = original;
    private readonly Type partial = partial;
    private readonly string? name = name;
}
/// <summary>
/// Excludes a property from being included in the generated partial entity
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal sealed class ExcludePartialAttribute : Attribute
{
}
/// <summary>
/// Force a property to be nullable
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal sealed class ForceNullAttribute : Attribute
{
}