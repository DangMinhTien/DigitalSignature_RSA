using Microsoft.Win32;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Xceed.Words.NET;

namespace DangMinhTien_2020600144
{
    public class MyOpenFileDialog
    {
        private readonly WebBrowser? _webBrowser;
        private readonly Border? _webContainer;
        private readonly TextBox _textBox;
        private readonly OpenFileDialog _openFileDialog;

        public string DirName { get; set; }

        public byte[]? FileData { get; set; }

        public string? FileText { get; set; }

        public string? Filter { get; set; }

        public string? FileName { get; set; }

        public MyOpenFileDialog(WebBrowser? webBrowser, Border? webContainer, TextBox textBox, string dirName = "", string filter = "File txt hoặc doc (.txt;.docx)|*.txt;*.docx")
        {
            _openFileDialog = new()
            {
                FileName = "Document", // Default file name
                Title = "Chọn file",
                DefaultExt = ".txt", // Default file extension
                Filter = filter,
                Multiselect = false
            };
            _webBrowser = webBrowser;
            _webContainer = webContainer;
            _textBox = textBox;
            DirName = dirName;
        }

        public void HandleSelectFile()
        {
            if (_openFileDialog.ShowDialog() == true)
            {
                DisplayFileContent(_openFileDialog.FileName);
                FileName = _openFileDialog.FileName;
            }
        }

        public void DisplayFileContent(string fileName)
        {
            string[] fileNameArr = fileName.Split(".");
            if (fileNameArr[^1] == "docx")
            {
                Document doc = new(fileName);
                DirectoryInfo? rootPath = Directory.GetParent(Environment.CurrentDirectory);

                if (rootPath?.Parent?.Parent?.FullName != null)
                {

                    _webBrowser?.Navigate("data:application/docx");
                    string tempPath = Path.Combine(rootPath.Parent.Parent.FullName, DirName, "temp.docx");
                    try
                    {
                        doc.SaveToFile(tempPath, FileFormat.Docx);
                        doc.Close();
                    }
                    catch
                    {
                        try
                        {
                            tempPath = Path.Combine(rootPath.Parent.Parent.FullName, "temp2.docx");
                            doc.SaveToFile(tempPath, FileFormat.Docx);
                        }
                        catch
                        {
                            tempPath = Path.Combine(rootPath.Parent.Parent.FullName, "temp3.docx");
                            doc.SaveToFile(tempPath, FileFormat.Docx);
                        }
                    }


                    _webBrowser?.Navigate(tempPath);
                    if (_webContainer != null)
                    {
                        _webContainer.Visibility = Visibility.Visible;
                    }
                }
                FileData = File.ReadAllBytes(fileName);
                FileText = null;
                /*
                DocX document = DocX.Load(fileName);

                // Đọc nội dung của tài liệu Word
                string text = document.Text;
                _textBox.Text = text;
                */
                return;
            }
            else if (fileNameArr[^1] == "signature")
            {
                byte[] data = File.ReadAllBytes(fileName);
                string hexData = Convert.ToHexString(data);
                _textBox.Text = hexData;
                FileText = hexData;
                FileData = null;
                return;
            }
            string inputData = File.ReadAllText(fileName, Encoding.UTF8);
            _textBox.Text = inputData;
            FileText = inputData;
            FileData = null;
            if (_webContainer != null)
            {
                _webContainer.Visibility = Visibility.Hidden;
            }
        }
    }
}
