namespace WebStore.Entities.ViewModels
{
    /// <summary>Модель детального представления корзины, включающая модель заказа</summary>
    public class DetailsViewModel
    {
        /// <summary>Модель-представление корзины</summary>
        public CartViewModel Cart { get; set; }

        /// <summary>Модель-представление заказа</summary>
        public OrderViewModel Order { get; set; }
    }
}