using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Comment
    {
        public int IDComment { get; set; }
        public string CommentDetail { get; set; }
        public int IDFood { get; set; }

        public int CommentID { get; set; }
        public string CommenterName { get; set; }
        public string CommenterImage { get; set; }
        public string CommentComment { get; set; }
    }
}
