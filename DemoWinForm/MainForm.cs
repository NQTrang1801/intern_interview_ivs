using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileProcessingApp
{
    public partial class MainForm : Form
    {
        private const long LargeFileSizeThreshold = 10 * 1024 * 1024; 

        public MainForm()
        {
            InitializeComponent();
        }

        private async void LoadFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                await ExecuteWithExceptionHandling(async () => await LoadFileAsync(filePath), string.Empty);
            }
        }

        private async void SaveFileButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                await ExecuteWithExceptionHandling(async () => await SaveFileAsync(filePath, fileContentTextBox.Text), "File saved successfully.");
            }
        }

        private async Task ExecuteWithExceptionHandling(Func<Task> func, string successMessage)
        {
            try
            {
                await func();
                if (!string.IsNullOrEmpty(successMessage))
                {
                    MessageBox.Show(successMessage);
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("File not found: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Access denied: " + ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show("I/O error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }

        private bool IsLargeFile(string filePath)
        {
            return new FileInfo(filePath).Length > LargeFileSizeThreshold;
        }

        private async Task LoadFileAsync(string filePath)
        {
            if (IsLargeFile(filePath))
            {
                var contentBuilder = new StringBuilder();
                using (var reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        contentBuilder.AppendLine(line);
                    }
                }
                fileContentTextBox.Text = contentBuilder.ToString();
            }
            else
            {
                fileContentTextBox.Text = await File.ReadAllTextAsync(filePath);
            }
        }

        private async Task SaveFileAsync(string filePath, string content)
        {
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8, 4096))
            {
                await writer.WriteAsync(content);
            }
        }
    }
}
