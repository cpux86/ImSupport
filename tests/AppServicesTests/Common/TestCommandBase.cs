using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServicesTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ICaseContext Context;
        public TestCommandBase()
        {
            Context = CaseContextFactory.Create();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
