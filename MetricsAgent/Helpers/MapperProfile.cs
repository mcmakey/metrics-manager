using AutoMapper;
using MetricsAgent.DTO;
using MetricsAgent.Models;
using MetricsAgent.Requests;

namespace MetricsAgent.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetricsCreateRequest, CpuMetric>();
            CreateMap<DotNetMetricsCreateRequest, DotNetMetric>();
            CreateMap<HddMetricsCreateRequest, HddMetric>();
            CreateMap<NetworkMetricsCreateRequest, NetworkMetric>();
            CreateMap<RamMetricsCreateRequest, RamMetric>();

            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<DotNetMetric, DotNetMetricDto>();
            CreateMap<HddMetric, HddMetricDto>();
            CreateMap<NetworkMetric, NetworkMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();

        }
    }

}
