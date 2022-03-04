/*
 * Date Picker functionality init
 * */
jQuery(function () {
    var today = new Date();
    var mStartDate = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 1);
    var mStartDateWithToday = new Date(today.getFullYear(), today.getMonth(), today.getDate());

    $('.date-picker').datepicker({
        todayBtn: true,
        defaultDate: mStartDate,
        format: "dd/mm/yyyy",
        starView: "days",
        minViewMode: "days",
        endDate: mStartDate
    }).on("hide", function (e) {
        var date_check = $(this).datepicker("getDate");
        var true_false_date = moment(date_check).isValid();
        if (true_false_date == false) {
            $(this).datepicker('setDate', $('#from_date_hidden').val());
        }
        $('#from_date_hidden').val(moment($(this).datepicker("getDate")).format("DD/MM/YYYY"));
    });

    $('.date-picker-v190').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "es",
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,

        defaultDate: mStartDateWithToday,
        starView: "days",
        minViewMode: "days",
        endDate: mStartDateWithToday
    }).on("hide", function (e) {
        e.preventDefault();
        var date_check = $(this).datepicker("getDate");
        var true_false_date = moment(date_check).isValid();
        if (true_false_date == false) {
            $(this).datepicker('setDate', $('#from_date_hidden').val());
        }
        $('#from_date_hidden').val(moment($(this).datepicker("getDate")).format("DD/MM/YYYY"));
    });

    $('.date-picker-v190_enableFuture').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "es",
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,

        defaultDate: mStartDateWithToday,
        starView: "days",
        minViewMode: "days",
        //endDate: mStartDateWithToday,
        allowFuture: true

    }).on("hide", function (e) {
        e.preventDefault();
        var date_check = $(this).datepicker("getDate");
        var true_false_date = moment(date_check).isValid();
        if (true_false_date == false) {
            $(this).datepicker('setDate', $('#from_date_hidden').val());
        }
        $('#from_date_hidden').val(moment($(this).datepicker("getDate")).format("DD/MM/YYYY"));
    });

    $('.date-picker-v190_disablePast').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "es",
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,

        defaultDate: mStartDateWithToday,
        starView: "days",
        minViewMode: "days",
        minDate: mStartDateWithToday,
        allowFuture: true,
        allowPast: false

    }).on("hide", function (e) {
        e.preventDefault();
        var date_check = $(this).datepicker("getDate");
        var true_false_date = moment(date_check).isValid();
        if (true_false_date == false) {
            $(this).datepicker('setDate', $('#from_date_hidden').val());
        }
        $('#from_date_hidden').val(moment($(this).datepicker("getDate")).format("DD/MM/YYYY"));
    });
});


function CalcularEdad(fechaNacimiento) {
    var diffDuration = CalculateTimeDiff(fechaNacimiento, "YYYY-MM-DDThh:mm:ss");

    return diffDuration.years();
}
function CalculateTimeDiff(date, format = "DD/MM/YYYY") {
    if (date == "")
        return "";

    var actualDate = moment(new Date());
    var formatedDate = moment(date, format);
    return moment.duration(actualDate.diff(formatedDate));
}

function changeTitleModalNecesidades(title, type) {

    if (type == 1) {
        $("#causasIncidentesModalTitle").empty();
        $("#causasIncidentesModalTitle").append(title);
    } else {
        $("#necesidadesIncidentesModalTitle").empty();
        $("#necesidadesIncidentesModalTitle").append(title);
    }
}

function focusDatePicker(idDatePicker) {
    event.preventDefault();
    $(`#${idDatePicker}`).datepicker().focus();
}


function quitRedMessage() {
    console.log("Ejecuta fucnion del tmer")
    $(".validation-summary-errors").html("");
}

var timer;
function timerRedMessage() {
    console.log("Entra ala funcion");
    clearTimeout(timer);
    console.log("Limpia timer");
    setTimeout(quitRedMessage, 3000);
}

var validateForm = false;
function sendDataFromForm(formID) {
    validateForm = true;
    var validationModel = $(`#${formID}`).valid();
    if (!validationModel) {
        validateForm = false;
    } else {
        $(`#${formID}`).submit();
    }
}