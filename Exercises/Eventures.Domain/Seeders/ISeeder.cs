using System.Threading.Tasks;

namespace Eventures.Domain.Seeders
{
    public interface ISeeder
    {
        void Seed(EventuresDbContext context);
    }
}