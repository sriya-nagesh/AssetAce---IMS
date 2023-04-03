using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using MouveForm;

namespace AssetAce
{
    public partial class OrderReport : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private int rowCount,columnCount,currentPage = 0;
        private float leftMargin = 10,topMargin = 10,bottomMargin = 10,rowHeight = 0;
        private Font font;
        public OrderReport()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            float yPos = topMargin;

            DataGridViewRow headerRow = dgv_report.Rows[0];

            float xPos = leftMargin;

            for (int i = 0; i < columnCount; i++)
            {
                string header = headerRow.Cells[i].FormattedValue.ToString();
                SizeF size = e.Graphics.MeasureString(header, font);
                RectangleF rect = new RectangleF(xPos, yPos, dgv_report.Columns[i].Width, rowHeight);
                e.Graphics.DrawString(header, font, Brushes.Black, rect);
                xPos += dgv_report.Columns[i].Width;
            }

            yPos += rowHeight;

            while (currentPage < rowCount)
            {
                DataGridViewRow row = dgv_report.Rows[currentPage];

                xPos = leftMargin;

                for (int i = 0; i < columnCount; i++)
                {
                    string value = row.Cells[i].FormattedValue.ToString();
                    SizeF size = e.Graphics.MeasureString(value, font);

                    if (size.Height > rowHeight)
                    {
                        rowHeight = size.Height;
                    }

                    RectangleF rect = new RectangleF(xPos, yPos, dgv_report.Columns[i].Width, rowHeight);
                    e.Graphics.DrawString(value, font, Brushes.Black, rect);

                    xPos += dgv_report.Columns[i].Width;
                }

                yPos += rowHeight;

                if (yPos + rowHeight > e.MarginBounds.Bottom - bottomMargin)
                {
                    e.HasMorePages = true;
                    currentPage++;
                    return;
                }

                currentPage++;
            }

            e.HasMorePages = false;
        }

        private void OrderReport_Load(object sender, EventArgs e)
        {
            MouveForm.Mouve.Go(panel_header);
            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");

            string query = "SELECT * FROM Orders";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Bind the DataTable to a DataGridView
            dgv_report.DataSource = dataTable;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True"))
            {
                DateTime start = dtp_sdate.Value;
                DateTime end = dtp_edate.Value;

                string startDateString = start.ToString("yyyy-MM-dd");
                string endDateString = end.ToString("yyyy-MM-dd");

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE OrderTime BETWEEN '" + startDateString + "' AND '" + endDateString + "'", con);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgv_report.DataSource = dt;
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            rowCount = dgv_report.Rows.Count;
            columnCount = dgv_report.Columns.Count;
            currentPage = 0;
            font = dgv_report.Font;
            rowHeight = font.GetHeight() + 5;

            printPreviewDialog.ShowDialog();
        }

    }
}
