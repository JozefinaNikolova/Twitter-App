﻿namespace Twitter.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Respondent { get; set; }
    }
}
