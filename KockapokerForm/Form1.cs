using KockapokerForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KockapokerForm
{
    public partial class frmFo : Form
    {
        private Dobas gep;
        private Dobas ember;


        public frmFo()
        {
            InitializeComponent();

            gep = new Dobas();
            ember = new Dobas();
        }

        private void KepElhelyez(PictureBox pb, int szam)
        {
            switch (szam)
            {
                case 1:
                    pb.Image = Resources.egy;
                    break;
                case 2: pb.Image = Resources.ketto;
                    break;
                case 3: pb.Image = Resources.harom;
                    break;
                case 4: pb.Image = Resources.negy;
                    break;
                case 5: pb.Image = Resources.ot;
                    break;
                case 6: pb.Image = Resources.hat;
                    break;

                default:
                    break;
            }
        }

        private void DobasMegjelenit(Dobas d)
        {
            KepElhelyez(pbGep1, d.Kockak[0]);
            KepElhelyez(pbGep2, d.Kockak[1]);
            KepElhelyez(pbGep3, d.Kockak[2]);
            KepElhelyez(pbGep4, d.Kockak[3]);
            KepElhelyez(pbGep5, d.Kockak[4]);
        }

        private void btnDobas_Click(object sender, EventArgs e)
        {
            gep.EgyDobas();
            ember.EgyDobas();

            DobasMegjelenit(gep);
        }
    }
}
