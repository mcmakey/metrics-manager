﻿using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using MetricsAgent.Responses;
using MetricsAgent.Requests;
using System.Collections.Generic;
using MetricsAgent.Models;
using MetricsAgent.DAL.Interfaces;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private IHddMetricsRepository _repository;
        private readonly ILogger<HddMetricsController> _logger;

        public HddMetricsController(IHddMetricsRepository repository, ILogger<HddMetricsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public HddMetricsController(IHddMetricsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricsCreateRequest request)
        {
            if (_logger is not null)
            {
                _logger.LogInformation($"Create Time={request.Time}, Value={request.Value}");
            }

            _repository.Create(new HddMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            if (_logger is not null)
            {
                _logger.LogInformation("All");
            }

            var metrics = _repository.GetAll();

            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto
                {
                    Time = DateTimeOffset.FromUnixTimeSeconds(metric.Time),
                    Value = metric.Value,
                    Id = metric.Id
                });
            }

            return Ok(response);
        }

        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] HddMetricsGetByPeriodRequest request)
        {
            if (_logger is not null)
            {
                _logger.LogInformation($"GetByTimePeriod fromTime={request.FromTime}, toTime={request.ToTime}");
            }

            var metrics = _repository.GetByTimePeriod(request.FromTime, request.ToTime);

            var response = new HddMetricsByTimePeriodResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto
                {
                    Time = DateTimeOffset.FromUnixTimeSeconds(metric.Time),
                    Value = metric.Value,
                    Id = metric.Id
                });
            }

            return Ok(response);
        }
    }
}
