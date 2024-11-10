using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext db;

    public GenericRepository(AppDbContext db)
    {
        this.db = db;
    }

    // Asenkron ekleme
    public async Task<bool> AddAsync(T entity)
    {
        try
        {
            await db.Set<T>().AddAsync(entity);  // Asenkron olarak ekleme
            return await db.SaveChangesAsync() > 0;  // Asenkron olarak veritabanına kaydetme
        }
        catch
        {
            return false;
        }
    }

    // Asenkron silme
    public async Task<bool> DeleteAsync(T entity)
    {
        try
        {
            entity.IsDeleted = true;
            db.Set<T>().Update(entity);
            return await db.SaveChangesAsync() > 0;  // Asenkron kaydetme
        }
        catch
        {
            return false;
        }
    }

    // Asenkron olarak tüm veriyi getirme
    public async Task<IEnumerable<T>> GetAllAsync(bool includeDeleted = false)
    {
        if (includeDeleted)
        {
            return await db.Set<T>().ToListAsync();  // Asenkron olarak tüm veriyi al
        }
        return await db.Set<T>().Where(x => !x.IsDeleted).ToListAsync();  // Silinmemiş veriyi al
    }

    // Asenkron olarak ID ile getirme
    public async Task<T> GetByIDAsync(Guid id, bool includeDeleted = false)
    {
        if (includeDeleted)
        {
            return await db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);  // Asenkron olarak veriyi al
        }
        return await db.Set<T>().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);  // Silinmemiş veriyi al
    }

    // Asenkron olarak belirli bir predikat ile veri getirme
    public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false)
    {
        if (includeDeleted)
        {
            return await db.Set<T>().Where(predicate).ToListAsync();  // Asenkron olarak veriyi al
        }
        return await db.Set<T>().Where(x => !x.IsDeleted).Where(predicate).ToListAsync();  // Silinmemiş veriyi al
    }

    // Asenkron olarak belirli bir predikat ile tek bir veri getirme
    public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false)
    {
        if (includeDeleted)
        {
            return await db.Set<T>().SingleOrDefaultAsync(predicate);  // Asenkron olarak veriyi al
        }
        return await db.Set<T>().Where(x => !x.IsDeleted).SingleOrDefaultAsync(predicate);  // Silinmemiş veriyi al
    }

    // Asenkron olarak veri güncelleme
    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            db.Set<T>().Update(entity);
            return await db.SaveChangesAsync() > 0;  // Asenkron olarak kaydetme
        }
        catch
        {
            return false;
        }
    }
}
