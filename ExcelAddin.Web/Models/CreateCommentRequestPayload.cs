using System;

namespace ExcelAddin.Web.Models
{
    public class CreateCommentRequestPayload
    {
        public Guid? EngagementId { get; set; }

        public string FileName { get; set; }

        public string Content { get; set; }
    }
}