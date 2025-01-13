using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimEfTravelDbEntities dbEntities = new EgitimEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values=dbEntities.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values=dbEntities.Guide.Select(x=>new
            {
                FullName=x.GuideName+" "+x.GuideSurname,x.GuideId
            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource= values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location=new Location();
            location.Capacity=byte.Parse(nudCapasity.Value.ToString());
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.Price=decimal.Parse(txtPrice.Text);
            location.DayNight=txtDayNight.Text;
            location.GuideId=int.Parse(cmbGuide.SelectedValue.ToString());
            dbEntities.Location.Add(location);
            dbEntities.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var deletedvalue = dbEntities.Location.Find(id);
            dbEntities.Location.Remove(deletedvalue);
            dbEntities.SaveChanges();
            MessageBox.Show("Sİlme işlemi başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var updatedvalue = dbEntities.Location.Find(id);
            updatedvalue.DayNight = txtDayNight.Text;
            updatedvalue.Price = decimal.Parse(txtPrice.Text);
            updatedvalue.Capacity=byte.Parse(nudCapasity.Value.ToString());
            updatedvalue.City=txtCity.Text;
            updatedvalue.Country=txtCountry.Text;
            updatedvalue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            dbEntities.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}
