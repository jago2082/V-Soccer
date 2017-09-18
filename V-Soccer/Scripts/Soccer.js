$(document).ready(function () {
    loadSates();
    loadCities();
});

function loadCities() {

    $("#DepartmentId").change(function () {
        $("#CityId").empty();
        $("#CityId").append('<option value="0">[Select a city...]</option>');
        $.ajax({
            type: 'POST',
            url: Url,
            dataType: 'json',
            data: { departmentId: $("#DepartmentId").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#CityId").append('<option value="'
                        + data.CityId + '">'
                        + data.Name + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve cities.' + ex);
            }
        });
        return false;
    });
}
function loadSates() {

    $("#CountryId").change(function () {
        $("#DeparmentId").empty();
        $("#DeparmentId").append('<option value="0">[Select a city...]</option>');
        $.ajax({
            type: 'POST',
            url: Url1,
            dataType: 'json',
            data: { departmentId: $("#CountryId").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#DeparmentId").append('<option value="'
                        + data.CityId + '">'
                        + data.Name + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve deparments.' + ex);
            }
        });
        return false;
    });
}

