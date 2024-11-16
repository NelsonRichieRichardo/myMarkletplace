using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using myMarkletplace.Business_Logic;

namespace myMarkletplace
{
    public partial class Form1 : Form
    {
        private readonly BLProducts _blProducts;

        public Form1()
        {
            InitializeComponent();
            _blProducts = new BLProducts();
            LoadProducts();
            UpdateTotalValueLabel();
        }

        private void UpdateTotalValueLabel()
        {
            decimal totalValue = _blProducts.GetTotalInventoryValue();
            lblnilaibrg.Text = $"Total Nilai Barang: Rp {totalValue:N2}";
        }
        private void LoadProducts()
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _blProducts.GetAllProducts();
            UpdateTotalValueLabel();
        }

        private void ClearFields()
        {
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtProductStock.Clear();
            txtProductDescription.Clear();
            pictureBox1.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _blProducts.CreateProduct(
                    txtProductName.Text,
                    txtProductPrice.Text,
                    txtProductStock.Text,
                    txtProductDescription.Text,
                    pictureBox1.Image
                );

                MessageBox.Show("Product added successfully!");
                LoadProducts();
                ClearFields();
                UpdateTotalValueLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count != 0)
            {
                try
                {
                    int selectedProductId = (int)dgvProducts.SelectedRows[0].Cells["product_id"].Value;

                    _blProducts.UpdateProduct(
                        selectedProductId,
                        txtProductName.Text,
                        txtProductPrice.Text,
                        txtProductStock.Text,
                        txtProductDescription.Text,
                        pictureBox1.Image
                    );

                    MessageBox.Show("Product updated successfully!");
                    LoadProducts();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating product: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count != 0)
            {
                try
                {
                    int selectedProductId = (int)dgvProducts.SelectedRows[0].Cells["product_id"].Value;

                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this Product?",
                        "Delete Product",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        _blProducts.DeleteProduct(selectedProductId);
                        LoadProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting product: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Jika Anda ingin menampilkan data produk yang dipilih di form
            if (e.RowIndex >= 0)
            {
                var row = dgvProducts.Rows[e.RowIndex];
                txtProductName.Text = row.Cells["product_name"].Value.ToString();
                txtProductPrice.Text = row.Cells["product_price"].Value.ToString();
                txtProductStock.Text = row.Cells["product_stock"].Value.ToString();
                txtProductDescription.Text = row.Cells["product_description"].Value.ToString();

                if (row.Cells["product_image"].Value != null)
                {
                    byte[] imageBytes = (byte[])row.Cells["product_image"].Value;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading image: " + ex.Message);
            }
        }

        // Jika Anda ingin menampilkan timestamp
        private void DisplayTimestamps(DateTime createdAt, DateTime updatedAt)
        {
            string utcCreatedAt = _blProducts.FormatUtcTimestamp(createdAt);
            string utcUpdatedAt = _blProducts.FormatUtcTimestamp(updatedAt);

            // Asumsikan Anda memiliki label untuk menampilkan timestamp
            lblCreatedAt.Text = $"Created: {utcCreatedAt}";
            lblUpdatedAt.Text = $"Updated: {utcUpdatedAt}";
        }

        // Jika Anda ingin menampilkan timestamp dalam waktu lokal
        private void DisplayLocalTimestamps(DateTime createdAt, DateTime updatedAt)
        {
            string localCreatedAt = _blProducts.ConvertUtcToLocal(createdAt);
            string localUpdatedAt = _blProducts.ConvertUtcToLocal(updatedAt);

            lblCreatedAt.Text = $"Created: {localCreatedAt}";
            lblUpdatedAt.Text = $"Updated: {localUpdatedAt}";
        }

        // Optional: Handler untuk row selection di DataGridView
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dgvProducts.SelectedRows[0];

                // Mengisi form fields
                txtProductName.Text = selectedRow.Cells["product_name"].Value.ToString();
                txtProductPrice.Text = selectedRow.Cells["product_price"].Value.ToString();
                txtProductStock.Text = selectedRow.Cells["product_stock"].Value.ToString();
                txtProductDescription.Text = selectedRow.Cells["product_description"].Value.ToString();

                // Menampilkan gambar
                if (selectedRow.Cells["product_image"].Value != null)
                {
                    byte[] imageBytes = (byte[])selectedRow.Cells["product_image"].Value;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }

                // Menampilkan timestamp jika ada
                if (selectedRow.Cells["created_at"].Value != null &&
                    selectedRow.Cells["updated_at"].Value != null)
                {
                    DateTime createdAt = (DateTime)selectedRow.Cells["created_at"].Value;
                    DateTime updatedAt = (DateTime)selectedRow.Cells["updated_at"].Value;
                    DisplayTimestamps(createdAt, updatedAt);
                    // Atau gunakan DisplayLocalTimestamps(createdAt, updatedAt); untuk waktu lokal
                }
            }
        }
    }
}