using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI.Models.SigneeModels
{
    public class Signee : ISignee
    {
        protected int signeeID;
        public int ID
        {
            get { return signeeID; }
            set { signeeID = value; }
        }

        protected string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        protected string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FullName
        {
            get { return firstname + " " + lastname; }
        }

        public Signee(int signeeid,string firstname,string lastname)
        {
            signeeID = signeeid;
            firstName = firstname;
            lastName = lastname;
        }

        public Signee(string firstname, string lastname)
        {
            firstName = firstname;
            lastName = lastname;
        }

        public Signee()
        {
            signeeID = 0;
            firstName = "";
            lastName = "";
        }
    }
}
