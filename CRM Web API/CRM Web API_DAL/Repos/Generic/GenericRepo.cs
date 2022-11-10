﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly ApplicationDbContext context;
    public GenericRepo(ApplicationDbContext _context)
    {
        context = _context;
    }
    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }
    public T? GetById(int id)
    {
        return context.Set<T>().Find(id);
    }
    public void Add(T item)
    {
        context.Set<T>().Add(item);
    }
    public void Delete(T item)
    {
        context.Set<T>().Remove(item);
    }
    public void Update(T item)
    {

    }
}
