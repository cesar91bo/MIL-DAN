namespace SistemaFacturacionInventario.Rubros
{
    partial class frmRubro
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
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.listViewRubro = new System.Windows.Forms.ListView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc.Location = new System.Drawing.Point(38, 375);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(42, 15);
            this.lblDesc.TabIndex = 18;
            this.lblDesc.Text = "Rubro:";
            // 
            // txtRubro
            // 
            this.txtRubro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRubro.Location = new System.Drawing.Point(86, 373);
            this.txtRubro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(281, 22);
            this.txtRubro.TabIndex = 17;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(376, 369);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(83, 29);
            this.btnNuevo.TabIndex = 19;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // listViewRubro
            // 
            this.listViewRubro.HideSelection = false;
            this.listViewRubro.Location = new System.Drawing.Point(34, 38);
            this.listViewRubro.Margin = new System.Windows.Forms.Padding(4);
            this.listViewRubro.Name = "listViewRubro";
            this.listViewRubro.Size = new System.Drawing.Size(516, 327);
            this.listViewRubro.TabIndex = 20;
            this.listViewRubro.UseCompatibleStateImageBehavior = false;
            this.listViewRubro.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewRubro_ItemSelectionChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(467, 368);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 29);
            this.btnEliminar.TabIndex = 26;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmRubro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 450);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.listViewRubro);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtRubro);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmRubro";
            this.Text = "Rubro";
            this.Load += new System.EventHandler(this.frmRubro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtRubro;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ListView listViewRubro;
        private System.Windows.Forms.Button btnEliminar;
    }
}