namespace upp3
{
    public partial class Form1 : Form
    {
        private List<Task> tasks = new List<Task>(); // ������ ��� �������� �����

        public Form1()
        {
            InitializeComponent();
            ApplyCustomPaletteStyle(); // ���������� ����������������� �����

            // ������������� ����� ����������������� ��������� ��� ListBox
            lstTasks.DrawMode = DrawMode.OwnerDrawVariable; // ����� ��������� ����������� ������ ���������
            lstTasks.MeasureItem += lstTasks_MeasureItem;   // ������� ��� ��������� ������ ������� ��������
            lstTasks.DrawItem += lstTasks_DrawItem;         // ������� ��� ���������� ��������� ������� ��������
        }

        // ���������� ��� ������ "�������� ������"
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text; // ��������� �������� ������
            int priority = cmbPriority.SelectedIndex + 1; // ����������� ���������� ������
            DateTime? deadline = dtpDeadline.Checked ? (DateTime?)dtpDeadline.Value : null; // �������� ������� ��������
            string dayOfWeek = cmbDayOfWeek.SelectedItem.ToString(); // ���� ������ ��� ������

            // �������� ����� ������ � ���������� � � ������
            Task newTask = new Task
            {
                Description = description,
                Priority = priority,
                Deadline = deadline,
                DayOfWeek = dayOfWeek == "��. ����" ? null : dayOfWeek // ��������� ��� ������, ���� �� ������
            };

            tasks.Add(newTask); // ��������� ������ � ������
            UpdateTaskList();   // ��������� ������ ����� � ListBox

            // ������� ����� ����� ����� ���������� ������
            txtDescription.Clear();
            cmbPriority.SelectedIndex = 1;  // ��������� �������� �� ���������
            cmbDayOfWeek.SelectedIndex = 0; // ��������� �������� �� ���������
            dtpDeadline.Checked = false;    // ����� �������� ��������
        }

        // ���������� ��� ������ "������� ������"
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex >= 0) // ��������, ������ �� ������� � ListBox
            {
                tasks.RemoveAt(lstTasks.SelectedIndex); // �������� ������ �� ������
                UpdateTaskList();                       // ���������� ListBox
            }
            else
            {
                MessageBox.Show("����������, �������� ������ ��� ��������"); // ���������, ���� ������ �� �������
            }
        }

        // ���������� ��� ������ "��������"
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateTaskList(); // ���������� ������ �����
        }

        // ����� ��� ���������� ListBox �� ������ ������ �����
        private void UpdateTaskList()
        {
            lstTasks.Items.Clear(); // ������� ListBox
            foreach (var task in tasks) // ���������� ������ ������ � ListBox
            {
                lstTasks.Items.Add(task.ToString()); // �������������� ������ � ������
            }
        }

        // ������� ��������� ������ ������� �������� ListBox
        private void lstTasks_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            string itemText = lstTasks.Items[e.Index].ToString(); // ��������� ������ ��������
            var font = lstTasks.Font;

            // ����������� ������� ������ � ������ ������ ListBox
            SizeF textSize = e.Graphics.MeasureString(itemText, font, lstTasks.Width);
            e.ItemHeight = (int)textSize.Height + 5; // ��������� ������ ������ � �������������� ��������
        }

        // ������� ��� ���������� ��������� ������� �������� ListBox
        private void lstTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground(); // ������ ��� ��������
            string itemText = lstTasks.Items[e.Index].ToString(); // �������� ����� ��������
            var font = lstTasks.Font;

            // ���������� ������� ��� ��������� ������
            RectangleF rect = new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

            // ������ ����� �������� ������ �������� ������� � ��������� �����
            e.Graphics.DrawString(itemText, font, Brushes.Black, rect);

            e.DrawFocusRectangle(); // ������ �������������, ���� ������� � ������
        }
    }

    // ����� ��� ������������� ������
    public class Task
    {
        public string Description { get; set; } // �������� ������
        public DateTime? Deadline { get; set; } // ������� ������
        public int Priority { get; set; }       // ��������� ������
        public string DayOfWeek { get; set; }   // ���� ������ ��� ������

        // ����� ��� �������������� ������ � ������ ��� ����������� � ListBox
        public override string ToString()
        {
            string priorityStr = Priority == 1 ? "�����" : Priority == 2 ? "����������" : "�������������";
            string deadlineStr = Deadline.HasValue ? Deadline.Value.ToString("yyyy-MM-dd") : "��� ��������";
            string dayOfWeekStr = !string.IsNullOrEmpty(DayOfWeek) ? DayOfWeek : "��. ����";

            // ��������� ������ � ����������� � ������
            return $"{Description} | ���������: {priorityStr} | �������: {deadlineStr} | ���� ������: {dayOfWeekStr}";
        }
    }
}
