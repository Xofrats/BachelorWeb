currentPage = 1;
let page1 = document.getElementsByClassName("page1")
let page2 = document.getElementsByClassName("page2")
let page3 = document.getElementsByClassName("page3")
let page4 = document.getElementsByClassName("page4")
let page5 = document.getElementsByClassName("page5")

function NextPage() {
    removeInfo();

    switch (currentPage) {
        case 1:
            showElement(page2)
            hideElement(page1)
            document.getElementById('prev-btn').classList.remove("disable")

            document.getElementById('Navi2').classList.remove("table-primary")
            document.getElementById('Navi2').classList.add("table-info")

            currentPage++

            break;

        case 2:
            showElement(page3)
            hideElement(page2)

            document.getElementById('Navi3').classList.remove("table-primary")
            document.getElementById('Navi3').classList.add("table-info")

            currentPage++

            break;

        case 3:
            showElement(page4)
            hideElement(page3)

            document.getElementById('Navi4').classList.remove("table-primary")
            document.getElementById('Navi4').classList.add("table-info")

            currentPage++

            break;

        case 4:
            showElement(page5)
            hideElement(page4)
            document.getElementById('next-btn').classList.add("disable")

            document.getElementById('Navi5').classList.remove("table-primary")
            document.getElementById('Navi5').classList.add("table-info")

            generateReview()

            currentPage++

            break;

    }
}

function PrevPage() {
    removeInfo();
    switch (currentPage) {
        case 2:
            showElement(page1)
            hideElement(page2)
            document.getElementById('prev-btn').classList.add("disable")

            document.getElementById('Navi1').classList.remove("table-primary")
            document.getElementById('Navi1').classList.add("table-info")

            currentPage--

            break;

        case 3:
            showElement(page2)
            hideElement(page3)

            document.getElementById('Navi2').classList.remove("table-primary")
            document.getElementById('Navi2').classList.add("table-info")

            currentPage--

            break;

        case 4:
            showElement(page3)
            hideElement(page4)

            document.getElementById('Navi3').classList.remove("table-primary")
            document.getElementById('Navi3').classList.add("table-info")

            currentPage--

            break;

        case 5:
            showElement(page4)
            hideElement(page5)
            document.getElementById('next-btn').classList.remove("disable")

            document.getElementById('Navi4').classList.remove("table-primary")
            document.getElementById('Navi4').classList.add("table-info")

            currentPage--

            break;

    }
}

function FormNavigation(val) {
    removeInfo();

    switch (val) {
        case 1:
            showElement(page1)
            hideElement(page2)
            hideElement(page3)
            hideElement(page4)
            hideElement(page5)

            document.getElementById('next-btn').classList.remove("disable")
            document.getElementById('prev-btn').classList.add("disable")

            document.getElementById('Navi1').classList.remove("table-primary")
            document.getElementById('Navi1').classList.add("table-info")

            currentPage = 1
            break;

        case 2:
            showElement(page2)
            hideElement(page1)
            hideElement(page3)
            hideElement(page4)
            hideElement(page5)
            document.getElementById('next-btn').classList.remove("disable")
            document.getElementById('prev-btn').classList.remove("disable")

            document.getElementById('Navi2').classList.remove("table-primary")
            document.getElementById('Navi2').classList.add("table-info")

            currentPage = 2
            break;

        case 3:
            showElement(page3)
            hideElement(page2)
            hideElement(page1)
            hideElement(page4)
            hideElement(page5)
            document.getElementById('next-btn').classList.remove("disable")
            document.getElementById('prev-btn').classList.remove("disable")

            document.getElementById('Navi3').classList.remove("table-primary")
            document.getElementById('Navi3').classList.add("table-info")

            currentPage = 3
            break;

        case 4:
            showElement(page4)
            hideElement(page2)
            hideElement(page3)
            hideElement(page1)
            hideElement(page5)
            document.getElementById('next-btn').classList.remove("disable")
            document.getElementById('prev-btn').classList.remove("disable")

            document.getElementById('Navi4').classList.remove("table-primary")
            document.getElementById('Navi4').classList.add("table-info")

            currentPage = 4
            break;

        case 5:
            showElement(page5)
            hideElement(page2)
            hideElement(page3)
            hideElement(page4)
            hideElement(page1)

            document.getElementById('next-btn').classList.add("disable")
            document.getElementById('prev-btn').classList.remove("disable")

            document.getElementById('Navi5').classList.remove("table-primary")
            document.getElementById('Navi5').classList.add("table-info")

            generateReview();

            currentPage = 5
            break;
    }


}

function removeInfo() {
    var elements = document.getElementsByClassName('naviCustom')
    for (var i = 0; i < elements.length; i++) {
        if (this != elements[i]) {
            elements[i].classList.remove("table-info")
            elements[i].classList.add("table-primary")
        }
    }
}

function showElement(elements) {
    for (var i = 0; i < elements.length; i++) {
        if (this != elements[i]) {
            elements[i].style.display = "block";
        }
    }
}


function hideElement(elements) {
    for (var i = 0; i < elements.length; i++) {
        if (this != elements[i]) {
            elements[i].style.display = "none";
        }
    }

}

function generateReview() {
    document.getElementById("review_Title").innerHTML = document.getElementById("form_Title").value;
    document.getElementById("review_Beskriv").innerHTML = document.getElementById("form_Beskriv").value;

    var klasse = document.getElementById("form_Klasse");
    document.getElementById("review_Klasse").innerHTML = klasse.options[klasse.selectedIndex].text;

    var fag = document.getElementById("form_Fag");
    document.getElementById("review_Fag").innerHTML = fag.options[fag.selectedIndex].text;

    document.getElementById("review_Spil").innerHTML = document.getElementById("gamesList").innerHTML;

    document.getElementById("review_Frist").innerHTML = "Den " + document.getElementById("Frist_dato").value

}
