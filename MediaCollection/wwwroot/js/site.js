var teller = 1;
var afleveringTeller = 1;
function addInputForSeizoen() {

    const div = document.createElement("div");
    div.className = 'form-group';

   // document.getElementById("seizoen").value = ++teller;
    div.innerHTML = `
                <input id="seizoen" asp-for="Seizoen[${teller}].Nummer" class="form-control btn btn-outline-dark" value="${teller}" readonly />
</div>
`

        ;
    ++teller;
    
    return div;

}
function addInputForAflevering() {
    const div = document.createElement("div");
    div.className = "form-group";

    div.innerHTML = `<input id="Seizoen[${teller}].Afleveringen[${afleveringTeller}]" asp-for="Aflevering.Naam" class="form-control" />
                `;
    return div;
}
var form = document.getElementById('seizoenPart');
document.getElementById('addSeizoen').addEventListener('click', function (e) {
    form.appendChild(addInputForSeizoen());
});
var form2 = document.getElementById('addSeizoen');
document.getElementById('addAflevering').addEventListener('click', function (e) {
    form.appendChild(addInputForAflevering());
})
function Create()
{
    var formdata = $("#SerieCreate").serialize() + "&urlofRequest=" + escape(window.location.href);
    var naam = document.getElementById("Naam").value;
    var hoeveel = document.getElementsByClassName("form-control");
    for (var i = 0; i < hoeveel.length; i++) {
        
    }
    $.ajax({
        type: 'POST',
        url: '/Serie/MaakSerie',
        dataType: 'json',
        data: { formdata }
        
        });

    
    

}
