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
        GTE,
        GT,
        EQ,
        NEQ,
        LT,
        LTE,
        CONTAINS,
        NOTCONTAINS,
        STARTSWITH,
        ENDSWITH,
        INLIST,
        NOTINLIST,
        NOTSTARTSWITH,
        NOTENDSWITH,
        CONTAINSINLIST,
        NOTCONTAINSINLIST,
        STARTSWITHINLIST,
        ENDSWITHINLIST,
        NOTSTARTSWITHINLIST,
        NOTENDSWITHINLIST
    }
    public enum FilterLogicEnum
    {
        AND,
        OR
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
        ASC,
        DESC
    }
}

namespace GraphQL.Extension.Base.Unique
{
    public class DistinctByInput
    {

        /// <summary>
        /// List of strings containing field names.
        /// </summary>
        public List<string> FieldNames { get; set; }

        /// <summary>
        /// Provide Delimiter for Field Values, default is ",".
        /// </summary>
        public string DelimiterFieldValues { get; set; } = ",";

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
        /// List of strings containing field names.
        /// </summary>
        public List<string> FieldNames { get; set; }

        /// <summary>
        /// Provide search object to filter data for GroupBy.
        /// </summary>
        public SearchInput Search { get; set; }
    }

    public class GroupByOperationOnInput
    {
        /// <summary>
        /// List of strings containing field names.
        /// </summary>
        public List<string> GroupByFieldNames { get; set; }

        /// <summary>
        /// Single field name.
        /// </summary>
        public string OperationOnFieldName { get; set; }

        /// <summary>
        /// Provide Delimiter for Field Values, default is ",".
        /// </summary>
        public string DelimiterFieldValues { get; set; } = ",";

        /// <summary>
        /// Operations can be sum, count, min and max, default is count.
        /// </summary>
        public GroupByOperationEnum Operation { get; set; }

        /// <summary>
        /// Provide search object to filter data for GroupBy fields.
        /// </summary>
        public SearchInput Search { get; set; }

        /// <summary>
        /// Provide pagination object to apply sort, take and skip on data for GroupBy fields.
        /// </summary>
        public PaginationInput Pagination { get; set; }
    }

    public enum GroupByOperationEnum
    {
        SUM,
        COUNT,        
        MAX,
        MIN
    }

    public class GroupValuePair
    {
        public List<GroupKeyNameValue> Keys { get; set; }
        public int Value { get; set; }
    }

    public class GroupKeyNameValue
    {
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
    }
}

namespace GraphQL.Extension.Base.Aggregation
{
    public class GroupByAggregationInput
    {
        /// <summary>
        /// List of strings for group by field names
        /// </summary>
        /// 
        public List<string> GroupByFieldNames { get; set; }

        /// <summary>
        /// Single field Name for aggregtion 
        /// </summary>
        /// 
        public string AggregationFieldName { get; set; }


        /// <summary>
        /// Single field name for Aggregation Result, this will field will contain aggregated value.
        /// </summary>
        public string AggregationResultFieldName { get; set; }

        /// <summary>
        /// AggregationOperation can be COUNTDISTINCT, COUNT, SUM, MIN AND MAX, default is COUNTDISTINCT.
        /// </summary>
        /// 
        public AggregationOperationEnum AggregationOperation { get; set; } = AggregationOperationEnum.COUNTDISTINCT;

        /// <summary>
        /// Provide search object to filter data for GroupBy
        /// </summary>
        /// 
        public SearchInput Search { get; set; }
    }

    public enum AggregationOperationEnum
    {
        COUNTDISTINCT,
        COUNT,
        SUM,
        MIN,
        MAX
    }
    public class GroupAggregateValuePair
    {
        public string Group { get; set; }
        public int AggregatedValue { get; set; }
    }
}

namespace GraphQL.Extension.Base.Mutation
{
    public enum MutationOperationEnum
    {
        ADD,
        UPDATE,
        DELETE
    }
}
