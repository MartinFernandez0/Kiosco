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
    public partial class ProveedoresView : Form
    {
        IProveedorService proveedorService = new ProveedorService();
        ILocalidadService localidadService = new LocalidadService();

        BindingSource ListaProveedores = new BindingSource();

        List<Proveedor> ListaAFiltrar = new List<Proveedor>();

        Proveedor proveedorCurrent;

        public ProveedoresView()
        {
            InitializeComponent();
            dataGridProveedores.DataSource = ListaProveedores;
            CargarGrilla();
            CargarCombo();
        }

        private async Task CargarCombo()
        {
            comboBoxLocalidades.DataSource = await localidadService.GetAllAsync();
            comboBoxLocalidades.DisplayMember = "Nombre";
            comboBoxLocalidades.ValueMember = "Id";
            comboBoxLocalidades.SelectedIndex = -1;
        }

        private async Task CargarGrilla()
        {
            var proveedores = await proveedorService.GetAllAsync(null);
            ListaProveedores.DataSource = proveedores;
            dataGridProveedores.AutoGenerateColumns = true; // Mostrar todas las columnas automáticamente
        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (proveedorCurrent != null)
            {
                proveedorCurrent.Nombre = txtNombre.Text;
                proveedorCurrent.Direccion = txtDireccion.Text;
                proveedorCurrent.Telefonos = txtTelefonos.Text;
                proveedorCurrent.Cbu = txtCbu.Text;
                proveedorCurrent.LocalidadId = (int)comboBoxLocalidades.SelectedValue;
                await proveedorService.UpdateAsync(proveedorCurrent);
                proveedorCurrent = null;
            }
            else
            {
                var proveedor = new Proveedor
                {
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefonos = txtTelefonos.Text,
                    Cbu = txtCbu.Text,
                    LocalidadId = (int)comboBoxLocalidades.SelectedValue,
                };
                await proveedorService.AddAsync(proveedor);
            }
            await CargarGrilla();
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonos.Text = string.Empty;
            txtCbu.Text = string.Empty;
            tabControl1.SelectTab(tabPageLista);
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            proveedorCurrent = null;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonos.Text = string.Empty;
            txtCbu.Text = string.Empty;
            tabControl1.SelectTab(tabPageLista);
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPageAgregarEditar);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            proveedorCurrent = (Proveedor)ListaProveedores.Current;
            txtNombre.Text = proveedorCurrent.Nombre;
            txtDireccion.Text = proveedorCurrent.Direccion;
            txtTelefonos.Text = proveedorCurrent.Telefonos;
            txtCbu.Text = proveedorCurrent.Cbu;
            comboBoxLocalidades.SelectedValue = proveedorCurrent.LocalidadId;
            tabControl1.SelectTab(tabPageAgregarEditar);
        }

        private async void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (ListaProveedores.Current is Proveedor proveedor)
            {
                var result = MessageBox.Show("¿Está seguro de eliminar el proveedor?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await proveedorService.DeleteAsync(proveedor.Id);
                    await CargarGrilla();
                    MessageBox.Show("Proveedor eliminado correctamente");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void FiltrarClientes()
        {
            var filteredClientes = ListaAFiltrar.Where(c => c.Nombre.Contains(txtFiltro.Text)).ToList();
            ListaProveedores.DataSource = new BindingSource(filteredClientes, null);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }
    }
}
