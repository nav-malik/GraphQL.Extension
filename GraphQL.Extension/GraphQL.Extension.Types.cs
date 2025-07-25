using GraphQL.Extension.Base.Aggregation;
using GraphQL.Extension.Base.Filter;
using GraphQL.Extension.Base.Grouping;
using GraphQL.Extension.Base.Mutation;
using GraphQL.Extension.Base.Pagination;
using GraphQL.Extension.Base.Unique;
using GraphQL.Extension.Types.Filter;
using GraphQL.Extension.Types.Pagination;
using GraphQL.Types;

namespace GraphQL.Extension.Types.Filter
{
    public class FilterOperationEnumType : EnumerationGraphType<FilterOperationEnum>
    {
        public FilterOperationEnumType()
        {
            Name = "FilterOperation";
            Description = "";
            //Add("gte", "gte");
            //Add("gt", "gt");
            //Add("eq", "eq");
            //Add("neq", "neq");
            //Add("lt", "lt");
            //Add("lte", "lte");
            //Add("contains", "contains");
            //Add("notcontains", "notcontains");
            //Add("startswith", "startswith");
            //Add("endswith", "endswith");
            //Add("inlist", "inlist");
            //Add("notinlist", "notinlist");
            //Add("notstartswith", "notstartswith");
            //Add("notendswith", "notendswith");
            //Add("containsinlist", "containsinlist");
            //Add("notcontainsinlist", "notcontainsinlist");
            //Add("startswithinlist", "startswithinlist");
            //Add("endswithinlist", "endswithinlist");
            //Add("notstartswithinlist", "notstartswithinlist");
            //Add("notendswithinlist", "notendswithinlist");
        }
    }
    public class FilterLogicEnumType : EnumerationGraphType<FilterLogicEnum>
    {
        public FilterLogicEnumType()
        {
            Name = "FilterLogic";
            Description = "Logic can be one of 'and', 'or'";
            //Add("and", "and");
            //Add("or", "or");
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
            Field<StringGraphType>("delimiterListOfValues");
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
    public class SortDirectionEnumType : EnumerationGraphType<SortDirectionEnum>
    {
        public SortDirectionEnumType()
        {
            Name = "sortDirection";
            Description = "";
            //Add("asc", "asc");
            //Add("desc", "desc");
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

            Field<NonNullGraphType<ListGraphType<StringGraphType>>>("fieldNames");
            Field<StringGraphType>("delimiterFieldValues");
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

            Field<NonNullGraphType<ListGraphType<StringGraphType>>>("fieldNames");
            Field<SearchInputType>("search");
        }
    }

    public class GroupByOperationOnInputType : InputObjectGraphType<GroupByOperationOnInput> 
    {
        public GroupByOperationOnInputType()
        {
            Name = "GroupByOperationOnInput";

            Field<NonNullGraphType<ListGraphType<StringGraphType>>>("groupByFieldNames");
            Field<NonNullGraphType<StringGraphType>>("operationOnFieldName");
            Field<StringGraphType>("delimiterFieldValues");
            Field<NonNullGraphType<GroupByOperationEnumType>>("operation");
            Field<SearchInputType>("search");
            Field<PaginationInputType>("pagination");
        }
    }

    public class GroupValuePairType : ObjectGraphType<GroupValuePair>
    {
        public GroupValuePairType()
        {
            Name = nameof(GroupValuePairType);

            Field<ListGraphType<GroupKeyNameValueType>>("keys");
            Field<IntGraphType>("value");
        }
    }

    public class GroupKeyNameValueType : ObjectGraphType<GroupKeyNameValue>
    {
        public GroupKeyNameValueType()
        {
            Name = nameof(GroupKeyNameValueType);

            Field<StringGraphType>("keyName");
            Field<StringGraphType>("keyValue");
        }
    }

    public class GroupByOperationEnumType : EnumerationGraphType<GroupByOperationEnum>
    {
        public GroupByOperationEnumType()
        {
            base.Name = "GroupByOperationEnum";
            base.Description = "";
            //Add("sum", "sum");
            //Add("count", "count");
            //Add("max", "max");
            //Add("min", "min");
        }
    }
}

namespace GraphQL.Extension.Types.Aggregation
{
    public class GroupByAggregationInputType : ObjectGraphType<GroupByAggregationInput>
    {
        public GroupByAggregationInputType()
        {
            base.Name = "GroupByAggregationInput";
            base.Description = "Perform Group By in multiple fields and perform aggregation on a single field."
                + "AggregationOperation can be COUNTDISTINCT, COUNT, SUM, MIN AND MAX, default is COUNTDISTINCT.";

            Field<NonNullGraphType<ListGraphType<StringGraphType>>>("groupByFieldNames");
            Field<NonNullGraphType<StringGraphType>>("aggregationFieldName");
            Field<NonNullGraphType<StringGraphType>>("aggregationResultFieldName");
            Field<NonNullGraphType<AggregationOperationEnumType>>("aggregationOperation");
            Field<SearchInputType>("search");
        }
        
    }

    public class AggregationOperationEnumType : EnumerationGraphType<AggregationOperationEnum>
    {
        public AggregationOperationEnumType()
        {
            base.Name = "GroupByOperationEnum";
            base.Description = "";
        }
    }
}

namespace GraphQL.Extension.Types.Mutation
{
    public class MutationOperationEnumType : EnumerationGraphType<MutationOperationEnum>
    {
        public MutationOperationEnumType()
        {
            base.Name = "MutationOperation";
            Description = "";
        }
    }
}