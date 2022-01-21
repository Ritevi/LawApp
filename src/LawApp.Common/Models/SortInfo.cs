using LawApp.Common.Models.Enum;

namespace LawApp.Common.Models
{
    public struct SortInfo
    {
        public static SortInfo Empty => new SortInfo(null, SortDirection.Asc);

        public string SortBy { get; }
        public SortDirection Direction { get; }

        public SortInfo(string sortBy, SortDirection direction)
        {
            SortBy = sortBy;
            Direction = direction;
        }

        public override int GetHashCode() => (SortBy, Direction).GetHashCode();

        public override bool Equals(object obj) => obj is SortInfo si && si.SortBy == SortBy && si.Direction == Direction;
    }
}
