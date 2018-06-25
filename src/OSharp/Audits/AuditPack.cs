﻿// -----------------------------------------------------------------------
//  <copyright file="AuditPack.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-23 15:23</last-date>
// -----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

using OSharp.Core.Packs;
using OSharp.EventBuses;


namespace OSharp.Audits
{
    /// <summary>
    /// 审计模块
    /// </summary>
    [DependsOnPacks(typeof(EventBusPack))]
    public class AuditPack : OsharpPack
    {
        /// <summary>
        /// 获取 模块级别
        /// </summary>
        public override PackLevel Level => PackLevel.Application;

        /// <summary>
        /// 将模块服务添加到依赖注入服务容器中
        /// </summary>
        /// <param name="services">依赖注入服务容器</param>
        /// <returns></returns>
        public override IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<AuditEntityStoreEventHandler>();
            services.AddSingleton<IAuditStore, NullAuditStore>();

            return services;
        }
    }
}