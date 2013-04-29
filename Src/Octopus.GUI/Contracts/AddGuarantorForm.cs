//Octopus MFS is an integrated suite for managing a Micro Finance Institution: clients, contracts, accounting, reporting and risk
//Copyright © 2006,2007 OCTO Technology & OXUS Development Network
//
//This program is free software; you can redistribute it and/or modify
//it under the terms of the GNU Lesser General Public License as published by
//the Free Software Foundation; either version 2 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU Lesser General Public License for more details.
//
//You should have received a copy of the GNU Lesser General Public License along
//with this program; if not, write to the Free Software Foundation, Inc.,
//51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
//
// Licence : http://www.octopusnetwork.org/OverviewLicence.aspx
//
// Website : http://www.octopusnetwork.org
// Business contact: business(at)octopusnetwork.org
// Technical contact email : tech(at)octopusnetwork.org 

using System;
using System.ComponentModel;
using System.Windows.Forms;
using Octopus.CoreDomain.Accounting;
using Octopus.CoreDomain.Clients;
using Octopus.Enums;
using Octopus.ExceptionsHandler;
using Octopus.GUI.Accounting;
using Octopus.GUI.Clients;
using Octopus.Services;
using Octopus.GUI.UserControl;
using Octopus.Services.Accounting;
using Octopus.Services.Currencies;
using Octopus.Shared;

namespace Octopus.GUI
{
    public class AddGuarantorForm : SweetBaseForm
    {
        private GroupBox groupBoxName;
        private Label labelNameOfLeader;
        private TextBox textBoxName;
        private SweetButton buttonAddMembres;
        private SweetButton buttonSelectAMember;
        private Label labelAmount;
        private SweetButton buttonCancel;
        private SweetButton buttonSave;
        private Guarantor _guarantor;
        private readonly Form _mdiParent;
        private TextBox textBoxDesc;
        private Label labelDesc;
        private GroupBox groupBoxAmount;
        private NumericUpDown nudAmount;
        private const Container components = null;
        private Currency code;

        public AddGuarantorForm(Form pMdiParent, Currency tcode)
        {
            _mdiParent = pMdiParent;
            _guarantor = new Guarantor();
            _guarantor.Amount = 0;
            code = tcode;
            Initialization();
        }

