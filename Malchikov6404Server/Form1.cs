using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;

namespace Malchikov6404Server
{
    public partial class Server : Form
    {
        private delegate void Connect();
        Socket socket;
        Socket client;
        EndPoint end;
        byte[] buffer, bytesLen;

        public int sendport = 9081;
        public int keyport = 9082;
        private Thread thrListener;
        private static Thread thrDownload ;
        private static NetworkStream strRemote;
        private static TcpListener tlsServer;
        private BigInteger _Ekey, _Pkey, _Qkey, _Nkey, _Phikey, _Dkey, _Xkey, _Ykey, _NODkey;
        private double[] SimpleArray = new double[] { 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997 };
        private string[] mes;
        private byte[] messagecc = null;
        private byte[] key =null;
        private byte[] iv = null;
        private byte[] decrypted; // the decrypted bytes
        private byte[] message;
        private BigInteger newBigInt;
        private BigInteger superkey1;
        private BigInteger b_Nkey ;
        private BigInteger b_Dkey ;
        private byte[] tmp = new byte[32];
        private byte[] inivector;
        private static byte[] DataContent;

        private static string NameFile;

        private byte[] encMessage; // the encrypted bytes
        private byte[] decMessage; // the decrypted bytes - s/b same as message

        public Server()
        {
            InitializeComponent();
            Pkey.Text = ""; Qkey.Text = ""; Nkey.Text = ""; Phikey.Text = ""; NODkey.Text = ""; Dkey.Text = ""; Ykey.Text = ""; Ekey.Text = "";
            String strHostName;
            strHostName = Dns.GetHostName();
            System.Net.IPAddress ip = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0];
            myIP.Text += ip.ToString();
            ipadress.Text = ip.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            logs.Text += "===Сервер запущен===\r\n";
            if ((ipadress.Text != "") && (directory.Text != ""))
            {
                thrDownload = new Thread(() => StartReceiving(ipadress.Text, directory.Text, sendport));
                thrDownload.Start();
                thrDownload.Join();
                logs.Text += "Завершено, проверьте файл\r\nГотово к новому запуску\r\n";
                //thrDownload.Abort();
                //strRemote.Close();
                //tlsServer.Stop();
                
            }
            else { logs.Text += "Неправильный адрес или Папка"; }
        }
        private static void StartReceiving(string ipa,string path,int send_port)
        {
            path += "\\"  ;
            try
            {
                IPEndPoint ipadress = new IPEndPoint(IPAddress.Parse(ipa), send_port);

                if (tlsServer == null)
                {
                    tlsServer = new TcpListener(ipadress);
                }
                tlsServer.Start();
                TcpClient tclServer = tlsServer.AcceptTcpClient();
                strRemote = tclServer.GetStream();
                List<byte> Bytes = new List<byte>();
                Bytes.WholeAdding(strRemote);
                ReceivedFile Model = ConvertFileModel(Bytes.ToArray());
                NameFile = Model.FileName;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                FileStream fs = File.Create(path+ Model.FileName);
               // Byte[] info = new ASCIIEncoding().GetBytes(Model.FileContent);
                Byte[] info = Model.FileContent;
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
            finally
            {
                strRemote.Close();
                //StartReceiving( ipa, path, send_port);
            }
        }
        private static ReceivedFile ConvertFileModel(byte[] DBytes)
        {
            try
            {
                
                string FullData = Encoding.ASCII.GetString(DBytes);
                ReceivedFile File = new ReceivedFile();
                
                int FinishedIndex;
                File.FileName = GetSelected(FullData, 0, '&', out FinishedIndex);
                File.FileSize = GetSelected(FullData, FinishedIndex + 1, '&', out FinishedIndex);
                //File.FileContent = FullData.Substring(FinishedIndex + 1);
                int tt = DBytes.Length - (FinishedIndex + 1);
                DataContent = new byte[tt];
                Array.Copy(DBytes, FinishedIndex + 1, DataContent, 0, tt);
                File.FileContent = DataContent;
                return File;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private static string GetSelected(string Data, int Started, char Finished, out int FinishedIndex)
        {
            for (int i = Started; i < Data.Length; i++)
            {
                if (Data[i].Equals(Finished))
                {
                    FinishedIndex = i;
                    string Sub = Data.Substring(Started, (i - Started));
                    return Sub;
                }
            }
            FinishedIndex = -1;
            return null;
        }
        private void getDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                directory.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void genKey_Click(object sender, EventArgs e)
        {
            if (ipadress.Text != "")
            {
                genkey(out  _Ekey, out  _Nkey, out  _Pkey, out  _Qkey, out  _Phikey, out  _NODkey, out  _Dkey, out  _Ykey);
                Pkey.Text += Convert.ToString(_Pkey);
                Qkey.Text += Convert.ToString(_Qkey);
                Nkey.Text += Convert.ToString(_Nkey);
                Phikey.Text += Convert.ToString(_Phikey);
                Ekey.Text += Convert.ToString(_Ekey);
                NODkey.Text += Convert.ToString(_NODkey);
                Dkey.Text += Convert.ToString(_Dkey);
                Ykey.Text += Convert.ToString(_Ykey);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Any;
                IPEndPoint ipe = new IPEndPoint(ip, keyport);
                end = (EndPoint)ipe;
                socket.Bind(ipe);
                socket.Listen(1);
                logs.Text += "  Порт в режиме ожидания соединения\n";
                new Connect(delegate() { Conect(); }).BeginInvoke(null, null);
                timer1.Enabled = true;
                }
            else { logs.Text += "Неправильный IP\r\n"; }
      
        }
        public void listener() {//не нужен
            // получаем адреса для запуска сокета
             IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ipadress.Text), keyport);
            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(1);
                genkey(out  _Ekey, out  _Nkey, out  _Pkey, out  _Qkey, out  _Phikey, out  _NODkey, out  _Dkey, out  _Ykey);
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => Pkey.Visible = true));
                    this.Invoke(new Action(() => Qkey.Visible = true));
                    this.Invoke(new Action(() => Nkey.Visible = true));
                    this.Invoke(new Action(() => Phikey.Visible = true));
                    this.Invoke(new Action(() => Ekey.Visible = true));
                    this.Invoke(new Action(() => NODkey.Visible = true));
                    this.Invoke(new Action(() => Dkey.Visible = true));
                    this.Invoke(new Action(() => Ykey.Visible = true));
                }
                else
                {
                    Pkey.Visible = true;
                    Qkey.Visible = true;
                    Nkey.Visible = true;
                    Phikey.Visible = true;
                    Ekey.Visible = true;
                    NODkey.Visible = true;
                    Dkey.Visible = true;
                    Ykey.Visible = true;
                }
                
                //logs.Text += "Сервер запущен. Ожидание подключений...\r\n";
                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных
                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);
                    BigInteger[] message = new BigInteger[] { _Ekey, _Nkey };
                    data = message.Select(i => (byte)i).ToArray();//Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        private void Conect()
        {
            
            client = socket.Accept();
            StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[2048]; // буфер для получаемых данных
                    do
                    {
                        bytes = client.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (client.Available > 0);
                    data = _Ekey.ToByteArray(); Thread.Sleep(100);
                    client.Send(data);
                    data = _Nkey.ToByteArray(); Thread.Sleep(100);
                    client.Send(data);
                    data = _Dkey.ToByteArray(); Thread.Sleep(100);
                    client.Send(data);
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        void genkey(out BigInteger _Ekey, out BigInteger _Nkey, out BigInteger _Pkey, out BigInteger _Qkey, out BigInteger _Phikey, out BigInteger _NODkey, out BigInteger _Dkey, out BigInteger _Ykey)
        {
            RSACryptoServiceProvider testRSA = new RSACryptoServiceProvider(1024);
            Random rnd = new Random();
            _Pkey = new BigInteger(testRSA.ExportParameters(true).P.Reverse().Concat(new byte[] { 0x00 }).ToArray());
            _Qkey = new BigInteger(testRSA.ExportParameters(true).Q.Reverse().Concat(new byte[] { 0x00 }).ToArray());
             _Nkey = _Pkey * _Qkey;
            _Phikey = (_Pkey - 1) * (_Qkey - 1);
            _Ekey = 65537;
            BigInteger ddkey;
            _NODkey = IteratGCD(_Ekey, _Phikey, out ddkey, out _Ykey);
            _Dkey = ddkey;
            if (ddkey < 0)   
            {
                _Dkey = _Phikey + ddkey; 
            }
           
        }
        double Gcd(double a, double b, out double x, out double y)
        {
            {
                if (b < a)
                {
                    var t = a;
                    a = b;
                    b = t;
                }

                if (a == 0)
                {
                    x = 0;
                    y = 1;
                    return b;
                }

                double gcd = Gcd(b % a, a, out x, out y);

                double newY = x;
                double newX = y - (b / a) * x;

                x = newX;
                y = newY;
                return gcd;
            }

        }
        private void GetCryptFile_Click(object sender, EventArgs e)
        {
            //принятие файла 
            thrDownload = new Thread(() => StartReceiving(ipadress.Text, directory.Text, sendport));
            thrDownload.Start();
            thrDownload.Join();
            logs.Text += "Завершено, проверьте файл\r\nГотово к новому запуску\r\n";
            // принятие закончено 

            
            try
            {
            //Aes myAes = Aes.Create();
            int rrr = superkey1.ToByteArray().Length;
            //myAes.Key = superkey1.ToByteArray();
            encMessage = File.ReadAllBytes(directory.Text + "/" + NameFile);

            var rijndael = new RijndaelManaged();
            
                byte[] tmp2 = superkey1.ToByteArray();
                for (int i = 0; i < 32; i++) { tmp[i] = tmp2[i]; }//т..к размер ключа 32, а не 33
                rijndael.Key = tmp;
                rijndael.IV = inivector;
                decMessage = DecryptBytes(rijndael, encMessage);
            
           
            File.WriteAllBytes(directory.Text + NameFile, decMessage);
           
            thrDownload.Abort();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        BigInteger IteratGCD(BigInteger a, BigInteger b, out BigInteger dx, out BigInteger dy)
        {	/* calculates a * *x + b * *y = gcd(a, b) = *d */
            BigInteger q, r, x1, x2, y1, y2;
            if (b == 0) //если один из множителей равен 0
            {
                dx = 1; dy = 0;
                return a;
            }
            x2 = 1; x1 = 0; y2 = 0; y1 = 1;

            while (b > 0)
            {
                q = a / b;
                r = a - q * b;
                dx = x2 - q * x1;
                dy = y2 - q * y1;
                //промежуточный вывод
                a = b; b = r;
                x2 = x1; x1 = dx; y2 = y1; y1 = dy;

            }	//end while (b>0)

            dx = x2; dy = y2;
            return a;
        }
        private void button2_Click(object sender, EventArgs e)//СУПЕРКЛЮЧ ПОЛУЧЕНИЕ
        {
            client = socket.Accept();
            StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байтов
            byte[] superkey = new byte[129]; // буфер для получаемых данных
            do
            {
                bytes = client.Receive(superkey);
                builder.Append(Encoding.Unicode.GetString(superkey, 0, bytes));
            }
            while (client.Available > 0);
            Thread.Sleep(100);
            bytes = 0; // количество полученных байтов
            inivector = new byte[16]; // буфер для получаемых данных
            do
            {
                bytes = client.Receive(inivector);
                builder.Append(Encoding.Unicode.GetString(superkey, 0, bytes));
            }
            while (client.Available > 0);
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            newBigInt = new BigInteger(superkey);
             b_Nkey = _Nkey;
             b_Dkey = _Dkey;
            //while (superkey1.ToByteArray().Length != 32)
            //{
                 superkey1 = BigInteger.ModPow(newBigInt, b_Dkey, b_Nkey);
            //}
    logs.Text += "Суперключ принят =" + Convert.ToString(superkey1) + "\r\n";
            superkey11.Text = Convert.ToString(superkey1);
        }

        ///////тест метода из инета который работает! Используем его
        private static byte[] EncryptBytes(SymmetricAlgorithm alg, byte[] message)
        {
            if ((message == null) || (message.Length == 0))
            {
                return message;
            }

            if (alg == null)
            {
                throw new ArgumentNullException("alg");
            }

            using (var stream = new MemoryStream())
            using (var encryptor = alg.CreateEncryptor())
            using (var encrypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(message, 0, message.Length);
                encrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }
        private static byte[] DecryptBytes(SymmetricAlgorithm alg, byte[] message)
        {
            if ((message == null) || (message.Length == 0))
            {
                return message;
            }

            if (alg == null)
            {
                throw new ArgumentNullException("alg");
            }

            using (var stream = new MemoryStream())
            using (var decryptor = alg.CreateDecryptor())
            using (var encrypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(message, 0, message.Length);
                encrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }
        //////конец метода из инета
        // проверить размер зашифрованного текущего, проверить размер зашифрованного отправленного
        
    }

}
