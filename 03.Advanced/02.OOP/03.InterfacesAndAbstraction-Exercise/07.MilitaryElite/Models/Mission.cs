using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string state;

        public string CodeName { get; }
        public string State
        {
            get => state;
            private set
            {
                if (value != "InProgress" && value != "Finished")
                {
                    throw new ArgumentException("Invalid mission state");
                }
                state = value;
            }
        }

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state; // validation happens here
        }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
