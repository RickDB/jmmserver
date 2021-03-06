﻿using System.Collections.Generic;
using JMMServer.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace JMMServer.Repositories.Direct
{
    public class AniDB_Character_SeiyuuRepository : BaseDirectRepository<AniDB_Character_Seiyuu, int>
    {
        private AniDB_Character_SeiyuuRepository()
        {
            
        }

        public static AniDB_Character_SeiyuuRepository Create()
        {
            return new AniDB_Character_SeiyuuRepository();
        }
        public AniDB_Character_Seiyuu GetByCharIDAndSeiyuuID(int animeid, int catid)
        {
            using (var session = JMMService.SessionFactory.OpenSession())
            {
                AniDB_Character_Seiyuu cr = session
                    .CreateCriteria(typeof(AniDB_Character_Seiyuu))
                    .Add(Restrictions.Eq("CharID", animeid))
                    .Add(Restrictions.Eq("SeiyuuID", catid))
                    .UniqueResult<AniDB_Character_Seiyuu>();
                return cr;
            }
        }

        public AniDB_Character_Seiyuu GetByCharIDAndSeiyuuID(ISession session, int animeid, int catid)
        {
            AniDB_Character_Seiyuu cr = session
                .CreateCriteria(typeof(AniDB_Character_Seiyuu))
                .Add(Restrictions.Eq("CharID", animeid))
                .Add(Restrictions.Eq("SeiyuuID", catid))
                .UniqueResult<AniDB_Character_Seiyuu>();
            return cr;
        }

        public List<AniDB_Character_Seiyuu> GetByCharID(int id)
        {
            using (var session = JMMService.SessionFactory.OpenSession())
            {
                return GetByCharID(session, id);
            }
        }

        public List<AniDB_Character_Seiyuu> GetByCharID(ISession session, int id)
        {
            var objs = session
                .CreateCriteria(typeof(AniDB_Character_Seiyuu))
                .Add(Restrictions.Eq("CharID", id))
                .List<AniDB_Character_Seiyuu>();

            return new List<AniDB_Character_Seiyuu>(objs);
        }

        public List<AniDB_Character_Seiyuu> GetBySeiyuuID(int id)
        {
            using (var session = JMMService.SessionFactory.OpenSession())
            {
                var objs = session
                    .CreateCriteria(typeof(AniDB_Character_Seiyuu))
                    .Add(Restrictions.Eq("SeiyuuID", id))
                    .List<AniDB_Character_Seiyuu>();

                return new List<AniDB_Character_Seiyuu>(objs);
            }
        }
    }
}