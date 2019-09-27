//var teller = 1;
//var afleveringTeller = 1;
//var textboxval = document.getElementById("seizoen" + teller);
//function addInputForSeizoen() {
//    var value = "";

//    const div = document.createElement("div");
//    div.className = 'form-group row';

//   // document.getElementById("seizoen").value = ++teller;
//    div.innerHTML = `
//                <input id="seizoen" name="Seizoen[${teller}].Nummer" class="form-control btn btn-outline-dark" value="${teller}" readonly />`;
//    var textbox = document.getElementsByName("Seizoen[${teller}].Nummer");
//    textbox.val(value);
//    ++teller;
    
//    return div;

//}
//function addInputForAflevering() {
//    var value = "";

//    var div = document.createElement("div");
//    div.className = "form-group row";

//    div.innerHTML = `<input id="aflevering[${teller}]" name="Seizoen[${teller - 1}].Afleveringen[${afleveringTeller}]" value="" class="form-control" type="text" /> `;
//    var textbox = document.getElementsByName("Seizoen[${teller - 1}].Afleveringen[${afleveringTeller}]");
//    textbox.val(value);
//    ++afleveringTeller;
//    return div;
//}
//var form = document.getElementById('seizoenPart');
//document.getElementById('addSeizoen').addEventListener('click', function (e) {
//    form.appendChild(addInputForSeizoen());
//});
//var form2 = document.getElementById("aflevering");
//document.getElementById('addAflevering').addEventListener('click', function (e) {
//    form.appendChild(addInputForAflevering());
//})
//function Create()
//{
//    var formdata = document.getElementById("SerieForm");
 
//    var hoeveel = document.getElementsByClassName("form-control");
//    for (var i = 0; i < hoeveel.length; i++) {
        
//    }
//    $.ajax({
//        type: 'POST',
//        url: '/Serie/MaakSerie',
//        dataType: 'json',
//        data: { formdata }
        
//        });

//}

    var iSeizoen = 0;
    var iAflevering = 0;
var seizoen = 0;
var i = 0;
$(document).ready(function () {
    $("#addSeizoen").click(function () {
        var div = $("<div />");
        var value = iSeizoen+1;

        var seizoenBox = $("<input readonly/>").attr("type", "textbox").attr("name", "Seizoen[" + iSeizoen + "].Nummer");

        seizoenBox.val(value);
        div.append(seizoenBox);
        var button = $("<input/>").attr("type", "button").attr("value", "Remove");
        button.attr("onclick", "RemoveTextBox(this)");
        div.append(button);
        $("#seizoenPart").append(div);
        iSeizoen++;
        iAflevering = 0;
    });
});
$(document).ready(function () {
    $("#addAflevering").click(function () {
        var div = $("<div/>");
        var value = "";
        seizoen = iSeizoen--;
        seizoen = iSeizoen--;
        var afleveringBox = $("<input />").attr("type", "textbox").attr("Name", "Seizoen[" + seizoen + "].Afleveringen[" + iAflevering + "].Naam").attr("onchange", "callFunction(this)").attr("onfocus", "getCurrentTextBox(this)");
        afleveringBox.val(value);
        div.append(afleveringBox);
        var button = $("<input/>").attr("type", "button").attr("value", "Remove");
        button.attr("onclick", "RemoveTextBox(this)");
        div.append(button);
        $("#seizoenPart").append(div);
        iAflevering++;
        iSeizoen++;
        iSeizoen++;
    });
});
    var txtBoxValue;
var currentTextBox;
function getCurrentTextBox(txtBox) {
    
}
function callFunction(txtBox) {
    var txtBoxCounter;
    if (txtBox != null)
        txtBoxValue = txtBox.value;
    txtBox.val(txtBoxValue);
    

};

function sendArray() {

    $.ajax({
        type: 'POST',
        url: '/Serie/MaakSerie',
        contentType:'application/json; charset=utf-8',
        data: { txtBoxValues }

    });
}