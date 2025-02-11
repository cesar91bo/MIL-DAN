namespace SistemaFacturacionInventario.Unidad_Medida
{
    partial class frmUMedida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewUMedida = new System.Windows.Forms.ListView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtUMedida = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewUMedida
            // 
            this.listViewUMedida.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewUMedida.FullRowSelect = true;
            this.listViewUMedida.HideSelection = false;
            this.listViewUMedida.Location = new System.Drawing.Point(34, 38);
            this.listViewUMedida.Margin = new System.Windows.Forms.Padding(4);
            this.listViewUMedida.Name = "listViewUMedida";
            this.listViewUMedida.Size = new System.Drawing.Size(516, 327);
            this.listViewUMedida.TabIndex = 24;
            this.listViewUMedida.UseCompatibleStateImageBehavior = false;
            this.listViewUMedida.View = System.Windows.Forms.View.Details;
            this.listViewUMedida.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewUMedida_ItemSelectionChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(369, 377);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(83, 29);
            this.btnNuevo.TabIndex = 23;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDesc.Location = new System.Drawing.Point(31, 385);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(63, 13);
            this.lblDesc.TabIndex = 22;
            this.lblDesc.Text = "U. Medida:";
            // 
            // txtUMedida
            // 
            this.txtUMedida.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUMedida.Location = new System.Drawing.Point(104, 382);
            this.txtUMedida.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUMedida.Name = "txtUMedida";
            this.txtUMedida.Size = new System.Drawing.Size(256, 22);
            this.txtUMedida.TabIndex = 21;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(460, 377);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 29);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmUMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 450);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.listViewUMedida);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtUMedida);
            this.Name = "frmUMedida";
            this.Text = "frmUMedida";
            this.Load += new System.EventHandler(this.frmUMedida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewUMedida;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtUMedida;
        private System.Windows.Forms.Button btnEliminar;
    }
}