var s,
    CandidateSkills = {
        settings: {
            updateSkill_cb: $(".candidate_skill"),
        },

        init: function () {
            console.log("_init");
            s = this.settings;
            this.bindUIActions();
            this.datatableActions();
        },
        bindUIActions: function () {

            s.updateSkill_cb.on("click", function (e) {
                var element = $(this);
                console.log(element);

                var candidateId = element.attr('candidate');
                var skillId = element.attr('id');

                var data = JSON.stringify({
                    'candidateId': candidateId,
                    'skillId': skillId
                });
                console.log(data);
                $.ajax({
                    type: "POST",
                    url: "/api/candidates/addskill",
                    data: data,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        alert(data);
                    },
                    failure: function (errMsg) {
                        alert(errMsg);
                    }
                });
            });

            // Add events
            $('input[type=file]').on('change', prepareUpload);

            // Grab the files and set them to our variable
            function prepareUpload(event) {
                files = event.target.files;
                console.log(files);

                var data = new FormData();
                $.each(files, function (key, value) {
                    data.append(key, value);
                });


                $.ajax({
                    url: '/api/files/upload/',
                    type: 'POST',
                    data: data,
                    cache: false,
                    dataType: 'json',
                    processData: false, // Don't process the files
                    contentType: false, // Set content type to false as jQuery will tell the server its a query string request
                    complete: function (e, xhr, settings) {
                        if (e.status === 200) {
                            console.log("Success");
                        } else if (e.status === 304) {

                        } else {

                        }
                    }
                });
            }
        },
        datatableActions: function () {
            $('.search-skill').on('click', function () {
                var search = $('input[type=search]');
                search.focusin();

                var temp = search.val() + "asdasd";
                search.val(temp);
                console.log(search);
              
                search.trigger(jQuery.Event('keypress', { keycode: 13 }));

            });
        }
    };


(function () {

    CandidateSkills.init();

})();