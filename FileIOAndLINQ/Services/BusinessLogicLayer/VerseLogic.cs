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
    }
}
