namespace Subject_index
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(519, 12);
            button1.Name = "button1";
            button1.Size = new Size(157, 43);
            button1.TabIndex = 2;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 3;
            label1.Text = "Слово";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(166, 27);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(242, 23);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 3;
            label2.Text = "Странницы";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(331, 20);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(182, 27);
            textBox2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(664, 256);
            dataGridView1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(16, 366);
            button2.Name = "button2";
            button2.Size = new Size(157, 51);
            button2.TabIndex = 6;
            button2.Text = "Загрузить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(179, 366);
            button3.Name = "button3";
            button3.Size = new Size(157, 51);
            button3.TabIndex = 7;
            button3.Text = "Печать";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(342, 366);
            button4.Name = "button4";
            button4.Size = new Size(157, 51);
            button4.TabIndex = 7;
            button4.Text = "Сохранить для редактирования";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 326);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 3;
            label3.Text = "Найти слово: ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(122, 323);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(289, 27);
            textBox3.TabIndex = 4;
            // 
            // button5
            // 
            button5.Location = new Point(505, 366);
            button5.Name = "button5";
            button5.Size = new Size(157, 51);
            button5.TabIndex = 7;
            button5.Text = "Обновить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(342, 423);
            button6.Name = "button6";
            button6.Size = new Size(157, 51);
            button6.TabIndex = 7;
            button6.Text = "Сохранить для документа";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button4_Click;
            // 
            // button7
            // 
            button7.Location = new Point(179, 424);
            button7.Name = "button7";
            button7.Size = new Size(157, 51);
            button7.TabIndex = 7;
            button7.Text = "Удалить слово";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button5_Click;
            // 
            // button8
            // 
            button8.Location = new Point(179, 481);
            button8.Name = "button8";
            button8.Size = new Size(157, 51);
            button8.TabIndex = 7;
            button8.Text = "Удалить страницу";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 704);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Пердметный указатель";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label3;
        private TextBox textBox3;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}
