using KioscoInformaticoServices.Interfaces;
using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioscoInformaticoDesktop.Views
{
    public partial class ProductosView : Form
    {
        IGenericService<Producto> productoService = new GenericService<Producto>();

        BindingSource listaProductos = new BindingSource();
        List<Producto> ListaAFiltrar = new List<Producto>();

        Producto productoCurrent;
        public ProductosView()
        {
            InitializeComponent();
            dataGridProductosView.DataSource = listaProductos;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listaProductos.DataSource = await productoService.GetAllAsync();
            ListaAFiltrar = (List<Producto>)listaProductos.DataSource;
        }

        private async void btnAgregar_Click_1(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            tabControl1.SelectTab(tabPageAgregarEditar);
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            productoCurrent = (Producto)listaProductos.Current;
            txtNombre.Text = productoCurrent.Nombre;
            tabControl1.SelectTab(tabPageAgregarEditar);
        }

        private async void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (listaProductos.Current is Producto producto)
            {
                var result = MessageBox.Show("¿Está seguro de eliminar el producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await productoService.DeleteAsync(producto.Id);
                    await CargarGrilla();
                    MessageBox.Show("Producto eliminado correctamente");
                }
            }
        }
        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var producto = new Producto
            {
                Nombre = txtNombre.Text
            };

            if (productoCurrent != null)
            {
                productoCurrent.Nombre = txtNombre.Text;
                await productoService.UpdateAsync(productoCurrent);
                productoCurrent = null;
            }
            else
            {
                await productoService.AddAsync(producto);
            }

            MessageBox.Show("Producto guardado correctamente", "Producto guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await CargarGrilla();
            txtNombre.Text = string.Empty;
            tabControl1.SelectedTab = tabPageLista;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro de cancelar la operación?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtNombre.Text = string.Empty;
                tabControl1.SelectedTab = tabPageLista;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void FiltrarProductos()
        {
            var filteredProductos = ListaAFiltrar.Where(p => p.Nombre.Contains(txtFiltro.Text)).ToList();
            listaProductos.DataSource = new BindingSource(filteredProductos, null);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }
    }
}
