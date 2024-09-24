namespace KioscoInformaticoDesktop
{
    partial class MenuPrincipalView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem3 = new FontAwesome.Sharp.IconMenuItem();
            menuItemLocalidades = new FontAwesome.Sharp.IconMenuItem();
            menuItemProductos = new FontAwesome.Sharp.IconMenuItem();
            MenuItemClose = new FontAwesome.Sharp.IconMenuItem();
            menuItemClientes = new FontAwesome.Sharp.IconMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { iconMenuItem1, iconMenuItem3, MenuItemClose });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(711, 61);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.House;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.IconSize = 40;
            iconMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            iconMenuItem1.Margin = new Padding(0, 5, 5, 10);
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(105, 42);
            iconMenuItem1.Text = "Principal";
            // 
            // iconMenuItem3
            // 
            iconMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { menuItemLocalidades, menuItemProductos, menuItemClientes });
            iconMenuItem3.IconChar = FontAwesome.Sharp.IconChar.Database;
            iconMenuItem3.IconColor = Color.Black;
            iconMenuItem3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem3.IconSize = 40;
            iconMenuItem3.ImageScaling = ToolStripItemImageScaling.None;
            iconMenuItem3.Margin = new Padding(0, 5, 5, 10);
            iconMenuItem3.Name = "iconMenuItem3";
            iconMenuItem3.Size = new Size(88, 42);
            iconMenuItem3.Text = "Bases";
            // 
            // menuItemLocalidades
            // 
            menuItemLocalidades.IconChar = FontAwesome.Sharp.IconChar.LocationPin;
            menuItemLocalidades.IconColor = Color.Black;
            menuItemLocalidades.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuItemLocalidades.Name = "menuItemLocalidades";
            menuItemLocalidades.Size = new Size(184, 26);
            menuItemLocalidades.Text = "Localidades";
            menuItemLocalidades.Click += menuItemLocalidades_Click;
            // 
            // menuItemProductos
            // 
            menuItemProductos.IconChar = FontAwesome.Sharp.IconChar.Computer;
            menuItemProductos.IconColor = Color.Black;
            menuItemProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuItemProductos.Name = "menuItemProductos";
            menuItemProductos.Size = new Size(184, 26);
            menuItemProductos.Text = "Productos";
            menuItemProductos.Click += menuItemProductos_Click;
            // 
            // MenuItemClose
            // 
            MenuItemClose.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            MenuItemClose.IconColor = Color.Black;
            MenuItemClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MenuItemClose.IconSize = 40;
            MenuItemClose.ImageScaling = ToolStripItemImageScaling.None;
            MenuItemClose.Margin = new Padding(0, 5, 5, 10);
            MenuItemClose.Name = "MenuItemClose";
            MenuItemClose.Padding = new Padding(0);
            MenuItemClose.Size = new Size(73, 42);
            MenuItemClose.Text = "Salir";
            MenuItemClose.Click += MenuItemClose_Click;
            // 
            // menuItemClientes
            // 
            menuItemClientes.IconChar = FontAwesome.Sharp.IconChar.User;
            menuItemClientes.IconColor = Color.Black;
            menuItemClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuItemClientes.Name = "menuItemClientes";
            menuItemClientes.Size = new Size(184, 26);
            menuItemClientes.Text = "Clientes";
            menuItemClientes.Click += menuItemClientes_Click;
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 254);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MenuPrincipalView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KioscoInformaticoDesktop";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem MenuItemClose;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem3;
        private FontAwesome.Sharp.IconMenuItem menuItemLocalidades;
        private FontAwesome.Sharp.IconMenuItem menuItemProductos;
        private FontAwesome.Sharp.IconMenuItem menuItemClientes;
    }
}
