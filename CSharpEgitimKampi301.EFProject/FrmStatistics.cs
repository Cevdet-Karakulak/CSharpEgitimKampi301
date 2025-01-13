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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimEfTravelDbEntities db=new EgitimEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCountry.Text = db.Location.Count().ToString();
            lblSumCapacity.Text=db.Location.Sum(x=>x.Capacity).ToString();
            lblGuideCount.Text=db.Guide.Count().ToString();
            lblAvgCapacity.Text=db.Location.Average(x=>x.Capacity).ToString();
            decimal avgLocationPrice = decimal.Parse(db.Location.Average(x => x.Price).ToString());
            lblAvgLocationPrice.Text = avgLocationPrice.ToString("0.00") + " ₺";
            int lastcountryId=db.Location.Max(x=>x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastcountryId).Select(y => y.Country).FirstOrDefault();
            lblCappadociaLocationCapacity.Text=db.Location.Where(x=>x.City== "Kapadokya").Select(y=>y.Capacity).FirstOrDefault().ToString();
            lblTürkiyeCapacityAvg.Text=db.Location.Where(x=>x.Country=="Türkiye").Average(y=>y.Capacity).ToString();

            var romeGuideId=db.Location.Where(x=>x.City== "Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text=db.Guide.Where(x=>x.GuideId==romeGuideId).Select(y=>y.GuideName + " "+y.GuideSurname).FirstOrDefault().ToString();

            var maximumCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text=db.Location.Where(x=>x.Capacity==maximumCapacity).Select(y=>y.City).FirstOrDefault().ToString();

            var maximumPrice=db.Location.Max(x=>x.Price);
            lblMostExpensiveTour.Text=db.Location.Where(x=>x.Price==maximumPrice).Select(y=>y.City).FirstOrDefault().ToString();

            var guideIdByAysegul=db.Guide.Where(x=>x.GuideName== "Ayşegül"&& x.GuideSurname== "Çınar").Select(y=>y.GuideId).FirstOrDefault();
            lblAysegulLocationPrompt.Text = db.Location.Where(x => x.GuideId == guideIdByAysegul).Count().ToString();


        }
    }
}
