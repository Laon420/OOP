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

namespace Notepad
{
    public partial class Form1 : Form
    {
        private string fileName = "noname.txt";
        bool modifyFlag = false;
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        #region 변경내용확인
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            modifyFlag = true; // 변경 내용있을때 true
        }
        #endregion
        #region 새로만들기
        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileProcessBeforeClose();

            richTextBox1.Text = "";
            modifyFlag = false;
            fileName = "noname.txt";
        }

        private void FileProcessBeforeClose()
        {
            if (modifyFlag = true)
            {
                Save();
            }
        }
        #endregion
        #region 열기

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileProcessBeforeClose();
                
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName;
            if (fileName != "")
            {
                StreamReader r = File.OpenText(fileName);
                richTextBox1.Text = r.ReadToEnd();

                modifyFlag = false;
                r.Close();
            }

        }
        #endregion
        #region 저장
        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            saveFileDialog1.Filter = "txt file(*.txt)|*.txt"; // 저장할때 파일 형식 지정 ( 이름만 치면 바로 txt로 저장)
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // ok 눌렀을때만 저장
            {
                fileName = saveFileDialog1.FileName; // 설정한 파일 이름을 가져옴

                if (fileName != "") //설정한 파일 이름이 빈공간이 아닐경우 
                {
                    StreamWriter sw = File.CreateText(fileName);
                    sw.WriteLine(richTextBox1.Text);

                    modifyFlag = false;
                    sw.Close();
                }
            }
        }
        #endregion
        #region 종료
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileProcessBeforeClose();
            Close();
        }
        #endregion
        #region 붙여넣기
        private void 붙여넣기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox contents = (RichTextBox)ActiveControl;
            if (contents != null)
            {
                IDataObject data = Clipboard.GetDataObject();
                contents.SelectedText = data.GetData(DataFormats.Text).ToString();
                modifyFlag = true;
            }
        }
        #endregion
        #region 복사
        private void 복사ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox contents = (RichTextBox)ActiveControl;
            if (contents != null)
            {
                Clipboard.SetDataObject(contents.SelectedText);
                MessageBox.Show(contents.SelectedText);
            }
        }
        #endregion
        #region 정보
        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fabout f = new fabout();
            f.ShowDialog();
        }
        #endregion

        #region 찾기
        private void 찾기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search s = new Search(this);
            s.Show();
        }
        #endregion
    }
}
