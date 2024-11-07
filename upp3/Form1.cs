namespace upp3
{
    public partial class Form1 : Form
    {
        private List<Task> tasks = new List<Task>(); // Список для хранения задач

        public Form1()
        {
            InitializeComponent();
            ApplyCustomPaletteStyle(); // Применение пользовательского стиля

            // Устанавливаем режим пользовательского рисования для ListBox
            lstTasks.DrawMode = DrawMode.OwnerDrawVariable; // Режим позволяет настраивать высоту элементов
            lstTasks.MeasureItem += lstTasks_MeasureItem;   // Событие для измерения высоты каждого элемента
            lstTasks.DrawItem += lstTasks_DrawItem;         // Событие для кастомного рисования каждого элемента
        }

        // Обработчик для кнопки "Добавить задачу"
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text; // Получение описания задачи
            int priority = cmbPriority.SelectedIndex + 1; // Определение приоритета задачи
            DateTime? deadline = dtpDeadline.Checked ? (DateTime?)dtpDeadline.Value : null; // Проверка наличия дэдлайна
            string dayOfWeek = cmbDayOfWeek.SelectedItem.ToString(); // День недели для задачи

            // Создание новой задачи и добавление её в список
            Task newTask = new Task
            {
                Description = description,
                Priority = priority,
                Deadline = deadline,
                DayOfWeek = dayOfWeek == "Др. день" ? null : dayOfWeek // Установка дня недели, если он выбран
            };

            tasks.Add(newTask); // Добавляем задачу в список
            UpdateTaskList();   // Обновляем список задач в ListBox

            // Очистка полей ввода после добавления задачи
            txtDescription.Clear();
            cmbPriority.SelectedIndex = 1;  // Установка значения по умолчанию
            cmbDayOfWeek.SelectedIndex = 0; // Установка значения по умолчанию
            dtpDeadline.Checked = false;    // Сброс чекбокса дэдлайна
        }

        // Обработчик для кнопки "Удалить задачу"
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex >= 0) // Проверка, выбран ли элемент в ListBox
            {
                tasks.RemoveAt(lstTasks.SelectedIndex); // Удаление задачи из списка
                UpdateTaskList();                       // Обновление ListBox
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для удаления"); // Сообщение, если задача не выбрана
            }
        }

        // Обработчик для кнопки "Обновить"
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateTaskList(); // Обновление списка задач
        }

        // Метод для обновления ListBox на основе списка задач
        private void UpdateTaskList()
        {
            lstTasks.Items.Clear(); // Очистка ListBox
            foreach (var task in tasks) // Добавление каждой задачи в ListBox
            {
                lstTasks.Items.Add(task.ToString()); // Преобразование задачи в строку
            }
        }

        // Событие измерения высоты каждого элемента ListBox
        private void lstTasks_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            string itemText = lstTasks.Items[e.Index].ToString(); // Получение текста элемента
            var font = lstTasks.Font;

            // Определение размера текста с учетом ширины ListBox
            SizeF textSize = e.Graphics.MeasureString(itemText, font, lstTasks.Width);
            e.ItemHeight = (int)textSize.Height + 5; // Установка высоты строки с дополнительным отступом
        }

        // Событие для кастомного рисования каждого элемента ListBox
        private void lstTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground(); // Рисуем фон элемента
            string itemText = lstTasks.Items[e.Index].ToString(); // Получаем текст элемента
            var font = lstTasks.Font;

            // Определяем область для рисования текста
            RectangleF rect = new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

            // Рисуем текст элемента внутри заданной области с переносом строк
            e.Graphics.DrawString(itemText, font, Brushes.Black, rect);

            e.DrawFocusRectangle(); // Рисуем прямоугольник, если элемент в фокусе
        }
    }

    // Класс для представления задачи
    public class Task
    {
        public string Description { get; set; } // Описание задачи
        public DateTime? Deadline { get; set; } // Дэдлайн задачи
        public int Priority { get; set; }       // Приоритет задачи
        public string DayOfWeek { get; set; }   // День недели для задачи

        // Метод для преобразования задачи в строку для отображения в ListBox
        public override string ToString()
        {
            string priorityStr = Priority == 1 ? "Важно" : Priority == 2 ? "Желательно" : "Необязательно";
            string deadlineStr = Deadline.HasValue ? Deadline.Value.ToString("yyyy-MM-dd") : "Нет дэдлайна";
            string dayOfWeekStr = !string.IsNullOrEmpty(DayOfWeek) ? DayOfWeek : "Др. день";

            // Формируем строку с информацией о задаче
            return $"{Description} | Приоритет: {priorityStr} | Дэдлайн: {deadlineStr} | День недели: {dayOfWeekStr}";
        }
    }
}
