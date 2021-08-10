using System;

namespace ExcelAddin.Web.Models
{
    public class CreateCommentRequestPayload
    {
        public Guid? EngagementId { get; set; }

        public Guid? TodoID { get; set; }

        public string Content { get; set; }
    }
}