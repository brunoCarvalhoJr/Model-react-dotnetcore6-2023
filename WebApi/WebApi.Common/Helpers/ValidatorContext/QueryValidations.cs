using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Common.Exceptions;

namespace WebApi_Common.Helpers.ValidatorContext
{
    public static class QueryValidations
    {
        public static void CheckExists(this object obj, string entity)
        {
            if (obj == null)
            {
                throw new NotFoundException($"{entity} not found.");
            }
        }

        public static void Invalid(this object obj, string entity)
        {
            if (obj == null)
            {
                throw new NotFoundException($"{entity} is invalid.");
            }
        }

        public static void AlreadyExits(this object obj, string entity)
        {
            if (obj == null)
            {
                throw new DomainException($"{entity} already extis.");
            }
        }

        public static void AlreadyExits(this bool obj, string entity)
        {
            if (obj)
            {
                throw new DomainException($"{entity} already extis.");
            }
        }

    }
}
