
function showHide() {
    var drchkBox = document.getElementById("drchkBox");
    var drtxtBox1 = document.getElementById("drtxtBox1");
    var drtxtBox2 = document.getElementById("drtxtBox2");

    if (drchkBox.checked) {
        drtxtBox1.style.visibility = "visible";
        drtxtBox2.style.visibility = "visible";
    } else {
        drtxtBox1.style.visibility = "hidden";
        drtxtBox2.style.visibility = "hidden";
    }
}

_model.Firstname
_model.Lastname

function DisplayTableData(mvcapplication1) {
    document.getElementById("DisplayData").innerHTML = "";
    var table = document.createElement("table");
    var headers = ["Name", "Quantity", "Price", "Sum"];
    var trh = document.createElement("tr");
    var text = document.createTextNode("TEST");
    var th0 = document.createElement("th");
    th0.appendChild(text);
    trh.appendChild(th0);
    table.appendChild(trh);
    document.getElementById("DisplayData").appendChild(table);
}

