using Autofac;
using KanbanBoard.BuildingBlocks.EventBus.RabbitMQEventBus;
using KanbanBoard.BuildingBlocks.EventBus.Settings;
using KanbanBoard.BuildingBlocks.EventBus.Settings.Abstractions;
using KanbanBoard.Services.MailService.Api.IntegrationEvents.EventHandling;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;

namespace KanbanBoard.Services.MailService.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddTransient<CreatedGoalIntegrationEventHandler>();
        }

        public static void RegisterCustomRepositories(this IServiceCollection services)
        {
            services.AddTransient<CreatedGoalIntegrationEventHandler>();
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
        }

        public static void RegisterRabbitMQEventBus(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = Configuration["EventBusConnection"],
                    VirtualHost = Configuration["EventBusVirtualHostName"],
                    Port = Int32.Parse(Configuration["EventBusPort"]),
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                {
                    factory.UserName = Configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                {
                    factory.Password = Configuration["EventBusPassword"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            var subscriptionClientName = Configuration["SubscriptionClientName"];

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });
        }
    }
}
