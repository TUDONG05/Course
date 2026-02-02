using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataUtil data = new DataUtil();
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
            dataGridView1.DataSource = data.GetAllStudent();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            count.Text =dataGridView1.Rows.Count+"";

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.id = textID.Text;
            s.name = textName.Text;
            s.age = textAge.Text;
            s.city = textCity.Text;
            data.AddStudent(s);
            ClearTextBoxs();
            DisplayData();
        }

        private void ClearTextBoxs()
        {
            textID.Clear();
            textName.Clear();
            textAge.Clear();
            textCity.Clear();
   
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void getAStudent(object sender, DataGridViewCellEventArgs e)
        {
            Student s = (Student)dataGridView1.CurrentRow.DataBoundItem;
            textID.Text = s.id;
            textName.Text = s.name;
            textAge.Text = s.age;
            textCity.Text = s.city;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            Student s = new Student();
            s.id = textID.Text;
            s.name = textName.Text;
            s.age = textAge.Text;
            s.city = textCity.Text;

            bool kt = data.UpdateStudent(s);
            if(!kt)
            {
                MessageBox.Show("Không cập nhật được sinh viên có ID = " + s.id);
                return;
            }
            DisplayData();
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if(d == DialogResult.Yes)
            {
                bool kt = data.DeleteStudent(textID.Text);
                if (!kt)
                {
                    MessageBox.Show("Có lỗi khi xóa", "Thông báo");
                    return;
                }
                DisplayData();
                ClearTextBoxs();

            }    
        }

        private void buttonFindByID_Click(object sender, EventArgs e)
        {
            string id = textID.Text;
            List<Student> ds = new List<Student>();
            Student s = data.FindByID(id);
            if(s!= null)
            {
                ds.Add(s);
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên có id =" + id);
                return;
            }

            dataGridView1.DataSource = ds;
            count.Text = dataGridView1.Rows.Count + "";
            textID.Text = s.id;
            textName.Text = s.name;
            textAge.Text = s.age;
            textCity.Text = s.city;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            count.Text = dataGridView1.Rows.Count + "";
        }

        private void buttonFindByCity_Click(object sender, EventArgs e)
        {
            string city = textCity.Text;
            List<Student> ds = new List<Student>();
            Student s = data.FindByCity(city);
            if (s != null)
            {
                ds.Add(s);
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên có city =" + city);
                return;
            }

            dataGridView1.DataSource = ds;
            count.Text = dataGridView1.Rows.Count + "";
            textID.Text = s.id;
            textName.Text = s.name;
            textAge.Text = s.age;
            textCity.Text = s.city;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            count.Text = dataGridView1.Rows.Count + "";
        }
    }
}
