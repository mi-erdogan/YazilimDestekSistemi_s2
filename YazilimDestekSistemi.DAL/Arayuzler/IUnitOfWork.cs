using System;

namespace YazilimDestekSistemi.DAL.Arayuzler
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> Rep { get; }
        bool Kaydet();
    }
}