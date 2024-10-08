using KioscoInformaticoApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;

namespace KioscoInformaticoApp.ViewModels
{
    public class ProductosViewModel : ObjectNotification
    {
        private GenericService<Producto> productoService = new GenericService<Producto>();

        private string filterProducts;
        public string FilterProducts
        {
            get { return filterProducts; }
            set
            {
                filterProducts = value;
                OnPropertyChanged();
                FiltarProductos();
            }
        }
 
        private ObservableCollection<Producto> productos;
        public ObservableCollection<Producto> Productos
        {
            get { return productos; }
            set
            {
                productos = value;
                OnPropertyChanged();
            }
        }

        //porque hacemos esto, porque lo dijo Gabriel
        //https://chatgpt.com/share/9ab527ab-34a6-426c-b7a7-362c38e460a7
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        private List<Producto>? ProductListToFilter;

        private bool activityStart;
        public bool ActivityStart
        {
            get { return activityStart; }
            set
            {
                activityStart = value;
                OnPropertyChanged();
            }
        }

        public Command ObtenerProductosCommand { get; set; }
        public Command FiltrarProductosCommand { get; set; }

        public ProductosViewModel()
        {
            ObtenerProductosCommand = new Command(async () => await ObtenerProductos());
            FiltrarProductosCommand = new Command(async () =>  await FiltarProductos());
            ObtenerProductos();
        }

        private async Task FiltarProductos()
        {
            var prductosFiltrados = ProductListToFilter.Where(p => p.Nombre.ToUpper().Contains(FilterProducts.ToUpper()));
            Productos = new ObservableCollection<Producto>(prductosFiltrados);
        }

        private async Task ObtenerProductos()
        {
            FilterProducts = string.Empty;
            ActivityStart = true;
            ProductListToFilter = await productoService.GetAllAsync();
            Productos = new ObservableCollection<Producto>(ProductListToFilter);
            ActivityStart = false;
        }

    }
}
