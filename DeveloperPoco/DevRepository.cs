using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPoco
{
    public class DevRepository
    {
        private List<Developers> _listOfDevs = new List<Developers>();

        //Create
        public void AddContentToList(Developers content)
        {
            _listOfDevs.Add(content);
        }

        //Read
        public List<Developers> GetContentList()
        {
            return _listOfDevs;
        }

        //Update
        public bool UpdateExistingContent(string originalFirstName, Developers newContent)
        {
            //Find the content
            Developers oldContent = GetDevelopersByFirstName(originalFirstName);

            //Update the content
            if(oldContent != null)
            {
                oldContent.FirstName = newContent.FirstName;
                oldContent.LastName = newContent.LastName;
                oldContent.ID = newContent.ID;
                oldContent.PluralSight = newContent.PluralSight;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveContentFromList(string firstName)
        {
            Developers content = GetDevelopersByFirstName(firstName);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfDevs.Count;
            _listOfDevs.Remove(content);

            if(initialCount > _listOfDevs.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method
        public Developers GetDevelopersByFirstName(string firstName)
        {
            foreach (Developers content in _listOfDevs)
            {
                if(content.FirstName == firstName)
                {
                    return content;
                }
            }

            return null;
        }

    }
}
