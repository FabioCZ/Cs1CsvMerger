using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace GradeSheetMerger

{
    public partial class Form1 : Form
    {
        private readonly int ANumberColumnIndex = 3;
        private List<List<string>> cs1400Records;
        private List<List<string>> cs1405ExtractedRecords;
         
        private List<string> header1;
        private List<String> header2;
        private bool  isCommandLineMode;
          
        public Form1()
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                var args = Environment.GetCommandLineArgs();
                //Command line arguments - 1st is CS1400 file name, 2nd is CS1405 filename, 3rd is output filename
                parseCs1400File(args[1]);
                parseCs1405File(args[2]);
                writeResult(args[3]);
                isCommandLineMode = true;
            }
            else
            {
                InitializeComponent();
                isCommandLineMode = false;
            }
            cs1400Records = new List<List<string>>();
            cs1405ExtractedRecords = new List<List<string>>();
        }


        private void cs1400FileButton_Click(object sender, EventArgs e)
        {
            if (cs1400FileDialog.ShowDialog() == DialogResult.OK)
            {
                parseCs1400File(cs1400FileDialog.FileName);
            }
        }

        private void parseCs1400File(string filename)
        {
            cs1400Records.Clear();
            using (TextFieldParser parser = new TextFieldParser(cs1400FileDialog.FileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                header1 = parser.ReadFields()?.ToList();
                header2 = parser.ReadFields()?.ToList();
                while (!parser.EndOfData)
                {
                    //Processing row

                    var fields = parser.ReadFields();
                    cs1400Records.Add(fields.ToList());
                }
            }
        }

        private void cs1405FileButton_Click(object sender, EventArgs e)
        {
            if (cs1405FileDialog.ShowDialog() == DialogResult.OK)
            {
                parseCs1405File(cs1405FileDialog.FileName);

                if (resultSaveDialog.ShowDialog() == DialogResult.OK)
                {
                    writeResult(resultSaveDialog.FileName);

                    
                }

            }
        }

        private void parseCs1405File(string fileName)
        {
            cs1405ExtractedRecords.Clear();
            var noMatches = new List<string>();
            using (TextFieldParser parser = new TextFieldParser(fileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                //skip top 2 lines
                parser.ReadFields();
                parser.ReadFields();

                while (!parser.EndOfData)
                {

                    var fields = parser.ReadFields();
                    var match = from a in cs1400Records
                                where a[ANumberColumnIndex] == fields[ANumberColumnIndex]
                                select a;
                    if (match.Any())
                    {
                        cs1405ExtractedRecords.Add(match.First());
                    }
                    else
                    {
                        noMatches.Add(fields[ANumberColumnIndex]);
                    }
                }
                if (isCommandLineMode && noMatches.Any())
                {
                    foreach (var m in noMatches)
                    {
                        Console.WriteLine($"Could not find a match for {m}");
                    }
                }
                else if(noMatches.Any())
                {
                    var msg = $"Could not find a match for: {Environment.NewLine}";
                    foreach (var m in noMatches)
                    {
                        msg += $"{m}{Environment.NewLine}";
                    }
                    MessageBox.Show(msg);
                }
            }
        }

        private void writeResult(string fileName)
        {
            cs1405ExtractedRecords.Insert(0, header1);
            cs1405ExtractedRecords.Insert(1, header2);

            const string SEPARATOR = ",";
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    cs1405ExtractedRecords.ForEach(line =>
                    {
                        var lineArray = line.Select(c =>
                            c.Contains(SEPARATOR) ? c.Replace(SEPARATOR.ToString(), "\\" + SEPARATOR) : c).ToArray();
                        writer.WriteLine(string.Join(SEPARATOR, lineArray));
                    });
                }
            }
            catch (Exception e)
            {
                var msg = $"Exception writing to file: {e.Message}";
                if (isCommandLineMode)
                {
                    Console.WriteLine(msg);
                }
                else
                {
                    MessageBox.Show(msg);
                }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"This tool will take 2 csv files (the gradebook from CS1400 and your CS1405 lab section), and generate a new CSV file that will have all the grades but only for the students that are in your lab section.

First select your CS1400 csv file, then your CS1405 csv file, and then you will be prompted to save the result file");
        }
    }
}
