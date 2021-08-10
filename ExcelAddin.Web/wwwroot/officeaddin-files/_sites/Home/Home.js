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

            $("#add-comments").on("click", function () {
                var value = $("#review-comments-value").val();
                return callApi(value);
            });
        });
    });

    async function addReviewNote(value) {
        await Excel.run(async (context) => {
            var range = context.workbook.getSelectedRange();
            range.values = value;
            await context.sync();
        });
    }

    async function callApi(value) {
        $.ajax({
            url: "/api/ReviewNote/addReviewNote",
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify({
                Payload:
                {
                    EngagementId: "302F6CA1-007B-469A-9BA3-A6121F034018",
                    TodoID: "759D2910-C9F2-4BBA-9BAF-243A7DD51D1E",
                    Content: value
                }
            }),
            dataType: 'json',
            success: async function (response) {
                if (response == true) {
                    await addReviewComments(value);
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