/*
 * Patrick Brewster
 * CST - 250
 * 07/25/2026
 * File I/O and LINQ
 * Activity 6
 */

using FileIOAndLINQ.Models;
using FileIOAndLINQ.Services.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileIOAndLINQ.Services.BusinessLogicLayer
{
    class VerseLogic
    {
        // Class level variables
        private VerseDAO _verseDAO;

        /// <summary>
        /// Default constructor for VerseLogic
        /// </summary>
        public VerseLogic()
        {
            // Initalize the data access object
            _verseDAO = new VerseDAO();
        }

        public int AddVerse(VerseRequestModel verse)
        {
            // Return the DAO method
            return _verseDAO.AddVerse(verse);
        }

        

        /// <summary>
        /// Get a list of verses from the inventory
        /// </summary>
        /// <returns></returns>
        public List<VerseDisplayModel> GetAllVerses()
        {
            // Declare and initialize
            // Get the verses from the DAO

            List<VerseDataModel> dataVerses = _verseDAO.GetAllVerses();

            // Convert the dataVerses list to a displayVerses list and return
            return ConvertVerseDataToDisplay(dataVerses);
        }
          

        /// <summary>
        ///  Write the verses list to the given file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string WriteVersesToFile(string fileName)
        {
            // Call and return the DAO method
            return _verseDAO.WriteVersesToFile(fileName);
        }
        
        /// <summary>
        /// Read the verse
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadVersesFromFile(string fileName)
        {
            //Return the DAO method
            return _verseDAO.ReadVersesFromFile(fileName);
        }
        /// <summary>
        ///  Get a list of the least important verses
        /// </summary>
        /// <param name="numToFind"></param>
        /// <returns></returns>

        public List<VerseDisplayModel> GetLeastImportantVerses(int numToFind)
        {
            // Get a list of the least important data verses
            List<VerseDataModel> dataVerses = _verseDAO.GetLeastImportantVerses(numToFind);
            // Convert the dataVerses list to a displayVerses list and return
            return ConvertVerseDataToDisplay(dataVerses);
        }

        public List<VerseDisplayModel> GetMostImportantVerses(int numToFind)
        {
            // Get a list of the most important data verses
            List<VerseDataModel> dataVerses = _verseDAO.GetMostImportantVerses(numToFind);
            // Convert the dataVerses list to a displayVerses list and return
            return ConvertVerseDataToDisplay(dataVerses);
        }

        /// <summary>
        /// Convert a list of VerseDataModels to VerseDisplayModels
        /// </summary>
        /// <param name="dataVerses"></param>
        /// <returns></returns>
        public List<VerseDisplayModel> ConvertVerseDataToDisplay(List<VerseDataModel> dataVerses)
        {
            // Declare and initialize
            List<VerseDisplayModel> displayVerses = new List<VerseDisplayModel>();
            string reference = "";

            // Loop through the dataVerses list
            foreach (VerseDataModel verse in dataVerses)
            {
                // Use the book, chapter, and verse to create the reference
                reference = $"{verse.Book} {verse.Chapter}:{verse.Verse}";

                // Create a display verse model using the VerseDataModel verse
                VerseDisplayModel displayVerse = new VerseDisplayModel(
                    reference,
                    verse.Text,
                    verse.Meaning,
                    verse.Importance);

                // Add the display model to the displayVerses list
                displayVerses.Add(displayVerse);
            }

            // Return the display verses list
            return displayVerses;
        }
        /// <summary>
        /// Calculate the total number of individual verses
        /// </summary>
        /// <returns></returns>
        public int GetTotalVerseCount()
        {
            // Get all verses from the DAO
            List<VerseDataModel> verses = _verseDAO.GetAllVerses();

            // Store the total number of verses
            int totalVerses = 0;

            // Loop through the verse list
            foreach (VerseDataModel verse in verses)
            {
                // Check if the verse contains a range
                if (verse.Verse.Contains("-"))
                {
                    // Split the starting and ending verse numbers
                    string[] range = verse.Verse.Split('-');

                    int startingVerse;
                    int endingVerse;

                    // Make sure both values are valid numbers
                    if (range.Length == 2 &&
                        int.TryParse(range[0], out startingVerse) &&
                        int.TryParse(range[1], out endingVerse) &&
                        endingVerse >= startingVerse)
                    {
                        // Count every verse included in the range
                        totalVerses += endingVerse - startingVerse + 1;
                    }
                    else
                    {
                        // Count an invalid range as one entry
                        totalVerses++;
                    }
                }
                else
                {
                    // A normal verse counts as one
                    totalVerses++;
                }
            }

            // Return the total
            return totalVerses;
        }
    }
}
