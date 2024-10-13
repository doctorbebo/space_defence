public interface IObjectPool<out T>
{
    T Next();
}