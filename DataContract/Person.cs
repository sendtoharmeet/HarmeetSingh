using System;

namespace DataContract
{
    public class Person
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string AmountText { get; set; }
    }
}
