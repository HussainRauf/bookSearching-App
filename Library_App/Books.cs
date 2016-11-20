using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Library_App
{

    class Books
    {

        public static DataTable createBooks()
        {
            
            DataTable booksTable = new DataTable("tblBooks");

            DataColumn column1 = new DataColumn();
            column1.DataType = System.Type.GetType("System.Int32");
            column1.ColumnName = "BookISBN";
            booksTable.Columns.Add(column1);
            booksTable.PrimaryKey = new DataColumn[] { column1 };

            DataColumn column2 = new DataColumn();
            column2.DataType = System.Type.GetType("System.String");
            column2.ColumnName = "BookName";

            DataColumn column3 = new DataColumn();
            column3.DataType = System.Type.GetType("System.String");
            column3.ColumnName = "AuthorName";

            DataColumn column4 = new DataColumn();
            column4.DataType = System.Type.GetType("System.String");
            column4.ColumnName = "BookGenre";

            DataColumn column5 = new DataColumn();
            column5.DataType = System.Type.GetType("System.String");
            column5.ColumnName = "BookPublished";

            booksTable.Columns.AddRange(new DataColumn[] { column2, column3, column4,column5 });

            booksTable.Rows.Add("0976002701", "Tales of Heroes and Angels", "Robert Tabor", "History & Criticism", "October 1, 2015");
            booksTable.Rows.Add("0672320886", "Microsoft(R) .NET XML Web Services", "Robert Tabor", "Hardware & DIY", "November 27, 2001");
            booksTable.Rows.Add("1448697050", "CreateSpace Independent Publishing Platform", "Marco Antonio Meggiolaro", "Hardware & DIY", "August 29, 2009");
            booksTable.Rows.Add("0735666059", "Querying Microsoft SQL Server 2012 ", " Dejan Sarka and Itzik Ben-Gan", "Networking & Cloud Computing", "August 29, 2009");

            return booksTable;

        }

    }
}
