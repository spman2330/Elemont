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
    public partial class fSkillEdit : Form
    {
        public fSkillEdit()
        {
            InitializeComponent();
            loadData();
            loadNull();
        }
        public void loadData()
        {
            skillGridView.DataSource = SkillDao.Instance.GetAllSkill().Select(
                item => new
                {
                    Id = item.SkillId,
                    Name = item.Name,
                    Type = item.Type,
                    Num = item.Num,
                    ManaCost = item.ManaCost
                }
                ).ToArray();
        }
        public void loadNull()
        {
            nameTxt.Text = "";
            typeTxt.Text = "";
            numTxt.Text = "";
            idTxt.Text = "";
            manaTxt.Text = "";
        }

        private void skillGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void manaTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void numTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void skillGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                loadNull();
                Skill skill = SkillDao.Instance.GetskillById(Convert.ToInt32
                    (skillGridView.Rows[e.RowIndex].Cells[0].Value));
                nameTxt.Text = skill.Name;
                typeTxt.Text = skill.Type;
                numTxt.Text = skill.Num.ToString();
                manaTxt.Text = skill.ManaCost.ToString();
                idTxt.Text = skill.SkillId.ToString();
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (idTxt.Text != "")
            {
                Skill skill = new Skill(nameTxt.Text, typeTxt.Text
                    , Convert.ToInt32(numTxt.Text), Convert.ToInt32(manaTxt.Text),
                    Convert.ToInt32(idTxt.Text));
                if (!SkillDao.Instance.ChangeSkill(skill))
                {

                }
            }
            else
            {
                Skill skill = new Skill(nameTxt.Text, typeTxt.Text
                   , Convert.ToInt32(numTxt.Text), Convert.ToInt32(manaTxt.Text));
                if (!SkillDao.Instance.AddSkill(skill))
                {

                }
            }
            loadData();
            loadNull();
        }
    }
}
