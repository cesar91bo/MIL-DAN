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
            this.listViewRubro = new System.Windows.Forms.ListView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewRubro
            // 
            this.listViewRubro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewRubro.HideSelection = false;
            this.listViewRubro.Location = new System.Drawing.Point(34, 38);
            this.listViewRubro.Margin = new System.Windows.Forms.Padding(4);
            this.listViewRubro.Name = "listViewRubro";
            this.listViewRubro.Size = new System.Drawing.Size(492, 327);
            this.listViewRubro.TabIndex = 24;
            this.listViewRubro.UseCompatibleStateImageBehavior = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(443, 377);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(83, 29);
            this.btnNuevo.TabIndex = 23;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
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
            // txtRubro
            // 
            this.txtRubro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRubro.Location = new System.Drawing.Point(104, 382);
            this.txtRubro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(331, 22);
            this.txtRubro.TabIndex = 21;
            // 
            // frmUMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 450);
            this.Controls.Add(this.listViewRubro);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtRubro);
            this.Name = "frmUMedida";
            this.Text = "frmUMedida";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewRubro;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtRubro;
    }
}