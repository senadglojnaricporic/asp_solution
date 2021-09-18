namespace Project.Service.Interfaces
{
    public interface IVehicleModelGenericModel<T>
    {
        int Id { get; set; }
        int MakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }

        T VehicleMake { get; set; }
    }
}