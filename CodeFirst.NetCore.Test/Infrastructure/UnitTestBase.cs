using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.NetCore.Test
{
    public abstract class UnitTestBase : IDisposable
    {
        /// <summary>
        /// asp net core configuration
        /// </summary>
        protected readonly IConfiguration configuration;

        /// <summary>
        /// Mediator instance 
        /// </summary>
        protected readonly IMediator mediator;

        /// <summary>
        /// Model Mapper instance
        /// </summary>
        protected readonly IMapper mapper;

        /// <summary>
        /// DbContext instance
        /// </summary>
        protected readonly UserDBContext context;

        /// <summary>
        /// String value comparer
        /// </summary>
        protected readonly StringComparer _Comparer = StringComparer.OrdinalIgnoreCase;


        /// <summary>
        /// User Repository
        /// </summary>
        protected readonly IUserRepository userRepository;

        /// <summary>
        /// User Group Repository
        /// </summary>
        protected readonly IUserGroupRepository userGroupRepository;

        public UnitTestBase()
        {
            // Mock IConfiguration Instance
            var config = new Mock<IConfiguration>();
            config.Setup(c => c.GetSection(It.IsAny<string>()))
                .Returns(new Mock<IConfigurationSection>().Object);

            configuration = config.Object;

            mediator = new Mock<IMediator>().Object;

            mapper = new Mock<IMapper>().Object;

            context = DbContextFactory.Create();

            userRepository = new UserRepository(context);

            userGroupRepository = new UserGroupRepository(context);

        }

        /// <summary>
        /// Implemented using the IDisposable Interface. Automatically invokes this method after use
        /// </summary>
        public void Dispose()
        {
            // Dispose dbContext instance
            if (context != null)
                context.Dispose();
        }
    }
}
