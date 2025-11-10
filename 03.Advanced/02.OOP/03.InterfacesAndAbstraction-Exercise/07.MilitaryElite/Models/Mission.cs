using MilitaryElite.Models.Interfaces;
using System;

namespace MilitaryElite.Models
{
    internal class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }
        public string State
        {
            get => this.state;
            set
            {
                if (value != "InProgress" && value != "Finished")
                    throw new ArgumentException("Invalid mission state");

                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
