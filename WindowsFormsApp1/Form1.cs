using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Заполнение ComboBox типами транзакций (Income/Expense)
            comboBoxType.Items.Add("Income");
            comboBoxType.Items.Add("Expense");
            comboBoxType.SelectedIndex = 0; // По умолчанию выбирается первый элемент

            // Установка начальных текстов для текстовых полей
            SetPlaceholderText();
        }

        private void SetPlaceholderText()
        {
            txtDescription.Text = "Введите описание...";
            txtDescription.ForeColor = Color.Gray;

            txtAmount.Text = "Введите сумму...";
            txtAmount.ForeColor = Color.Gray;

            txtID.Text = "Введите ID...";
            txtID.ForeColor = Color.Gray;

            // Добавление обработчиков событий
            txtDescription.Enter += txtDescription_Enter;
            txtDescription.Leave += txtDescription_Leave;

            txtAmount.Enter += txtAmount_Enter;
            txtAmount.Leave += txtAmount_Leave;

            txtID.Enter += txtID_Enter;
            txtID.Leave += txtID_Leave;
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            string type = comboBoxType.SelectedItem.ToString();
            string description = txtDescription.Text;
            decimal amount;

            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Пожалуйста, введите правильную сумму.");
                return;
            }

            DateTime date = dateTimePickerTransaction.Value;

            try
            {
                dataBase.OpenConnection();
                using (SqlCommand command = new SqlCommand("INSERT INTO fin_ce (transaction_type, description, amount, transaction_date) VALUES (@type, @description, @amount, @date)", dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.Add("@amount", SqlDbType.Decimal).Value = amount;
                    command.Parameters.AddWithValue("@date", date);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Транзакция успешно добавлена!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении транзакции: " + ex.Message);
            }
            finally
            {
                dataBase.CloseConnection();
            }
        }

        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtID.Text, out id))
            {
                string type = comboBoxType.SelectedItem.ToString();
                string description = txtDescription.Text;
                decimal amount;

                if (!decimal.TryParse(txtAmount.Text, out amount))
                {
                    MessageBox.Show("Пожалуйста, введите правильную сумму.");
                    return;
                }

                DateTime date = dateTimePickerTransaction.Value;

                try
                {
                    dataBase.OpenConnection();
                    using (SqlCommand command = new SqlCommand("UPDATE fin_ce SET transaction_type = @type, description = @description, amount = @amount, transaction_date = @date WHERE id = @id", dataBase.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.Add("@amount", SqlDbType.Decimal).Value = amount;
                        command.Parameters.AddWithValue("@date", date);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Транзакция успешно обновлена!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении транзакции: " + ex.Message);
                }
                finally
                {
                    dataBase.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите правильный ID транзакции.");
            }
        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtID.Text, out id))
            {
                try
                {
                    dataBase.OpenConnection();
                    using (SqlCommand command = new SqlCommand("DELETE FROM fin_ce WHERE id = @id", dataBase.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Транзакция успешно удалена!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении транзакции: " + ex.Message);
                }
                finally
                {
                    dataBase.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите правильный ID транзакции.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(txtDescription.Text) ||
                string.IsNullOrEmpty(txtAmount.Text) ||
                string.IsNullOrEmpty(txtID.Text) ||
                comboBoxType.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем значения из полей ввода
            string transactionType = comboBoxType.SelectedItem.ToString();
            string description = txtDescription.Text;
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Введите корректную сумму.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime transactionDate = dateTimePickerTransaction.Value;
            int id = int.Parse(txtID.Text);

            try
            {
                dataBase.OpenConnection();
                using (SqlCommand command = new SqlCommand("INSERT INTO fin_ce (transaction_type, description, amount, transaction_date) VALUES (@type, @description, @amount, @date)", dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@type", transactionType);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.Add("@amount", SqlDbType.Decimal).Value = amount;
                    command.Parameters.AddWithValue("@date", transactionDate);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении записи: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.CloseConnection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtDescription.Clear();
            txtAmount.Clear();
            comboBoxType.SelectedIndex = -1; // Сбрасываем выбор в ComboBox
            dateTimePickerTransaction.Value = DateTime.Now; // Сбрасываем дату на текущую

            SetPlaceholderText();
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            if (txtDescription.Text == "Введите описание...")
            {
                txtDescription.Text = "";
                txtDescription.ForeColor = Color.Black;
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                txtDescription.Text = "Введите описание...";
                txtDescription.ForeColor = Color.Gray;
            }
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            if (txtAmount.Text == "Введите сумму...")
            {
                txtAmount.Text = "";
                txtAmount.ForeColor = Color.Black;
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                txtAmount.Text = "Введите сумму...";
                txtAmount.ForeColor = Color.Gray;
            }
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            if (txtID.Text == "Введите ID...")
            {
                txtID.Text = "";
                txtID.ForeColor = Color.Black;
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                txtID.Text = "Введите ID...";
                txtID.ForeColor = Color.Gray;
            }
        }
    }
}

