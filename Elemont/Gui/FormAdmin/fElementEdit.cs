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

namespace Elemont.Gui.GameManager
{
    public partial class fElementEdit : Form
    {
        public fElementEdit()
        {
            InitializeComponent();
            loadData();
            loadNull();
        }
        public void loadData()
        {
            ElementGridView.DataSource = ElementDao.Instance.GetAllElements().Select(
                item => new
                {
                    Id = item.ElementId,
                    Name = item.Name,
                    Environment = item.Environment
                }
                ).ToArray();
            WeakTxt.Items.Clear();
            WeakTxt.Items.AddRange(ElementDao.Instance.GetAllElements());
            WeakTxt.DisplayMember = "Name";
            WeakTxt.ValueMember = "ElementId";
            StrongTxt.Items.Clear();
            StrongTxt.Items.AddRange(ElementDao.Instance.GetAllElements());
            StrongTxt.DisplayMember = "Name";
            StrongTxt.ValueMember = "ElementId";
            String[] myArray = { "Jungle", "Swamp", "Snow", "Desert" };
            envirBox.DataSource = myArray;


        }
        public void loadNull()
        {
            IdTxt.Text = "";
            nameTxt.Text = "";
            envirBox.SelectedIndex = -1;
            for (int i = 0; i < WeakTxt.Items.Count; i++)
            {
                WeakTxt.SetItemChecked(i, false);
            }
            for (int i = 0; i < StrongTxt.Items.Count; i++)
            {
                StrongTxt.SetItemChecked(i, false);
            }
        }
        private void fElementEdit_Load(object sender, EventArgs e)
        {

        }

        private void ElementGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                loadNull();
                Element element = ElementDao.Instance.GetElementById(Convert.ToInt32(ElementGridView.Rows[e.RowIndex].Cells[0].Value));
                IdTxt.Text = element.ElementId.ToString();
                nameTxt.Text = element.Name;
                envirBox.SelectedItem = element.Environment;
                for (int i = 0; i < WeakTxt.Items.Count; i++)
                {
                    if (element.Weak.Contains((WeakTxt.Items[i] as Element).ElementId))
                    {
                        WeakTxt.SetItemChecked(i, true);
                    }
                }
                for (int i = 0; i < StrongTxt.Items.Count; i++)
                {
                    if (element.Strong.Contains((StrongTxt.Items[i] as Element).ElementId))
                    {
                        StrongTxt.SetItemChecked(i, true);
                    }
                }
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (envirBox.SelectedIndex != -1)
            {
                if (IdTxt.Text == "")
                {
                    int[] weak = WeakTxt.CheckedItems.OfType<Element>().ToArray().Select(
                        item => item.ElementId).ToArray();
                    int[] strong = StrongTxt.CheckedItems.OfType<Element>().ToArray().Select(
                        item => item.ElementId).ToArray();
                    Element element = new Element(nameTxt.Text, envirBox.SelectedItem.ToString()
                        , weak, strong);
                    if (!ElementDao.Instance.AddElement(element))
                    {

                    }
                }
                else
                {
                    int[] weak = WeakTxt.CheckedItems.OfType<Element>().ToArray().Select(
                       item => item.ElementId).ToArray();
                    int[] strong = StrongTxt.CheckedItems.OfType<Element>().ToArray().Select(
                        item => item.ElementId).ToArray();
                    Element element = new Element(nameTxt.Text, envirBox.SelectedItem.ToString(), weak, strong,
                        Convert.ToInt32(IdTxt.Text));
                    if (!ElementDao.Instance.ChangeElement(element))
                    {

                    }
                }
            }
            loadData();
            loadNull();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IdTxt.Text != "")
            {
                if (!ElementDao.Instance.DeleteElement(Convert.ToInt32(IdTxt.Text)))
                {

                }
            }
            loadData();
            loadNull();
        }
    }
}
