﻿using ContactManager.Model;

namespace ContactManager.Repository
{
    public interface IContactRepository
    {
        void Add(ContactModel contact);
    }
}