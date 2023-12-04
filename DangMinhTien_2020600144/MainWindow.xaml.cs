using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;
using System.ComponentModel;
using Spire.Doc;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using DangMinhTien_2020600144;

namespace DangMinhTien_2020600144
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RSADigitalSignature _digitalSignature;
        private readonly MyOpenFileDialog _senderOpenFileDialog;
        private readonly MyOpenFileDialog _receiverOpenFileDialog;
        private readonly MyOpenFileDialog _receiverOpenFileSignature;

        public MainWindow()
        {
            InitializeComponent();
            _digitalSignature = new();
            _senderOpenFileDialog = new(webGui, webContainerGui, tbVanBan, "TempSender");
            _receiverOpenFileDialog = new(webReceiver, webContainerReceiver, tbVanBanNhan, "TempReceiver");
            _receiverOpenFileSignature = new(null, null, tbChuKyNhan, filter: "File .signature (.signature)|*.signature");
            webContainerGui.Visibility = Visibility.Hidden;
            webContainerReceiver.Visibility = Visibility.Hidden;
        }

        private void btnKy_Click(object sender, RoutedEventArgs e)
        {
            byte[] originalData;
            // Nếu ký file word
            if (webContainerGui.Visibility == Visibility.Visible && _senderOpenFileDialog.FileData != null)
            {
                // Ký dữ liệu từ file word
                originalData = _senderOpenFileDialog.FileData;
            }
            else if (!string.IsNullOrEmpty(tbVanBan.Text))
            {
                // Ký dữ liệu từ file text hoặc văn bản
                ASCIIEncoding encoding = new();
                originalData = encoding.GetBytes(tbVanBan.Text);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để ký", "Thông báo");
                return;
            }

            byte[]? signature = _digitalSignature.HashAndSign(originalData);
            if (signature == null)
            {
                MessageBox.Show("Có lỗi xảy ra", "Thông báo");
                return;
            }
            string signatureHex = Convert.ToHexString(signature);
            tbChuKy.Text = signatureHex;
        }

        private void btnKiemTra_Click(object sender, RoutedEventArgs e)
        {
            byte[] receivedData;
            // Nếu mở file word
            if (webContainerReceiver.Visibility == Visibility.Visible && _receiverOpenFileDialog.FileData != null)
            {
                // Lấy dữ liệu từ file word
                receivedData = _receiverOpenFileDialog.FileData;
            }
            else if (!string.IsNullOrEmpty(tbVanBanNhan.Text))
            {
                // Lấy dữ liệu từ text box
                ASCIIEncoding encoding = new();
                receivedData = encoding.GetBytes(tbVanBanNhan.Text);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để kiểm tra", "Thông báo");
                return;
            }

            if (string.IsNullOrEmpty(tbChuKyNhan.Text))
            {
                MessageBox.Show("Không có chữ ký để kiểm tra", "Thông báo");
                return;
            }

            string msg = "Có lỗi xảy ra";
            try
            {
                byte[] signature = Convert.FromHexString(tbChuKyNhan.Text);
                VerifySignatureResult verifySignatureResult = _digitalSignature.VerifySignature(receivedData, signature);
                switch (verifySignatureResult)
                {
                    case VerifySignatureResult.Error:
                        msg = "Có lỗi xảy ra";
                        break;
                    case VerifySignatureResult.DataChanged:
                        msg = "Chữ ký sai hoặc dữ liệu bị thay đổi";
                        break;
                    case VerifySignatureResult.InvalidSignature:
                        msg = "Chữ ký sai hoặc dữ liệu bị thay đổi";
                        break;
                    case VerifySignatureResult.ValidSignature:
                        msg = "Chữ ký đúng, dữ liệu không bị thay đổi";
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                msg = "Chữ ký không đúng định dạng";
            }
            MessageBox.Show(msg, "Thông báo");
        }

        private void btnChuyen_Click(object sender, RoutedEventArgs e)
        {
            if (
                string.IsNullOrEmpty(tbChuKy.Text) &&
                (
                    string.IsNullOrEmpty(tbVanBan.Text) ||
                    _senderOpenFileDialog.FileData == null
                )
            )
            {
                MessageBox.Show("Cần điền đầy đủ văn bản và chữ ký", "Thông báo");
                return;
            }
            if (webContainerGui.Visibility == Visibility.Visible && !string.IsNullOrEmpty(_senderOpenFileDialog.FileName))
            {
                // Nếu đang view file word thì sẽ chuyển file word
                _receiverOpenFileDialog.FileData = _senderOpenFileDialog.FileData;
                _receiverOpenFileDialog.FileText = null;
                webContainerReceiver.Visibility = Visibility.Visible;
                tbChuKyNhan.Text = tbChuKy.Text;
                tbVanBanNhan.Text = "";
                _receiverOpenFileDialog.DisplayFileContent(_senderOpenFileDialog.FileName);
                return;
            }
            // Ngược lại là view file txt hoặc văn bản
            tbChuKyNhan.Text = tbChuKy.Text;
            tbVanBanNhan.Text = tbVanBan.Text;
            webContainerReceiver.Visibility = Visibility.Hidden;
        }

        private void btnVanBanGui_Click(object sender, RoutedEventArgs e)
        {
            _senderOpenFileDialog.HandleSelectFile();
        }

        private void btnCreateKey_Click(object sender, RoutedEventArgs e)
        {
            int keySize = 2048;
            if (rb512bits.IsChecked == true)
            {
                keySize = 512;
            }
            else if (rb1024bits.IsChecked == true)
            {
                keySize = 1024;
            }
            else if (rb2048bits.IsChecked == true)
            {
                keySize = 2048;
            }
            else if (rb4096bits.IsChecked == true)
            {
                keySize = 4096;
            }
            _digitalSignature.CreateKey(keySize);
            tbPublicKey.Text = _digitalSignature.PublicKeyHex;
            tbPrivateKey.Text = _digitalSignature.PrivateKeyHex;
            btnKy.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbChuKy.Text))
            {
                MessageBox.Show("Không có chữ ký", "Thông báo");
                return;
            }

            byte[] signature = Convert.FromHexString(tbChuKy.Text);

            SaveFileDialog saveFileDialog = new()
            {
                Title = "Lưu File",
                FileName = "chuKy.signature",
                Filter = "File chữ ký (*.signature)|*.signature"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllBytes(saveFileDialog.FileName, signature);
                MessageBox.Show("Lưu file chữ ký thành công", "Thông báo");
            }
        }

        private void btnSelectFileDataReceiver_Click(object sender, RoutedEventArgs e)
        {
            _receiverOpenFileDialog.HandleSelectFile();
        }

        private void btnSelectSignature_Click(object sender, RoutedEventArgs e)
        {
            _receiverOpenFileSignature.HandleSelectFile();
        }

        private void btnResetReveiver_Click(object sender, RoutedEventArgs e)
        {
            _receiverOpenFileDialog.FileData = null;
            _receiverOpenFileDialog.FileText = null;
            tbVanBanNhan.Text = "";
            _receiverOpenFileSignature.FileData = null;
            _receiverOpenFileSignature.FileText = null;
            tbChuKyNhan.Text = "";
            webContainerReceiver.Visibility = Visibility.Hidden;
        }

        private void btnResetSender_Click(object sender, RoutedEventArgs e)
        {
            _senderOpenFileDialog.FileData = null;
            _senderOpenFileDialog.FileText = null;
            tbVanBan.Text = "";
            tbChuKy.Text = "";
            webContainerGui.Visibility = Visibility.Hidden;
        }

    }
}
