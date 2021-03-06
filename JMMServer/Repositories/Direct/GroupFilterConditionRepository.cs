﻿using System.Collections.Generic;
using JMMServer.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace JMMServer.Repositories.Direct
{
    public class GroupFilterConditionRepository : BaseDirectRepository<GroupFilterCondition, int>
    {
        private GroupFilterConditionRepository()
        {
            
        }

        public static GroupFilterConditionRepository Create()
        {
            return new GroupFilterConditionRepository();
        }
        public List<GroupFilterCondition> GetByGroupFilterID(int gfid)
        {
            using (var session = JMMService.SessionFactory.OpenSession())
            {
                return GetByGroupFilterID(session, gfid);
            }
        }

        public List<GroupFilterCondition> GetByGroupFilterID(ISession session, int gfid)
        {
            var gfcs = session
                .CreateCriteria(typeof(GroupFilterCondition))
                .Add(Restrictions.Eq("GroupFilterID", gfid))
                .List<GroupFilterCondition>();

            return new List<GroupFilterCondition>(gfcs);
        }

        public List<GroupFilterCondition> GetByConditionType(GroupFilterConditionType ctype)
        {
            using (var session = JMMService.SessionFactory.OpenSession())
            {
                var gfcs = session
                    .CreateCriteria(typeof(GroupFilterCondition))
                    .Add(Restrictions.Eq("ConditionType", (int) ctype))
                    .List<GroupFilterCondition>();

                return new List<GroupFilterCondition>(gfcs);
            }
        }
    }
}