using Zitec.Automation.Application.Extensions;
using Zitec.Automation.Infra.Extensions;
using Zitec.Automation.Worker;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfraServices(builder.Configuration);

IHost host = builder.Build();
host.Run();
