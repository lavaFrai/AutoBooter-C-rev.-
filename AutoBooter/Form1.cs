using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace AutoBooter
{
    public partial class root : Form
    {
        public root()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void prepare_btn_Click(object sender, EventArgs e)
        {
            prepare_btn.Enabled = false;
            status_txt.Text = "вычисление констант";
            progress_bar.Value = 10;
            string reposytory = "https://github.com/lavaFrai/lostis";
            progress_bar.Value = 20;
            string frimware_path = reposytory + "/blob/master/autoboot/lasted.hex?raw=true";
            progress_bar.Value = 30;
            string checksum_path = reposytory + "/blob/master/autoboot/hash.sha256?raw=true";
            progress_bar.Value = 40;
            string avr_dude_path = "https://github.com/lavaFrai/autobooter/blob/main/host/avrdude.exe?raw=true";
            progress_bar.Value = 50;
            string avr_conf_path = "https://github.com/lavaFrai/autobooter/blob/main/host/avrdude.conf?raw=true";
            progress_bar.Value = 60;


            status_txt.Text = "загрузка файлов прошивки";
            progress_bar.Value = 0;
            string link = @frimware_path; //ссылка на файл
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += (o, args) => progress_bar.Value = args.ProgressPercentage;
            webClient.DownloadFileCompleted += (o, args) => progress_bar.Value = 100;
            try
            {
                webClient.DownloadFileAsync(new Uri(link), "frimware.hex"); //куда сохранить, в данный момент в папку где запущена программа
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Не удалось загрузить файлы, проверьте подключение");
                status_txt.Text = "ошибка загрузки";
                progress_bar.Value = 0;
                prepare_btn.Enabled = true;
                return;
            }
            status_txt.Text = "проверка сумм прошивки";
            progress_bar.Value = 0;
            status_txt.Text = "загрузка AVRDUDE";
            progress_bar.Value = 0;
            link = @avr_dude_path; //ссылка на файл
            webClient = new WebClient();
            webClient.DownloadProgressChanged += (o, args) => progress_bar.Value = args.ProgressPercentage;
            webClient.DownloadFileCompleted += (o, args) => progress_bar.Value = 100;
            try
            {
                webClient.DownloadFile(new Uri(link), "avrdude.exe"); //куда сохранить, в данный момент в папку где запущена программа
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Не удалось загрузить файлы, проверьте подключение");
                status_txt.Text = "ошибка загрузки";
                progress_bar.Value = 0;
                prepare_btn.Enabled = true;
                return;
            }
            status_txt.Text = "проверка сумм программы";
            progress_bar.Value = 0;
            status_txt.Text = "загрузка файлов конфигурации";
            link = @avr_conf_path; //ссылка на файл
            webClient = new WebClient();
            webClient.DownloadProgressChanged += (o, args) => progress_bar.Value = args.ProgressPercentage;
            webClient.DownloadFileCompleted += (o, args) => progress_bar.Value = 100;
            try
            {
                webClient.DownloadFile(new Uri(link), "avrdude.conf"); //куда сохранить, в данный момент в папку где запущена программа
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Не удалось загрузить файлы, проверьте подключение");
                status_txt.Text = "ошибка загрузки";
                progress_bar.Value = 0;
                prepare_btn.Enabled = true;
                return;
            }
            status_txt.Text = "проверка сумм конфига";
            progress_bar.Value = 0;


            this.prepare_btn.Location = new System.Drawing.Point(9, 110);
            this.boot_btn.Location = new System.Drawing.Point(147, 110);
            this.MaximumSize = new System.Drawing.Size(304, 190);
            this.MinimumSize = new System.Drawing.Size(304, 190);
            MessageBox.Show("Теперь подключите устройство к ПК, дождитьесь, когда оно будет готово и нажмите ОК");
            string[] ports = SerialPort.GetPortNames();
            this.port_select.Items.AddRange(ports);
            this.port_select.Visible = true;
            this.label2.Visible = true;

            status_txt.Text = "готово к обновлению";
            boot_btn.Enabled = true;
            }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void boot_btn_Click(object sender, EventArgs e)
        {
            this.boot_btn.Enabled = false;
            this.port_select.Enabled = false;
            status_txt.Text = "проверка достоверности";
            progress_bar.Value = 0;
            bool has_port = false;
            foreach (string i in SerialPort.GetPortNames())
            {
                if (i == (string)this.port_select.SelectedItem)
                {
                    has_port = true;
                }
            }
            if (this.port_select.SelectedItem == null || !has_port)
            {
                MessageBox.Show("Необходимо выбрать существующий порт для прошивки устройства");
                string[] ports = SerialPort.GetPortNames();
                this.boot_btn.Enabled = true;
                this.port_select.Items.Clear();
                this.port_select.Items.AddRange(ports);
                this.port_select.Enabled = true;
                status_txt.Text = "ошибка подключения";
                return;
            }
            // тут начинаем загрузку обновления
            status_txt.Text = "подготовка AVRDUDE";
            this.progress_bar.Value = 20;
            string path = System.IO.Directory.GetCurrentDirectory();
            string port = (string)this.port_select.SelectedItem;
            string request = "  -C\"" + path + "\\config.conf\" -v -patmega328p -carduino -P" + port + " -b115200 -D \"-Uflash:w:\"" + path + "\\firmware.hex\":i";
            Process iStartProcess = new Process(); // новый процесс
            iStartProcess.StartInfo.FileName = (path + "\\avrdude.exe"); // путь к запускаемому файлу
            iStartProcess.StartInfo.Arguments = request; // эта строка указывается, если программа запускается с параметрами (здесь указан пример, для наглядности)
                                                         // iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // эту строку указываем, если хотим запустить программу в скрытом виде

            this.progress_bar.Value = 40;
            status_txt.Text = "загрузка прошивки";
            iStartProcess.Start(); // запускаем программу
            iStartProcess.WaitForExit(30000); // эту строку указываем, если нам надо будет ждать завершения программы определённое время, пример: 2 мин. (указано в миллисекундах - 2 мин. * 60 сек. * 1000 м.сек.)
            iStartProcess.WaitForExit();
            if (iStartProcess.ExitCode == 0)
            {
                this.status_txt.Text = "готово";
                this.progress_bar.Value = 100;
                return;
            }
            
            this.boot_btn.Enabled = true;
            this.port_select.Items.Clear();
            this.port_select.Items.AddRange(SerialPort.GetPortNames());
            this.port_select.Enabled = true;
            this.progress_bar.Value = 0;
            this.status_txt.Text = "ошибка загрузки (code " + iStartProcess.ExitCode + ")";
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
