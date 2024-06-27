using GraphQL.Extension.Base.Filter;
using GraphQL.Extension.Base.Pagination;
using System.Collections.Generic;

namespace GraphQL.Extension.Base.Filter
{
    public class FilterInput
    {
        public FilterOperationEnum Operation { get; set; }
        public FilterLogicEnum Logic { get; set; }
        public string Value { get; set; }
        public string FieldName { get; set; }
        /// <summary>
        /// Provide Delimiter for Field Values, default is ",".
        /// </summary>
        public string DelimiterListOfValues { get; set; } = ",";
    }

    public class FilterGroupInput
    {
        public FilterLogicEnum Logic { get; set; }
        public List<FilterGroupInput> ChildGroups { get; set; }
        public List<FilterInput> Filters { get; set; }
    }
    public class SearchInput
    {
        //public List<FilterInput> Filters { get; set; }
        public List<FilterGroupInput> FilterGroups { get; set; }
    }
    public enum FilterOperationEnum
    {
        gte,
        gt,
        eq,
        neq,
        lt,
        lte,
        contains,
        notcontains,
        startswith,
        endswith,
        inlist,
        notinlist,
        notstartswith,
        notendswith,
        containsinlist,
        notcontainsinlist,
        startswithinlist,
        endswithinlist,
        notstartswithinlist,
        notendswithinlist
    }
    public enum FilterLogicEnum
    {
        and,
        or
    }
}

namespace GraphQL.Extension.Base.Pagination
{
    public class PaginationInput
    {
        public int? Take { get; set; }
        public int? Skip { get; set; }
        public List<SortInput> Sorts { get; set; }
    }

    public class SortInput
    {
        public string FieldName { get; set; }
        public SortDirectionEnum Direction { get; set; }
    }

    public enum SortDirectionEnum
    {
        asc,
        desc
    }
}

namespace GraphQL.Extension.Base.Unique
{
    public class DistinctByInput
    {
        /// <summary>
        /// Coma (,) separated field names.
        /// </summary>
        public string FieldNames { get; set; }

        /// <summary>
        /// Provide search object to filter data for DistinctBy.
        /// </summary>
        public SearchInput Search { get; set; }

        /// <summary>
        /// Provide pagination object to apply sort, take and skip on data for DistinctBy.
        /// </summary>
        public PaginationInput Pagination { get; set; }
    }
}

namespace GraphQL.Extension.Base.Grouping
{
    public class GroupByInput
    {
        /// <summary>
        /// Coma (,) separated field names.
        /// </summary>
        public string FieldNames { get; set; }

        /// <summary>
        /// Provide search object to filter data for GroupBy.
        /// </summary>
        public SearchInput Search { get; set; }
    }
}

namespace GraphQL.Extension.Base.Mutation
{
    public enum MutationOperationEnum
    {
        add,
        update,
        delete
    }
}
