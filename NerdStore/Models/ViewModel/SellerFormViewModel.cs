using System.Collections.Generic;

namespace NerdStore.Models.ViewModel
{
    public class SellerFormViewModel
    {
        //Essa classe é uma view model, que contém uma referência aos objetos/models/entidades que pretendemos usar em uma View
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
