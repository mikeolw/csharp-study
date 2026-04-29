using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TextBox의 텍스트를 가져옴
            string task = txtInput.Text;
            //TextBox가 비어있는지 확인
            if(string.IsNullOrEmpty(task)) {      
                MessageBox.Show("할 일을 입력해주세요.", "알림");
                return;
            }
            //ListBox에 가져온 텍스트 추가
            lstTasks.Items.Add(task);
            //TextBox 비우기
            txtInput.Clear();
        }
    }
}
