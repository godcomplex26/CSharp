﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teamProject
{
    public class Utils
    {
        // 데이터 표시 포맷, 시간은 초까지, 소수점은 두 자리까지 - P or QData(Form2, 3)
        public void Format(DataGridView dgv, string data)
        {
            if(data.Equals)
            // 날짜 설정
            dgv.Columns["datetime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            // 소수점 이하 두 자리까지만 표시되도록 설정
            string[] columns = { "ReactA_Temp", "ReactB_Temp", "ReactC_Temp", "ReactD_Temp", "ReactE_Temp",
            "ReactF_Temp", "ReactF_PH", "Power", "CurrentA", "CurrentB","CurrentC"};
            for (int i = 0; i < columns.Length; i++)
            {
                dgv.Columns[columns[i]].DefaultCellStyle.Format = "N2";
            }

            if (data.Equals("QData"))
            {
                // 날짜 설정
                dgv.Columns["date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                // 소수점 이하 두 자리까지만 표시되도록 설정
                string[] columns2 = { "weight", "water", "material", "HSO", "pH" };
                for (int i = 0; i < columns2.Length; i++)
                {
                    dgv.Columns[columns2[i]].DefaultCellStyle.Format = "N2";
                }
            }
        }

        // 데이터 표시 포맷, 시간은 초까지, 소수점은 두 자리까지 - 2개(Form1)
        public void Format(DataGridView dgv1, DataGridView dgv2)
        {
            dgv1.Columns["datetime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgv2.Columns["date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            // gridview1 소수점 이하 두 자리까지만 표시되도록 설정
            string[] columns = { "ReactA_Temp", "ReactB_Temp", "ReactC_Temp", "ReactD_Temp", "ReactE_Temp",
            "ReactF_Temp", "ReactF_PH", "Power", "CurrentA", "CurrentB","CurrentC"};
            for (int i = 0; i < columns.Length; i++)
            {
                dgv1.Columns[columns[i]].DefaultCellStyle.Format = "N2";
            }

            // gridview2 소수점 이하 두 자리까지만 표시되도록 설정
            string[] columns2 = { "weight", "water", "material", "HSO", "pH" };
            for (int i = 0; i < columns2.Length; i++)
            {
                dgv2.Columns[columns2[i]].DefaultCellStyle.Format = "N2";
            }
        }

        // 화면 리프레시 - 1개(Form2, 3)
        public void reScreen(DataGridView dgv)
        {
            dgv.DataSource = null;
            DataManager.Load();
            if (DataManager.datas.Count > 0)
            {
                dgv.DataSource = DataManager.datas;
                Format(dgv);
            }
        }

        // 화면 리프레시 - 2개(Form1)
        public void reScreen(DataGridView dgv1, DataGridView dgv2)
        {
            dgv1.DataSource = null;
            dgv2.DataSource = null;
            DataManager.Load();
            if (DataManager.datas.Count > 0)
            {
                dgv1.DataSource = DataManager.datas;
                dgv2.DataSource = DataManager.datas2;
                Format(dgv1, dgv2);
            }
        }

        public static string sqlQueryConverter(string text)
        {
            string query = "";
            string pattern = @"BETWEEN\((.+?),(.+?)\)";

            char[] separators = { ';' };

            List<string> resultList = text.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                                  .ToList();

            for (int i = 0; i < resultList.Count; i++)
            {
                Match match = Regex.Match(resultList[i], pattern);
                string tempQ;

                if (match.Success)
                {
                    string value1 = match.Groups[1].Value;
                    string value2 = match.Groups[2].Value;
                    string value3 = match.Groups[3].Value;
                    tempQ = Between(value1, value2, value3);
                }
                else
                {
                    tempQ = resultList[i].ToString();
                }

                if (i == resultList.Count - 1)
                {
                    // 마지막 항목에 대한 처리
                    query += tempQ;
                }
                else
                {
                    // 마지막 항목이 아닌 경우에 대한 처리
                    query += tempQ + " AND ";
                }
            }
            return query;
        }

        delegate int Operation(int a, int b);

        static string Between(string q, string a, string b)
        {
            return $"{q} BETWEEN {a} AND {b}";
        }
    }
}