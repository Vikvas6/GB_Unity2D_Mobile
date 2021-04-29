namespace Tools
{
    public interface IInitialize<T>
    {
        void Init(T initObject);
    }
    
    public interface IInitialize<T, M>
    {
        void Init(T initObject1, M initObject2);
    }
    
    public interface IInitialize<T, M, K>
    {
        void Init(T initObject1, M initObject2, K initObject3);
    }
}