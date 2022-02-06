using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Elemont.Dto
{
    public class Skin
    {
        private string avatar;
        private string left;
        private string right;
        private string up;
        private string down;
        private string name;
        private int skinId;

        public string Avatar { get => avatar; set => avatar = value; }
        public string Left { get => left; set => left = value; }
        public string Right { get => right; set => right = value; }
        public string Up { get => up; set => up = value; }
        public string Down { get => down; set => down = value; }
        public string Name { get => name; set => name = value; }
        public int SkinId { get => skinId; set => skinId = value; }
        public Skin(DataRow row)
        {
            Avatar = row["avatar"].ToString();
            Left = row["left"].ToString();
            Right = row["right"].ToString();
            Up = row["up"].ToString();
            Down = row["down"].ToString();
            Name = row["name"].ToString();
            SkinId = Convert.ToInt32(row["skinId"].ToString());
        }

        public Skin(string avatar, string left, string right, string up, string down, string name)
        {
            this.avatar = avatar;
            this.left = left;
            this.right = right;
            this.up = up;
            this.down = down;
            this.name = name;
        }
    }
}
