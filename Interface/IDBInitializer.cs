using OVS.Database;

namespace OVS.Initializers
{
    public interface IDBInitializer
    {
        void Initialize(SQLiteDBContext context); // Make sure this matches
    }
}
