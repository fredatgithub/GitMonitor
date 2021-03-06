// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GitCommitController.cs" company="FreeToDev">Copyright Mike Fourie</copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace GitMonitor.Controllers
{
    using System;
    using GitMonitor.Models;
    using GitMonitor.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [Route("api/commits")]
    public class GitCommitController : Controller
    {
        private readonly ILogger<GitCommitController> locallogger;
        private readonly ICommitRepository localRepository;
        private readonly IOptions<MonitoredPathConfig> localMonitoredPathConfig;

        public GitCommitController(ICommitRepository repository, ILogger<GitCommitController> logger, IOptions<MonitoredPathConfig> monitoredPathConfig)
        {
            this.localRepository = repository;
            this.locallogger = logger;
            this.localMonitoredPathConfig = monitoredPathConfig;
        }

        [Route("{days:int?}")]
        public JsonResult Get(int days)
        {
            var results = this.localRepository.Get(this.localMonitoredPathConfig.Value, string.Empty, string.Empty, string.Empty, days);
            return this.Json(results);
        }

        [Route("{monitoredPathName}/{days:int?}")]
        public JsonResult Get(string monitoredPathName, int days)
        {
            var results = this.localRepository.Get(this.localMonitoredPathConfig.Value, monitoredPathName, string.Empty, string.Empty, days);
            return this.Json(results);
        }

        [Route("{monitoredPathName}/{repoName}/{days:int?}")]
        public JsonResult Get(string monitoredPathName, string repoName, int days)
        {
            var results = this.localRepository.Get(this.localMonitoredPathConfig.Value, monitoredPathName, repoName, string.Empty, days);
            return this.Json(results);
        }

        [Route("{monitoredPathName}")]
        public JsonResult Get(string monitoredPathName, string repoName, string branchName, int days)
        {
            var results = this.localRepository.Get(this.localMonitoredPathConfig.Value, monitoredPathName, repoName, branchName, days);
            return this.Json(results);
        }

        [Route("{startDateTime:DateTime}")]
        public JsonResult Get(DateTime startDateTime, string repoName, string branchName)
        {
            var results = this.localRepository.Get(this.localMonitoredPathConfig.Value, string.Empty, repoName, branchName, startDateTime, DateTime.UtcNow);
            return this.Json(results);
        }

        [Route("{monitoredPathName}/{startDateTime:DateTime}")]
        public JsonResult Get(string monitoredPathName, string repoName, string branchName, DateTime startDateTime)
        {
            var results = this.localRepository.Get(this.localMonitoredPathConfig.Value, monitoredPathName, repoName, branchName, startDateTime, DateTime.UtcNow);
            return this.Json(results);
        }

        [Route("{startDateTime:DateTime}/{endDateTime:DateTime}")]
        public JsonResult Get(DateTime startDateTime, DateTime endDateTime, string repoName, string branchName)
        {
            var results = this.localRepository.Get(this.localMonitoredPathConfig.Value, string.Empty, repoName, branchName, startDateTime, endDateTime);
            return this.Json(results);
        }

        [Route("{monitoredPathName}/{startDateTime:DateTime}/{endDateTime:DateTime}")]
        public JsonResult Get(string monitoredPathName, DateTime startDateTime, DateTime endDateTime, string repoName, string branchName)
        {
            var results = this.localRepository.Get(this.localMonitoredPathConfig.Value, monitoredPathName, repoName, branchName, startDateTime, endDateTime);
            return this.Json(results);
        }

        [Route("{monitoredPathName}/{commitId}")]
        public JsonResult Get(string monitoredPathName, string commitId, string repoName, string branchName)
        {
            var results = this.localRepository.Get(this.localMonitoredPathConfig.Value, monitoredPathName, repoName, branchName, commitId);
            return this.Json(results);
        }
    }
}