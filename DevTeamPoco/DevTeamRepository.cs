using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamPoco
{
    public class DevTeamRepository
    {
        private List<DevTeam> _devTeamList = new List<DevTeam>();

        //Create
        public void AddContentToList(DevTeam content)
        {
            _devTeamList.Add(content);
        }

        //Read
        public List<DevTeam> GetContentList()
        {
            return _devTeamList;
        }

        //Update
        public bool UpdateExistingContent(string originalTeamName, DevTeam newContent)
        {
            //Find the content
            DevTeam oldContent = GetDevTeamsByTeamName(originalTeamName);

            //Update the content
            if (oldContent != null)
            {
                oldContent.TeamName = newContent.TeamName;
                oldContent.TeamID = newContent.TeamID;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveContentFromList(string teamName)
        {
            DevTeam content = GetDevTeamsByTeamName(teamName);

            if (content == null)
            {
                return false;
            }

            int initialCount = _devTeamList.Count;
            _devTeamList.Remove(content);

            if (initialCount > _devTeamList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method
        public DevTeam GetDevTeamsByTeamName(string teamName)
        {
            foreach (DevTeam content in _devTeamList)
            {
                if (content.TeamName == teamName)
                {
                    return content;
                }
            }

            return null;
        }

    }
}