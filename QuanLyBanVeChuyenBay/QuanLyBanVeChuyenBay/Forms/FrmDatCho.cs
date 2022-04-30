﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanVeChuyenBay.Forms
{
    public partial class FrmDatCho : Form
    {
        public FrmDatCho()
        {
            InitializeComponent();
        }

        private void pictureBoxNgayDatVe_Click(object sender, EventArgs e)
        {
            FrmCalendar calendarForm = null;

            try
            {
                // decide to pass a date time or not
                calendarForm = DateTime.TryParse(textBoxNgayDatVe.Text, out var currentDateTime) ?
                    new FrmCalendar(currentDateTime) :
                    new FrmCalendar();

                // reposition to be next to calendar button
                calendarForm.Location = new Point(Left + (Width - 100), Bottom - 80);

                calendarForm.DateTimeHandler += CalendarFormOnDateTimeHandlerNgaySinh;
                calendarForm.ShowDialog();

            }
            finally
            {
                calendarForm.DateTimeHandler -= CalendarFormOnDateTimeHandlerNgaySinh;
                calendarForm.Dispose();
            }
        }

        private void CalendarFormOnDateTimeHandlerNgaySinh(DateTime sender)
        {
            textBoxNgayDatVe.Text = $"{sender.ToString("MM-dd-yyyy")}";
        }

        private void buttonTaoMoi_Click(object sender, EventArgs e)
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(TextBox))
                {
                    TextBox txb = (TextBox)btns;
                    txb.Text = "";
                }
            }
        }

        private void pictureBoxNgayBay_Click(object sender, EventArgs e)
        {
            FrmCalendar calendarForm = null;

            try
            {
                // decide to pass a date time or not
                calendarForm = DateTime.TryParse(textBoxNgay.Text, out var currentDateTime) ?
                    new FrmCalendar(currentDateTime) :
                    new FrmCalendar();

                // reposition to be next to calendar button
                calendarForm.Location = new Point(Left + (Width - 100), Bottom - 80);

                calendarForm.DateTimeHandler += CalendarFormOnDateTimeHandlerNgayBay;
                calendarForm.ShowDialog();

            }
            finally
            {
                calendarForm.DateTimeHandler -= CalendarFormOnDateTimeHandlerNgayBay;
                calendarForm.Dispose();
            }
        }

        private void CalendarFormOnDateTimeHandlerNgayBay(DateTime sender)
        {
            textBoxNgay.Text = $"{sender.ToString("MM-dd-yyyy")}";
        }
    }
}
