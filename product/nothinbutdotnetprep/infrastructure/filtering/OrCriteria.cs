namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class OrCriteria<T> : BinaryCriteria<T>
    {
        public OrCriteria(Criteria<T> left_side, Criteria<T> right_side) : base(left_side, right_side)
        {
        }

        public override bool matches(T item)
        {
            return left_side.matches(item) || right_side.matches(item);
        }
    }
}