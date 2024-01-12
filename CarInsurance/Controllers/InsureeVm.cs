using System;

namespace CarInsurance.Controllers
{
    internal class InsureeVm
    {
        public InsureeVm()
        {
        }

        public object FirstName { get; internal set; }
        public object LastName { get; internal set; }
        public object EmailAddress { get; internal set; }
       // public object Add { get; internal set; }

        internal void Add(InsureeVm insureeVm)
        {
            throw new NotImplementedException();
        }
    }
}