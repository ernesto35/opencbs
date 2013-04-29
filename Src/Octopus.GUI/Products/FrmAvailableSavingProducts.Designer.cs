﻿using System.ComponentModel;
using System.Windows.Forms;
using Octopus.GUI.UserControl;

namespace Octopus.GUI.Products
{
    public partial class FrmAvailableSavingProducts
    {
        private SweetButton buttonDeleteProduct;
        private SweetButton buttonAddProduct;

        private GroupBox groupBox1;
        private Panel pnlSavingsProducts;
        private CheckBox checkBoxShowDeletedProduct;
        private SweetButton buttonEditProduct;
        private WebBrowser webBrowserPackage;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAvailableSavingProducts));
            this.webBrowserPackage = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEditProduct = new Octopus.GUI.UserControl.SweetButton();
            this.checkBoxShowDeletedProduct = new System.Windows.Forms.CheckBox();
            this.buttonAddProduct = new Octopus.GUI.UserControl.SweetButton();
            this.buttonDeleteProduct = new Octopus.GUI.UserControl.SweetButton();
            this.pnlSavingsProducts = new System.Windows.Forms.Panel();
            this.menuBtnAddProduct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.savingBookProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.pnlSavingsProducts.SuspendLayout();
            this.menuBtnAddProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserPackage
            // 
            resources.ApplyResources(this.webBrowserPackage, "webBrowserPackage");
            this.webBrowserPackage.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPackage.Name = "webBrowserPackage";
            this.webBrowserPackage.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserPackage_DocumentCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Octopus.GUI.Properties.Resources.theme1_1_fond_gris_180;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.buttonEditProduct);
            this.groupBox1.Controls.Add(this.checkBoxShowDeletedProduct);
            this.groupBox1.Controls.Add(this.buttonAddProduct);
            this.groupBox1.Controls.Add(this.buttonDeleteProduct);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // buttonEditProduct
            // 
            resources.ApplyResources(this.buttonEditProduct, "buttonEditProduct");
            this.buttonEditProduct.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonEditProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonEditProduct.Icon = Octopus.GUI.UserControl.SweetButton.ButtonIcon.None;
            this.buttonEditProduct.Image = global::Octopus.GUI.Properties.Resources.theme1_1_bouton_validity;
            this.buttonEditProduct.Menu = null;
            this.buttonEditProduct.Name = "buttonEditProduct";
            this.buttonEditProduct.UseVisualStyleBackColor = false;
            this.buttonEditProduct.Click += new System.EventHandler(this.buttonEditProduct_Click);
            // 
            // checkBoxShowDeletedProduct
            // 
            resources.ApplyResources(this.checkBoxShowDeletedProduct, "checkBoxShowDeletedProduct");
            this.checkBoxShowDeletedProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.checkBoxShowDeletedProduct.Name = "checkBoxShowDeletedProduct";
            this.checkBoxShowDeletedProduct.UseVisualStyleBackColor = true;
            this.checkBoxShowDeletedProduct.CheckedChanged += new System.EventHandler(this.checkBoxShowDeletedProduct_CheckedChanged);
            // 
            // buttonAddProduct
            // 
            resources.ApplyResources(this.buttonAddProduct, "buttonAddProduct");
            this.buttonAddProduct.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonAddProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonAddProduct.Icon = Octopus.GUI.UserControl.SweetButton.ButtonIcon.New;
            this.buttonAddProduct.Image = global::Octopus.GUI.Properties.Resources.theme1_1_bouton_new;
            this.buttonAddProduct.Menu = null;
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.UseVisualStyleBackColor = false;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddPackage_Click);
            // 
            // buttonDeleteProduct
            // 
            resources.ApplyResources(this.buttonDeleteProduct, "buttonDeleteProduct");
            this.buttonDeleteProduct.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonDeleteProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonDeleteProduct.Icon = Octopus.GUI.UserControl.SweetButton.ButtonIcon.Delete;
            this.buttonDeleteProduct.Image = global::Octopus.GUI.Properties.Resources.theme1_1_bouton_delete;
            this.buttonDeleteProduct.Menu = null;
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.UseVisualStyleBackColor = false;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeletePackage_Click);
            // 
            // pnlSavingsProducts
            // 
            this.pnlSavingsProducts.Controls.Add(this.webBrowserPackage);
            this.pnlSavingsProducts.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.pnlSavingsProducts, "pnlSavingsProducts");
            this.pnlSavingsProducts.Name = "pnlSavingsProducts";
            // 
            // menuBtnAddProduct
            // 
            this.menuBtnAddProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savingBookProductToolStripMenuItem});
            this.menuBtnAddProduct.Name = "contextMenuStrip1";
            resources.ApplyResources(this.menuBtnAddProduct, "menuBtnAddProduct");
            // 
            // savingBookProductToolStripMenuItem
            // 
            this.savingBookProductToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.savingBookProductToolStripMenuItem.Name = "savingBookProductToolStripMenuItem";
            resources.ApplyResources(this.savingBookProductToolStripMenuItem, "savingBookProductToolStripMenuItem");
            this.savingBookProductToolStripMenuItem.Click += new System.EventHandler(this.savingBookProductToolStripMenuItem_Click);
            // 
            // FrmAvailableSavingProducts
            // 
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlSavingsProducts);
            this.Name = "FrmAvailableSavingProducts";
            this.Load += new System.EventHandler(this.PackagesForm_Load);
            this.Controls.SetChildIndex(this.pnlSavingsProducts, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlSavingsProducts.ResumeLayout(false);
            this.menuBtnAddProduct.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private IContainer components;
        private ContextMenuStrip menuBtnAddProduct;
        private ToolStripMenuItem savingBookProductToolStripMenuItem;
    }
}