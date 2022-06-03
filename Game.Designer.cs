using NewGame.Entities;
using System.Drawing;
using System.Drawing.Text;

namespace NewGame
{
    partial class Game
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.movingTimer = new System.Windows.Forms.Timer(this.components);
            this.fish = new System.Windows.Forms.Label();
            this.money = new System.Windows.Forms.Label();
            this.strRod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fish
            // 
            resources.ApplyResources(this.fish, "fish");
            this.fish.BackColor = System.Drawing.Color.Transparent;
            this.fish.Name = "fish";
            // 
            // money
            // 
            resources.ApplyResources(this.money, "money");
            this.money.BackColor = System.Drawing.Color.Transparent;
            this.money.Name = "money";
            // 
            // strRod
            // 
            resources.ApplyResources(this.strRod, "strRod");
            this.strRod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.strRod.Name = "strRod";
            // 
            // Game
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::NewGame.Resource1.background;
            this.Controls.Add(this.strRod);
            this.Controls.Add(this.money);
            this.Controls.Add(this.fish);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "Game";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer movingTimer;
        private System.Windows.Forms.Label fish;
        private System.Windows.Forms.Label money;
        private System.Windows.Forms.Label strRod;
    }
}

