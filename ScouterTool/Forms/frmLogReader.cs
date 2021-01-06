using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScouterTool.Forms
{
    public partial class frmLogReader : Form
    {
        private string selectedFile; 
        public frmLogReader()
        {
            InitializeComponent();
        }

        public string SelectedFile { get => selectedFile; set => selectedFile = value; }

        private Dictionary<string, string> dicLogs = new Dictionary<string, string>();
        private void btnReader_Click(object sender, EventArgs e)
        {
            string strForder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            if (Directory.Exists(strForder + @"\EVE\logs\Chatlogs"))
            {
                List<string> lstLog = Directory.GetFiles(strForder + @"\EVE\logs\Chatlogs", "本地_*", SearchOption.AllDirectories).ToList();
                Console.WriteLine("文件夹确定");
                dicLogs.Clear();
                foreach (string strFile in lstLog)
                {
                    dicLogs.Add(Path.GetFileNameWithoutExtension(strFile), strFile);
                    ckblLogs.Items.Add(Path.GetFileNameWithoutExtension(strFile),false);
                }

                

            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (ckblLogs.CheckedItems.Count <1)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EVE\logs\Chatlogs";
                dialog.RestoreDirectory = false;
                dialog.ShowDialog();

                SelectedFile = dialog.FileName;
            }
            else
            {
                SelectedFile = dicLogs[ckblLogs.CheckedItems[0].ToString()];

            }
            base.Close();
        }
    }
}
