using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;
using KioscoInformaticoServices.Interfaces;
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
    public partial class ClientesView : Form
    {
        IClienteService ClienteService = new ClienteService();
        ILocalidadService LocalidadService = new LocalidadService();

        BindingSource listaClientes = new BindingSource();
        List<Cliente> listaAFiltrar = new List<Cliente>();

        Cliente clienteCurrent;

        public ClientesView()
        {
            InitializeComponent();
            dataGridClientesView.DataSource = listaClientes;
            CargarGrilla();
            CargarCombo();
        }

        private async Task CargarCombo()
        {
            comboBoxLocalidades.DataSource = await LocalidadService.GetAllAsync();
            comboBoxLocalidades.DisplayMember = "Nombre";
            comboBoxLocalidades.ValueMember = "Id";
            comboBoxLocalidades.SelectedItem = 0;
        }

        private async Task CargarGrilla()
        {
            listaClientes.DataSource = await ClienteService.GetAllAsync();
            listaAFiltrar = (List<Cliente>)listaClientes.DataSource;

            dataGridClientesView.Columns["LocalidadId"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            dateTimeFechaNacimiento.Value = DateTime.Now;
            tabControl1.SelectTab(tabPageAgregarEditar);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            clienteCurrent = (Cliente)listaClientes.Current;
            txtNombre.Text = clienteCurrent.Nombre;
            txtDireccion.Text = clienteCurrent.Direccion;
            txtTelefono.Text = clienteCurrent.Telefonos;
            dateTimeFechaNacimiento.Value = clienteCurrent.FechaNacimiento;

            comboBoxLocalidades.SelectedValue = clienteCurrent.LocalidadId;

            tabControl1.SelectTab(tabPageAgregarEditar);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listaClientes.Current is Cliente cliente)
            {
                var result = MessageBox.Show("¿Está seguro de eliminar el Cliente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await ClienteService.DeleteAsync(cliente.Id);
                    await CargarGrilla();
                    MessageBox.Show("Cliente eliminado correctamente");
                }
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Telefonos = txtTelefono.Text,
                FechaNacimiento = dateTimeFechaNacimiento.Value,

                LocalidadId = (int)comboBoxLocalidades.SelectedValue

            };

            if (clienteCurrent != null)
            {
                clienteCurrent.Nombre = txtNombre.Text;
                clienteCurrent.Direccion = txtDireccion.Text;
                clienteCurrent.Telefonos = txtTelefono.Text;
                clienteCurrent.FechaNacimiento = dateTimeFechaNacimiento.Value;

                clienteCurrent.LocalidadId = (int)comboBoxLocalidades.SelectedValue;

                await ClienteService.UpdateAsync(clienteCurrent);
                clienteCurrent = null;
            }
            else
            {
                await ClienteService.AddAsync(cliente);
            }

            MessageBox.Show("Cliente guardado correctamente", "Cliente guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await CargarGrilla();
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            dateTimeFechaNacimiento.Value = DateTime.Now;
            tabControl1.SelectedTab = tabPageLista;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro de cancelar la operación?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                clienteCurrent = null;

                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                dateTimeFechaNacimiento.Value = DateTime.Now;
                tabControl1.SelectedTab = tabPageLista;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void FiltrarClientes()
        {
            var filteredClientes = listaAFiltrar.Where(c => c.Nombre.Contains(txtFiltro.Text)).ToList();
            listaClientes.DataSource = new BindingSource(filteredClientes, null);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void dataGridClientesView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
