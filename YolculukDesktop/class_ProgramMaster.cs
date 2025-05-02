using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YolculukDesktop
{
    class class_ProgramMaster
    {
        //
        //Forms
        //
        public static Form mainloginform;
        public static Form mainyolculuk;

        //
        //User
        //
        public static string logged_user = "";
        public static int logged_user_id = -1;
        public static int logged_user_authority = -1;

        //
        //Program Memory
        //
        public static int this_bus_id = -1;

        public static int seat_id = -1;
        public static int seat_number = -1;
        public static int seat_bus_id = -1;
        public static int totalseatcoin = -1;
    }
}
