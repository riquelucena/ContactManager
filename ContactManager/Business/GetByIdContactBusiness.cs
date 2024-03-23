﻿using ContactManager.Interfaces;
using ContactManager.Model;
using ContactManager.Repository;

namespace ContactManager.Business
{
    public class GetByIdContactBusiness : IGetByIdContactBusiness
    {
        private readonly IContactRepository _contactRepository;

        public GetByIdContactBusiness(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public ContactModel GetById(int id)
        {
            return _contactRepository.GetById(id);
        }
    }
}