        public AddGuarantorForm(Guarantor guarantor, Form pMdiParent, bool isView, Currency tcode)
        {
            _mdiParent = pMdiParent;
            _guarantor = guarantor;
            code = tcode;

            Initialization();
            InitializeGuarantor();

            if (isView)
            {
                groupBoxName.Enabled = false;
                groupBoxAmount.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        private void Initialization()
        {
            InitializeComponent();
            nudAmount.Minimum = 0;
            nudAmount.Maximum = decimal.MaxValue;
        }

        private void InitializeGuarantor()
        {
            buttonAddMembres.Enabled = false;
            buttonSelectAMember.Enabled = false;
            textBoxName.Text = _guarantor.Tiers.Name;
            nudAmount.Value = _guarantor.Amount.Value;
            textBoxDesc.Text = _guarantor.Description;
        }

        public Guarantor Guarantor
        {
            get { return _guarantor; }
        }

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGuarantorForm));
            this.groupBoxAmount = new System.Windows.Forms.GroupBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.labelNameOfLeader = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonAddMembres = new Octopus.GUI.UserControl.SweetButton();
            this.buttonSelectAMember = new Octopus.GUI.UserControl.SweetButton();
            this.buttonCancel = new Octopus.GUI.UserControl.SweetButton();
            this.buttonSave = new Octopus.GUI.UserControl.SweetButton();
            this.groupBoxAmount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.groupBoxName.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAmount
            // 
            this.groupBoxAmount.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxAmount.Controls.Add(this.nudAmount);
            this.groupBoxAmount.Controls.Add(this.textBoxDesc);
            this.groupBoxAmount.Controls.Add(this.labelAmount);
            this.groupBoxAmount.Controls.Add(this.labelDesc);
            resources.ApplyResources(this.groupBoxAmount, "groupBoxAmount");
            this.groupBoxAmount.Name = "groupBoxAmount";
            this.groupBoxAmount.TabStop = false;
            // 
            // nudAmount
            // 
            resources.ApplyResources(this.nudAmount, "nudAmount");
            this.nudAmount.Name = "nudAmount";
            // 
            // textBoxDesc
            // 
            resources.ApplyResources(this.textBoxDesc, "textBoxDesc");
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.TextChanged += new System.EventHandler(this.textBoxDesc_TextChanged);
            // 
            // labelAmount
            // 
            resources.ApplyResources(this.labelAmount, "labelAmount");
            this.labelAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.labelAmount.Name = "labelAmount";
            // 
            // labelDesc
            // 
            resources.ApplyResources(this.labelDesc, "labelDesc");
            this.labelDesc.BackColor = System.Drawing.Color.Transparent;
            this.labelDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.labelDesc.Name = "labelDesc";
            // 
            // groupBoxName
            // 
            this.groupBoxName.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxName.Controls.Add(this.labelNameOfLeader);
            this.groupBoxName.Controls.Add(this.textBoxName);
            this.groupBoxName.Controls.Add(this.buttonAddMembres);
            this.groupBoxName.Controls.Add(this.buttonSelectAMember);
            resources.ApplyResources(this.groupBoxName, "groupBoxName");
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.TabStop = false;
            // 
            // labelNameOfLeader
            // 
            resources.ApplyResources(this.labelNameOfLeader, "labelNameOfLeader");
            this.labelNameOfLeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.labelNameOfLeader.Name = "labelNameOfLeader";
            // 
            // textBoxName
            // 
            resources.ApplyResources(this.textBoxName, "textBoxName");
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            // 
            // buttonAddMembres
            // 
            this.buttonAddMembres.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.buttonAddMembres, "buttonAddMembres");
            this.buttonAddMembres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonAddMembres.Icon = Octopus.GUI.UserControl.SweetButton.ButtonIcon.New;
            this.buttonAddMembres.Menu = null;
            this.buttonAddMembres.Name = "buttonAddMembres";
            this.buttonAddMembres.UseVisualStyleBackColor = false;
            this.buttonAddMembres.Click += new System.EventHandler(this.buttonAddMembres_Click);
            // 
            // buttonSelectAMember
            // 
            this.buttonSelectAMember.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.buttonSelectAMember, "buttonSelectAMember");
            this.buttonSelectAMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonSelectAMember.Icon = Octopus.GUI.UserControl.SweetButton.ButtonIcon.Search;
            this.buttonSelectAMember.Menu = null;
            this.buttonSelectAMember.Name = "buttonSelectAMember";
            this.buttonSelectAMember.UseVisualStyleBackColor = false;
            this.buttonSelectAMember.Click += new System.EventHandler(this.buttonSelectAMember_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonCancel.Icon = Octopus.GUI.UserControl.SweetButton.ButtonIcon.Close;
            this.buttonCancel.Menu = null;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonSave.Icon = Octopus.GUI.UserControl.SweetButton.ButtonIcon.Save;
            this.buttonSave.Menu = null;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // AddGuarantorForm
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxAmount);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxName);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddGuarantorForm";
            this.groupBoxAmount.ResumeLayout(false);
            this.groupBoxAmount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.groupBoxName.ResumeLayout(false);
            this.groupBoxName.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

        private void buttonAddMembres_Click(object sender, EventArgs e)
        {
            AddAGuarantor();
        }

        private void AddAGuarantor()
        {
            var personForm = new ClientForm(OClientTypes.Person, _mdiParent, true);
            personForm.ShowDialog();
            _guarantor.Tiers = personForm.Person;

            try
            {
                textBoxName.Text = ServicesProvider.GetInstance().GetClientServices().ClientIsAPerson(_guarantor.Tiers) 
                    ? _guarantor.Tiers.Name : String.Empty;
            }
            catch (Exception ex)
            {
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void SelectAGuarantor()
        {
            using (SearchClientForm searchClientForm = SearchClientForm.GetInstance(OClientTypes.Person, false))
            {
                searchClientForm.ShowDialog();
                _guarantor.Tiers = searchClientForm.Client;

                try
                {
                    if (ServicesProvider.GetInstance().GetClientServices().ClientIsAPerson(_guarantor.Tiers))
                    {
                        ServicesProvider.GetInstance().GetClientServices().ClientsNumberGuarantee(_guarantor.Tiers);
                        textBoxName.Text = _guarantor.Tiers.Name;
                    }
                    else
                        textBoxName.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
                }
            }
        }

        private void buttonSelectAMember_Click(object sender, EventArgs e)
        {
            SelectAGuarantor();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _guarantor = null;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _guarantor.Amount = nudAmount.Value;
            if (textBoxName.Text == String.Empty)
            {
                Fail("GuarantorNameIsNull");
                return;
            }
            if (_guarantor.Amount == 0 || string.IsNullOrEmpty(nudAmount.Text))
            {
                Fail("AmountIsNull");
                return;
            }

            if (MaxAmountExceed())
            {
                MaxAmountExceedMessage();
                return;
            }
            Close();
        }

        private void MaxAmountExceedMessage()
        {
            string caption = GetString("SweetBaseForm", "error");
            string errorMessage = GetString("GuarantorMaxAmount.Text") + " " +
                                  ServicesProvider.GetInstance().GetGeneralSettings().MaxGuarantorAmount.ToString() + " " +
                                  ServicesProvider.GetInstance().GetCurrencyServices().GetPivot().Code;
            MessageBox.Show(errorMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool MaxAmountExceed()
        {
            OCurrency maxGuarantorAmount = ServicesProvider.GetInstance().GetGeneralSettings().MaxGuarantorAmount;
            OCurrency tempAmount;
            if (code.IsPivot) tempAmount = _guarantor.Amount;
            else
            {
                ExchangeRateServices rateServices = ServicesProvider.GetInstance().GetExchangeRateServices();
                ExchangeRate currentRate = rateServices.SelectExchangeRate(TimeProvider.Now, code);
                if (currentRate == null)
                {
                    ExchangeRateForm xrForm = new ExchangeRateForm(TimeProvider.Now.Date, code);
                    xrForm.ShowDialog();
                    currentRate = xrForm.ExchangeRate;
                }
                tempAmount = _guarantor.Amount/currentRate.Rate;
            }

            if (tempAmount > maxGuarantorAmount)
                return true;
            return false;
        }

        private void textBoxDesc_TextChanged(object sender, EventArgs e)
        {
            _guarantor.Description = textBoxDesc.Text;
        }

    }
}