namespace Contract.Architecture.Backend.Core.Contract.Contexts
{
    public interface IPaginationFilterItem
    {
        string PropertyName { get; set; }

        string PropertyValue { get; set; }

        FilterType FilterType { get; set; }
    }
}