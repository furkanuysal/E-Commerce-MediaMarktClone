namespace MediaMarkt.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private string _OrderID;
        public string OrderID
        {
            set
            {
                _OrderID = value;
                OnPropertyChanged();
            }

            get
            {
                return _OrderID;
            }
        }

        public OrderViewModel(string id)
        {
            OrderID = id;
        }
    }
}
