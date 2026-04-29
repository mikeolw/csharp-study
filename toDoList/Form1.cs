using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            string filePath = "tasks.txt";
            //파일이 존재하는지 확인
            if(File.Exists(filePath))
            {
                //중복방지
                lstTasks.Items.Clear();
                string[] savedItems = File.ReadAllLines(filePath);
                lstTasks.Items.AddRange(savedItems);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //리스트 박스에서 마우스로 선택된 번호(인덱스)를 가져옴
            //아무것도 선택하지 않으면 -1이 반환됨
            int selectedIndex = lstTasks.SelectedIndex;
            //항목을 선택했는지 확인
            if(selectedIndex!=-1)
            {
                //선택된 번호의 항목 삭제
                lstTasks.Items.RemoveAt(selectedIndex);
            }
            else
            {
                //선택을 안 하고 삭제를 눌렀을 때 알림
                MessageBox.Show("삭제할 항목을 먼저 선택해 주세요", "알림");

            }
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

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            //엔터 키가 눌렸는지 확인
            if(e.KeyCode == Keys.Enter)
            {
                //엔터 키가 눌렸을때 추가 버튼의 기능을 동일하게 실행시킴
                btnAdd_Click(sender, e);

                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //저장할 파일 경로 설정
            string filePath = "tasks.txt";

            //ListBox의 모든 항목을 문자열 리스트로 변환
            List<string> items = new List<string>();
            foreach(var item in lstTasks.Items)
            {
                items.Add(item.ToString());
            }
            //문자열 리스트를 파일에 저장
            File.WriteAllLines(filePath, items);

            MessageBox.Show("안전하게 저장되었습니다", "완료");
        }
    }
}
