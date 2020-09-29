using Christ3D.Domain.Interfaces;
using Christ3D.Infrastruct.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Infrastruct.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudyContext _studyContext;
        public UnitOfWork(StudyContext studyContext)
        {
            _studyContext = studyContext;
        }
        public bool Commit()
        {
            return _studyContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _studyContext.Dispose();
        }
    }
}
