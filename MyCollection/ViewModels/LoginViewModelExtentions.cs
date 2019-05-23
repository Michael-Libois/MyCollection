using Common.MTO;
using Common.DTO.DataContext;

namespace MyCollection.ViewModels
{
    public static class LoginViewModelExtentions
    {
        public static Adress ToAdress(this LoginViewModel Model)
            => new Adress
            {
                Id = 0,
                Street = Model.Street,
                Number = Model.Number,
                PostalCode = Model.PostalCode,
                City = Model.City
            };
    }
}
