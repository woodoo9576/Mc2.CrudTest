using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Domain.Common.Entities
{
    public class BaseEntity : IBaseEntity
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }

    public interface IBaseEntity
    {
        [Key]
        int Id { get; set; }
    }
}
