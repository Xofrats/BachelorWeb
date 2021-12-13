let spilIDer = [];

function visKnap() {
    document.getElementById("AddGamebtn").style.display = "block";
}

function AddGameToList() {

    var niveau = document.getElementById("Niveauer");
    var niveauText = niveau.options[niveau.selectedIndex].innerHTML;

    var spil = document.getElementById("Spil");
    var spilTitletext = spil.options[spil.selectedIndex].innerHTML;

    if (spilIDer.filter(e => e.ID_spil == spil.value).length > 0) {
        console.log("already there")
    } else {
        spilIDer.push({ ID_spil: spil.value, ID_Niveau: niveau.value });

        let gamelist = document.getElementById("gamesList");

        var li = document.createElement("li");
        li.id = document.getElementById("Spil").value;
        li.setAttribute("name", "SpilList[]");
        li.setAttribute("value", document.getElementById("Spil").value);
        gamelist.appendChild(li);

        var btn = document.createElement("button");
        btn.innerHTML = "Fjern";
        btn.classList.add("btn");
        btn.classList.add("btn-danger")
        btn.onclick = function () { fjernSpil(this) };

        li.appendChild(document.createTextNode(spilTitletext + "   "))
        li.appendChild(document.createTextNode(niveauText + "   "))
        li.appendChild(btn)
    }

    document.getElementById("AddGamebtn").style.display = "none";
    document.getElementById("Niveauer").value = '0';
    document.getElementById("Spil").value = '0';
}

function fjernSpil(element) {

    var li = element.parentElement;
    spilIDer = spilIDer.filter(e => e.ID_spil != li.id);
    li.remove();
}

function makeOptions(data) {
    var dropdown = document.getElementById("Niveauer");
    var option = document.createElement("option");

    option.text = data.Navn;
    option.value = data.ID;
    dropdown.options.add(option);
}

function makeOptionsSpil(data) {
    var dropdown = document.getElementById("Spil");
    var option = document.createElement("option");

    option.text = data.Navn;
    option.value = data.ID;
    dropdown.options.add(option);
}