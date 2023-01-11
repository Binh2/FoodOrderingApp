using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
{
    public interface IComment
    {
        int CommentID { get; set; }
        int CommentDetail { get; set; }
        int CommentDate { get; set; }
        int FoodID { get; set; }
        int ConsumerID { get; set; }
    }

    public class Comment:IComment
    {
        public int CommentID { get; set; }
        public int CommentDetail { get; set; }
        public int CommentDate { get; set; }
        public int FoodID { get; set; }
        public int ConsumerID { get; set; }
    }
}