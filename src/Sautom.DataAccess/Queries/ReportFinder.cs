using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using Sautom.Queries;
using Sautom.Queries.ReportOptimizedDto;

namespace Sautom.DataAccess.Queries
{
    public sealed class ReportFinder : FinderBase, IReportFinder
    {
	    #region Constructors

	    #endregion

	    #region Implementation of IReportFinder

	    public IList<OrderReportDto> OrderReport(OrderReportDto standard)
        {
            IQueryable<OrderReportDto> queryable = DatabaseContext.Orders.Select(rec => new OrderReportDto
            {
                                                         ClientName = rec.Client.LastName + " " + rec.Client.FirstName + " " + rec.Client.MiddleName,
                                                         CourceName = rec.Proposal.CourseName,
                                                         SchoolName = rec.Proposal.SchoolName,
                                                         StartDate = rec.StartDate,
                                                         EndDate = rec.EndDate
                                                     });

            Expression<Func<OrderReportDto, bool>> where =
                rec => standard.StartDate <= rec.StartDate && rec.EndDate <= standard.EndDate;

            if (!string.IsNullOrWhiteSpace(standard.ClientName))
            {
                where = where.And(rec => rec.ClientName.Contains(standard.ClientName));
            }

            if (!string.IsNullOrWhiteSpace(standard.CourceName))
            {
                where = where.And(rec => rec.CourceName.Contains(standard.CourceName));
            }

            if (!string.IsNullOrWhiteSpace(standard.SchoolName))
            {
                where = where.And(rec => rec.SchoolName.Contains(standard.SchoolName));
            }

            queryable = queryable.AsExpandable().Where(where);

            return queryable.ToList();
        }

	    #endregion
    }
}
