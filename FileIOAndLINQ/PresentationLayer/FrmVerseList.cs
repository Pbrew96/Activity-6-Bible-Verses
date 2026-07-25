/*
 * Patrick Brewster
 * CST - 250
 * 07/25/2026
 * File I/O and LINQ
 * Activity 6
 */

using FileIOAndLINQ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FileIOAndLINQ.PresentationLayer
{
    public partial class FrmVerseList : Form
    {
        // Declare class level variables
        private List<Label> _errorLabels;
        // Flags for user input
        bool isValidBook = false, isValidChapter = false,
             isValidVerse = false, isValidText = false,
             isValidMeaning = false, isValidImportance = false;
        public FrmVerseList()
        {
            InitializeComponent();
            // Initialize and hide the error list
            InitializeErrors();
            // Initialize cmbVerseBook
            InitializeBooks();
        }
        /// <summary>
        /// Initialize the errors list
        /// </summary>
        private void InitializeErrors()
        {
            // Initialize the error label list
            _errorLabels = new List<Label>
            {
            lblBookError, lblChapterError,
            lblVerseError, lblTextError,
            lblMeaningError, lblImportanceError
            };
            // Loop through the error label list
            foreach (Label errorLabel in _errorLabels)
            {
                errorLabel.Visible = false;
            }
        }
        /// <summary>
        /// Set up the verse book combo box
        /// </summary>
        private void InitializeBooks()
        {
            // Set up a list of books of the Bible
            List<string> bibleBooks = new List<string>
    {
        // Old Testament
        "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy",
        "Joshua", "Judges", "Ruth", "1 Samuel", "2 Samuel",
        "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra",
        "Nehemiah", "Esther", "Job", "Psalms", "Proverbs",
        "Ecclesiastes", "Song of Solomon", "Isaiah", "Jeremiah", "Lamentations",
        "Ezekiel", "Daniel", "Hosea", "Joel", "Amos",
        "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk",
        "Zephaniah", "Haggai", "Zechariah", "Malachi",

        // New Testament
        "Matthew", "Mark", "Luke", "John", "Acts",
        "Romans", "1 Corinthians", "2 Corinthians", "Galatians", "Ephesians",
        "Philippians", "Colossians", "1 Thessalonians", "2 Thessalonians", "1 Timothy",
        "2 Timothy", "Titus", "Philemon", "Hebrews", "James",
        "1 Peter", "2 Peter", "1 John", "2 John", "3 John",
        "Jude", "Revelation"
    };

            // Populate cmbVerseBook with the list
            cmbVerseBook.DataSource = bibleBooks;

            // Set the automatically selected book to -1 (none)
            cmbVerseBook.SelectedIndex = -1;

            // Set the combo box to suggest books based on the user typing
            cmbVerseBook.AutoCompleteMode = AutoCompleteMode.Suggest;

            // Set the autocomplete source to the List items
            cmbVerseBook.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// LEave event handler for the book combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbVerseBookLeaveEH(object sender, EventArgs e)
        {
            // Check if the user has selected a book
            if (cmbVerseBook.SelectedIndex >= 0)
            {
                // Set the book flag to true
                isValidBook = true;

                // Hide the book error label
                lblBookError.Visible = false;
            }
            else
            {
                // Set the book flag to false
                isValidBook = false;

                // Update the book error label
                lblBookError.Text = "You must select a book";

                // Show the book error label
                lblBookError.Visible = true;
            }
        }

        /// <summary>
        /// Leave event handler to make sure the user entered a number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtVerseChapterLeaveEH(object sender, EventArgs e)
        {
            // Declare and initialize the RegEx object to check that the chapter is a number
            Regex regex = new Regex(@"^[0-9]+$");

            // Match object to hold the result of the RegEx comparison
            Match match;

            // Compare the regex pattern to the textbox text
            match = regex.Match(txtVerseChapter.Text);

            // Check if the match was a success
            if (match.Success)
            {
                // Set the chapter flag to true
                isValidChapter = true;

                // Hide the chapter error label
                lblChapterError.Visible = false;
            }
            else
            {
                // Set the chapter flag to false
                isValidChapter = false;

                // Update the text for the chapter error label
                lblChapterError.Text = "The chapter must be a number";

                // Show the chapter error label
                lblChapterError.Visible = true;
            }
        }
        /// <summary>
        /// Leave event handler to validate verse input from the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtVerseVerseLeaveEH(object sender, EventArgs e)
        {
            //Declare and initialize
            // RegEx pattern to validate the verse
            Regex regex = new Regex(@"^\d+(?:-\d+)?$");
            // Match object to hold the result of the RegEx comparison
            bool match;

            // Match the RegEx pattern with the verse text
            match = regex.IsMatch(txtVerseVerse.Text);
            // Check if the match was a success
            if (match)
            {
                // Set the verse flag to true
                isValidVerse = true;
                // Hide the verse error label
                lblVerseError.Visible = false;
            }
            else
            {
                // Set the verse flag to false
                isValidVerse = false;
                // Update the text for the verse error label
                lblVerseError.Text = "The verse must be a number or a range (e.g., 1-3)";
                // Show the verse error label
                lblVerseError.Visible = true;
            }
        }

        /// <summary>
        /// Leave event handler for txtVerseText
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtVerseTextLeaveEH(object sender, EventArgs e)
        {
            // Check to make sure the user entered text for the verse
            if (!string.IsNullOrWhiteSpace(txtVerseText.Text))
            {
                // Set the valid text flag to true
                isValidText = true;
                // Hide the error label
                lblTextError.Visible = false;
            }
            else
            {
                // Make sure the valid text flag is false
                isValidText = false;
                // Update the error label
                lblTextError.Text = "The text cannot be blank";
                // Show the error label
                lblTextError.Visible = true;
            }
        }

        /// <summary>
        /// Leave event handler for txtVerseMeaning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtVerseMeaningLeaveEH(object sender, EventArgs e)
        {
            // Check to make sure the user entered a meaning for the verse
            if (!string.IsNullOrWhiteSpace(txtVerseMeaning.Text))
            {
                // Set the valid meaning flag to true
                isValidMeaning = true;

                // Hide the error label
                lblMeaningError.Visible = false;
            }
            else
            {
                // Make sure the valid meaning flag is false
                isValidMeaning = false;

                // Update the error label
                lblMeaningError.Text = "The meaning cannot be blank";

                // Show the error label
                lblMeaningError.Visible = true;
            }
        }

        /// <summary>
        /// Leave event handler to validate important input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NudVerseImportanceLeaveEH(object sender, EventArgs e)
        {
            // Check if the value is between 1 and 10
            if (nudVerseImportance.Value >= 1 && nudVerseImportance.Value <= 10)
            {
                // Set the importance flag to true
                isValidImportance = true;

                // Hide the importance error label
                lblImportanceError.Visible = false;
            }
            else
            {
                // Set the importance flag to false
                isValidImportance = false;

                // Update the importance error label
                lblImportanceError.Text = "The importance must be 1 - 10";

                // Show the importance error label
                lblImportanceError.Visible = true;
            }
        }
        /// <summary>
        /// Click event handler to add a new verse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddVerseClickEH(object sender, EventArgs e)
        {
            // Declare and initialize
            int chapter = -1;
            VerseRequestModel verse;

            // Check the flags to see if the user has entered valid data
            if (isValidBook && isValidChapter && isValidVerse &&
                isValidText && isValidMeaning && isValidImportance)
            {
                // Set up a try-catch to cast the chapter to an int
                try
                {
                    // Parse the chapter to an int
                    chapter = int.Parse(txtVerseChapter.Text);
                }
                catch (Exception)
                {
                    // Update the error label for the chapter
                    lblChapterError.Text = "The chapter must be a number";

                    // Show the chapter error label
                    lblChapterError.Visible = true;
                }

                // Create the verse variable
                verse = new VerseRequestModel(
                    cmbVerseBook.Text,
                    chapter,
                    txtVerseVerse.Text,
                    txtVerseText.Text,
                    txtVerseMeaning.Text,
                    (int)nudVerseImportance.Value);
            }
            else if (!isValidBook)
            {
                lblBookError.Visible = true;
            }
            else if (!isValidChapter)
            {
                lblChapterError.Visible = true;
            }
            else if (!isValidVerse)
            {
                lblVerseError.Visible = true;
            }
            else if (!isValidText)
            {
                lblTextError.Visible = true;
            }
            else if (!isValidMeaning)
            {
                lblMeaningError.Visible = true;
            }
            else if (!isValidImportance)
            {
                lblImportanceError.Visible = true;
            }
        } // End of BtnAddVerseClickEH
    }
}

