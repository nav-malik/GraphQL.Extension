using GraphQL.Types;
using GraphQL.Extension.Base.Filter;
using GraphQL.Extension.Base.Pagination;

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
    public class SearchInputType : InputObjectGraphType<SearchInput>
    {
        public SearchInputType()
        {
            Name = "SearchInput";
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<FilterInputType>>>>("filters");
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
