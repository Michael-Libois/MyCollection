using Common.BTO;
using Common.DTO.DataContext;

namespace MyCollection.ViewModels
{
    public static class LoginViewModelExtentions
    {
        public static AdressBTO ToAdressBTO(this LoginViewModel Model)
            => new AdressBTO
            {
                Id = 0,
                Street = Model.Street,
                Number = Model.Number,
                PostalCode = Model.PostalCode,
                City = Model.City
            };
    }
}
