using Ardalis.Specification;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications
{
    public class CaseListByOfficeIdSpec : Specification<Case>, ISingleResultSpecification
    {
        public CaseListByOfficeIdSpec(int officeId)
        {
            Query.Where(c => c.Service.Id == officeId)
                .OrderByDescending(date => date.CreatedDate);
                //.Skip(start)
                //.Take(count)
        }
    }
}
