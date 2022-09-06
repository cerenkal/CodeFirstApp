using DataAccess.ConcreteRepository;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Form1 : Form
    {
        private CodeFirstDBContext _codeFirstDBContext;
        private SchoolRepository _schoolRepository;
        private TeacherRepository _teacherRepository;
        public Form1()
        {
            _codeFirstDBContext = new CodeFirstDBContext();
            _schoolRepository = new SchoolRepository(_codeFirstDBContext);
            _teacherRepository = new TeacherRepository(_codeFirstDBContext);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            School eklenecekOkul = new School();
            eklenecekOkul.Name = txtSchoolName.Text;
            eklenecekOkul.NumberOfEmployee = Convert.ToInt32(txtNumberOfEmploye.Text);
            eklenecekOkul.NumberOfStudent = Convert.ToInt32(txtNumberOfStudent.Text);
            _schoolRepository.Add(eklenecekOkul);
            Clear();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _schoolRepository.GetAll();
        }
        int aranacakOkulID;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            aranacakOkulID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var silinecekOkul = _schoolRepository.GetById(aranacakOkulID);
            silinecekOkul.DeletedDate = DateTime.Now;
            _schoolRepository.Delete(silinecekOkul);
            dataGridView1.DataSource = _schoolRepository.GetAll();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var guncellenecekOkul = _schoolRepository.GetById(aranacakOkulID);
            guncellenecekOkul.Name = txtSchoolName.Text;
            guncellenecekOkul.NumberOfStudent = Convert.ToInt32(txtNumberOfStudent.Text);
            guncellenecekOkul.NumberOfEmployee = Convert.ToInt32(txtNumberOfEmploye.Text);
            guncellenecekOkul.ModifiedDate = DateTime.Now;
            guncellenecekOkul.ModifiedBy = "Ceren Kal";
            _schoolRepository.Update(guncellenecekOkul);
            dataGridView1.DataSource = _schoolRepository.GetAll();
            Clear();
        }
        private void Clear()
        {
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = " ";
                }
            }
        }
    }
}
