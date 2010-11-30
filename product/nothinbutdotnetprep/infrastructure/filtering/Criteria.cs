namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface Criteria<T>
    {
        bool matches(T item);
    }
}