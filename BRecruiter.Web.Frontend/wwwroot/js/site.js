var s,
    CandidateSkills = {
        settings: {
            updateSkill: $(".candidate_skill")
        },

        init: function () {
            console.log("_init");
            s = this.settings;
            this.bindUIActions();
        },
        bindUIActions: function () {
            s.updateSkill.on("click", function (e) {
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
    };

(function () {

    CandidateSkills.init();

})();