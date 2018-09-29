namespace ConsoleApp
{
    interface IObserver<T> {
        void Update(T value);
    }
}
