﻿using RESTWithASP_NET.Data.Converter.Implementations;
using RESTWithASP_NET.Data.VO;
using RESTWithASP_NET.Model;
using RESTWithASP_NET.Repository;

namespace RESTWithASP_NET.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);

            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);

            return _converter.Parse(personEntity);
        }

        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);

            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));

        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        //private Person MockPerson(int i)
        //{
        //    return new Person
        //    {
        //        Id = IncrementAndGet(),
        //        FirstName = "Test Person" + i,
        //        LastName = "Test Person2" + i,
        //        Address = "Test Person - Minas Gerais - Brasil" + i,
        //        Gender = "Male"
        //    };
        //}

        //private long IncrementAndGet()
        //{
        //    return Interlocked.Increment(ref count);
        //}
    }
}
