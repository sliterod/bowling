public interface INumberGenerator<TValue>  {

    TValue GetValue();

    void Reset();
}
