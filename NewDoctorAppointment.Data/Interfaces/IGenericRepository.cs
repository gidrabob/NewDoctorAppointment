﻿using NewDoctorAppointment.Domain.Entities;

namespace NewDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {
        TSource Create(TSource source);
        TSource? GetById(int id);
        TSource Update(int id, TSource source);
        IEnumerable<TSource> GetAll();
        bool Delete(int id);
        void ShowInfo(TSource source);
    }
}