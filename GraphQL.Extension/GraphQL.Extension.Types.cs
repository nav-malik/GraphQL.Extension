using GraphQL.Types;
using GraphQL.Extension.Base.Filter;
using GraphQL.Extension.Base.Pagination;

namespace GraphQL.Extension.Types.Filter
{
    public class FilterOperationEnumType : EnumerationGraphType<FilterOperationEnum>
    {
        public FilterOperationEnumType()
        {
            Name = "FilterOperation";
            Description = "";
        }
    }
    public class FilterLogicEnumType : EnumerationGraphType<FilterLogicEnum>
    {
        public FilterLogicEnumType()
        {
            Name = "FilterLogic";
            Description = "Logic can be one of 'and', 'or'";
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
    public class SortDirectionEnumType : EnumerationGraphType<SortDirectionEnum>
    {
        public SortDirectionEnumType()
        {
            Name = "sortDirection";
            Description = "";
        }
    }
}
