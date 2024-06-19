using GraphQL.Types;
using GraphQL.Extension.Base.Filter;
using GraphQL.Extension.Base.Pagination;
using GraphQL.Extension.Base.Unique;
using GraphQL.Extension.Types.Filter;
using GraphQL.Extension.Types.Pagination;
using GraphQL.Extension.Base.Grouping;

namespace GraphQL.Extension.Types.Filter
{
    public class FilterOperationEnumType : EnumerationGraphType
    {
        public FilterOperationEnumType()
        {
            Name = "FilterOperation";
            Description = "";
            Add("gte", "gte");
            Add("gt", "gt");
            Add("eq", "eq");
            Add("neq", "neq");
            Add("lt", "lt");
            Add("lte", "lte");
            Add("contains", "contains");
            Add("notcontains", "notcontains");
            Add("startswith", "startswith");
            Add("endswith", "endswith");
            Add("inlist", "inlist");
            Add("notinlist", "notinlist");
            Add("notstartswith", "notstartswith");
            Add("notendswith", "notendswith");
            Add("containsinlist", "containsinlist");
            Add("notcontainsinlist", "notcontainsinlist");
            Add("startswithinlist", "startswithinlist");
            Add("endswithinlist", "endswithinlist");
            Add("notstartswithinlist", "notstartswithinlist");
            Add("notendswithinlist", "notendswithinlist");
        }
    }
    public class FilterLogicEnumType : EnumerationGraphType
    {
        public FilterLogicEnumType()
        {
            Name = "FilterLogic";
            Description = "Logic can be one of 'and', 'or'";
            Add("and", "and");
            Add("or", "or");
        }
    }    
    public class FilterInputType : InputObjectGraphType<FilterInput>
    {
        public FilterInputType()
        {
            Name = "FilterInput";
            Field<NonNullGraphType<FilterOperationEnumType>>("operation");
            Field<NonNullGraphType<FilterLogicEnumType>>("logic");
            Field<StringGraphType>("value");
            Field<StringGraphType>("fieldName");
        }
    }

    public class FilterGroupInputType : InputObjectGraphType<FilterGroupInput>
    {
        public FilterGroupInputType()
        {
            Name = "FilterGroupInput";
            Field<NonNullGraphType<FilterLogicEnumType>>("logic");
            Field<ListGraphType<NonNullGraphType<FilterGroupInputType>>>("childGroups");
            Field<ListGraphType<NonNullGraphType<FilterInputType>>>("filters");
        }
    }
    public class SearchInputType : InputObjectGraphType<SearchInput>
    {
        public SearchInputType()
        {
            Name = "SearchInput";
            //Field<NonNullGraphType<ListGraphType<NonNullGraphType<FilterInputType>>>>("filters");
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<FilterGroupInputType>>>>("filterGroups");
        }
    }    
}
namespace GraphQL.Extension.Types.Pagination
{
    public class PaginationInputType : InputObjectGraphType<PaginationInput>
    {
        public PaginationInputType()
        {
            Name = "PaginationInput";
            Field<IntGraphType>("take");
            Field<IntGraphType>("skip");
            Field<ListGraphType<SortInputType>>("sorts");

        }
    }
    public class SortInputType : InputObjectGraphType<SortInput>
    {
        public SortInputType()
        {
            Field<StringGraphType>("fieldName");
            Field<SortDirectionEnumType>("direction");
        }
    }
    public class SortDirectionEnumType : EnumerationGraphType
    {
        public SortDirectionEnumType()
        {
            Name = "sortDirection";
            Description = "";
            Add("asc", "asc");
            Add("desc", "desc");
        }
    }
}

namespace GraphQL.Extension.Types.Unique
{
    public class DistinctByInputType : InputObjectGraphType<DistinctByInput>
    {
        public DistinctByInputType()
        {
            Name = "DistinctByInput";

            Field<NonNullGraphType<StringGraphType>>("fieldNames");
            Field<SearchInputType>("search");
            Field<PaginationInputType>("pagination");
        }
    }
}

namespace GraphQL.Extension.Types.Grouping
{
    public class GroupByInputType : InputObjectGraphType<GroupByInput>
    {
        public GroupByInputType()
        {
            Name = "GroupByInput";

            Field<NonNullGraphType<StringGraphType>>("fieldNames");
            Field<SearchInputType>("search");
        }
    }
}

namespace GraphQL.Extension.Types.Mutation
{
    public class MutationOperationEnumType : EnumerationGraphType
    {
        public MutationOperationEnumType()
        {
            base.Name = "MutationOperation";
            Description = "";
            Add("add", "add");
            Add("update", "update");
            Add("delete", "delete");
        }
    }
}