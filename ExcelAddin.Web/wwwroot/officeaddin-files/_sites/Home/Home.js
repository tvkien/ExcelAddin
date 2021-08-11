(function ($) {
    "use strict";

    Office.onReady(function () {
        // Office is ready
        $(document).ready(function () {
            // The document is ready
            //app.initialize();
            $("#add-review-note").on("click", function () {
                var value = $("#review-note-value").val();
                return addReviewNote(value);
            });

            $("#add-comments").on("click", async function () {
                var valueContent = $("#review-comments-value").val();
                return getFileUrl(valueContent);
                //return callApi(fileName);
            });
        });
    });

    async function getFileUrl(valueContent) {
        //Get the URL of the current file.
        await Office.context.document.getFilePropertiesAsync(function (asyncResult) {
            var fileUrl = asyncResult.value.url;

            const a = "https://pod3.sharepoint.com/sites/Local-AAAAAA-73e29943-8bd6-48c1-84cd-4e2f1a2dd833/302f6ca1-007b-469a-9ba3-a6121f034018/Shared Documents/Office Working Paper/Test 123.xlsx"
            const [http, empty, domain, site, siteCollection, subsite, document, folder, filename] = fileUrl.split('/');
            var obj = {
                EngagementId: subsite,
                FileName: filename,
                Content: valueContent
            };
            return callApi(obj);
        });
    }

    async function addReviewNote(value) {
        await Excel.run(async (context) => {
            var range = context.workbook.getSelectedRange();
            range.values = value;
            await context.sync();
        });
    }

    async function callApi(obj) {
        $.ajax({
            url: "/api/ReviewNote/addReviewNote",
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify({
                Payload:
                {
                    EngagementId: obj.EngagementId,
                    FileName: obj.FileName,
                    Content: obj.Content
                }
            }),
            dataType: 'json',
            success: async function (response) {
                if (response == true) {
                    await addReviewComments(obj.Content);
                }
            },
            error: function () {
            }
        });        
    }

    async function addReviewComments(value) {
        await Excel.run(async (context) => {
            const selectedRange = context.workbook.getSelectedRange();

            // Note that an InvalidArgument error will be thrown if multiple cells are selected.
            context.workbook.comments.add(selectedRange, value);
            await context.sync();
        });
    }
})(jQuery);