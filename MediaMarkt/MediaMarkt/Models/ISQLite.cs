using SQLite;

namespace MediaMarkt.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
