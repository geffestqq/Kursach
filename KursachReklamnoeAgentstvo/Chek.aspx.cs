using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KursachReklamnoeAgentstvo
{
    public partial class Chek : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBconnection.qrChek;
            {
                gvFill(QR);
            }
        }
        private void gvFill(string qr)
        {
            sdsChek.ConnectionString =
            DBconnection.connection.ConnectionString.ToString();
            sdsChek.SelectCommand = qr;
            sdsChek.DataSourceMode = SqlDataSourceMode.DataReader;
            gvChek.DataSource = sdsChek;
            gvChek.DataBind();
        }


        DBprocedure procedures = new DBprocedure();
        protected void gvChek_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void gvChek_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //Verify that the control is rendered
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Employees.doc");
            Response.ContentType = "application/word";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            gvChek.HeaderRow.Style.Add("background-color", "#FFFFFF");
            gvChek.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Employees.xls");
            Response.ContentType = "application/excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            gvChek.HeaderRow.Style.Add("background-color", "#FFFFFF");
            gvChek.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
        
            PdfPTable pdfTable = new PdfPTable(gvChek.HeaderRow.Cells.Count);
            foreach (GridViewRow gridViewRow in gvChek.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfTable.AddCell(pdfCell);
                }
            }

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(pdfTable);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename= Air.pdf");
            Response.Write(pdfDoc);
            Response.Flush();
            Response.End();
        }
    }
}