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
    }
}
