/*
 * Patrick Brewster
 * CST - 250
 * 07/25/2026
 * File I/O and LINQ
 * Activity 6
 */

using FileIOAndLINQ.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace FileIOAndLINQ.Services.DataAccessLayer
{
    public class VerseDAO
    {
        // Declare class level variables
        private List<VerseDataModel> _verses;

        /// <summary>
        /// Default constructor for VerseDAO
        /// </summary>
        public VerseDAO()
        {
            // Set the EPPlus license for this school project
            ExcelPackage.License.SetNonCommercialPersonal(
                "Patrick Brewster");

            // Create a new List of VerseDataModels
            _verses = new List<VerseDataModel>();
        }

        /// <summary>
        /// Add a new verse to the inventory
        /// </summary>
        /// <param name="verse"></param>
        /// <returns></returns>
        public int AddVerse(VerseRequestModel verse)
        {
            // Declare and initialize
            int id = _verses.Count + 1;

            // Create a new verse based on the verse request model
            VerseDataModel newVerse = new VerseDataModel(
                id,
                verse.Book,
                verse.Chapter,
                verse.Verse,
                verse.Text,
                verse.Meaning,
                verse.Importance);

            // Add the new verse to the verses list
            _verses.Add(newVerse);

            // Return the id of the new verse
            return id;
        }

        /// <summary>
        /// Get the list of verses in the inventory
        /// </summary>
        /// <returns></returns>
        public List<VerseDataModel> GetAllVerses()
        {
            // Return the _verses list
            return _verses;
        }

        /// <summary>
        /// Write verses to the selected file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string WriteVersesToFile(string fileName)
        {
            // Declare and initialize
            string serialized = "";

            // Get the file extension
            string extension =
                Path.GetExtension(fileName).ToLower();

            // Create a switch based on the file extension
            switch (extension)
            {
                case ".txt":
                    // Loop through the verses list
                    foreach (VerseDataModel verse in _verses)
                    {
                        // Add each verse to the serialized string
                        serialized += verse.ToString() + "\n";
                    }
                    break;

                case ".json":
                    // Serialize the verses to JSON
                    serialized =
                        ServiceStack.Text.JsonSerializer
                        .SerializeToString(_verses);
                    break;

                case ".csv":
                    // Serialize the verses to CSV
                    serialized =
                        ServiceStack.Text.CsvSerializer
                        .SerializeToString(_verses);
                    break;

                case ".xml":
                    try
                    {
                        // Create an XML serializer
                        XmlSerializer serializer =
                            new XmlSerializer(
                                typeof(List<VerseDataModel>));

                        // Create the XML file
                        using (FileStream fileStream =
                            new FileStream(
                                fileName,
                                FileMode.Create))
                        {
                            // Serialize the verses
                            serializer.Serialize(
                                fileStream,
                                _verses);
                        }

                        return "The verses have been saved to your XML file";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }

                case ".xlsx":
                    // Write verses to the Excel file
                    return WriteVersesToExcel(fileName);

                default:
                    return "File not recognized";
            }

            try
            {
                // Write the serialized string to the file
                File.WriteAllText(fileName, serialized);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            // Return a success message
            return "The verses have been saved to your file";
        }

        /// <summary>
        /// Read verses from the given file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadVersesFromFile(string fileName)
        {
            // Declare and initialize
            string data = "";

            List<VerseDataModel> dataVerses =
                new List<VerseDataModel>();

            // Get the file extension
            string extension =
                Path.GetExtension(fileName).ToLower();

            // Read plain-text file formats
            if (extension == ".txt" ||
                extension == ".json" ||
                extension == ".csv")
            {
                try
                {
                    // Get the text from the file
                    data = File.ReadAllText(fileName);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            // Create a switch based on the file extension
            switch (extension)
            {
                case ".txt":
                    // Split the text file on the newline character
                    string[] lines = data.Split('\n');

                    // Loop through the array of lines
                    foreach (string line in lines)
                    {
                        // Check if each line contains data
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            // Convert the line to a VerseDataModel
                            dataVerses.Add(
                                ConvertTxtToVerseDataModel(
                                    line.Trim()));
                        }
                    }
                    break;

                case ".json":
                    // Deserialize the JSON data
                    dataVerses =
                        ServiceStack.Text.JsonSerializer
                        .DeserializeFromString
                        <List<VerseDataModel>>(data);
                    break;

                case ".csv":
                    // Deserialize the CSV data
                    dataVerses =
                        ServiceStack.Text.CsvSerializer
                        .DeserializeFromString
                        <List<VerseDataModel>>(data);
                    break;

                case ".xml":
                    try
                    {
                        // Create an XML serializer
                        XmlSerializer serializer =
                            new XmlSerializer(
                                typeof(List<VerseDataModel>));

                        // Open the selected XML file
                        using (FileStream fileStream =
                            new FileStream(
                                fileName,
                                FileMode.Open))
                        {
                            // Deserialize the XML file
                            dataVerses =
                                (List<VerseDataModel>)
                                serializer.Deserialize(fileStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    break;

                case ".xlsx":
                    try
                    {
                        // Read verses from the Excel file
                        dataVerses =
                            ReadVersesFromExcel(fileName);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    break;

                default:
                    return "File not recognized";
            }

            // Make sure the list is not null
            if (dataVerses == null)
            {
                return "No verses were found in the file";
            }

            // Loop through the dataVerses list
            foreach (VerseDataModel newVerse in dataVerses)
            {
                // Set the id for each new verse
                newVerse.Id = _verses.Count + 1;

                // Add the new verse to the verses list
                _verses.Add(newVerse);
            }

            // Return a success message
            return "The verses have been read from your file and added to the list";
        }

        /// <summary>
        /// Take a line from the text file and return a VerseDataModel
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public VerseDataModel ConvertTxtToVerseDataModel(
            string line)
        {
            // Declare and initialize
            string[] values;
            int chapter = 0;
            int importance = 0;

            // Split the line on "* "
            values = line.Split("* ");

            // Parse the chapter
            int.TryParse(values[1], out chapter);

            // Parse the importance
            int.TryParse(values[5], out importance);

            // Create the new verse
            VerseDataModel verse =
                new VerseDataModel(
                    0,
                    values[0],
                    chapter,
                    values[2],
                    values[3],
                    values[4],
                    importance);

            // Return the verse
            return verse;
        }

        /// <summary>
        /// Get a list of the least important verses
        /// </summary>
        /// <param name="numToFind"></param>
        /// <returns></returns>
        public List<VerseDataModel> GetLeastImportantVerses(
            int numToFind)
        {
            // Use LINQ query syntax
            List<VerseDataModel> leastImportantVerses =
                (from verse in _verses
                 orderby verse.Importance
                 select verse)
                .Take(numToFind)
                .ToList();

            // Return the list
            return leastImportantVerses;
        }

        /// <summary>
        /// Get a list of the most important verses
        /// </summary>
        /// <param name="numToFind"></param>
        /// <returns></returns>
        public List<VerseDataModel> GetMostImportantVerses(
            int numToFind)
        {
            // Use LINQ method syntax
            List<VerseDataModel> mostImportantVerses =
                _verses
                .OrderByDescending(
                    verse => verse.Importance)
                .Take(numToFind)
                .ToList();

            // Return the list
            return mostImportantVerses;
        }

        /// <summary>
        /// Write verses to an Excel file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string WriteVersesToExcel(string fileName)
        {
            try
            {
                // Create file information
                FileInfo fileInfo =
                    new FileInfo(fileName);

                // Delete the existing file
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }

                // Create a new Excel package
                using (ExcelPackage package =
                    new ExcelPackage(fileInfo))
                {
                    // Add a worksheet
                    ExcelWorksheet worksheet =
                        package.Workbook.Worksheets.Add(
                            "Bible Verses");

                    // Add the column headings
                    worksheet.Cells[1, 1].Value = "Id";
                    worksheet.Cells[1, 2].Value = "Book";
                    worksheet.Cells[1, 3].Value = "Chapter";
                    worksheet.Cells[1, 4].Value = "Verse";
                    worksheet.Cells[1, 5].Value = "Text";
                    worksheet.Cells[1, 6].Value = "Meaning";
                    worksheet.Cells[1, 7].Value = "Importance";

                    // Start the verse data on row two
                    int row = 2;

                    // Add each verse to the worksheet
                    foreach (VerseDataModel verse in _verses)
                    {
                        worksheet.Cells[row, 1].Value =
                            verse.Id;

                        worksheet.Cells[row, 2].Value =
                            verse.Book;

                        worksheet.Cells[row, 3].Value =
                            verse.Chapter;

                        worksheet.Cells[row, 4].Value =
                            verse.Verse;

                        worksheet.Cells[row, 5].Value =
                            verse.Text;

                        worksheet.Cells[row, 6].Value =
                            verse.Meaning;

                        worksheet.Cells[row, 7].Value =
                            verse.Importance;

                        row++;
                    }

                    // Automatically size the columns
                    if (worksheet.Dimension != null)
                    {
                        worksheet.Cells[
                            worksheet.Dimension.Address]
                            .AutoFitColumns();
                    }

                    // Save the Excel file
                    package.Save();
                }

                return "The verses have been saved to your Excel file";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Read verses from an Excel file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private List<VerseDataModel> ReadVersesFromExcel(
            string fileName)
        {
            // Create a list for the verses
            List<VerseDataModel> dataVerses =
                new List<VerseDataModel>();

            // Open the Excel file
            using (ExcelPackage package =
                new ExcelPackage(
                    new FileInfo(fileName)))
            {
                // Make sure a worksheet exists
                if (package.Workbook.Worksheets.Count == 0)
                {
                    return dataVerses;
                }

                // Get the first worksheet
                ExcelWorksheet worksheet =
                    package.Workbook.Worksheets[0];

                // Check if the worksheet is empty
                if (worksheet.Dimension == null)
                {
                    return dataVerses;
                }

                // Start on row two because row one has headings
                for (int row = 2;
                     row <= worksheet.Dimension.End.Row;
                     row++)
                {
                    // Skip empty rows
                    if (string.IsNullOrWhiteSpace(
                        worksheet.Cells[row, 2].Text))
                    {
                        continue;
                    }

                    // Convert chapter to an integer
                    int.TryParse(
                        worksheet.Cells[row, 3].Text,
                        out int chapter);

                    // Convert importance to an integer
                    int.TryParse(
                        worksheet.Cells[row, 7].Text,
                        out int importance);

                    // Create a VerseDataModel
                    VerseDataModel verse =
                        new VerseDataModel(
                            0,
                            worksheet.Cells[row, 2].Text,
                            chapter,
                            worksheet.Cells[row, 4].Text,
                            worksheet.Cells[row, 5].Text,
                            worksheet.Cells[row, 6].Text,
                            importance);

                    // Add the verse to the list
                    dataVerses.Add(verse);
                }
            }

            // Return the list
            return dataVerses;
        }
    }
}