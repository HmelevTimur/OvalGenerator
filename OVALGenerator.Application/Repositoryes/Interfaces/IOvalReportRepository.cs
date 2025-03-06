using OVALGenerator.Domain.Entities;

namespace OVALGenerator.Application.Repositoryes.Interfaces;

public interface IOvalReportRepository
{
    Task SaveReportAsync(SecurityBulletinReport report);
}