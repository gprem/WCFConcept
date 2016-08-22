using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Proplanner.ServiceModel;
using ProLINK.Data;
using ProLINK.Data.Entity;
using Proplanner;
using System.ServiceModel;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                       

            //int count = Service<IProcess>.Execute(proxy => proxy.GetRoutingCount("GPL", "M"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Routing r = Service<IProcess>.Execute(proxy => proxy.GetRouting("1023"));

                this.propertyGrid1.SelectedObject = r;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChannelFactory<IProcess> myChannelFactory = new ChannelFactory<IProcess>("IIS_IProcess");
            myChannelFactory.CreateChannel().GetRouting("123");

        }
    }
}
