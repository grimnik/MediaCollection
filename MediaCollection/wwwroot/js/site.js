function addInputForSeizoen() {

    var input = document.getElementById("seizoen");

    input.insertAdjacentHTML("afterend", " <a>1</a>")
    input.classList("form-control btn btn-outline-dark")
    return input;

}
var form = document.getElementById('seizoenPart');
document.getElementById('addSeizoen').addEventListener('click', function (e) {
    form.appendChild(addInputForSeizoen());
});