using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_App
{
    public partial class Form1 : Form
    {
        public DataTable allBooks = null;

        public Form1()
        {
            InitializeComponent();

            Task.Run(() =>
                {
                    allBooks = Books.createBooks();
                }).Wait();
            cbAuthors.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string bookISBN = txtISBN.Text;

            if (string.IsNullOrEmpty(bookISBN) || string.IsNullOrWhiteSpace(bookISBN))
            {
                lblSearchError.Text = "Enter ISBN.";
            }
            else if (bookISBN.Length <= 9)
            {
                lblSearchError.Text = "ISBN length should be 10.";

            }
            else
            {
                Int32 isbn;
                bool isNumeric = Int32.TryParse(bookISBN, out isbn);
                if (isNumeric)
                {
                    DataRow dr = allBooks.AsEnumerable().SingleOrDefault(r => r.Field<Int32>("BookISBN") == Convert.ToInt32(isbn));

                    if (dr != null)
                    {
                        lblSearchError.Text = "";
                        MessageBox.Show(string.Format("Book Name : {1}{0}Author Name : {2}{0}Originally Published : {3}{0}Genre : {4}",
                            Environment.NewLine, dr["BookName"].ToString(), dr["AuthorName"].ToString(), dr["BookPublished"].ToString(),
                            dr["BookGenre"].ToString()));
                    }
                    else
                    {
                        lblSearchError.Text = "Record Not Found.";
                    }
                }
                else if (!isNumeric)
                {
                    lblSearchError.Text = "ISBN should be numeric.";
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DataRow[] row = allBooks.Select("BookGenre = '" + cbGenre.SelectedItem + "' AND AuthorName = '" + cbAuthors.SelectedItem + "' ");
            if (row != null)
            {
                foreach (DataRow dr in row)
                {
                    MessageBox.Show(string.Format("Book Name : {1}{0}Author Name : {2}{0}Originally Published : {3}{0}Genre : {4}{0}ISBN : {5}",
                           Environment.NewLine, dr["BookName"].ToString(), dr["AuthorName"].ToString(), dr["BookPublished"].ToString(),
                            dr["BookGenre"].ToString(), dr["BookISBN"].ToString()));
                }
            }

        }

        private void cbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] row = allBooks.Select("BookGenre = '" + cbGenre.SelectedItem + "'");
            if (row != null)
            {
                cbAuthors.Enabled = true;
                cbAuthors.Items.Clear();
                cbAuthors.Text = "Choose Author";
                foreach (DataRow dr in row)
                {
                    cbAuthors.Items.Add(dr["AuthorName"].ToString());
                }
            }
        }




    }
}
