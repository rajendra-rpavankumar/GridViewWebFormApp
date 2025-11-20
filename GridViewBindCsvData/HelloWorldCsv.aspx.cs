using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridViewBindCsvData
{
    public partial class HelloWorldCsv : System.Web.UI.Page
    {
        private const string CsvData =
   @"Footnotes;;;;;;
1;This is the first footnote used for testing purposes;;;;;
2;This is another example entry;with;multiple;columns;;
3;Short note;;;;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCsvDataToGridView();
            }

        }

        private void BindCsvDataToGridView()
        {
            // Split the data into individual lines
            string[] lines = CsvData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length == 0) return;

            DataTable dt = new DataTable();

            // Determine the maximum number of columns across all rows for consistent column generation
            int maxColumns = lines.Max(line => line.Split(';').Length);

            // Create columns dynamically (e.g., Column 1, Column 2, ...)
            for (int i = 0; i < maxColumns; i++)
            {
                dt.Columns.Add($"Column {i + 1}", typeof(string));
            }

            // Populate the DataTable with row data
            foreach (string line in lines)
            {
                // Split each line by the semicolon delimiter
                string[] fields = line.Split(';');

                // Create a new row
                DataRow dr = dt.NewRow();

                // Fill the row with the field values, ensuring we don't exceed the column count
                for (int i = 0; i < fields.Length && i < maxColumns; i++)
                {
                    dr[i] = fields[i].Trim();
                }

                dt.Rows.Add(dr);
            }

            // Bind the DataTable to the GridView control
            GridViewData.DataSource = dt;
            GridViewData.DataBind();
        }

        protected void btnShowFootote_Click(object sender, EventArgs e)
        {
            // Split the data into lines
            string[] lines = CsvData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // The 'first footnote line' is the second line (index 1) in the CSV, as the first line is the header ("Footnotes")
            if (lines.Length > 1)
            {
                // The required output is the content of this row
                string footnoteLine = lines[1].Trim();

                // For a cleaner display, split and take only the main content (second field)
                string[] fields = footnoteLine.Split(';');
                string content = fields.Length > 1 ? fields[1].Trim() : footnoteLine;

                // Display the content in the label
                lblFootnote.Text = $"{content}";
                //lblFootnote.Text = $"Footnote Content: {footnoteLine}";
                //LabelFootnote.Text = $"Footnote Content: **{content}**";
            }
            else
            {
                lblFootnote.Text = "No footnote data available.";
                // LabelFootnote.Text = "No footnote data available.";
            }
        }
    }
}