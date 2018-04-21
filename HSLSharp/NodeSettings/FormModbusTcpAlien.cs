﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSLSharp.Configuration;

namespace HSLSharp.NodeSettings
{
    public partial class FormModbusTcpAlien : Form
    {
        public FormModbusTcpAlien( ModbusTcpAline modbusTcpAline )
        {
            InitializeComponent( );

            ModbusTcpAline = modbusTcpAline;
            Icon = Util.GetWinformICon( );
        }

        private void FormModbusTcpAlien_Load( object sender, EventArgs e )
        {
            if(ModbusTcpAline != null)
            {
                textBox1.Text = ModbusTcpAline.Name;
                textBox2.Text = ModbusTcpAline.Description;
                textBox3.Text = ModbusTcpAline.DTU;
                textBox5.Text = ModbusTcpAline.Station.ToString( );
                checkBox1.Checked = !ModbusTcpAline.IsAddressStartWithZero;
            }
        }





        public ModbusTcpAline ModbusTcpAline { get; set; }

        private void userButton1_Click( object sender, EventArgs e )
        {
            if(!byte.TryParse(textBox5.Text,out byte station))
            {
                MessageBox.Show( "站号的输入失败！" );
                return;
            }

            ModbusTcpAline = new ModbusTcpAline( )
            {
                Name = textBox1.Text,
                Description = textBox2.Text,
                DTU = textBox3.Text,
                Station = station,
                IsAddressStartWithZero = !checkBox1.Checked,
            };

            DialogResult = DialogResult.OK;

        }




    }
}