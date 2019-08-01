using System;

namespace Task_DEV_10
{
    /// <summary>
    /// Interface for pattern command.
    /// </summary>
    public interface ICommand
    {
        event Action<ICommand> UpdateData;

        /// <summary>
        /// Method writes data to XML file.
        /// </summary>
        void WriteToXML();

        /// <summary>
        /// Method adds new element.
        /// </summary>
        void AddNewElement();

        /// <summary>
        /// Method deletes element.
        /// </summary>
        void DeleteElement();

        /// <summary>
        /// Method display elements.
        /// </summary>
        void DisplayElements();
    }
}
