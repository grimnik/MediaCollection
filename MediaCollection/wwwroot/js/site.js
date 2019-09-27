var iSeizoen = 0;
var iAflevering = 0;
var seizoen = 0;
var i = 0;
$(document).ready(function () {
    $("#addSeizoen").click(function () {
        var div = $("<div />");
        var value = iSeizoen + 1;
        
        var seizoenBox = $("<input readonly/>").attr("type", "textbox").attr("name", "Seizoen[" + iSeizoen + "].Nummer").attr("class","btn btn-outline-dark form-control");

        seizoenBox.val(value);
        div.append(seizoenBox);
        
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
        var afleveringLabel = "Titel:";
        
        var afleveringBox = $("<input />").attr("type", "textbox").attr("Name", "Seizoen[" + seizoen + "].Afleveringen[" + iAflevering + "].Naam").attr("class", "form-control");
        var BeschrijvingLabel = "Beschrijving:";
        var afleveringBeschrijving = $("<input/>").attr("type", "textbox").attr("Name", "Seizoen[" + seizoen + "].Afleveringen[" + iAflevering + "].Beschrijving").attr("class", "form-control");
        afleveringBox.val(value);
        div.append(afleveringLabel)
        div.append(afleveringBox);
        div.append(BeschrijvingLabel);
        div.append(afleveringBeschrijving);
        
        $("#seizoenPart").append(div);
        iAflevering++;
        iSeizoen++;
        iSeizoen++;
    });
});

