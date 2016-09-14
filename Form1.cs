using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GradeSheetMerger

{
    public partial class Form1 : Form
    {
        private readonly int ANumberColumnIndex = 3;
        private List<List<string>> cs1400Records;
        private List<List<string>> cs1405ExtractedRecords;

        private List<string> header1;
        private List<string> header2;
        private bool isCommandLineMode;

        private const string token = "TODO";
        private const string courseId = "TODO";
        public Form1()
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                var args = Environment.GetCommandLineArgs();
                //Command line arguments - 1st is CS1400 file name, 2nd is CS1405 filename, 3rd is output filename
                parseCs1400File(args[1]);
                parseCs1405File(args[2]);
                WriteResult(args[3]);
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
                    WriteResult(resultSaveDialog.FileName);


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
                else if (noMatches.Any())
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

        private void WriteResult(string fileName)
        {
            cs1405ExtractedRecords.Insert(0, header1);
            cs1405ExtractedRecords.Insert(1, header2);

            const string separator = ",";
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    cs1405ExtractedRecords.ForEach(line =>
                    {
                        var lineArray = line.Select(c =>
                c.Contains(separator) ? c.Replace(separator.ToString(), "\\" + separator) : c).ToArray();
                        writer.WriteLine(string.Join(separator, lineArray));
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
            MessageBox.Show(
              @"Merger:
This tool will take 2 csv files (the gradebook from CS1400 and your CS1405 lab section), and generate a new CSV file that will have all the grades but only for the students that are in your lab section.

First select your CS1400 csv file, then your CS1405 csv file, and then you will be prompted to save the result file
-----
Submission Comments Retriever:
As a developer, you will set your development Canvas token in the code. 

Input the assignment number, which you can find in the url when you view the assignment on canvas. Then click get, and you will be asked to locate your CS1405 csv file with list of students in your section.");
        }

        private void GetSubmissionComments(string assignmentId, List<string> userIds)
        {
            var comments = new List<Comment>();
            foreach (var user in userIds)
            {
                string url =
                  $"https://usu.instructure.com/api/v1/courses/{courseId}/assignments/{assignmentId}/submissions/{user}?include=submission_comments&access_token={token}";
                var req = WebRequest.CreateHttp(url);
                req.Method = "GET";
                var r = req.GetResponse();
                var resString = new StreamReader(r.GetResponseStream()).ReadToEnd();
                var resJson = JObject.Parse(resString);
                var c = resJson["submission_comments"];
                if (c.HasValues)
                {
                    var author = (from a in c where resJson["user_id"] == a["author_id"] select a["name"]).FirstOrDefault()?.ToString() ?? c[0]["author_name"]?.ToString();
                    var list = new List<string>();
                    var name = c[0]["author_name"].ToString(); // This might not be the best if the first comment is made by the grader
                    foreach (var i in c)
                    {
                        list.Add(i["comment"].ToString());
                    }
                    comments.Add(new Comment(author, list));
                }
            }

            var message = "";
            foreach (var c in comments)
            {
                message += c.Name + ": " + Environment.NewLine + "- " + String.Join(Environment.NewLine + "- ", c.Comments.ToArray()) + Environment.NewLine;
                message += "----------------------------------" + Environment.NewLine;
            }
            MessageBox.Show(message);
        }

        private void commentsButton_Click(object sender, EventArgs e)
        {
            if (commentsDialog.ShowDialog() == DialogResult.OK)
            {
                using (TextFieldParser parser = new TextFieldParser(commentsDialog.FileName))
                {
                    var list = new List<string>();
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    //skip top 2 lines
                    parser.ReadFields();
                    parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        list.Add(parser.ReadFields()[1]);
                    }
                    GetSubmissionComments(assignmentIdBox.Text, list);
                }
            }
        }

        public class Comment
        {
            public string Name { get; }
            public List<string> Comments { get; }
            public Comment(string n, List<string> c)
            {
                Name = n;
                Comments = c;
            }


        }
    }
}
