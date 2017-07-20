$(function () {

    var getSkillsModel = function () {
        var skills = null;
        $.ajax({
            type: "GET",
            url: "/api/graph/getskills",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                Morris.Donut({
                    element: 'chart_skills',
                    data: result,
                    resize: true
                });
            },
            failure: function (errMsg) {
                console.log(errMsg);
            }
        });
        return skills;
    }
    var getExperienceModel = function () {
        var skills = null;
        $.ajax({
            type: "GET",
            url: "/api/graph/getexperience",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                Morris.Donut({
                    element: 'chart_experience',
                    data: result,
                    resize: true
                });
            },
            failure: function (errMsg) {
                console.log(errMsg);
            }
        });
        return skills;
    }
    getSkillsModel();
    getExperienceModel();


});
