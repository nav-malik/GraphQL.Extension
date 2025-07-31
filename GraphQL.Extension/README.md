GraphQL Extensions to provide Pagination, Search, DistinctBy, GroupBy and MutationOperationEnum Input types for GraphQL schema.

4.6.1 Updated GroupByAggregationInputType base type from ObjectGraphType to InputObjectGraphType and addded IInputObjectGraphType in base.
This type is not nullable so it's needed IInputObjectGraphType as well.

4.6.0 Updated GroupByAggregationInputType base type from ObjectGraphType to InputObjectGraphType

4.5.0 Added GroupByAggregation, that will allow to perfom Count Distinct, Count, Sum, Min, and Max on a field other than in GroupBy field name list.
Also, update the GroupByInput and DistinctByInput, instead of passing field names as delimated string now field names will be List of strings. 

4.0.0 Updated Enums to match with GraphQL.Net version 8.x

3.5.0 Addes support for Net6.0, Net8.0 and Framework4.8

3.4.0 Added delimiter for in FinterInputType for list type operation values. Also, added delimiter for Field Names and Field Values in DistinctByInputType, GroupByInputType and GroupByOperationOnInputType so we can pass more than one character for delimiter, this is particularly helpful in field values as comma (,) can be in the values it self.

3.3.0 Added GroupByOperationOn graph types.

3.2.0 Added DistinctBy, GroupBy and MutationOperationEnum Input types.

3.1.0 Added Filter Groups. This allow to create SQL queries with 'Parenthesis' () and separate And/Or groups with () in SQL.