using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Threading;

namespace QuanLyNhanVienLVTN
{
    public partial class BaoCao : Form
    {   private static string[] str2 = new string[30];
        public BaoCao()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                MailMessage mail = new MailMessage(textboxFrom.Text, textBoxTo.Text, textBoxTD.Text, textBoxNDMail.Text); //
                foreach (string names in str2)
                {
                    if (names != null)
                    {
                        mail.Attachments.Add(new Attachment(names));
                        MessageBox.Show("Have upload " + names + " succesfully!", "Upload File");
                    };

                };
                mail.IsBodyHtml = true;
                //gửi tin nhắn
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Host = "smtp.gmail.com";
                //ta không dùng cái mặc định đâu, mà sẽ dùng cái của riêng mình

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Timeout = 30 * 1000;
                client.Port = 587; //vì sử dụng Gmail nên mình dùng port 587
                                   // thêm vào credential vì SMTP server cần nó để biết được email + password của email đó mà bạn đang dùng
                client.Credentials = new System.Net.NetworkCredential(textboxFrom.Text, textBoxPW.Text);
                client.EnableSsl = true; //vì ta cần thiết lập kết nối SSL với SMTP server nên cần gán nó bằng true
                client.Send(mail);
                MessageBox.Show("Đã gửi tin nhắn thành công!", "Thành Công", MessageBoxButtons.OK);

                
            });
            thread.Start();
            
        }

        private void buttonAttach_Click(object sender, EventArgs e)
        {
            string fileName = ""; //khởi tạo ban đầu
                                  //open tệp tin với component OpenFileDialog
            using (OpenFileDialog myDialog = new OpenFileDialog())
            {
                myDialog.Multiselect = true;
                myDialog.InitialDirectory = "";
                myDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                myDialog.FilterIndex = 2;
                myDialog.RestoreDirectory = true;

                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in myDialog.FileNames)
                    //cứ sau mỗi lần lặp ta lại có được một file, điều này cho phép bạn chọn nhiều file thay vì chỉ một cái
                    {
                        //Lấy đường dẫn của file cụ thể
                        //lấy tên của file cụ thể
                        fileName = Path.GetFileName(file);
                        MessageBox.Show("attach " + file + "done !");
                       
                    }

                }
                str2 = myDialog.FileNames;
            }
        }
    }
}
