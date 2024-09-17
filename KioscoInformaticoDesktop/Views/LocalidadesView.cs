using KioscoInformaticoDesktop.DataContext;
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
using System.Xml.Linq;
using System.Windows.Controls;

namespace KioscoInformaticoDesktop.Views
{
    public partial class LocalidadesView : Form
    {
        IGenericService<Localidad> localidadService = new GenericService<Localidad>();

        BindingSource listaLocalidades = new BindingSource();

        Localidad localidadCurrent;
        public LocalidadesView()
        {
            InitializeComponent();
            dataGridLocalidades.DataSource = listaLocalidades;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listaLocalidades.DataSource = await localidadService.GetAllAsync();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            tabControl1.SelectTab(tabPageAgregarEditar);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio, por favor completelo");
                return;
            }
            var localidad = new Localidad
            {
                Nombre = txtNombre.Text
            };


            if (localidadCurrent != null)
            {
                localidadCurrent.Nombre = txtNombre.Text;
                await localidadService.UpdateAsync(localidadCurrent);
                localidadCurrent = null;

            }
            else
            {
                await localidadService.AddAsync(localidad);
            }

            MessageBox.Show("Localidad guardada correctamente", "Localidad guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await CargarGrilla();
            txtNombre.Text = string.Empty;
            tabControl1.SelectedTab = tabPageLista;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            localidadCurrent = (Localidad)listaLocalidades.Current;
            txtNombre.Text = localidadCurrent.Nombre;
            tabControl1.SelectTab(tabPageAgregarEditar);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listaLocalidades.Current is Localidad localidad)
            {
                var result = MessageBox.Show("¿Está seguro de eliminar esta localidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await localidadService.DeleteAsync(localidad.Id);
                    await CargarGrilla();
                    MessageBox.Show("Localidad eliminada con éxito");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea salir sin guardar los datos?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                tabControl1.SelectTab(tabPageLista);
            }
        }
    }
}
