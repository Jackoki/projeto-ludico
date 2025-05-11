public class SearchFilter
{
    public string ColumnName { get; set; }
    public string SearchTerm { get; set; }
    public SearchOperator Operator { get; set; } = SearchOperator.Contains;
}

public enum SearchOperator
{
    Equals,
    Contains
}
