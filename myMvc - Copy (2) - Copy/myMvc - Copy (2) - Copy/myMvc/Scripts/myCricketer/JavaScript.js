
function cricketerGet() {

    var Name = $("#name1").val();
    var Email = $("#email1").val();
    var Number = $("#number1").val();
    var Password = $("#password1").val();
    var data = { username: Name, email: Email,number: Number, password: Password};

    $.ajax({
        type: 'POST',
        url: '/gym/sighup',
        url: '/Home/login',
        datatype: 'json',
        data: (JSON.stringify(data)),
        contentType: 'application/json',
        success: function (data, textStatus, xhr) {

            let rowlength = document.querySelector(".table").rows.length;
            let x = document.querySelector(".table").insertRow(rowlength);
            let c1 = x.insertCell(0);
            let c2 = x.insertCell(1);
            let c3 = x.insertCell(2);
            let c4 = x.insertCell(3);
            c1.innerHTML = Name;
            c2.innerHTML = Email;
            c3.innerHTML = Number;
            c4.innerHTML = Password;

            // console.log(document.getElementById("tblCricketers").rows.length);
        },
    });

}




