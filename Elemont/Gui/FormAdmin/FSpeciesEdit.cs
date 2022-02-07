using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elemont.Dao;
using Elemont.Dto;

namespace Elemont.Gui.FormAdmin
{
    public partial class FSpeciesEdit : Form
    {
        public Species species;
        public FSpeciesEdit()
        {
            InitializeComponent();
            loadData();
            loadNull();
        }
        public void loadNull()
        {
            elementBox.SelectedIndex = -1;
            nameTxt.Text = "";
            attackTxt.Text = "";
            defenseTxt.Text = "";
            hptxt.Text = "";
            speciesIdTxt.Text = "";
            comboBox1.SelectedIndex = -1;
        }
        public void loadData()
        {
            speciesGridView.DataSource = SpeciesDao.Instance.GetAllSpecies().Select(
                item => new
                {
                    Id = item.SpeciesId,
                    Name = item.Name,
                    Element = item.Element.Name,
                    BaseAttack = item.BaseAttack,
                    BaseDefense = item.BaseDefense,
                    BaseHp = item.BaseHp
                }
                ).ToArray();

            elementBox.DataSource = ElementDao.Instance.GetAllElements();
            elementBox.DisplayMember = "Name";
            elementBox.ValueMember = "ElementId";

        }
        public void loadSpecies()
        {
            nameTxt.Text = species.Name;
            elementBox.SelectedValue = species.Element.ElementId;
            attackTxt.Text = species.BaseAttack.ToString();
            defenseTxt.Text = species.BaseDefense.ToString();
            hptxt.Text = species.BaseHp.ToString();
            speciesIdTxt.Text = species.SpeciesId.ToString();
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FSpeciesEdit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                species = SpeciesDao.Instance.GetSpeciesById(
                    Convert.ToInt32(speciesGridView.Rows[e.RowIndex].Cells[0].Value));
                loadSpecies();
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (speciesIdTxt.Text != "")
            {
                species = new Species(nameTxt.Text, "", Convert.ToInt32(attackTxt.Text),
                Convert.ToInt32(defenseTxt.Text), Convert.ToInt32(hptxt.Text),
                (Element)elementBox.SelectedItem, Convert.ToInt32(speciesIdTxt.Text));
                if (SpeciesDao.Instance.ChangeSpecies(species))
                {

                }
            }
            else
            {
                species = new Species(nameTxt.Text, "", Convert.ToInt32(attackTxt.Text),
                Convert.ToInt32(defenseTxt.Text), Convert.ToInt32(hptxt.Text),
                (Element)elementBox.SelectedItem);
                if (SpeciesDao.Instance.AddSpecies(species))
                {

                }
            }
            loadData();
            loadNull();
        }

        private void attackTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void defenseTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void hptxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (speciesIdTxt.Text != "")
            {
                if (SpeciesDao.Instance.RemoveSpeciesById(Convert.ToInt32(speciesIdTxt.Text)))
                {

                }
            }
            loadData();
            loadNull();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
