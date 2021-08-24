function DeleteRow(data) {
    $.post("/Json/DeleteUser", { Uid: data }, function (data) {
        if (data != 0) {
            alert("Usuario eliminado");
        }
        else {
            alert("El usuario no pudo ser eliminado");
        }
    });

}
function ShowUpdate(data) {
    $('#forma').css("display", "block");
    var is = data;
    $.getJSON("/Json/GetUser", { Uid: data }, function (data) {
        $('#Exp').val(data.Exp);
        $('#Active option[value=" ' + data.Active + '"]');
        $('#Name').val(data.Name);
        $('#Alias').val(data.Alias);
    });
}
function AltaDeUsuario() {
    var Aname = $('#AltaName').val();
    var AAlias = $('#AltaAlias').val();
    var AActive = $('#AltaActive').val();
    var AExp = $('#AltaExp').val();
    var UserJson = { EXp: AExp, Active: AActive, Name: Aname, Alias: AAlias };
    $.post("/Json/InsertUser", UserJson, function (data) {
        if (data != 0) {
            alert("Alta exitosa");
        }
        else {
            alert("Usuario no registrado");
        }
    });
}
function Update(data) {
    $('.UpdUsuario').show();
    $('.NuevoUsuario').hide();
    var exp = $('#ActExp').val();
    var acta = $('#ActActive').val();
    var actN = $('#ActName').val();
    var ActAls = $('#ActAlias').val();
    var UserJson = { EXp: exp, Active: acta, Name: actN, Alias: ActAls };
    $.post("/Json/UpdateUser", UserJson, function (data) {
        if (data != 0) {
            alert("Actualizacion exitosa");
        }
        else {
            alert("Actualizacion fallida");
        }
    });
    $('#forma').css("display", "none");

}