using AutoMapper;
using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model.DTO
{
    [DataContract]
    public class OM_DepartmentDto
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Guid { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public bool IsDel { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UpdateDateTime { get; set; }

        public OM_DepartmentDto()
        {
            Mapper.CreateMap<OM_DepartmentDto, OM_Permission>();
            Mapper.CreateMap<OM_Permission, OM_DepartmentDto>();
        }

        public void test()
        {
            OrderManagementContext context = new OrderManagementContext();
            IEnumerable<OM_DepartmentDto> test1 = context.Set<OM_Permission>().Where(p => p.ID > 0).Select(p => Mapper.Map<OM_Permission, OM_DepartmentDto>(p));


            OM_Permission permission = new OM_Permission();
            OM_DepartmentDto test = Mapper.Map<OM_Permission, OM_DepartmentDto>(permission);
        }
    }


}
