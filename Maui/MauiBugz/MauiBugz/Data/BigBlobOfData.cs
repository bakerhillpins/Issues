
namespace MauiBugz.Data
{
    internal class BigBlobOfData : IDisposable
    {
        public int Id { get; set; } = -1;

        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        Console.WriteLine($"{this} disposed");
        //    }
        //}

#if DEBUG
        ~BigBlobOfData()
        {
            Console.WriteLine($"{this} collected");
        }
#endif

        public override string ToString()
        {
            return $"BigBlobOfData {this.Id}";
        }
    }
}
