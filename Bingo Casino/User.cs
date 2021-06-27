using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo_Casino
{
    class User
    {
        string ursname;
        double money = 70;
        public  int HScore { get; } = 70;
        



        string getSetUrsname
        {
            get { return ursname; }
            set { ursname = value; }
        }

        public int addMoney
        {
            get { return (int)money; }
            set { money = value; }
        }

    }
}
