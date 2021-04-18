using System.Collections.Generic;

namespace WebApplicationAssignment.Models
{
    interface IMessageService
    {
        public bool Save(float temp);
        List<float> GetAll();
    }
}
