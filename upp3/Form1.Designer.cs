namespace upp3
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
            btnAddTask = new Button();
            txtDescription = new TextBox();
            dtpDeadline = new DateTimePicker();
            cmbDayOfWeek = new ComboBox();
            lstTasks = new ListBox();
            btnDeleteTask = new Button();
            btnRefresh = new Button();
            cmbPriority = new ComboBox();
            SuspendLayout();
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(36, 27);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(200, 47);
            btnAddTask.TabIndex = 5;
            btnAddTask.Text = "Добавить задачу";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(36, 118);
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Введите название";
            txtDescription.Size = new Size(200, 30);
            txtDescription.TabIndex = 0;
            // 
            // dtpDeadline
            // 
            dtpDeadline.Location = new Point(36, 170);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.ShowCheckBox = true;
            dtpDeadline.Size = new Size(200, 30);
            dtpDeadline.TabIndex = 2;
            // 
            // cmbDayOfWeek
            // 
            cmbDayOfWeek.FormattingEnabled = true;
            cmbDayOfWeek.Location = new Point(36, 281);
            cmbDayOfWeek.Name = "cmbDayOfWeek";
            cmbDayOfWeek.Size = new Size(200, 31);
            cmbDayOfWeek.TabIndex = 3;
            // 
            // lstTasks
            // 
            lstTasks.ItemHeight = 23;
            lstTasks.Location = new Point(277, 124);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(742, 188);
            lstTasks.TabIndex = 8;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(277, 27);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(200, 47);
            btnDeleteTask.TabIndex = 6;
            btnDeleteTask.Text = "Удалить задачу";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(534, 27);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(200, 47);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Обновить список";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cmbPriority
            // 
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(36, 231);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(200, 31);
            cmbPriority.TabIndex = 1;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1047, 361);
            Controls.Add(btnRefresh);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnAddTask);
            Controls.Add(lstTasks);
            Controls.Add(cmbDayOfWeek);
            Controls.Add(dtpDeadline);
            Controls.Add(cmbPriority);
            Controls.Add(txtDescription);
            Font = new Font("Segoe UI", 10F);
            Name = "Form1";
            Text = "Task Planner";
            ResumeLayout(false);
            PerformLayout();
        }

        private void ApplyCustomPaletteStyle()
        {
            this.BackColor = Color.FromArgb(1, 46, 74); 
            this.Font = new Font("Segoe UI", 10);

            // Настройка текстового поля
            ConfigureControl(txtDescription, new Point(20, 20), new Size(300, 30), Color.FromArgb(204, 204, 204), Color.FromArgb(51, 51, 51));
            txtDescription.PlaceholderText = "Введите название";
            txtDescription.BorderStyle = BorderStyle.None;

            // Настройка комбобоксов
            ConfigureComboBox(cmbPriority, new[] { "Важно", "Желательно", "Необязательно" }, new Point(20, 60), Color.FromArgb(204, 204, 204), Color.FromArgb(51, 51, 51));
            ConfigureComboBox(cmbDayOfWeek, new[] { "Др. день", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" }, new Point(20, 100), Color.FromArgb(204, 204, 204), Color.FromArgb(51, 51, 51));

            // Настройка DateTimePicker
            ConfigureControl(dtpDeadline, new Point(20, 140), new Size(300, 30), Color.FromArgb(204, 204, 204), Color.FromArgb(51, 51, 51));
            dtpDeadline.Format = DateTimePickerFormat.Short;
            dtpDeadline.ShowCheckBox = true;

            // Настройка ListBox
            ConfigureListBox(lstTasks, new Point(20, 200), new Size(500, 300), Color.White, Color.FromArgb(51, 51, 51));

            // Настройка кнопок с использованием насыщенного синего цвета
            ConfigureButton(btnAddTask, "Добавить задачу", new Point(20, 180), Color.FromArgb(51, 102, 153));
            ConfigureButton(btnDeleteTask, "Удалить задачу", new Point(120, 180), Color.FromArgb(51, 102, 153));
            ConfigureButton(btnRefresh, "Обновить список", new Point(220, 180), Color.FromArgb(51, 102, 153));
        }

        // Метод для настройки основных элементов управления
        private void ConfigureControl(Control control, Point location, Size size, Color backColor, Color foreColor)
        {
            control.Font = new Font("Segoe UI", 10);
            control.BackColor = backColor;  // Светло-серый (#CCCCCC)
            control.ForeColor = foreColor;  // Тёмный серый (#333333)
        }

        // Настройка ComboBox
        private void ConfigureComboBox(ComboBox comboBox, string[] items, Point location, Color backColor, Color foreColor)
        {
            ConfigureControl(comboBox, location, new Size(300, 30), backColor, foreColor);
            comboBox.Items.AddRange(items);
            comboBox.SelectedIndex = 0;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FlatStyle = FlatStyle.Flat;
        }

        // Настройка ListBox
        private void ConfigureListBox(ListBox listBox, Point location, Size size, Color backColor, Color foreColor)
        {
            ConfigureControl(listBox, location, size, backColor, foreColor);
            listBox.BorderStyle = BorderStyle.None; // Убираем границы для минимализма
        }

        // Настройка кнопок
        private void ConfigureButton(Button button, string text, Point location, Color color)
        {
            button.Text = text;
            button.Font = new Font("Segoe UI", 10);
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = color;        // Насыщенный синий (#336699)
            button.ForeColor = Color.White;  // Белый текст на кнопке
            button.FlatAppearance.BorderSize = 0;

            // Эффект при наведении
            button.MouseEnter += (s, e) => button.BackColor = ControlPaint.Light(color);
            button.MouseLeave += (s, e) => button.BackColor = color;
        }


        #endregion

        private TextBox txtDescription;
        private DateTimePicker dtpDeadline;
        private ComboBox cmbDayOfWeek;
        private ListBox lstTasks;
        private Button btnAddTask;
        private Button btnDeleteTask;
        private Button btnRefresh;
        private ComboBox cmbPriority;
    }
}
