using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dateTimePickerTransaction;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelTransaction;

        private void InitializeComponent()
        {
            this.panelTransaction = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dateTimePickerTransaction = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panelTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTransaction
            // 
            this.panelTransaction.BackColor = System.Drawing.Color.AliceBlue;
            this.panelTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTransaction.Controls.Add(this.btnSave);
            this.panelTransaction.Controls.Add(this.comboBoxType);
            this.panelTransaction.Controls.Add(this.btnClear);
            this.panelTransaction.Controls.Add(this.txtDescription);
            this.panelTransaction.Controls.Add(this.txtAmount);
            this.panelTransaction.Controls.Add(this.dateTimePickerTransaction);
            this.panelTransaction.Controls.Add(this.txtID);
            this.panelTransaction.Location = new System.Drawing.Point(30, 20);
            this.panelTransaction.Name = "panelTransaction";
            this.panelTransaction.Size = new System.Drawing.Size(434, 290);
            this.panelTransaction.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(30, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Arial", 10F);
            this.comboBoxType.Items.AddRange(new object[] {
            "Доход",
            "Расход"});
            this.comboBoxType.Location = new System.Drawing.Point(30, 30);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(200, 27);
            this.comboBoxType.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.OrangeRed;
            this.btnClear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(149, 223);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtDescription.Location = new System.Drawing.Point(30, 70);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 27);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "Введите описание";
            this.txtDescription.Enter += new System.EventHandler(this.TxtDescription_Enter);
            this.txtDescription.Leave += new System.EventHandler(this.TxtDescription_Leave);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAmount.ForeColor = System.Drawing.Color.Gray;
            this.txtAmount.Location = new System.Drawing.Point(30, 110);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 27);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "Введите сумму";
            this.txtAmount.Enter += new System.EventHandler(this.TxtAmount_Enter);
            this.txtAmount.Leave += new System.EventHandler(this.TxtAmount_Leave);
            // 
            // dateTimePickerTransaction
            // 
            this.dateTimePickerTransaction.Font = new System.Drawing.Font("Arial", 10F);
            this.dateTimePickerTransaction.Location = new System.Drawing.Point(30, 150);
            this.dateTimePickerTransaction.Name = "dateTimePickerTransaction";
            this.dateTimePickerTransaction.Size = new System.Drawing.Size(289, 27);
            this.dateTimePickerTransaction.TabIndex = 4;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Arial", 10F);
            this.txtID.ForeColor = System.Drawing.Color.Gray;
            this.txtID.Location = new System.Drawing.Point(30, 190);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(200, 27);
            this.txtID.TabIndex = 5;
            this.txtID.Text = "ID транзакции";
            this.txtID.Enter += new System.EventHandler(this.TxtID_Enter);
            this.txtID.Leave += new System.EventHandler(this.TxtID_Leave);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelTransaction);
            this.Name = "Form1";
            this.Text = "Финансовый трекер";
            this.panelTransaction.ResumeLayout(false);
            this.panelTransaction.PerformLayout();
            this.ResumeLayout(false);

        }

        // Обработчики событий для текстовых полей
        private void TxtDescription_Enter(object sender, System.EventArgs e)
        {
            if (txtDescription.Text == "Введите описание")
            {
                txtDescription.Text = "";
                txtDescription.ForeColor = Color.Black;
            }
        }

        private void TxtDescription_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                txtDescription.Text = "Введите описание";
                txtDescription.ForeColor = Color.Gray;
            }
        }

        private void TxtAmount_Enter(object sender, System.EventArgs e)
        {
            if (txtAmount.Text == "Введите сумму")
            {
                txtAmount.Text = "";
                txtAmount.ForeColor = Color.Black;
            }
        }

        private void TxtAmount_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                txtAmount.Text = "Введите сумму";
                txtAmount.ForeColor = Color.Gray;
            }
        }

        private void TxtID_Enter(object sender, System.EventArgs e)
        {
            if (txtID.Text == "ID транзакции")
            {
                txtID.Text = "";
                txtID.ForeColor = Color.Black;
            }
        }

        private void TxtID_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                txtID.Text = "ID транзакции";
                txtID.ForeColor = Color.Gray;
            }
        }
    }
}
