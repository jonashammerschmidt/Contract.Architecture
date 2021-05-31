namespace Contract.Architecture.Backend.Core.Contract.Contexts
{
    public interface IPaginationSortItem
    {
        string PropertyName { get; set; }

        SortOrder OrderBy { get; set; }
    }
}
