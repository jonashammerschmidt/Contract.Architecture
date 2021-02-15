namespace Contract.Architecture.Backend.Core.API
{
    public class DataBody<T>
    {
        public DataBody()
        {
        }

        public DataBody(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }
    }
}