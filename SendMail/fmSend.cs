using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SendMail
{
    public partial class fmSend : Form
    {
        public fmSend()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send sMail = new Send();
            sMail.sendMail(txtFrom.Text, txtTo.Text, txtSubject.Text, txtText.Text,txtPasswordMail.Text);
            cls();
        }
        void cls()
        {
            txtFrom.Clear();
            txtTo.Clear();
            txtSubject.Clear();
            txtText.Clear();
            txtPasswordMail.Clear();
        }

        private void fmSend_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
