using Autofac;
using Project.Service.Interfaces;
using Project.Service.Services;
using Project.MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace Project.MVC.DI
{
    public class DIModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<VehicleDbContext>().As<DbContext>().InstancePerLifetimeScope();

            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>().InstancePerLifetimeScope();

            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>().InstancePerLifetimeScope();

        }
    }
}
