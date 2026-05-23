using System.Drawing.Printing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace Subject_index
{
    public partial class Form1 : Form
    {
        private bool isSave = false;
 


        Index index;
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private string textToPrint = "";
        private Timer timer;
        public Form1()
        {
            isSave = false;
            var timer = new Timer();
            timer.Interval = 5 * 60 * 1000;
            timer.Tick += Timer_Tick;
            InitializeComponent();
            SetupDataGridView();
            index = new Index();
            // Подписка на событие двойного клика
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog.Document = printDocument;
            textBox3.TextChanged += textBoxSearch_TextChanged;
            this.FormClosing += Form1_FormClosed;
        }
        /// <summary>
        /// Нету вызова обработчика удаления странницы и всего слова и неправильная работа проверки удаления 
        /// удаление не по таймеру а по внесено ли измененеие или нет
        /// 2 метода удаления:
        /// 1. удаление только странниц
        /// 2. удаление всего слова
        ///<summary>

        /// <summary>
        /// проверка сохранен ли проект перед загрытием
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object? sender, FormClosingEventArgs e)
        {
            if (isSave == false)
            {
                e.Cancel = true;
                DialogResult result = MessageBox.Show("Данные не сохранены, хотите сохранить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (result == DialogResult.Yes)
                {
                    btnSave_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = false;
                }
            }
            
        }
        /// <summary>
        /// Метод запускающий таймер 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            isSave = false;
        }
        /// <summary>
        /// функция по нахождаению слова при вбивании его в поле
        /// </summary>
        /// <param name="searchText"></param>
        private void SearchWords(string searchText)
        {
            dataGridView1.Rows.Clear();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                foreach (var entry in index.entries)
                {
                    dataGridView1.Rows.Add(entry.Word, string.Join(", ", entry.pages));
                }
                return;
            }

            foreach (var entry in index.entries)
            {
                if (entry.Word.ToLower().Contains(searchText.ToLower()))
                {
                    dataGridView1.Rows.Add(entry.Word, string.Join(", ", entry.pages));
                }
            }

            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Rows.Add($"Ничего не найдено", "");
            }
        }

        // ОБРАБОТЧИК ВВОДА В ПОИСК
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchWords(textBox3.Text);
        }
        private void SetupDataGridView()
        {
            // Очистка (на всякий случай)
            dataGridView1.Columns.Clear();

            // Создание колонки "Слово"
            DataGridViewTextBoxColumn wordColumn = new DataGridViewTextBoxColumn();
            wordColumn.Name = "WordColumn";
            wordColumn.HeaderText = "Слово";
            wordColumn.Width = 150;

            // Создание колонки "Страницы"
            DataGridViewTextBoxColumn pagesColumn = new DataGridViewTextBoxColumn();
            pagesColumn.Name = "PagesColumn";
            pagesColumn.HeaderText = "Страницы";
            pagesColumn.Width = 250;

            // Добавление колонок в DataGridView
            dataGridView1.Columns.Add(wordColumn);
            dataGridView1.Columns.Add(pagesColumn);

            // Запрещаем пользователю добавлять строки
            dataGridView1.AllowUserToAddRows = false;

            // Растягиваем последнюю колонку
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        /// <summary>
        /// метод отображение ввода, и проверки на наличе символов в строке
        /// </summary>
        private void AddWordInDVG()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите слово");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int page))
            {
                MessageBox.Show("Введите номер страницы");
                return;
            }
            index.Addword(textBox1.Text, page);
            //обновление datagridview
            RefreshDataGridView();

            // Очищаем поле страницы, но слово оставляем (чтобы добавить ещё страниц этому же слову)
            textBox2.Clear();
            textBox2.Focus();
        }
        /// <summary>
        /// обработка нажатие кнопки сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовые файлы|*.txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем имя, которое ввел пользователь
                string userFileName = saveDialog.FileName;

                // Добавляем суффикс перед расширением
                // Например: "мой_указатель.txt" → "мой_указатель_data.txt"
                string directory = Path.GetDirectoryName(userFileName);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(userFileName);
                string extension = Path.GetExtension(userFileName);

                string newFileName = Path.Combine(directory, fileNameWithoutExt + "_Редактирование" + extension);

                index.SaveToFile(saveDialog.FileName);
                isSave = true;
                MessageBox.Show("Сохранено!");
            }
        }
        /// <summary>
        /// обработчик кнопки экспорта в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовые файлы|*.txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем имя, которое ввел пользователь
                string userFileName = saveDialog.FileName;

                // Добавляем суффикс перед расширением
                // Например: "мой_указатель.txt" → "мой_указатель_data.txt"
                string directory = Path.GetDirectoryName(userFileName);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(userFileName);
                string extension = Path.GetExtension(userFileName);

                string newFileName = Path.Combine(directory, fileNameWithoutExt + "_Печать" + extension);

                index.SaveToFile(saveDialog.FileName);
                MessageBox.Show("Сохранено!");
            }
        }
        /// <summary>
        /// обработчик загрузки данных в DataGrtidview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadDialog = new OpenFileDialog();
            LoadDialog.Filter = "Текстовые файлы|*.txt";

            if (LoadDialog.ShowDialog() == DialogResult.OK)
            {
                index.LoadFromFile(LoadDialog.FileName);
                MessageBox.Show("Указатели загружены");
                RefreshDataGridView();
            }
        }
        /// <summary>
        /// обработчик кнопки обновления
        /// </summary>
        private void RefreshDataGridView()
        {
            dataGridView1.Rows.Clear();

            foreach (var entry in index.entries)
            {
                string pagesString = string.Join(", ", entry.pages);

                dataGridView1.Rows.Add(entry.Word, pagesString);
            }
        }
        /// <summary>
        /// обработка нажание на слово в DatagridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что клик не по заголовку (e.RowIndex >= 0)
            if (e.RowIndex >= 0)
            {
                // Получаем слово из первой колонки (индекс 0)
                string selectedWord = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Вставляем слово в TextBox
                textBox1.Text = selectedWord;

                // Очищаем TextBox для страницы (чтобы пользователь ввёл новую)
                textBox2.Clear();

                // Ставим курсор в поле для ввода страницы
                textBox2.Focus();
            }
        }
        /// <summary>
        /// Метод по созданию файла для печати
        /// </summary>
        /// <returns></returns>
        private string PreparePrintText()
        {
            string result = "ПРЕДМЕТНЫЙ УКАЗАТЕЛЬ\n";
            result += "==================\n\n";

            // Сортируем по алфавиту
            var sortedEntries = index.entries.OrderBy(e => e.Word);
            char currentLetter = '\0';
            foreach (var entry in sortedEntries)
            {
                if (!String.IsNullOrEmpty(entry.Word))
                {
                    char firstletter = char.ToUpper(entry.Word[0]);
                    if(firstletter != currentLetter)
                    {
                        currentLetter = firstletter;
                        result += " \n";
                        result += $"{currentLetter}\n";
                        result += $"{new string('=', 20)}";
                    }

                    string pages = string.Join(", ", entry.pages);
                    result += $"{entry.Word}";

                    // Добавляем точки для выравнивания
                    int dotsCount = 30 - entry.Word.Length;
                    if (dotsCount > 0)
                            result += new string('.', dotsCount);
                    else
                            result += " ";

                    result += $" {pages}\n";
                }
            }

            result += "\n==================\n";
            result += $"Всего слов: {index.entries.Count}\n";
            result += $"Дата печати: {DateTime.Now:dd.MM.yyyy HH:mm}";

            return result;
        }
        /// <summary>
        /// обработчик кнопки для открытия окна печати
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Courier New", 10);
            float linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            float yPos = e.MarginBounds.Top;
            int count = 0;

            string[] lines = textToPrint.Split('\n');

            while (count < lines.Length && yPos + printFont.GetHeight(e.Graphics) < e.MarginBounds.Bottom)
            {
                e.Graphics.DrawString(lines[count], printFont, Brushes.Black,
                                      e.MarginBounds.Left, yPos);
                yPos += printFont.GetHeight(e.Graphics);
                count++;
            }

            if (count < lines.Length)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        /// <summary>
        /// кнопкеа вызова печати
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (index.entries.Count == 0)
            {
                MessageBox.Show("Указатель пуст. Нечего печатать.", "Предупреждение");
                return;
            }

            textToPrint = PreparePrintText();
            printPreviewDialog.ShowDialog();
        }
        //кнопка обновления
        private void button5_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        //снопка добавление слова
        private void button1_Click(object sender, EventArgs e)
        {
            AddWordInDVG();
        }
        //кнопка сохранения
        private void button4_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
        //кнопка экспорта
        private void button6_Click(object sender, EventArgs e)
        {
            btnExport_Click(sender, e);
        }
        //кнопка загрузки данных
        private void button2_Click(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }
        //кнопка печати документа
        private void button3_Click(object sender, EventArgs e)
        {
            btnPrint_Click(sender,e);
        }
    }
}
