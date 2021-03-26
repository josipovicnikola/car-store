using CarClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarStoreGUI
{
    public partial class Form1 : Form
    {
        Store s = new Store();
        BindingSource carInventoryBindingSource = new BindingSource();
        BindingSource cartBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_create_car_Click(object sender, EventArgs e)
        {
            decimal price = 0.00M;
            if(decimal.TryParse(txt_price.Text,out price)){
                Car c = new Car(txt_make.Text, txt_model.Text, price);

                s.CarList.Add(c);
                carInventoryBindingSource.ResetBindings(false);

                txt_make.Clear();
                txt_model.Clear();
                txt_price.Clear();
            } else
            {
                MessageBox.Show("Price must be number.");
            }

        }

        private void btn_add_to_cart_Click(object sender, EventArgs e)
        {
            int selectedIndex = lst_inventory.SelectedIndex;
            Car selectedCar = s.CarList[selectedIndex];

            s.ShoppingList.Add(selectedCar);
            cartBindingSource.ResetBindings(false);

        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            decimal totalPrice = s.Checkout();

            lbl_total.Text = "$" + totalPrice.ToString();

            cartBindingSource.ResetBindings(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carInventoryBindingSource.DataSource = s.CarList;
            cartBindingSource.DataSource = s.ShoppingList;

            lst_inventory.DataSource = carInventoryBindingSource;
            lst_inventory.DisplayMember = ToString();

            lst_cart.DataSource = cartBindingSource;
            lst_cart.DisplayMember = ToString();
        }

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
