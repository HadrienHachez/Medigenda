using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGenerateForm.Attributes;

namespace Medigenda
{
    public class SkillList : PropertyChangeBase
    {
        private List<HaveSkill> mySkillList = new List<HaveSkill>();

        public SkillList(List<ServiceName> AllService)
        {
            foreach(ServiceName skill in AllService)
            {
                mySkillList.Add(new HaveSkill(skill));
            }
        }

        [AutoGenerateProperty]
        public List<HaveSkill> MySkillList
        {
            get { return this.mySkillList; }
            set { this.mySkillList = value; }
        }

    }
}
