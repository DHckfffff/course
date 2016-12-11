﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _183DataSet演示
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1.创建一个临时数据库
            DataSet ds = new DataSet("School");

            //2.创建一个临时表
            DataTable dt = new DataTable("Student");

            //2.1增加列 自动编号
            DataColumn dcAutoId = new DataColumn("autoId");
            dcAutoId.AutoIncrement = true;//设置自动编号
            dcAutoId.AutoIncrementSeed = 1;//自动编号种子从1开始
            dcAutoId.AutoIncrementStep = 1;//每次自动增长1
            dt.Columns.Add(dcAutoId);//将dcAutoId列增加到dt表中

            //2.2增加列 用户名
            dt.Columns.Add("loginId", typeof(string));
            dt.Columns[0].Unique = true;//设置列唯一

            //2.3增加列 密码
            dt.Columns.Add("loginPwd", typeof(string));

            //连续创建10行
            for (int i = 0; i < 10; i++)
            {
                //3为DataTable中增加一些行
                //创建DataRow时，我们自己不能new，需要调用DataTable的NewRow()方法来创建（DataRow dr = new DataRow();）
                DataRow dr = dt.NewRow();//增加行
                dr[1] = "zxh";//增加 第一列第一行的值，因为[0]是表的列，索引从[1]开始
                dr[2] = "zxh1234567";
                dt.Rows.Add(dr);
            }

            //3.将DataTable加到DataSet中
            ds.Tables.Add(dt);

            dataGridView1.DataSource = ds.Tables[0];//数据源是ds数据库tables[0]第0张表
        }
    }
}
