using DataContract;
using System;

namespace BusinessApi
{
    public interface IDataProcessor
    {
        Person ProcessPerson(Person person);
    }
}
