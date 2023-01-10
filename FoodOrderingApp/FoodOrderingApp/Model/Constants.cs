using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FoodOrderingApp.Model
{
    static public class Constants
    {
        // Binh
       //public static readonly string IP = "192.168.1.48";

        // Thien
        public static readonly string IP = "192.168.2.13";
    }

    static public class Route
    {
        public static readonly string SIGNIN_PAGE = "//signinPage";
        public static readonly string SIGNUP_PAGE = "//signupPage";
        public static readonly string VERIFICATION_PAGE = "//verificationPage";
        public static readonly string RESET_PASSWORD_PAGE = "//resetPasswordPage";

        public static readonly string TAB_BAR = "//tabBar";
        public static readonly string HOMEPAGE = TAB_BAR + "/homepage";
        public static readonly string FOOD_PAGE = TAB_BAR + "/foodPage";
        public static readonly string CART_PAGE = TAB_BAR + "/cartPage";
        public static readonly string PROFILE_PAGE = TAB_BAR + "/profilePage";
        public static readonly string RESOURCE_PAGE = TAB_BAR + "/resourcePage";
    }
}
