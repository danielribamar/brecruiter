﻿var s,
    CandidateSkills = {
        settings: {
            updateSkill_cb: $(".candidate_skill"),
        },

        init: function () {
            console.log("_init");
            s = this.settings;
            this.bindUIActions();
            this.datatableActions();
            this.datetimePickerActions();
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
        },
        datatableActions: function () {
            $('.search-skill').on('click', function () {
                var search = $('input[type=search]');
                search.focusin();
                console.log();
                var temp = search.val() + $('.search-skill').data('value') + ' ';
                search.val(temp);

                search.focus();

                search.keypress();

            });
        },
        datetimePickerActions: function () {

        }
    };


(function () {

    CandidateSkills.init();

})();