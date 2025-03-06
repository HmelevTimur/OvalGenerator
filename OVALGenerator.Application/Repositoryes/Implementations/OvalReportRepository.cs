using Microsoft.EntityFrameworkCore;
using OVALGenerator.Application.Repositoryes.Interfaces;
using OVALGenerator.Application.Services.Interfaces;
using OVALGenerator.Domain.Entities;
using OVALGenerator.Infrastructure.Persistence;

namespace OVALGenerator.Application.Repositoryes.Implementations;

public class OvalReportRepository(OvalDbContext context) : IOvalReportRepository
{
    public async Task SaveReportAsync(SecurityBulletinReport report)
    {
        var existingReport = await context.SecurityBulletins
            .FirstOrDefaultAsync(r => r.CveId == report.CveId);

        if (existingReport != null)
        {
            existingReport.OvalXml = report.OvalXml;
            context.SecurityBulletins.Update(existingReport);
        }
        else
        {
            await context.SecurityBulletins.AddAsync(report);
        }

        await context.SaveChangesAsync();
    }

}