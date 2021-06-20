namespace FordCars.Web.ViewModels.Settings
{
    using FordCars.Data.Models;
    using FordCars.Services.Mapping;

    public class SettingViewModel : IMapFrom<Setting>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
