using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Tongfang.DataAcquisition
{
    /// <summary>
    /// DAU创建者接口
    /// </summary>
    public interface IDauBuilder
    {
        /// <summary>
        /// <see cref="IServiceCollection"/>
        /// </summary>
        IServiceCollection Services { get; }
    }
    /// <summary>
    ///  DAU创建者默认实现
    /// </summary>
    public class DauBuilder : IDauBuilder
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public DauBuilder(IServiceCollection services)
        {
            Services = services;
        }
        /// <summary>
        /// 获得<see cref="IServiceCollection"/>
        /// </summary>
        public IServiceCollection Services { get; }
    }
}
