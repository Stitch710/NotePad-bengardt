using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace NotePad_bengardt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string _filename;
        private string _opened_file_path;

        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {

            }
        }
        public string Opened_file_path
        {
            get => _opened_file_path;
            set
            {

            }
        }
        public MainWindow(string filename)
        {
            try
            {
                _filename = filename;
                Title = _filename;
            }
            catch (Exception ext)
            {
                MessageBox.Show("No File Name\n" + "Error code : " + ext.Message, "Missing File name", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            if (text_area.Document.Blocks.Count == 0)
            {
                MainWindow newWun = new MainWindow();
                newWun.Show();
                this.Close();
            }
            else if (text_area.Document.Blocks.Count != 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы хотите сохранить изменения? " + _filename, "Сохранить файл", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {

                    SaveAS_File();
                    MainWindow newWun = new MainWindow();
                    newWun.Show();
                    this.Close();
                }
                else if (result == MessageBoxResult.No)
                {
                    MainWindow newWun = new MainWindow();
                    newWun.Show();
                    Close();
                }
            }
        }

        public void SaveAS_File()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Новый текстовый документ";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Текстовый документ (.txt) |*.txt";
            dialog.ShowDialog();
            TextRange range_of_text_area = new TextRange(text_area.Document.ContentStart, text_area.Document.ContentEnd);
            File.WriteAllText(dialog.FileName, range_of_text_area.Text.ToString());

        }

       

        private void open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 text_area.Document.Blocks.Clear();
                OpenFileDialog file_dialog = new OpenFileDialog();
                file_dialog.ShowDialog();
                text_area.AppendText(File.ReadAllText(file_dialog.FileName).ToString());
                _opened_file_path = System.IO.Path.GetFullPath(file_dialog.FileName);
                Title = System.IO.Path.GetFileNameWithoutExtension(file_dialog.FileName);
            }
            catch
            {
               
            }
        }

      

        private void save_as_Click(object sender, RoutedEventArgs e)
        {
            SaveAS_File();
        }

        private void page_setup_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Пичугин исп-41 ", "О ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

      

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = "Без названия",
                DefaultExt = ".txt",
                Filter = "Текстовый документ(.txt) |*.txt*"
            };
            dialog.ShowDialog();
            TextRange range_of_text_area = new TextRange(text_area.Document.ContentStart, text_area.Document.ContentEnd);
            File.WriteAllText(dialog.FileName, range_of_text_area.Text.ToString());
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
           
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {

        }
        private void copy_click(object sender, RoutedEventArgs e)
        {
            text_area.Copy();
        }
        private void cut_click(object sender, RoutedEventArgs e)
        {
            text_area.Cut();
        }
        private void paste_click(object sender, RoutedEventArgs e)
        {
            text_area.Paste();
        }
        private void select_click(object sender, RoutedEventArgs e)
        {
            text_area.SelectAll();
        }
        private void Fat_Click(object sender, RoutedEventArgs e)
        {

            object temp = text_area.Selection.GetPropertyValue(Inline.FontWeightProperty);
            if (temp != DependencyProperty.UnsetValue && temp.Equals(FontWeights.Normal))
            {
                text_area.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);

            }
            else
            {
                text_area.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
            }

        }
        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            object temp = text_area.Selection.GetPropertyValue(Inline.FontStyleProperty);
            if (temp != DependencyProperty.UnsetValue && temp.Equals(FontStyles.Normal))
            {
                text_area.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);

            }
            else
            {
                text_area.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
            }
        }
        private void UnderLine_Click(object sender, RoutedEventArgs e)
        {
            if (text_area.Selection.GetPropertyValue(Inline.TextDecorationsProperty) != TextDecorations.Underline)
            {
                text_area.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);

            }
            else
            {
                text_area.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
        }
    }
}


