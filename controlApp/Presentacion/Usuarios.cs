using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using controlApp.Datos;
using controlApp.Logica;

namespace controlApp.Presentacion
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        int idusuario;

        private void Usuarios_Load(object sender, EventArgs e)
        {
            mostrar_usuarios();
        }

        private void mostrar_usuarios()
        {
            DataTable dt;
            dusuarios funcion = new dusuarios();
            dt = funcion.mostrar_usuarios();
            dataListado.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = true;
            panelUsuario.Dock = DockStyle.Fill;
            btnGuardar.Visible = true;
            btnGuardarC.Visible = false;

            txtUsuario.Clear();
            txtPassword.Clear();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    insertar_usuario();
                    mostrar_usuarios();
                }
                else
                {
                    MessageBox.Show("Ingrese una contraseña", "Sin contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un usuario", "Sin usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertar_usuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();

            dt.Usuario = txtUsuario.Text;
            dt.Pass = txtPassword.Text;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imgIcono.Image.Save(ms, imgIcono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();

            dt.Estado = "Activo";

            if (funcion.insertar(dt))
            {
                MessageBox.Show("Usuario Registrado", "Registro Correcto");
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
            }
        }

        private void eliminar_usuarios()
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();

            dt.Idusuario = idusuario;

            if (funcion.eliminar(dt))
            {
                MessageBox.Show("Usuario Eliminado", "Eliminación Correcta");
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idusuario = Convert.ToInt32(dataListado.SelectedCells[2].Value.ToString());

            if (e.ColumnIndex == this.dataListado.Columns["Editar"].Index)
            {
                txtUsuario.Text = dataListado.SelectedCells[3].Value.ToString();
                txtPassword.Text = dataListado.SelectedCells[4].Value.ToString();
                imgIcono.BackgroundImage = null;
                byte[] b = (Byte[])dataListado.SelectedCells[5].Value;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
                imgIcono.Image = Image.FromStream(ms);

                panelUsuario.Visible = true;
                panelUsuario.Dock = DockStyle.Fill;
                btnGuardar.Visible = false;
                btnGuardarC.Visible = true;
            }

            if (e.ColumnIndex == this.dataListado.Columns["Eliminar"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Desea eliminar este registro?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    eliminar_usuarios();
                    mostrar_usuarios();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = false;
            panelUsuario.Dock = DockStyle.None;
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            editar_usuario();
            mostrar_usuarios();
        }

        private void editar_usuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();

            dt.Idusuario = idusuario;
            dt.Usuario = txtUsuario.Text;
            dt.Pass = txtPassword.Text;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imgIcono.Image.Save(ms, imgIcono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();

            dt.Estado = "Activo";

            if (funcion.editar(dt))
            {
                MessageBox.Show("Usuario modificado", "Registro Correcto");
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar_usuarios();
        }

        private void buscar_usuarios()
        {
            DataTable dt;
            dusuarios funcion = new dusuarios();
            dt = funcion.buscar_usuarios(txtBuscar.Text);
            dataListado.DataSource = dt;
        }

        private void imgIcono_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de imágen";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imgIcono.BackgroundImage = null;
                imgIcono.Image = new Bitmap(dlg.FileName);
            }
        }
    }
}
