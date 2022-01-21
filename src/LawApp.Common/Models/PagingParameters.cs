namespace LawApp.Common.Models
{
    public struct PagingParameters
    {
        public static PagingParameters Empty => new PagingParameters(0, 0);

        public int Skip { get; }
        public int Take { get; }

        public PagingParameters(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public override int GetHashCode() => unchecked(Skip * 27 + Take * 31);

        public override bool Equals(object obj) => obj is PagingParameters pp && pp.Skip == Skip && pp.Take == Take;
    }
}